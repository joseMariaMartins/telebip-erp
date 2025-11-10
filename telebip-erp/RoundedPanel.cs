using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 8;
        public Color BorderColor { get; set; } = Color.FromArgb(60, 62, 80);
        public Color FillColor { get; set; } = Color.FromArgb(40, 41, 52);
        public int BorderThickness { get; set; } = 1;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = FillColor;
            this.Height = 36; // Altura fixa padrão
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundedRect(rect, CornerRadius))
            using (SolidBrush brush = new SolidBrush(FillColor))
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Redesenha ao mudar tamanho
        }
    }
}
