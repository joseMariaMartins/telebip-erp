using MaterialSkin.Controls;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telebip_erp.Forms.Auth
{
    public partial class FormTrocarUsuario : FormLoad
    {
        private bool senhaVisivel = false;
        private Bitmap eyeOpenBmp;
        private Bitmap eyeClosedBmp;

        public FormTrocarUsuario()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
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
            cuiButton1.Click += BtnCancelar_Click;

            lblEsqueci.Click += LblEsqueci_Click;

            // Configurar toggle de senha
            if (picToggleSenha != null)
            {
                picToggleSenha.Click += PicToggleSenha_Click;
                picToggleSenha.Cursor = Cursors.Hand;
                picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            // Carregar imagens do "eye" e configurar botões
            LoadEyeImages();
            ConfigureButtonsVisuals();

            // Aplica estilo de bordas arredondadas
            try
            {
                StyleTextboxWrapperPanel(pnlWrapperUsuario, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
                StyleTextboxWrapperPanel(pnlWrapperSenha, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

                SetWrapperFocused(pnlWrapperUsuario, false);
                SetWrapperFocused(pnlWrapperSenha, false);

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

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            if (wrapper == null) return;

            wrapper.BackColor = fill;
            wrapper.Tag = border;
            wrapper.AccessibleDescription = radius.ToString();

            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;

            wrapper.Resize -= Wrapper_Resize;
            wrapper.Resize += Wrapper_Resize;

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

            int radius = 8;
            try
            {
                if (!string.IsNullOrEmpty(wrapper.AccessibleDescription) && int.TryParse(wrapper.AccessibleDescription, out int r))
                    radius = Math.Max(0, r);
            }
            catch { radius = 8; }

            var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);

            Color borderColor = Color.FromArgb(60, 62, 80);
            try
            {
                if (wrapper.Tag is Color c) borderColor = c;
            }
            catch { /* ignore */ }

            using (var path = GetRoundedRect(rect, radius))
            using (var pen = new Pen(borderColor, 1))
            {
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

            Color active = Color.FromArgb(100, 150, 255);
            Color normal = Color.FromArgb(60, 62, 80);

            wrapper.Tag = focused ? active : normal;
            try { wrapper.Invalidate(); } catch { }
        }
        #endregion

        #region Toggle Visibilidade da Senha
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

            // Começa sempre com o olho "fechado" (senha escondida)
            if (picToggleSenha != null)
            {
                picToggleSenha.Image = eyeClosedBmp;
                picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage; // ou Zoom, se preferir
                picToggleSenha.Cursor = Cursors.Hand;
            }

            // Garante que começa como campo de senha
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

        #region Event Handlers
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
                var parametros = new System.Data.SQLite.SQLiteParameter[]
                {
            new System.Data.SQLite.SQLiteParameter("@LOGIN", usuario)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                if (dt.Rows.Count == 0)
                {
                    lblUsuarioInvalido.Visible = true;
                    return;
                }

                string senhaBancoHash = (dt.Rows[0]["SENHA"]?.ToString() ?? "").Trim().ToLowerInvariant();
                int nivelAcesso = Convert.ToInt32(dt.Rows[0]["NIVEL_ACESSO"]);
                string senhaDigitadaHash = CryptoHelper.GerarHashSHA256(senhaDigitada).Trim().ToLowerInvariant();

                if (senhaDigitadaHash != senhaBancoHash)
                {
                    lblSenhaInvalida.Visible = true;
                    txtSenha.Clear();
                    txtSenha.Focus();
                    return;
                }

                // VERIFICA SE ESTÁ TENTANDO TROCAR PARA O MESMO USUÁRIO
                if (Session.NivelAcesso == nivelAcesso)
                {
                    string usuarioAtual = Session.NivelAcesso == 0 ? "Gerente (010301)" : "Funcionário (010302)";
                    string usuarioNovo = nivelAcesso == 0 ? "Gerente (010301)" : "Funcionário (010302)";

                    MessageBox.Show($"Você já está logado como {usuarioAtual}!\n\nNão é necessário trocar para o mesmo usuário.",
                        "Usuário Já Logado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // ATUALIZA A SESSÃO
                Session.NivelAcesso = nivelAcesso;

                // MENSAGEM PERSONALIZADA CONFORME O USUÁRIO
                string mensagem = "";
                string tipoUsuario = "";

                if (usuario == "010301")
                {
                    mensagem = "Gerente logado com sucesso!\n\nAcesso total ao sistema liberado.";
                    tipoUsuario = "👑 GERENTE";
                }
                else if (usuario == "010302")
                {
                    mensagem = "Funcionário logado com sucesso!\n\nAcesso às funções básicas liberado.";
                    tipoUsuario = "👤 FUNCIONÁRIO";
                }
                else
                {
                    mensagem = $"Usuário {usuario} logado com sucesso!";
                    tipoUsuario = nivelAcesso == 0 ? "👑 GERENTE" : "👤 FUNCIONÁRIO";
                }

                MessageBox.Show(mensagem, tipoUsuario,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fazer login:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LblEsqueci_Click(object sender, EventArgs e)
        {
            var formRecuperacao = new FormRecuperacaoSenha
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formRecuperacao.ShowDialog(this);
        }
        #endregion

        #region Helpers
        private void ConfigureButtonsVisuals()
        {
            try
            {
                // Botão Trocar (Login)
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

                // Botão Cancelar
                cuiButton1.NormalBackground = Color.FromArgb(180, 60, 60);
                cuiButton1.NormalForeColor = Color.White;
                cuiButton1.NormalOutline = Color.FromArgb(200, 200, 200);
                cuiButton1.OutlineThickness = 1F;
                cuiButton1.Rounding = new Padding(8);

                cuiButton1.HoverBackground = ControlPaint.Light(cuiButton1.NormalBackground);
                cuiButton1.HoverForeColor = cuiButton1.NormalForeColor;
                cuiButton1.HoverOutline = cuiButton1.NormalOutline;

                cuiButton1.PressedBackground = ControlPaint.Dark(cuiButton1.NormalBackground);
                cuiButton1.PressedForeColor = cuiButton1.NormalForeColor;
                cuiButton1.PressedOutline = cuiButton1.NormalOutline;
            }
            catch { /* evita crash caso controle mude */ }
        }

        private void FecharTodasFormsExcetoEsta()
        {
            try
            {
                var formsParaFechar = new List<Form>();

                foreach (Form form in Application.OpenForms)
                {
                    if (form != this &&
                        !form.Name.Contains("Login") &&
                        !form.Name.Contains("Auth") &&
                        form.Name != "FormTrocarUsuario")
                    {
                        formsParaFechar.Add(form);
                    }
                }

                foreach (Form form in formsParaFechar)
                {
                    try
                    {
                        form.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Erro ao fechar form {form.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao fechar forms: {ex.Message}");
            }
        }
        #endregion

        private void FormTrocarUsuario_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}