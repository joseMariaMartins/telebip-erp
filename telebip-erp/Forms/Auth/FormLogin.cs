using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Guna.UI2.WinForms;
using telebip_erp.Forms.Modules; // Ajuste conforme o namespace real do FormBase

namespace telebip_erp.Forms.Auth
{
    public partial class FormLogin : MaterialForm
    {
        // =========================================================
        // ▶ CONSTRUTOR
        // =========================================================
        public FormLogin()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // Limites e eventos iniciais
            lbUsuario.MaxLength = 6; // Máximo de 6 caracteres (igual ao banco)

            // Eventos de controle
            lbUsuario.KeyPress += LbUsuario_KeyPress;
            lbUsuario.TextChanged += LbUsuario_TextChanged;
            lbSenha.KeyDown += LbSenha_KeyDown;
            btnLogin.Click += BtnLogin_Click;
        }

        // =========================================================
        // ▶ EVENTOS DE ENTRADA DE USUÁRIO
        // =========================================================

        /// <summary>
        /// Bloqueia a digitação de letras e símbolos no campo de usuário.
        /// Pressionar Enter muda o foco para o campo de senha.
        /// </summary>
        private void LbUsuario_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Impede caracteres não numéricos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Enter → foca a senha
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                lbSenha.Focus();
            }
        }

        /// <summary>
        /// Garante que colagens só mantenham dígitos.
        /// </summary>
        private void LbUsuario_TextChanged(object? sender, EventArgs e)
        {
            var tb = sender as Guna2TextBox;
            if (tb == null) return;

            string apenasDigitos = Regex.Replace(tb.Text, "[^0-9]", ""); // Remove tudo que não for número

            if (apenasDigitos != tb.Text)
            {
                int pos = tb.SelectionStart - (tb.Text.Length - apenasDigitos.Length);
                tb.Text = apenasDigitos;
                tb.SelectionStart = Math.Max(0, pos);
            }
        }

        /// <summary>
        /// Pressionar Enter na senha executa o clique do botão Login.
        /// </summary>
        private void LbSenha_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }

        // =========================================================
        // ▶ BOTÃO DE LOGIN
        // =========================================================

        /// <summary>
        /// Valida credenciais, verifica no banco SQLite e abre o sistema.
        /// </summary>
        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            // 🔹 Esconde erros antigos antes de nova tentativa
            lbUsuarioInvalido.Visible = false;
            lbSenhaInvalida.Visible = false;

            // 🔹 Captura os textos digitados
            string usuario = lbUsuario.Text.Trim();
            string senha = lbSenha.Text.Trim();

            // 🔹 Verifica se os campos estão vazios
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                if (string.IsNullOrEmpty(usuario))
                    lbUsuarioInvalido.Visible = true;
                if (string.IsNullOrEmpty(senha))
                    lbSenhaInvalida.Visible = true;
                return;
            }

            try
            {
                // =====================================================
                // 🕐 INÍCIO DO PROCESSO DE VALIDAÇÃO
                // =====================================================
                Cursor = Cursors.WaitCursor; // Mostra cursor de carregamento
                await Task.Delay(200); // Delay pequeno (caso o banco demore)

                // 🔸 Consulta SQL — busca senha e nível de acesso
                string sql = "SELECT SENHA, NIVEL_ACESSO FROM USUARIO WHERE LOGIN = @LOGIN";
                var parametros = new SQLiteParameter[]
                {
                    new SQLiteParameter("@LOGIN", usuario)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                // =====================================================
                // ❌ USUÁRIO NÃO ENCONTRADO
                // =====================================================
                if (dt.Rows.Count == 0)
                {
                    lbUsuarioInvalido.Visible = true;
                    return;
                }

                // 🔸 Pega os dados do banco
                string senhaBanco = dt.Rows[0]["SENHA"].ToString()!;
                int nivelAcesso = Convert.ToInt32(dt.Rows[0]["NIVEL_ACESSO"]);

                // =====================================================
                // ❌ SENHA INCORRETA
                // =====================================================
                if (senha != senhaBanco)
                {
                    lbSenhaInvalida.Visible = true;
                    return;
                }

                // =====================================================
                // ✅ LOGIN BEM-SUCEDIDO
                // =====================================================
                Session.NivelAcesso = nivelAcesso;

                // 🔸 Mostra tela de carregamento (splash)
                using (var splash = new telebip_erp.SplashScreen.FormSplashScreen())
                {
                    splash.ShowDialog();
                }

                // 🔸 Abre o sistema principal
                FormBase formBase = new FormBase();
                formBase.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // =====================================================
                // ⚠️ TRATAMENTO DE ERROS
                // =====================================================
                MessageBox.Show("Erro ao tentar fazer login:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // =====================================================
                // 🔚 FINALIZAÇÃO
                // =====================================================
                Cursor = Cursors.Default;
            }
        }
    }
}
