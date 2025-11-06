using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaFuncionario : Form
    {
        public FormAlteracaoSenhaFuncionario()
        {
            InitializeComponent();

            // Eventos
            btnOlhos.MouseDown += BtnOlhos_MouseDown;
            btnOlhos.MouseUp += BtnOlhos_MouseUp;
            btnOlhos2.MouseDown += BtnOlhos2_MouseDown;
            btnOlhos2.MouseUp += BtnOlhos2_MouseUp;
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        // ==========================
        // MOSTRAR/OCULTAR SENHAS
        // ==========================
        private void BtnOlhos_MouseDown(object sender, MouseEventArgs e)
        {
            tbSenhaFuncionario.PasswordChar = '\0'; // Mostra senha
        }

        private void BtnOlhos_MouseUp(object sender, MouseEventArgs e)
        {
            tbSenhaFuncionario.PasswordChar = '*'; // Oculta senha
        }

        private void BtnOlhos2_MouseDown(object sender, MouseEventArgs e)
        {
            tbSenhaNovamente.PasswordChar = '\0'; // Mostra confirmação
        }

        private void BtnOlhos2_MouseUp(object sender, MouseEventArgs e)
        {
            tbSenhaNovamente.PasswordChar = '*'; // Oculta confirmação
        }

        // ==========================
        // BOTÃO CONFIRMAR
        // ==========================
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string novaSenha = tbSenhaFuncionario.Text.Trim();
            string confirmarSenha = tbSenhaNovamente.Text.Trim();

            if (string.IsNullOrWhiteSpace(novaSenha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha ambos os campos de senha.",
                    "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha.Length < 4)
            {
                MessageBox.Show("A senha deve ter pelo menos 4 caracteres.",
                    "Senha muito curta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas digitadas não coincidem.",
                    "Erro de confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ⚠️ Confirmação antes de alterar
            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja alterar a senha do funcionário?",
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes)
            {
                return; // Cancela se o usuário clicar em "Não"
            }

            string sql = "UPDATE USUARIO SET SENHA = @senha WHERE NIVEL_ACESSO = 0";

            var param = new SQLiteParameter[]
            {
                new SQLiteParameter("@senha", novaSenha)
            };

            try
            {
                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sql, param);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Senha do funcionário alterada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbSenhaFuncionario.Clear();
                    tbSenhaNovamente.Clear();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado para funcionário.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a senha: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // BOTÃO CANCELAR
        // ==========================
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
