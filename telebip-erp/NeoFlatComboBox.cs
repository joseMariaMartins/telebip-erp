using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class NeoFlatComboBox : ComboBox
    {
        private Color BackColorSurface = Color.FromArgb(40, 41, 52);
        private readonly Color ForeText = Color.White;
        private readonly Color PlaceholderColor = Color.FromArgb(140, 140, 140);
        private readonly Color ItemSelectionOverlay = Color.FromArgb(60, 255, 255, 255);
        private readonly int CornerRadius = 6;

        [Category("Appearance")]
        public string Placeholder { get; set; } = "Selecione...";

        [Category("Behavior")]
        public bool AutoSelectFirst { get; set; } = false;

        [Category("Behavior")]
        public bool ShowPlaceholder { get; set; } = true;

        private int _itemHeight = 30;
        [Category("Layout")]
        public int ItemEntryHeight
        {
            get => _itemHeight;
            set
            {
                _itemHeight = Math.Max(18, value);
                base.ItemHeight = _itemHeight;
                Invalidate();
            }
        }

        private bool _controlReady = false;
        private bool _suppressUpdate = false;

        public NeoFlatComboBox()
        {
            BackColorSurface = this.BackColor == Color.Empty ? BackColorSurface : this.BackColor;
            this.BackColor = BackColorSurface;

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.FlatStyle = FlatStyle.Flat;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            base.ItemHeight = _itemHeight;
            this.Font = new Font("Segoe UI", 9f);
            this.Margin = new Padding(0);

            SelectedIndexChanged += (s, e) => Invalidate();
            TextChanged += (s, e) => Invalidate();
            DropDown += (s, e) => AdjustDropDownHeight();
            DropDownClosed += (s, e) => Invalidate();
            HandleCreated += (s, e) => { _controlReady = true; Invalidate(); };

            // === Cursor ao passar o mouse ===
            MouseEnter += (s, e) => this.Cursor = Cursors.Hand;
            MouseLeave += (s, e) => this.Cursor = Cursors.Default;

            MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    try { DroppedDown = true; }
                    catch { }
                }
            };

            this.BackColorChanged += (s, e) =>
            {
                if (this.BackColor != Color.Empty) BackColorSurface = this.BackColor;
                Invalidate();
            };
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x14;
            if (m.Msg == WM_ERASEBKGND) return;
            base.WndProc(ref m);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            using (var b = new SolidBrush(BackColorSurface))
                pevent.Graphics.FillRectangle(b, this.ClientRectangle);
        }

        private void AdjustDropDownHeight()
        {
            try
            {
                int visible = Math.Min(Items.Count, this.MaxDropDownItems > 0 ? this.MaxDropDownItems : 8);
                if (visible <= 0) visible = 1;
                this.DropDownHeight = visible * ItemEntryHeight + 2;
            }
            catch { }
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            if (!_controlReady) return;

            if (AutoSelectFirst && Items.Count > 0 && SelectedIndex < 0)
            {
                _suppressUpdate = true;
                SelectedIndex = 0;
                _suppressUpdate = false;
            }
            Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle bounds = e.Bounds;

            using (var b = new SolidBrush(BackColorSurface))
                e.Graphics.FillRectangle(b, bounds);

            if (e.Index < 0)
                return;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (var sel = new SolidBrush(ItemSelectionOverlay))
                    e.Graphics.FillRectangle(sel, bounds);
            }

            string text = GetItemText(Items[e.Index]) ?? string.Empty;
            using (var brush = new SolidBrush(ForeText))
            {
                var sf = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisCharacter,
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near,
                    FormatFlags = StringFormatFlags.NoWrap
                };

                var textRect = new RectangleF(bounds.X + 8, bounds.Y, bounds.Width - 16, bounds.Height);
                e.Graphics.DrawString(text, this.Font, brush, textRect, sf);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (var b = new SolidBrush(BackColorSurface))
                g.FillRectangle(b, ClientRectangle);

            string toShow = string.Empty;
            Color textColor = ForeText;

            if (SelectedIndex >= 0 && SelectedItem != null)
            {
                toShow = GetItemText(SelectedItem);
            }
            else
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    bool matches = false;
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (string.Equals(GetItemText(Items[i]), Text, StringComparison.OrdinalIgnoreCase))
                        {
                            matches = true;
                            break;
                        }
                    }
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
                var sf = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisCharacter,
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                var textRect = new RectangleF(10, 0, Width - 20, Height);
                g.DrawString(toShow, Font, sb, textRect, sf);
            }

            int arrowAreaWidth = 20;
            var arrowRect = new Rectangle(Width - arrowAreaWidth, 0, arrowAreaWidth, Height);
            using (var b = new SolidBrush(BackColorSurface))
                g.FillRectangle(b, arrowRect);
        }

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
                        Invalidate();
                        break;
                    }
                }
            }
            catch { }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (_suppressUpdate) return;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (_suppressUpdate) return;
            Invalidate();
        }

        public void StartEmpty()
        {
            try
            {
                _suppressUpdate = true;
                SelectedIndex = -1;
                Text = string.Empty;
                _suppressUpdate = false;
                Invalidate();
            }
            catch { _suppressUpdate = false; }
        }
    }
}
