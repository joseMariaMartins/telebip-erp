using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class NeoFlatComboBox : ComboBox
    {
        private Panel pnlLeft, pnlRight, pnlTop, pnlBottom;
        private Panel roundedPanel;
        private Label lblOverlay;

        private readonly Color dark = Color.FromArgb(40, 41, 52);
        private readonly Padding textPadding = new Padding(8, 0, 28, 0);

        public NeoFlatComboBox()
        {
            DrawMode = DrawMode.Normal;
            DropDownStyle = ComboBoxStyle.DropDownList;
            ItemHeight = 26;
            BackColor = dark;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8F);

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            pnlLeft = MakeSidePanel();
            pnlRight = MakeSidePanel();
            pnlTop = MakeSidePanel();
            pnlBottom = MakeSidePanel();

            roundedPanel = new Panel
            {
                BackColor = dark,
                Location = new Point(-2, -2),
                Size = new Size(Width + 4, Height + 4),
                Cursor = Cursors.Hand
            };

            roundedPanel.Paint += (s, e) =>
            {
                using (var b = new SolidBrush(dark))
                {
                    var rect = new Rectangle(0, 0, roundedPanel.Width - 1, roundedPanel.Height - 1);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var path = RoundedRect(rect, 6))
                        e.Graphics.FillPath(b, path);
                }
            };

            roundedPanel.Click += (s, e) => OpenDropdown();
            roundedPanel.MouseDown += (s, e) => OpenDropdown();

            Controls.Add(roundedPanel);
            roundedPanel.SendToBack();

            lblOverlay = new Label
            {
                AutoSize = false,
                Text = "",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = this.Font,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(textPadding.Left, 0),
                Size = new Size(Width - textPadding.Left - textPadding.Right, Height),
                Cursor = Cursors.Hand
            };

            // Encaminhar cliques do overlay para abrir o dropdown
            lblOverlay.Click += (s, e) => OpenDropdown();
            lblOverlay.MouseDown += (s, e) => OpenDropdown();

            Controls.Add(lblOverlay);
            lblOverlay.BringToFront();

            // Eventos que garantem sincronização
            SelectedIndexChanged += (s, e) => UpdateOverlay();
            TextChanged += (s, e) => UpdateOverlay();
            Resize += (s, e) => UpdateOverlay();

            // Quando a fonte de dados mudar, tentar ajustar seleção e atualizar overlay
            DataSourceChanged += (s, e) => TrySetInitialSelection();

            // Quando handle criado, garantir estado inicial
            HandleCreated += (s, e) => TrySetInitialSelection();

            // Também garantir na criação do controle (cobre caminhos diferentes do handle)
            // usar override de OnCreateControl abaixo

            // Chamada inicial para tentar atualizar imediatamente (se já houver SelectedIndex)
            TrySetInitialSelection();
        }

        private void TrySetInitialSelection()
        {
            // Se houver itens e nenhum selecionado, seleciona o primeiro por padrão
            if (Items.Count > 0 && SelectedIndex < 0)
                SelectedIndex = 0;

            // Sempre atualiza o overlay (mesmo que SelectedIndex já estivesse definido)
            UpdateOverlay();
        }

        private Panel MakeSidePanel()
        {
            var p = new Panel
            {
                BackColor = dark,
                Width = 2,
                Height = Height,
                Visible = true,
                Cursor = Cursors.Hand
            };

            p.Click += (s, e) => OpenDropdown();
            p.MouseDown += (s, e) => OpenDropdown();

            return p;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            pnlLeft.Height = Height; pnlLeft.Location = new Point(0, 0);
            pnlRight.Height = Height; pnlRight.Location = new Point(Width - 2, 0);
            pnlTop.Width = Width; pnlTop.Height = 2; pnlTop.Location = new Point(0, 0);
            pnlBottom.Width = Width; pnlBottom.Height = 2; pnlBottom.Location = new Point(0, Height - 2);

            roundedPanel.Location = new Point(-2, -2);
            roundedPanel.Size = new Size(Width + 4, Height + 4);

            if (!Controls.Contains(pnlLeft))
            {
                Controls.Add(pnlLeft);
                Controls.Add(pnlRight);
                Controls.Add(pnlTop);
                Controls.Add(pnlBottom);

                pnlLeft.BringToFront();
                pnlRight.BringToFront();
                pnlTop.BringToFront();
                pnlBottom.BringToFront();
            }

            lblOverlay.Location = new Point(textPadding.Left, 0);
            lblOverlay.Size = new Size(Width - textPadding.Left - textPadding.Right, Height);
            lblOverlay.BringToFront();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = CreateGraphics())
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    int x = Width - 18;
                    int y = Height / 2 - 2;

                    using (Pen p = new Pen(Color.White, 2))
                    {
                        g.DrawLines(p, new Point[]
                        {
                            new Point(x,     y),
                            new Point(x + 4, y + 4),
                            new Point(x + 8, y)
                        });
                    }
                }
            }
        }

        private void UpdateOverlay()
        {
            // Usar SelectedItem + GetItemText para respeitar DisplayMember
            if (SelectedIndex >= 0 && SelectedItem != null)
            {
                lblOverlay.Text = GetItemText(SelectedItem);
            }
            else if (!string.IsNullOrEmpty(Text))
            {
                // Caso o controle possua texto (por segurança)
                lblOverlay.Text = Text;
            }
            else
            {
                lblOverlay.Text = string.Empty;
            }
        }

        private void OpenDropdown()
        {
            Focus();
            DroppedDown = true;
        }

        private System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;

            path.AddArc(new RectangleF(r.X, r.Y, d, d), 180, 90);
            path.AddArc(new RectangleF(r.Right - d, r.Y, d, d), 270, 90);
            path.AddArc(new RectangleF(r.Right - d, r.Bottom - d, d, d), 0, 90);
            path.AddArc(new RectangleF(r.X, r.Bottom - d, d, d), 90, 90);

            path.CloseFigure();
            return path;
        }

        // Garante atualização também no caminho de criação do controle
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            TrySetInitialSelection();
        }
    }
}
