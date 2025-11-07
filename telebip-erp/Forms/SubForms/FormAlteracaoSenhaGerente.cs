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

            // Inicialmente bloqueia os campos de nova senha
            tbNovaSenha.Enabled = false;
            tbNovaSenha2.Enabled = false;

            // Eventos dos botões de olho
            btnOlhos.MouseDown += BtnOlhos_MouseDown;
            btnOlhos.MouseUp += BtnOlhos_MouseUp;

            btnOlhos2.MouseDown += BtnOlhos2_MouseDown;
            btnOlhos2.MouseUp += BtnOlhos2_MouseUp;

            btnOlhos3.MouseDown += BtnOlhos3_MouseDown;
            btnOlhos3.MouseUp += BtnOlhos3_MouseUp;

            // Eventos de controle
            tbSenhaAtual.KeyDown += TbSenhaAtual_KeyDown;
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        // ==========================
        // MÉTODO PARA VALIDAR SENHA ATUAL (HASH)
        // ==========================
        private bool ValidarSenhaAtual(string senhaAtual)
        {
            // Gera o hash da senha digitada
            string senhaHash = CryptoHelper.GerarHashSHA256(senhaAtual);

            string sql = "SELECT COUNT(*) FROM USUARIO WHERE SENHA = @senha AND NIVEL_ACESSO = 1";
            var param = new SQLiteParameter[]
            {
                new SQLiteParameter("@senha", senhaHash)
            };

            object? resultado = DatabaseHelper.ExecuteScalar(sql, param);
            int count = Convert.ToInt32(resultado);

            return count > 0;
        }

        // ==========================
        // AO PRESSIONAR ENTER NA SENHA ATUAL
        // ==========================
        private void TbSenhaAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

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
                    tbNovaSenha2.Enabled = true;
                    tbNovaSenha.Focus();
                    MessageBox.Show("Senha atual verificada. Agora digite e confirme a nova senha.",
                        "Verificação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbNovaSenha.Enabled = false;
                    tbNovaSenha2.Enabled = false;
                    MessageBox.Show("Senha atual incorreta.",
                        "Erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================
        // BOTÃO CONFIRMAR
        // ==========================
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAtual = tbSenhaAtual.Text.Trim();
            string novaSenha = tbNovaSenha.Text.Trim();
            string confirmarSenha = tbNovaSenha2.Text.Trim();

            // Verifica a senha atual
            if (!ValidarSenhaAtual(senhaAtual))
            {
                MessageBox.Show("A senha atual está incorreta.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNovaSenha.Enabled = false;
                tbNovaSenha2.Enabled = false;
                return;
            }

            // Validações das novas senhas
            if (string.IsNullOrWhiteSpace(novaSenha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha os dois campos de nova senha.",
                    "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha.Length < 4)
            {
                MessageBox.Show("A nova senha deve ter pelo menos 4 caracteres.",
                    "Senha muito curta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas digitadas não coincidem.",
                    "Erro de confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmação final
            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja alterar a senha do gerente?",
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes)
                return;

            // 🔐 Criptografa antes de salvar
            string novaSenhaHash = CryptoHelper.GerarHashSHA256(novaSenha);

            string sqlUpdate = "UPDATE USUARIO SET SENHA = @novaSenha WHERE NIVEL_ACESSO = 1";
            var parametros = new SQLiteParameter[]
            {
                new SQLiteParameter("@novaSenha", novaSenhaHash)
            };

            try
            {
                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sqlUpdate, parametros);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Senha do gerente alterada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbSenhaAtual.Clear();
                    tbNovaSenha.Clear();
                    tbNovaSenha2.Clear();

                    tbNovaSenha.Enabled = false;
                    tbNovaSenha2.Enabled = false;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhum registro de gerente foi encontrado.",
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
        // BOTÕES DE OLHO
        // ==========================
        private void BtnOlhos_MouseDown(object sender, MouseEventArgs e)
        {
            tbSenhaAtual.PasswordChar = '\0';
        }

        private void BtnOlhos_MouseUp(object sender, MouseEventArgs e)
        {
            tbSenhaAtual.PasswordChar = '*';
        }

        private void BtnOlhos2_MouseDown(object sender, MouseEventArgs e)
        {
            tbNovaSenha.PasswordChar = '\0';
        }

        private void BtnOlhos2_MouseUp(object sender, MouseEventArgs e)
        {
            tbNovaSenha.PasswordChar = '*';
        }

        private void BtnOlhos3_MouseDown(object sender, MouseEventArgs e)
        {
            tbNovaSenha2.PasswordChar = '\0';
        }

        private void BtnOlhos3_MouseUp(object sender, MouseEventArgs e)
        {
            tbNovaSenha2.PasswordChar = '*';
        }

        // ==========================
        // BOTÃO CANCELAR
        // ==========================
        private void cuiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
