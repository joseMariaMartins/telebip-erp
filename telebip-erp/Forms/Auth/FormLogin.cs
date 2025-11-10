using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using telebip_erp.Forms.Modules;
using telebip_erp.Forms.Auth;

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
            catch { /* Evita crash caso tema falhe */ }

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
            picToggleSenha.Click += PicToggleSenha_Click;
            picToggleSenha.Cursor = Cursors.Hand;
            picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage;

            // Aplicar bordas arredondadas
            AplicarBordasArredondadas();

            // Criar ícones simples para o eye (open/closed) desenhados em runtime para não depender de resources externos
            eyeOpenBmp = CreateEyeBitmap(24, 24, true);
            eyeClosedBmp = CreateEyeBitmap(24, 24, false);

            AtualizarVisibilidadeSenha();

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
            // Armazenamos a cor de borda atual no Tag para permitir mudança dinâmica
            wrapper.Tag = border;

            // Remover handlers duplicados caso já existam (evita múltiplas assinaturas em reloads)
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

            // Aplica bordas arredondadas nos wrappers
            StyleTextboxWrapperPanel(pnlWrapperUsuario, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperSenha, fillColor, borderColor, radius);

            // Ajustes visuais do botão
            btnLogin.BackColor = Color.FromArgb(40, 120, 80);
            btnLogin.ForeColor = Color.White;
            btnLogin.Cursor = Cursors.Hand;

            // Labels com cores suaves
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

        #region Eye Icon Runtime
        private Bitmap CreateEyeBitmap(int width, int height, bool open)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Coordenadas base
                float cx = width / 2f;
                float cy = height / 2f;
                float rx = width * 0.45f;
                float ry = height * 0.25f;

                using (var pen = new Pen(Color.FromArgb(200, 200, 200), 2f))
                using (var brush = new SolidBrush(Color.FromArgb(200, 200, 200)))
                {
                    // Desenha contorno do olho (elipse estilizada)
                    var eyePath = new GraphicsPath();
                    // vamos desenhar uma forma mais elíptica estilizada:
                    var pts = new PointF[]
                    {
                        new PointF(cx - rx, cy),
                        new PointF(cx - rx/2, cy - ry),
                        new PointF(cx + rx/2, cy - ry),
                        new PointF(cx + rx, cy),
                        new PointF(cx + rx/2, cy + ry),
                        new PointF(cx - rx/2, cy + ry)
                    };
                    eyePath.AddPolygon(pts);
                    g.DrawPath(pen, eyePath);

                    // Iris / Pupila
                    if (open)
                    {
                        g.FillEllipse(brush, cx - rx * 0.35f, cy - ry * 0.35f, rx * 0.7f, ry * 0.7f);
                        g.FillEllipse(Brushes.Black, cx - rx * 0.12f, cy - ry * 0.12f, rx * 0.24f, ry * 0.24f);
                    }
                    else
                    {
                        // Linha cortando o olho para indicar fechado
                        using (var penLine = new Pen(Color.FromArgb(200, 200, 200), 2.5f))
                        {
                            g.DrawLine(penLine, cx - rx, cy + ry * 0.1f, cx + rx, cy - ry * 0.1f);
                        }
                    }
                }
            }
            return bmp;
        }
        #endregion

        #region Toggle Visibilidade da Senha
        private void PicToggleSenha_Click(object sender, EventArgs e)
        {
            senhaVisivel = !senhaVisivel;
            AtualizarVisibilidadeSenha();
        }

        private void AtualizarVisibilidadeSenha()
        {
            if (senhaVisivel)
            {
                txtSenha.UseSystemPasswordChar = false; // Mostrar texto
                picToggleSenha.Image = eyeOpenBmp;
                picToggleSenha.Cursor = Cursors.Hand;
                picToggleSenha.AccessibleDescription = "Ocultar senha";
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true; // Esconder texto
                picToggleSenha.Image = eyeClosedBmp;
                picToggleSenha.Cursor = Cursors.Hand;
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
        // Aceita apenas números no campo de login
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

        // ==========================
        // Enter na senha faz login
        // ==========================
        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }

        // ==========================
        // BOTÃO LOGIN
        // ==========================
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

        // ==========================
        // ESQUECI MINHA SENHA
        // ==========================
        private void LblEsqueci_Click(object sender, EventArgs e)
        {
            var formRecuperacao = new FormRecuperacaoSenha
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formRecuperacao.ShowDialog(this);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Foca no campo de usuário ao carregar
            txtUsuario.Focus();
        }
    }
}
