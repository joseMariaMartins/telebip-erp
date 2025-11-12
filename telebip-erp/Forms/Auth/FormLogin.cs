using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.Auth
{
    public partial class FormLogin : MaterialForm
    {
        private bool senhaVisivel = false;
        private Bitmap eyeOpenBmp;
        private Bitmap eyeClosedBmp;

        public FormLogin()
        {
            InitializeComponent();

            try
            {
                ThemeManager.ApplyDarkTheme();
            }
            catch { /* evita crash caso tema falhe */ }

            txtUsuario.MaxLength = 6;

            // Eventos
            txtUsuario.KeyPress += TxtUsuario_KeyPress;
            txtUsuario.TextChanged += TxtUsuario_TextChanged;
            txtUsuario.GotFocus += (s, e) => SetWrapperFocused(pnlWrapperUsuario, true);
            txtUsuario.LostFocus += (s, e) => SetWrapperFocused(pnlWrapperUsuario, false);

            txtSenha.KeyDown += TxtSenha_KeyDown;
            txtSenha.GotFocus += (s, e) => SetWrapperFocused(pnlWrapperSenha, true);
            txtSenha.LostFocus += (s, e) => SetWrapperFocused(pnlWrapperSenha, false);

            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            lblEsqueci.Click += LblEsqueci_Click;

            // garante que picToggleSenha existe antes de anexar
            if (picToggleSenha != null)
            {
                picToggleSenha.Click += PicToggleSenha_Click;
                picToggleSenha.Cursor = Cursors.Hand;
                picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            // Aplicar bordas arredondadas e estilos
            AplicarBordasArredondadas();

            // Carregar imagens do "eye" e configurar botão visual
            LoadEyeImages();
            ConfigureLoginButtonVisuals();

            // Focus inicial
            this.Load += (s, e) => txtUsuario.Focus();
        }

        #region Métodos para Bordas Arredondadas
        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(0, radius * 2);
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            wrapper.BackColor = fill;
            wrapper.Tag = border;
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;
            wrapper.Resize -= (s, e) => wrapper.Invalidate();
            wrapper.Resize += (s, e) => wrapper.Invalidate();
        }

        private void Wrapper_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Panel wrapper)) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
            using (var path = GetRoundedRect(rect, 8))
            using (var pen = new Pen((Color)wrapper.Tag, 1))
            {
                e.Graphics.FillPath(new SolidBrush(wrapper.BackColor), path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void AplicarBordasArredondadas()
        {
            Color borderColor = Color.FromArgb(60, 62, 80);
            Color fillColor = Color.FromArgb(40, 41, 52);
            int radius = 8;

            StyleTextboxWrapperPanel(pnlWrapperUsuario, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperSenha, fillColor, borderColor, radius);

            btnLogin.BackColor = Color.FromArgb(40, 120, 80);
            btnLogin.ForeColor = Color.White;
            btnLogin.Cursor = Cursors.Hand;

            lblAppName.ForeColor = Color.FromArgb(140, 180, 255);
            lblTitulo.ForeColor = Color.White;
        }
        #endregion

        #region Focus Helpers
        private void SetWrapperFocused(Panel wrapper, bool focused)
        {
            Color active = Color.FromArgb(100, 150, 255);
            Color normal = Color.FromArgb(60, 62, 80);
            wrapper.Tag = focused ? active : normal;
            wrapper.Invalidate();
        }
        #endregion

        #region Toggle Visibilidade da Senha / Eye images
        private void LoadEyeImages()
        {
            // tenta carregar eye images explicitamente via Properties.Resources (nomes comuns)
            try
            {
                // tenta nomes explícitos (se existirem no Resources)
                // (substitua pelos nomes reais se quiser forçar)
                var resType = typeof(Properties.Resources);

                // Tentativa direta por nomes conhecidos
                var tryNames = new[] { "eye_open", "eyeopen", "eyeOpen", "eye_open_white", "view", "show" };
                foreach (var name in tryNames)
                {
                    var prop = resType.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if (prop != null && prop.GetValue(null) is Image im)
                    {
                        eyeOpenBmp = new Bitmap(im);
                        break;
                    }
                }

                var tryNamesClosed = new[] { "eye_closed", "eyeclose", "eye_closed_white", "hide", "hide_eye" };
                foreach (var name in tryNamesClosed)
                {
                    var prop = resType.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if (prop != null && prop.GetValue(null) is Image im)
                    {
                        eyeClosedBmp = new Bitmap(im);
                        break;
                    }
                }
            }
            catch { /* ignore */ }

            // Se não encontrou, tenta varrer Resources por imagens candidatas
            if (eyeOpenBmp == null || eyeClosedBmp == null)
            {
                try
                {
                    var props = typeof(Properties.Resources).GetProperties(BindingFlags.Static | BindingFlags.Public);
                    foreach (var p in props)
                    {
                        if (!typeof(Image).IsAssignableFrom(p.PropertyType)) continue;
                        var img = p.GetValue(null) as Image;
                        if (img == null) continue;
                        var name = p.Name.ToLowerInvariant();

                        if (eyeOpenBmp == null && (name.Contains("eye") && (name.Contains("open") || name.Contains("view") || name.Contains("show"))))
                            eyeOpenBmp = new Bitmap(img);

                        if (eyeClosedBmp == null && (name.Contains("eye") && (name.Contains("close") || name.Contains("closed") || name.Contains("hide") || name.Contains("ocultar"))))
                            eyeClosedBmp = new Bitmap(img);

                        if (eyeOpenBmp != null && eyeClosedBmp != null) break;
                    }
                }
                catch { /* ignore */ }
            }

            // Se ainda não encontrou, usa a imagem que já está no PictureBox (designer) como closed
            try
            {
                if (eyeClosedBmp == null && picToggleSenha?.Image is Bitmap bmpFromDesigner)
                    eyeClosedBmp = new Bitmap(bmpFromDesigner);
            }
            catch { /* ignore */ }

            // fallback: desenha ícones simples
            if (eyeOpenBmp == null) eyeOpenBmp = DrawSimpleEye(20, 20, true);
            if (eyeClosedBmp == null) eyeClosedBmp = DrawSimpleEye(20, 20, false);

            // garante que picturebox comece com closed
            if (picToggleSenha != null && picToggleSenha.Image == null)
                picToggleSenha.Image = eyeClosedBmp;
        }

        private Bitmap DrawSimpleEye(int w, int h, bool open)
        {
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var pen = new Pen(Color.White, 1.5f))
                using (var brush = new SolidBrush(Color.White))
                {
                    // contorno do olho
                    g.DrawEllipse(pen, 2, 6, w - 4, h - 12);
                    if (open)
                    {
                        g.FillEllipse(brush, w / 2 - 3, h / 2 - 3, 6, 6);
                    }
                    else
                    {
                        g.DrawLine(pen, 3, h / 2, w - 3, h / 2);
                    }
                }
            }
            return bmp;
        }

        private void PicToggleSenha_Click(object sender, EventArgs e)
        {
            senhaVisivel = !senhaVisivel;
            AtualizarVisibilidadeSenha();
        }

        private void AtualizarVisibilidadeSenha()
        {
            if (senhaVisivel)
            {
                txtSenha.UseSystemPasswordChar = false;
                if (eyeOpenBmp != null) picToggleSenha.Image = eyeOpenBmp;
                picToggleSenha.AccessibleDescription = "Ocultar senha";
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                if (eyeClosedBmp != null) picToggleSenha.Image = eyeClosedBmp;
                picToggleSenha.AccessibleDescription = "Mostrar senha";
            }
        }
        #endregion

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                btnLogin.BackColor = ControlPaint.Light(btnLogin.BackColor);
            }
            catch { }
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(40, 120, 80);
        }

        // ==========================
        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtSenha.Focus();
            }
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            string apenasDigitos = Regex.Replace(txtUsuario.Text, "[^0-9]", "");
            if (txtUsuario.Text != apenasDigitos)
            {
                int pos = txtUsuario.SelectionStart - (txtUsuario.Text.Length - apenasDigitos.Length);
                txtUsuario.Text = apenasDigitos;
                txtUsuario.SelectionStart = Math.Max(0, pos);
            }
        }

        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            lblUsuarioInvalido.Visible = false;
            lblSenhaInvalida.Visible = false;

            string usuario = txtUsuario.Text.Trim();
            string senhaDigitada = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senhaDigitada))
            {
                if (string.IsNullOrEmpty(usuario))
                    lblUsuarioInvalido.Visible = true;
                if (string.IsNullOrEmpty(senhaDigitada))
                    lblSenhaInvalida.Visible = true;
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                await Task.Delay(150);

                string sql = "SELECT SENHA, NIVEL_ACESSO FROM USUARIO WHERE LOGIN = @LOGIN";
                var parametros = new SQLiteParameter[]
                {
                    new SQLiteParameter("@LOGIN", usuario)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                if (dt.Rows.Count == 0)
                {
                    lblUsuarioInvalido.Visible = true;
                    return;
                }

                string senhaBancoHash = (dt.Rows[0]["SENHA"]?.ToString() ?? "")
                    .Trim()
                    .ToLowerInvariant();

                int nivelAcesso = Convert.ToInt32(dt.Rows[0]["NIVEL_ACESSO"]);
                string senhaDigitadaHash = CryptoHelper.GerarHashSHA256(senhaDigitada)
                    .Trim()
                    .ToLowerInvariant();

                if (senhaDigitadaHash != senhaBancoHash)
                {
                    lblSenhaInvalida.Visible = true;
                    txtSenha.Clear();
                    txtSenha.Focus();
                    return;
                }

                // LOGIN OK
                Session.NivelAcesso = nivelAcesso;

                using (var splash = new telebip_erp.SplashScreen.FormSplashScreen())
                {
                    splash.ShowDialog();
                }

                var formBase = new FormBase();
                formBase.FormClosed += (s, _) => this.Close();
                formBase.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar fazer login:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LblEsqueci_Click(object sender, EventArgs e)
        {
            var formRecuperacao = new FormRecuperacaoSenha
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formRecuperacao.ShowDialog(this);
        }

        private void ConfigureLoginButtonVisuals()
        {
            try
            {
                btnLogin.NormalBackground = Color.FromArgb(40, 120, 80);
                btnLogin.NormalForeColor = Color.White;
                btnLogin.NormalOutline = Color.FromArgb(200, 200, 200);
                btnLogin.OutlineThickness = 1F;
                btnLogin.Rounding = new Padding(8);

                btnLogin.HoverBackground = ControlPaint.Light(btnLogin.NormalBackground);
                btnLogin.HoverForeColor = btnLogin.NormalForeColor;
                btnLogin.HoverOutline = btnLogin.NormalOutline;

                btnLogin.PressedBackground = ControlPaint.Dark(btnLogin.NormalBackground);
                btnLogin.PressedForeColor = btnLogin.NormalForeColor;
                btnLogin.PressedOutline = btnLogin.NormalOutline;
            }
            catch { /* evita crash caso controle mude */ }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
