using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaGerente : Form
    {
        public FormAlteracaoSenhaGerente()
        {
            InitializeComponent();

            // Inicialmente bloqueia o campo de nova senha
            tbNovaSenha.Enabled = false;

            btnOlhos.MouseDown += btnOlhos_MouseDown;
            btnOlhos.MouseUp += btnOlhos_MouseUp;

            btnOlhos2.MouseDown += btnOlhos2_MouseDown;
            btnOlhos2.MouseUp += btnOlhos2_MouseUp;


            // Eventos
            tbSenhaAtual.KeyDown += TbSenhaAtual_KeyDown;
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        // ==========================
        // MÉTODO PARA VALIDAR SENHA ATUAL
        // ==========================
        private bool ValidarSenhaAtual(string senhaAtual)
        {
            string sql = "SELECT COUNT(*) FROM USUARIO WHERE SENHA = @senha AND NIVEL_ACESSO = 1";

            var param = new SQLiteParameter[]
            {
                new SQLiteParameter("@senha", senhaAtual)
            };

            object? resultado = DatabaseHelper.ExecuteScalar(sql, param);
            int count = Convert.ToInt32(resultado);

            return count > 0;
        }

        // ==========================
        // EVENTO AO PRESSIONAR ENTER NA SENHA ATUAL
        // ==========================
        private void TbSenhaAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string senhaDigitada = tbSenhaAtual.Text.Trim();

                if (string.IsNullOrWhiteSpace(senhaDigitada))
                {
                    MessageBox.Show("Digite a senha atual do gerente.",
                        "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidarSenhaAtual(senhaDigitada))
                {
                    tbNovaSenha.Enabled = true;
                }
                else
                {
                    tbNovaSenha.Enabled = false;
                    MessageBox.Show("Senha atual incorreta.",
                        "Erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================
        // EVENTO DO BOTÃO CONFIRMAR
        // ==========================
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAtual = tbSenhaAtual.Text.Trim();
            string novaSenha = tbNovaSenha.Text.Trim();

            // Verificações básicas
            if (!ValidarSenhaAtual(senhaAtual))
            {
                MessageBox.Show("A senha atual está incorreta.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNovaSenha.Enabled = false;
                tbNovaSenha.Clear();
                return;
            }

            if (string.IsNullOrWhiteSpace(novaSenha))
            {
                MessageBox.Show("Digite a nova senha.",
                    "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha.Length < 4)
            {
                MessageBox.Show("A nova senha deve ter pelo menos 4 caracteres.",
                    "Senha muito curta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Atualiza no banco
            string sqlUpdate = "UPDATE USUARIO SET SENHA = @novaSenha WHERE NIVEL_ACESSO = 1";

            var parametros = new SQLiteParameter[]
            {
                new SQLiteParameter("@novaSenha", novaSenha)
            };

            int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sqlUpdate, parametros);

            if (linhasAfetadas > 0)
            {
                MessageBox.Show("Senha do gerente alterada com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSenhaAtual.Clear();
                tbNovaSenha.Clear();
                tbNovaSenha.Enabled = false;
            }
            else
            {
                MessageBox.Show("Não foi possível atualizar a senha. Verifique o banco de dados.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOlhos_MouseDown(object sender, MouseEventArgs e)
        {
            tbSenhaAtual.PasswordChar = '\0'; // Mostra a senha
        }

        private void btnOlhos_MouseUp(object sender, MouseEventArgs e)
        {
            tbSenhaAtual.PasswordChar = '*'; // Esconde a senha novamente
        }

        private void btnOlhos2_MouseDown(object sender, MouseEventArgs e)
        {
            tbNovaSenha.PasswordChar = '\0'; // Mostra a senha
        }

        private void btnOlhos2_MouseUp(object sender, MouseEventArgs e)
        {
            tbNovaSenha.PasswordChar = '*'; // Esconde a senha novamente
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
