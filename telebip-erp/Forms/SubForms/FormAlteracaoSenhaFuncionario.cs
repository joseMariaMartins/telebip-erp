using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaFuncionario : MaterialForm
    {
        public FormAlteracaoSenhaFuncionario()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            SetupEventHandlers();
            SetupEyeButtons();
        }

        private void SetupEyeButtons()
        {
            // Configura os botões de olho para funcionar mesmo sem imagens
            ConfigureEyeButton(btnOlhoNovaSenha, tbNovaSenha);
            ConfigureEyeButton(btnOlhoConfirmarSenha, tbConfirmarSenha);
        }

        private void ConfigureEyeButton(PictureBox btn, telebip_erp.Controls.PlaceholderTextBox textBox)
        {
            // Define visual dos botões (será substituído por imagens depois)
            btn.BackColor = Color.FromArgb(60, 62, 80);
            btn.SizeMode = PictureBoxSizeMode.CenterImage;

            // Usa texto como fallback até você adicionar as imagens
            using (var g = btn.CreateGraphics())
            {
                g.Clear(Color.FromArgb(60, 62, 80));
                using (var brush = new SolidBrush(Color.White))
                using (var font = new Font("Arial", 8, FontStyle.Bold))
                {
                    g.DrawString("👁", font, brush, new PointF(2, 2));
                }
            }

            btn.Click += (s, e) => TogglePasswordVisibility(btn, textBox);
        }

        private void TogglePasswordVisibility(PictureBox btn, telebip_erp.Controls.PlaceholderTextBox textBox)
        {
            if (textBox.UseSystemPasswordChar)
            {
                textBox.UseSystemPasswordChar = false;
                // Quando mostrar senha - mudar visual do botão
                btn.BackColor = Color.FromArgb(80, 100, 120);
            }
            else
            {
                textBox.UseSystemPasswordChar = true;
                // Quando ocultar senha - voltar ao normal
                btn.BackColor = Color.FromArgb(60, 62, 80);
            }
        }

        private void SetupEventHandlers()
        {
            // Eventos de tecla
            tbNovaSenha.KeyDown += (s, e) => HandleKeyDown(e, tbNovaSenha, tbConfirmarSenha);
            tbConfirmarSenha.KeyDown += (s, e) => HandleKeyDown(e, tbConfirmarSenha, btnConfirmar);

            // Eventos de botão
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private void HandleKeyDown(KeyEventArgs e, Control currentControl, Control nextControl)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (currentControl == tbConfirmarSenha)
                {
                    BtnConfirmar_Click(btnConfirmar, EventArgs.Empty);
                }
                else
                {
                    nextControl.Focus();
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
    }
}