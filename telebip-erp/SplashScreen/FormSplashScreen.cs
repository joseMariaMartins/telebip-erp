using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.SplashScreen
{
    public partial class FormSplashScreen : Form

    {
        private readonly Label lblMessage;
        private readonly PictureBox picLogo;
        private readonly System.Windows.Forms.Timer dotsTimer;
        private int dots = 0;
        private readonly int displayMs;

        public FormSplashScreen(int displayMilliseconds = 1200)
        {
            displayMs = Math.Max(500, displayMilliseconds);

            // Configurações básicas
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Size = new Size(450, 300);
            BackColor = Color.FromArgb(28, 29, 40);
            DoubleBuffered = true;
            Text = string.Empty;
            Opacity = 0; // inicia invisível para fade in

            // Bordas arredondadas
            Load += (s, e) => this.Region = new Region(GetRoundedRect(ClientRectangle, 12));

            // Logo
            picLogo = new PictureBox
            {
                Size = new Size(96, 96),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Location = new Point((Width - 96) / 2, 60)
            };

            // Mensagem
            lblMessage = new Label
            {
                Text = "Carregando",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(50, 180),
                Size = new Size(Width - 100, 30)
            };

            Controls.Add(picLogo);
            Controls.Add(lblMessage);

            // Timer de animação de dots
            dotsTimer = new System.Windows.Forms.Timer { Interval = 400 };
            dotsTimer.Tick += (s, e) =>
            {
                dots = (dots + 1) % 4;
                lblMessage.Text = "Carregando" + new string('.', dots);
            };
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Fade in
            for (double i = 0; i <= 1; i += 0.1)
            {
                Opacity = i;
                await Task.Delay(20);
            }

            dotsTimer.Start();
            await Task.Delay(displayMs);
            dotsTimer.Stop();

            await FadeOutAndClose();
        }

        private async Task FadeOutAndClose()
        {
            for (double i = Opacity; i >= 0; i -= 0.1)
            {
                Opacity = i;
                await Task.Delay(20);
            }
            Close();
        }

        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            var p = new GraphicsPath();
            int d = radius * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        public void SetLogo(Image image) => picLogo.Image = image;
        public void SetMessage(string text) => lblMessage.Text = text;
    }
}
