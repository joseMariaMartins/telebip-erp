using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaGerente : MaterialForm
    {
        public FormAlteracaoSenhaGerente()
        {
            InitializeComponent();

            // Inicializar a visibilidade das senhas
            AtualizarVisibilidadeSenha(false);
            AtualizarTextoLabel();

            // Configurar eventos
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            // Eventos de tecla
            tbSenhaAtual.KeyDown += (s, e) => HandleKeyDown(e, tbSenhaAtual, tbNovaSenha);
            tbNovaSenha.KeyDown += (s, e) => HandleKeyDown(e, tbNovaSenha, tbConfirmarSenha);
            tbConfirmarSenha.KeyDown += (s, e) => HandleKeyDown(e, tbConfirmarSenha, btnConfirmar);

            // Eventos de botão
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // Evento do checkbox
            cboxMostrarSenha.CheckedChanged += CboxMostrarSenha_CheckedChanged;
        }

        private void AtualizarTextoLabel()
        {
            // Atualiza o texto da label baseado no estado do checkbox
            if (lblSenha != null)
            {
                lblSenha.Text = cboxMostrarSenha.Checked ? "Ocultar Senha" : "Mostrar Senha";
            }
        }

        private void AtualizarVisibilidadeSenha(bool visivel)
        {
            try
            {
                if (visivel)
                {
                    // Mostrar texto
                    tbSenhaAtual.UseSystemPasswordChar = false;
                    tbSenhaAtual.PasswordChar = '\0';

                    tbNovaSenha.UseSystemPasswordChar = false;
                    tbNovaSenha.PasswordChar = '\0';

                    tbConfirmarSenha.UseSystemPasswordChar = false;
                    tbConfirmarSenha.PasswordChar = '\0';
                }
                else
                {
                    // Esconder com bullet
                    tbSenhaAtual.UseSystemPasswordChar = true;
                    tbSenhaAtual.PasswordChar = '●';

                    tbNovaSenha.UseSystemPasswordChar = true;
                    tbNovaSenha.PasswordChar = '●';

                    tbConfirmarSenha.UseSystemPasswordChar = true;
                    tbConfirmarSenha.PasswordChar = '●';
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar visibilidade: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleKeyDown(KeyEventArgs e, Control currentControl, Control nextControl)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (currentControl == tbSenhaAtual)
                {
                    // Apenas muda o foco, SEM validar
                    tbNovaSenha.Focus();
                }
                else if (currentControl == tbNovaSenha)
                {
                    // Apenas muda o foco, SEM validar
                    tbConfirmarSenha.Focus();
                }
                else if (currentControl == tbConfirmarSenha)
                {
                    // Aqui sim valida quando pressionar Enter no último campo
                    BtnConfirmar_Click(btnConfirmar, EventArgs.Empty);
                }
                else if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAtual = tbSenhaAtual.Text.Trim();
            string novaSenha = tbNovaSenha.Text.Trim();
            string confirmarSenha = tbConfirmarSenha.Text.Trim();

            // Validação da senha atual
            if (string.IsNullOrWhiteSpace(senhaAtual))
            {
                MessageBox.Show("Digite a senha atual do gerente.",
                    "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSenhaAtual.Focus();
                return;
            }

            if (!ValidarSenhaAtualNoBanco(senhaAtual))
            {
                MessageBox.Show("Senha atual incorreta.",
                    "Erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSenhaAtual.Focus();
                return;
            }

            // Validações das novas senhas
            if (string.IsNullOrWhiteSpace(novaSenha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha os dois campos de nova senha.",
                    "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNovaSenha.Focus();
                return;
            }

            if (novaSenha.Length < 4)
            {
                MessageBox.Show("A nova senha deve ter pelo menos 4 caracteres.",
                    "Senha muito curta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNovaSenha.Focus();
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas digitadas não coincidem.",
                    "Erro de confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbConfirmarSenha.Focus();
                return;
            }

            // Confirmação final
            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja alterar a senha do gerente?",
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes) return;

            // Atualiza no banco
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

        private void CboxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            // Atualizar a visibilidade de todas as senhas baseado no estado do checkbox
            AtualizarVisibilidadeSenha(cboxMostrarSenha.Checked);

            // Atualizar o texto da label
            AtualizarTextoLabel();
        }

        private static bool ValidarSenhaAtualNoBanco(string senhaAtual)
        {
            string senhaHash = CryptoHelper.GerarHashSHA256(senhaAtual);
            string sql = "SELECT COUNT(*) FROM USUARIO WHERE SENHA = @senha AND NIVEL_ACESSO = 1";

            var param = new SQLiteParameter[]
            {
                new SQLiteParameter("@senha", senhaHash)
            };

            object? resultado = DatabaseHelper.ExecuteScalar(sql, param);
            return Convert.ToInt32(resultado) > 0;
        }
    }
}