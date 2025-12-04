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
    public partial class FormLogin : FormLoad
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

            // Carregar imagens do "eye" e configurar botão visual
            LoadEyeImages();
            ConfigureLoginButtonVisuals();

            // Aplica estilo de bordas arredondadas aos wrappers (cor de fundo, cor da borda, raio)
            try
            {
                // cores de exemplo (mesmas paletas que você usa no resto do app)
                StyleTextboxWrapperPanel(pnlWrapperUsuario, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
                StyleTextboxWrapperPanel(pnlWrapperSenha, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

                // garante estado inicial visual
                SetWrapperFocused(pnlWrapperUsuario, false);
                SetWrapperFocused(pnlWrapperSenha, false);

                // força redraw após load para evitar Width/Height = 0 no design-time
                this.Load += (s, e) =>
                {
                    try
                    {
                        pnlWrapperUsuario?.Invalidate();
                        pnlWrapperSenha?.Invalidate();
                    }
                    catch { }
                };
            }
            catch { /* silencioso */ }

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

        /// <summary>
        /// Configura um painel wrapper para desenhar borda arredondada.
        /// - wrapper.Tag será usado para armazenar a cor da borda.
        /// - wrapper.AccessibleDescription será usado para armazenar o raio.
        /// </summary>
        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            if (wrapper == null) return;

            // define visual
            wrapper.BackColor = fill;

            // usa Tag para armazenar a cor atual da borda (SetWrapperFocused depende disso)
            wrapper.Tag = border;

            // guarda o raio em AccessibleDescription (não atrapalha design-time e evita trocar Tag)
            wrapper.AccessibleDescription = radius.ToString();

            // remove handler existente (evita múltiplas inscrições)
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;

            // redimensionar pede redraw
            wrapper.Resize -= Wrapper_Resize;
            wrapper.Resize += Wrapper_Resize;

            // invalidar para desenhar imediatamente se possível
            try { wrapper.Invalidate(); } catch { }
        }

        private void Wrapper_Resize(object sender, EventArgs e)
        {
            if (sender is Control c)
                c.Invalidate();
        }

        private void Wrapper_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Panel wrapper)) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // tenta ler raio guardado; fallback p/ 8
            int radius = 8;
            try
            {
                if (!string.IsNullOrEmpty(wrapper.AccessibleDescription) && int.TryParse(wrapper.AccessibleDescription, out int r))
                    radius = Math.Max(0, r);
            }
            catch { radius = 8; }

            var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);

            // cor da borda está no Tag (SetWrapperFocused manipula Tag)
            Color borderColor = Color.FromArgb(60, 62, 80);
            try
            {
                if (wrapper.Tag is Color c) borderColor = c;
            }
            catch { /* ignore */ }

            using (var path = GetRoundedRect(rect, radius))
            using (var pen = new Pen(borderColor, 1))
            {
                // preenche o fundo com a cor do panel e desenha borda
                using (var fillBrush = new SolidBrush(wrapper.BackColor))
                {
                    e.Graphics.FillPath(fillBrush, path);
                }
                e.Graphics.DrawPath(pen, path);
            }
        }
        #endregion

        #region Focus Helpers
        private void SetWrapperFocused(Panel wrapper, bool focused)
        {
            if (wrapper == null) return;

            // cores usadas quando focado / normal
            Color active = Color.FromArgb(100, 150, 255);
            Color normal = Color.FromArgb(60, 62, 80);

            // atualiza Tag (que o Paint usa como cor da borda)
            wrapper.Tag = focused ? active : normal;

            // invalida para repintar
            try { wrapper.Invalidate(); } catch { }
        }
        #endregion

        #region Toggle Visibilidade da Senha / Eye images
        private void LoadEyeImages()
        {
            try
            {
                // Carrega direto dos Resources
                eyeOpenBmp = Properties.Resources.view != null
                    ? new Bitmap(Properties.Resources.view)
                    : null;

                eyeClosedBmp = Properties.Resources.hide != null
                    ? new Bitmap(Properties.Resources.hide)
                    : null;
            }
            catch
            {
                eyeOpenBmp = null;
                eyeClosedBmp = null;
            }

            // Fallback: se der erro / não tiver nos Resources, desenha os olhos simples
            if (eyeOpenBmp == null)
                eyeOpenBmp = DrawSimpleEye(20, 20, true);

            if (eyeClosedBmp == null)
                eyeClosedBmp = DrawSimpleEye(20, 20, false);

            // Configura o PictureBox pra começar com o olho “fechado”
            if (picToggleSenha != null)
            {
                picToggleSenha.Image = eyeClosedBmp;
                picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage; // ou Zoom se preferir
                picToggleSenha.Cursor = Cursors.Hand;
            }

            // Garante que a senha começa como campo de senha
            txtSenha.UseSystemPasswordChar = true;
            senhaVisivel = false;
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
