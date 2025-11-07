using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Guna.UI2.WinForms;
using telebip_erp.Forms.Modules;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.Auth
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();

            try
            {
                ThemeManager.ApplyDarkTheme();
            }
            catch { /* Evita crash caso tema falhe */ }

            lbUsuario.MaxLength = 6;

            // Eventos
            lbUsuario.KeyPress += LbUsuario_KeyPress;
            lbUsuario.TextChanged += LbUsuario_TextChanged;
            lbSenha.KeyDown += LbSenha_KeyDown;
            btnLogin.Click += BtnLogin_Click;
            lbEsqueci.Click += lbEsqueci_Click;

            // ⚙️ Atalho para gerar senha criptografada (Ctrl+Shift+G)
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.G)
                {
                    GerarEExibirSenhaCriptografada();
                    e.SuppressKeyPress = true;
                }
            };
        }

        // ==========================
        // Aceita apenas números no campo de login
        // ==========================
        private void LbUsuario_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                lbSenha.Focus();
            }
        }

        private void LbUsuario_TextChanged(object? sender, EventArgs e)
        {
            if (sender is not Guna2TextBox tb) return;

            string apenasDigitos = Regex.Replace(tb.Text, "[^0-9]", "");
            if (tb.Text != apenasDigitos)
            {
                int pos = tb.SelectionStart - (tb.Text.Length - apenasDigitos.Length);
                tb.Text = apenasDigitos;
                tb.SelectionStart = Math.Max(0, pos);
            }
        }

        // ==========================
        // Enter na senha faz login
        // ==========================
        private void LbSenha_KeyDown(object? sender, KeyEventArgs e)
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
        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            lbUsuarioInvalido.Visible = false;
            lbSenhaInvalida.Visible = false;

            string usuario = lbUsuario.Text.Trim();
            string senhaDigitada = lbSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senhaDigitada))
            {
                if (string.IsNullOrEmpty(usuario))
                    lbUsuarioInvalido.Visible = true;
                if (string.IsNullOrEmpty(senhaDigitada))
                    lbSenhaInvalida.Visible = true;
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
                    lbUsuarioInvalido.Visible = true;
                    return;
                }

                string senhaBancoHash = (dt.Rows[0]["SENHA"]?.ToString() ?? "")
                    .Trim()
                    .ToLowerInvariant();

                int nivelAcesso = Convert.ToInt32(dt.Rows[0]["NIVEL_ACESSO"]);
                string senhaDigitadaHash = CryptoHelper.GerarHashSHA256(senhaDigitada)
                    .Trim()
                    .ToLowerInvariant();

                // Debug opcional — se quiser ver o que está sendo comparado
                // MessageBox.Show($"HASH DIGITADO:\n{senhaDigitadaHash}\n\nHASH BANCO:\n{senhaBancoHash}");

                if (senhaDigitadaHash != senhaBancoHash)
                {
                    lbSenhaInvalida.Visible = true;
                    lbSenha.Clear();
                    lbSenha.Focus();
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
        private void lbEsqueci_Click(object? sender, EventArgs e)
        {
            var formRecuperacao = new FormRecuperacaoSenha
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formRecuperacao.ShowDialog(this);
        }
        
    }
}
