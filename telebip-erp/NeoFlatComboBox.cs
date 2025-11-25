using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class NeoFlatComboBox : ComboBox
    {
        // Aparência
        private Color BackColorSurface = Color.FromArgb(40, 41, 52);
        private readonly Color ForeText = Color.White;
        private readonly Color PlaceholderColor = Color.FromArgb(140, 140, 140);
        private readonly Color ItemSelectionOverlay = Color.FromArgb(60, 255, 255, 255);

        // Layout público
        private int _itemHeight = 24;
        [Category("Layout")]
        [Description("Altura do item no dropdown (em pixels).")]
        public int ItemEntryHeight
        {
            get => _itemHeight;
            set
            {
                _itemHeight = Math.Max(16, value);
                base.ItemHeight = _itemHeight;
                InvalidateSafe();
                _overlay?.Invalidate();
            }
        }

        [Category("Appearance")] public string Placeholder { get; set; } = "Selecione...";
        [Category("Behavior")] public bool AutoSelectFirst { get; set; } = false;
        [Category("Behavior")] public bool ShowPlaceholder { get; set; } = true;

        // Internos / proteções
        private bool _controlReady = false;
        private bool _suppressUpdate = false;
        private bool _inWndProc = false;
        private bool _isInRecovery = false;
        private volatile bool _invalidateScheduled = false;
        private volatile bool _suspendInvalidation = false;
        private volatile bool _dropdownOpen = false;
        private readonly StringFormat _textFormat = new StringFormat
        {
            Trimming = StringTrimming.EllipsisCharacter,
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Near,
            FormatFlags = StringFormatFlags.NoWrap
        };

        // click lock curto para evitar reentrância extrema (responsivo)
        private volatile bool _clickLock = false;
        private readonly int _clickLockMs = 40;

        // logging
        private readonly string _logPath = Path.Combine(Path.GetTempPath(), "NeoFlatComboBox_logs.txt");
        private readonly int _maxLogBytes = 180 * 1024;
        private readonly object _logLock = new object();

        // recovery attempts
        private int _resetAttempts = 0;
        private readonly int _maxResetAttempts = 3;
        private DateTime _lastReset = DateTime.MinValue;

        // === NOVO: lock global para evitar dois dropdowns simultâneos ===
        private static readonly object _globalDropdownLock = new object();
        private static volatile int _globalDropdownInUse = 0; // 0 = free, 1 = in use

        // Força um pequeno backoff antes de reabrir (ms)
        private const int _globalDropdownBackoffMs = 45;

        // overlay para cobrir o desenho nativo do closed area e "tampar" bordas/brancos
        private Panel _overlay;

        public NeoFlatComboBox()
        {
            BackColorSurface = this.BackColor == Color.Empty ? BackColorSurface : this.BackColor;
            this.BackColor = BackColorSurface;

            // Não habilitar UserPaint para evitar AccessViolation com o ComboBox nativo.
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            UpdateStyles();

            this.FlatStyle = FlatStyle.Flat;
            this.DrawMode = DrawMode.OwnerDrawFixed; // owner draw para itens do dropdown
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            base.ItemHeight = _itemHeight;
            this.Font = new Font("Segoe UI", 9f);
            this.Margin = new Padding(0);

            SafeAttachHandlers();

            // cursor hand
            this.MouseEnter += (s, e) => this.Cursor = Cursors.Hand;
            this.MouseLeave += (s, e) => this.Cursor = Cursors.Default;

            this.BackColorChanged += (s, e) =>
            {
                if (this.BackColor != Color.Empty) BackColorSurface = this.BackColor;
                InvalidateSafe();
                _overlay?.Invalidate();
            };

            // construir overlay que cobre a área do controle e desenha o visual escuro
            CreateOverlay();
        }

        private void CreateOverlay()
        {
            if (_overlay != null) return;
            _overlay = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Enabled = true };
            _overlay.Paint += Overlay_Paint;
            _overlay.MouseDown += Overlay_MouseDown;
            _overlay.MouseEnter += (s, e) => this.Cursor = Cursors.Hand;
            _overlay.MouseLeave += (s, e) => this.Cursor = Cursors.Default;
            this.Controls.Add(_overlay);
            _overlay.BringToFront();
        }

        private void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            // tenta abrir dropdown de forma segura
            try
            {
                if (System.Threading.Interlocked.CompareExchange(ref _globalDropdownInUse, 1, 0) != 0)
                {
                    var t = new System.Windows.Forms.Timer { Interval = _globalDropdownBackoffMs };
                    t.Tick += (ts, te) =>
                    {
                        try { t.Stop(); t.Dispose(); } catch { }
                        if (!_isInRecovery && this.IsHandleCreated && !this.IsDisposed)
                        {
                            try { DroppedDown = true; } catch { }
                            ActivateClickLock();
                        }
                    };
                    t.Start();
                    return;
                }

                if (_isInRecovery || _inWndProc) { System.Threading.Interlocked.Exchange(ref _globalDropdownInUse, 0); return; }

                try { DroppedDown = true; } catch { }
                ActivateClickLock();
            }
            finally
            {
                // DropDownClosed handler libera o global lock
            }
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                var bounds = _overlay.ClientRectangle;

                // desenhar fundo totalmente escuro cobrindo possíveis detalhes brancos
                using (var b = new SolidBrush(BackColorSurface))
                    g.FillRectangle(b, bounds);

                // desenhar "borda" interna escura (substitui detalhes nativos)
                int innerPad = 1; // espessura da borda simulada
                using (var pen = new Pen(BackColorSurface))
                {
                    g.DrawRectangle(pen, innerPad, innerPad, bounds.Width - innerPad * 2 - 1, bounds.Height - innerPad * 2 - 1);
                }

                // texto a mostrar
                string toShow = string.Empty;
                Color textColor = ForeText;

                if (SelectedIndex >= 0 && SelectedItem != null) toShow = GetItemText(SelectedItem);
                else
                {
                    if (!string.IsNullOrEmpty(Text))
                    {
                        bool matches = false;
                        for (int i = 0; i < Items.Count; i++)
                            if (string.Equals(GetItemText(Items[i]), Text, StringComparison.OrdinalIgnoreCase)) { matches = true; break; }
                        if (!matches) toShow = Text;
                    }

                    if (string.IsNullOrEmpty(toShow))
                    {
                        if (ShowPlaceholder) { toShow = Placeholder; textColor = PlaceholderColor; }
                        else toShow = string.Empty;
                    }
                }

                using (var sb = new SolidBrush(textColor))
                {
                    var textRect = new Rectangle(8, 0, bounds.Width - 32, bounds.Height);
                    g.DrawString(toShow, this.Font, sb, textRect, _textFormat);
                }

                // desenhar seta/arrow preenchida escura com traço branco interno pequeno (opcional)
                int arrowSize = 8;
                int cx = bounds.Right - 18;
                int cy = bounds.Height / 2;
                Point[] triangle = new Point[] {
                    new Point(cx - arrowSize/2, cy - arrowSize/3),
                    new Point(cx + arrowSize/2, cy - arrowSize/3),
                    new Point(cx, cy + arrowSize/3)
                };
                using (var sb = new SolidBrush(ForeText))
                {
                    g.FillPolygon(sb, triangle);
                }
            }
            catch (Exception ex) { TryLogException(ex); }
        }

        #region Handlers attach/detach
        private void SafeAttachHandlers()
        {
            SafeDetachHandlers();
            SelectedIndexChanged += SelectedIndexChanged_Handler;
            TextChanged += TextChanged_Handler;
            DropDown += DropDown_Handler;
            DropDownClosed += DropDownClosed_Handler;
            HandleCreated += HandleCreated_Handler;
            // MouseDown handled by overlay
        }

        private void SafeDetachHandlers()
        {
            try
            {
                SelectedIndexChanged -= SelectedIndexChanged_Handler;
                TextChanged -= TextChanged_Handler;
                DropDown -= DropDown_Handler;
                DropDownClosed -= DropDownClosed_Handler;
                HandleCreated -= HandleCreated_Handler;
            }
            catch { }
        }
        #endregion

        #region Delegated handlers (desacoplados via BeginInvoke)
        private void SelectedIndexChanged_Handler(object s, EventArgs e)
        {
            // desacoplar para evitar executar durante fluxo do WndProc de outra combobox
            try
            {
                this.BeginInvoke((MethodInvoker)(() => SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); })));
            }
            catch { SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); }); }
        }

        private void TextChanged_Handler(object s, EventArgs e)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)(() => SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); })));
            }
            catch { SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); }); }
        }

        private void DropDown_Handler(object s, EventArgs e)
        {
            // tenta marcar uso global: se ocupado, adia a confirmação de abertura
            bool acquired = false;
            try
            {
                acquired = System.Threading.Interlocked.CompareExchange(ref _globalDropdownInUse, 1, 0) == 0;
                if (!acquired)
                {
                    // outro dropdown está em transição — reagendar abertura leve usando timer (não bloquear UI)
                    try
                    {
                        this.BeginInvoke((MethodInvoker)(() =>
                        {
                            var t = new System.Windows.Forms.Timer { Interval = _globalDropdownBackoffMs };
                            t.Tick += (ts, te) =>
                            {
                                try { t.Stop(); t.Dispose(); } catch { }
                                if (!_isInRecovery && !this.IsDisposed && this.IsHandleCreated)
                                {
                                    try { DroppedDown = true; } catch { }
                                }
                            };
                            t.Start();
                        }));
                    }
                    catch { }
                    return;
                }

                // agora que "reservamos" o slot global, prosseguir
                _dropdownOpen = true;
                _suspendInvalidation = true;

                // ajuste de altura
                SafeAction(() => AdjustDropDownHeight());

                // liberar repintura de forma assíncrona
                try
                {
                    this.BeginInvoke((MethodInvoker)(() =>
                    {
                        _suspendInvalidation = false;
                        InvalidateSafe();
                        _overlay?.Invalidate();
                    }));
                }
                catch { _suspendInvalidation = false; }
            }
            finally
            {
                // mantemos lock até DropDownClosed; não liberar aqui.
                if (!acquired)
                {
                    // nothing
                }
            }
        }

        private void DropDownClosed_Handler(object s, EventArgs e)
        {
            _dropdownOpen = false;
            // liberar slot global (caso estivermos sendo o dono)
            System.Threading.Interlocked.Exchange(ref _globalDropdownInUse, 0);

            try { this.BeginInvoke((MethodInvoker)(() => { InvalidateSafe(); _overlay?.Invalidate(); })); }
            catch { InvalidateSafe(); _overlay?.Invalidate(); }
        }

        private void HandleCreated_Handler(object s, EventArgs e)
        {
            _controlReady = true;
            try { this.BeginInvoke((MethodInvoker)(() => SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); }))); }
            catch { SafeAction(() => { InvalidateSafe(); _overlay?.Invalidate(); }); }
        }
        #endregion

        #region SafeAction / logging
        private void SafeAction(Action action)
        {
            if (_isInRecovery) return;
            try { action?.Invoke(); }
            catch (Exception ex)
            {
                TryLogException(ex);
                TryRecoverFromError(ex);
            }
        }
        #endregion

        #region Click lock
        private void ActivateClickLock()
        {
            try
            {
                _clickLock = true;
                var ms = _clickLockMs;
                this.BeginInvoke((MethodInvoker)(() =>
                {
                    var t = new System.Windows.Forms.Timer { Interval = ms };
                    t.Tick += (s, e) =>
                    {
                        try { t.Stop(); t.Dispose(); } catch { }
                        _clickLock = false;
                    };
                    t.Start();
                }));
            }
            catch { _clickLock = false; }
        }
        #endregion

        #region InvalidateSafe
        private void InvalidateSafe()
        {
            if (_suspendInvalidation) return;
            if (_isInRecovery) return;
            if (_invalidateScheduled) return;
            _invalidateScheduled = true;

            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        _invalidateScheduled = false;
                        if (this.IsDisposed || !this.IsHandleCreated) return;
                        base.Invalidate();
                    }
                    catch (Exception ex) { TryLogException(ex); TryRecoverFromError(ex); }
                });
            }
            catch (Exception ex) { _invalidateScheduled = false; TryLogException(ex); TryRecoverFromError(ex); }
        }
        #endregion

        #region WndProc defensivo e com fallback / soft-disable
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x14;

            if (this.IsDisposed) return;

            if (_inWndProc)
            {
                try { base.WndProc(ref m); return; }
                catch { try { DefWndProc(ref m); } catch { } return; }
            }

            if (!this.IsHandleCreated)
            {
                return;
            }

            try
            {
                _inWndProc = true;

                if (m.Msg == WM_ERASEBKGND)
                {
                    // ignore explicit erase background to reduce flicker
                    base.WndProc(ref m); // still forward to avoid surprising native control
                    return;
                }

                base.WndProc(ref m);
            }
            catch (ObjectDisposedException odex)
            {
                TryLogException(odex);
                // soft-disable and schedule recovery
                SafeDisableAndRecover("ObjectDisposedException in WndProc: " + odex.Message);
            }
            catch (InvalidOperationException ioex)
            {
                TryLogException(ioex);
                SafeDisableAndRecover("InvalidOperationException in WndProc: " + ioex.Message);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
                SafeDisableAndRecover("Unexpected exception in WndProc: " + ex.Message);
            }
            finally
            {
                _inWndProc = false;
            }
        }

        // disable briefly and schedule recovery on UI thread
        private void SafeDisableAndRecover(string reason)
        {
            try
            {
                Debug.WriteLine("SafeDisableAndRecover: " + reason);
                this.Enabled = false;
                this.BeginInvoke((MethodInvoker)(() =>
                {
                    try
                    {
                        // short pause using Timer so we don't block
                        var t = new System.Windows.Forms.Timer { Interval = 40 };
                        t.Tick += (s, e) =>
                        {
                            try { t.Stop(); t.Dispose(); } catch { }
                            try { this.RecreateHandle(); } catch { }
                            try { this.Enabled = true; } catch { }
                            TryRecoverFromError(new Exception(reason));
                        };
                        t.Start();
                    }
                    catch { }
                }));
            }
            catch { try { this.Enabled = true; } catch { } }
        }
        #endregion

        #region Paint / Draw (dark dropdown via OwnerDraw)
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                // Somente desenhar os itens do dropdown (e não tentar redesenhar a área fechada aqui — overlay cuida disso)
                if (e.Index < 0) return;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                Rectangle bounds = e.Bounds;

                using (var bg = new SolidBrush(BackColorSurface))
                    e.Graphics.FillRectangle(bg, bounds);

                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                if (selected)
                {
                    using (var sel = new SolidBrush(ItemSelectionOverlay))
                        e.Graphics.FillRectangle(sel, bounds);
                }

                string text = GetItemText(Items[e.Index]) ?? string.Empty;
                using (var brush = new SolidBrush(ForeText))
                {
                    var textRect = new Rectangle(bounds.X + 6, bounds.Y, bounds.Width - 12, bounds.Height);
                    e.Graphics.DrawString(text, this.Font, brush, textRect, _textFormat);
                }
            }
            catch (Exception ex) { TryLogException(ex); TryRecoverFromError(ex); }
        }
        #endregion

        #region Dropdown / DataSource helpers
        private void AdjustDropDownHeight()
        {
            try
            {
                int visible = Math.Min(Items.Count, this.MaxDropDownItems > 0 ? this.MaxDropDownItems : 8);
                if (visible <= 0) visible = 1;
                this.DropDownHeight = visible * ItemEntryHeight + 2;
            }
            catch (Exception ex) { TryLogException(ex); TryRecoverFromError(ex); }
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            if (!_controlReady) return;

            SafeAction(() =>
            {
                if (AutoSelectFirst && Items.Count > 0 && SelectedIndex < 0)
                {
                    _suppressUpdate = true;
                    SelectedIndex = 0;
                    _suppressUpdate = false;
                }
                InvalidateSafe();
                _overlay?.Invalidate();
            });
        }
        #endregion

        #region Texto / seleção helpers
        public void ClearFalseSelectionIfNeeded()
        {
            try
            {
                if (Items == null || Items.Count == 0) return;
                string currentText = this.Text ?? string.Empty;
                if (string.IsNullOrEmpty(currentText)) return;
                if (SelectedIndex >= 0) return;

                for (int i = 0; i < Items.Count; i++)
                {
                    if (string.Equals(GetItemText(Items[i]), currentText, StringComparison.OrdinalIgnoreCase))
                    {
                        _suppressUpdate = true;
                        SelectedIndex = -1;
                        this.Text = string.Empty;
                        _suppressUpdate = false;
                        InvalidateSafe();
                        _overlay?.Invalidate();
                        break;
                    }
                }
            }
            catch (Exception ex) { TryLogException(ex); TryRecoverFromError(ex); }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (_suppressUpdate) return;
            // desacoplar a atualização para reduzir chance de race com outro controle
            try { this.BeginInvoke((MethodInvoker)(() => { InvalidateSafe(); _overlay?.Invalidate(); })); }
            catch { InvalidateSafe(); _overlay?.Invalidate(); }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (_suppressUpdate) return;
            try { this.BeginInvoke((MethodInvoker)(() => { InvalidateSafe(); _overlay?.Invalidate(); })); }
            catch { InvalidateSafe(); _overlay?.Invalidate(); }
        }

        public void StartEmpty()
        {
            try
            {
                _suppressUpdate = true;
                SelectedIndex = -1;
                Text = string.Empty;
                _suppressUpdate = false;
                InvalidateSafe();
                _overlay?.Invalidate();
            }
            catch (Exception ex) { TryLogException(ex); TryRecoverFromError(ex); }
        }
        #endregion

        #region Recovery + Logging
        private void TryRecoverFromError(Exception ex)
        {
            if (_isInRecovery) return;
            _isInRecovery = true;
            try
            {
                TryLogException(ex);

                if ((DateTime.Now - _lastReset).TotalMinutes < 1) _resetAttempts++;
                else _resetAttempts = 1;
                _lastReset = DateTime.Now;

                if (_resetAttempts > _maxResetAttempts) return;

                SafeDetachHandlers();
                try { this.RecreateHandle(); } catch { }
                _invalidateScheduled = false;
                _suspendInvalidation = false;
                _inWndProc = false;
                _suppressUpdate = false;
                _clickLock = false;
                System.Threading.Interlocked.Exchange(ref _globalDropdownInUse, 0);
                SafeAttachHandlers();
                InvalidateSafe();
                _overlay?.Invalidate();
            }
            finally { _isInRecovery = false; }
        }

        private void TryLogException(Exception ex)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("---- NeoFlatComboBox Exception ----");
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.AppendLine(ex.GetType().FullName);
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace ?? "");
                sb.AppendLine("-----------------------------------");

                lock (_logLock)
                {
                    try
                    {
                        if (File.Exists(_logPath))
                        {
                            var fi = new FileInfo(_logPath);
                            if (fi.Length > _maxLogBytes)
                            {
                                var bak = _logPath + ".1";
                                try { File.Delete(bak); } catch { }
                                File.Move(_logPath, bak);
                            }
                        }
                    }
                    catch { }

                    File.AppendAllText(_logPath, sb.ToString());
                }
            }
            catch { }
        }
        #endregion

        #region Dispose override
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try { SafeDetachHandlers(); } catch { }
                try { _textFormat?.Dispose(); } catch { }
                try
                {
                    if (_overlay != null)
                    {
                        _overlay.Paint -= Overlay_Paint;
                        _overlay.MouseDown -= Overlay_MouseDown;
                        this.Controls.Remove(_overlay);
                        _overlay.Dispose();
                        _overlay = null;
                    }
                }
                catch { }
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
