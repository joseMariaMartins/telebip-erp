using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.SplashScreen
{
    public partial class FormSplashScreen : MaterialForm
    {
        public FormSplashScreen()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // Aparência
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";
            this.Size = new System.Drawing.Size(400, 200);

            // Label centralizada
            Label lblCarregando = new Label()
            {
                Text = "Verificando credenciais...",
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold)
            };
            Controls.Add(lblCarregando);

            // Cursor de carregamento
            this.UseWaitCursor = true;
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Atraso curto para visual de carregamento
            await Task.Delay(1000);
            this.Close();
        }
    }
}
