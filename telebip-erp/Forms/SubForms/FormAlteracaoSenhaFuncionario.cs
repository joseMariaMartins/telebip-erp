using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaFuncionario : FormLoad
    {
        public FormAlteracaoSenhaFuncionario()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // Inicializar a visibilidade das senhas
            AtualizarVisibilidadeSenha(false);
            AtualizarTextoLabel();

            // Configurar eventos
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            // Eventos de tecla
            tbNovaSenha.KeyDown += (s, e) => HandleKeyDown(e, tbNovaSenha, tbConfirmarSenha);
            tbConfirmarSenha.KeyDown += (s, e) => HandleKeyDown(e, tbConfirmarSenha, btnConfirmar);

            // Eventos de botão
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += (s, e) => this.Close();

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
                    tbNovaSenha.UseSystemPasswordChar = false;
                    tbNovaSenha.PasswordChar = '\0';

                    tbConfirmarSenha.UseSystemPasswordChar = false;
                    tbConfirmarSenha.PasswordChar = '\0';
                }
                else
                {
                    // Esconder com bullet
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

                if (currentControl == tbNovaSenha)
                {
                    // Apenas muda o foco, SEM validar
                    tbConfirmarSenha.Focus();
                }
                else if (currentControl == tbConfirmarSenha)
                {
                    // Aqui sim valida quando pressionar Enter no último campo
                    BtnConfirmar_Click(btnConfirmar, EventArgs.Empty);
                }
                else
                {
                    nextControl?.Focus();
                }
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string novaSenha = tbNovaSenha.Text.Trim();
            string confirmarSenha = tbConfirmarSenha.Text.Trim();

            // Validações
            if (string.IsNullOrWhiteSpace(novaSenha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha ambos os campos de senha.",
                    "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNovaSenha.Focus();
                return;
            }

            if (novaSenha.Length < 4)
            {
                MessageBox.Show("A senha deve ter pelo menos 4 caracteres.",
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
                "Tem certeza que deseja alterar a senha do funcionário?",
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes) return;

            // Atualiza no banco
            string novaSenhaHash = CryptoHelper.GerarHashSHA256(novaSenha);
            string sql = "UPDATE USUARIO SET SENHA = @senha WHERE NIVEL_ACESSO = 0";

            var param = new SQLiteParameter[]
            {
                new SQLiteParameter("@senha", novaSenhaHash)
            };

            try
            {
                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sql, param);

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Senha do funcionário alterada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        private void CboxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            // Atualizar a visibilidade de todas as senhas baseado no estado do checkbox
            AtualizarVisibilidadeSenha(cboxMostrarSenha.Checked);

            // Atualizar o texto da label
            AtualizarTextoLabel();
        }
    }
}