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
        private Bitmap eyeOpenBmp;
        private Bitmap eyeClosedBmp;

        // Estados de visibilidade para cada campo
        private bool novaSenhaVisivel = false;
        private bool confirmarSenhaVisivel = false;

        public FormAlteracaoSenhaFuncionario()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            SetupEventHandlers();
            LoadEyeImages();
            SetupEyeButtons();
        }

        private void LoadEyeImages()
        {
            try
            {
                // Fallback: desenha ícones simples (igual ao login)
                eyeOpenBmp = DrawSimpleEye(20, 20, true);
                eyeClosedBmp = DrawSimpleEye(20, 20, false);

                // Configura imagens iniciais
                btnOlhoNovaSenha.Image = eyeClosedBmp;
                btnOlhoConfirmarSenha.Image = eyeClosedBmp;

                // Configura tooltips
                btnOlhoNovaSenha.AccessibleDescription = "Mostrar senha";
                btnOlhoConfirmarSenha.AccessibleDescription = "Mostrar senha";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar imagens: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap DrawSimpleEye(int w, int h, bool open)
        {
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var pen = new Pen(Color.White, 1.5f))
                using (var brush = new SolidBrush(Color.White))
                {
                    // contorno do olho
                    g.DrawEllipse(pen, 2, 6, w - 4, h - 12);
                    if (open)
                    {
                        // Olho aberto: pupila
                        g.FillEllipse(brush, w / 2 - 3, h / 2 - 3, 6, 6);
                    }
                    else
                    {
                        // Olho fechado: linha horizontal
                        g.DrawLine(pen, 3, h / 2, w - 3, h / 2);
                    }
                }
            }
            return bmp;
        }

        private void SetupEyeButtons()
        {
            // Configura cada botão separadamente (método mais simples sem ref)
            ConfigurarOlhoNovaSenha();
            ConfigurarOlhoConfirmarSenha();
        }

        private void ConfigurarOlhoNovaSenha()
        {
            bool visivel = false;

            // Certifica propriedades básicas
            btnOlhoNovaSenha.BackColor = Color.FromArgb(60, 62, 80);
            btnOlhoNovaSenha.SizeMode = PictureBoxSizeMode.CenterImage;
            btnOlhoNovaSenha.Cursor = Cursors.Hand;
            btnOlhoNovaSenha.Enabled = true;
            btnOlhoNovaSenha.TabStop = false;
            btnOlhoNovaSenha.Visible = true;

            // Configura evento click
            btnOlhoNovaSenha.Click += (s, e) =>
            {
                visivel = !visivel;
                AtualizarVisibilidadeSenha(tbNovaSenha, btnOlhoNovaSenha, visivel);
            };
        }

        private void ConfigurarOlhoConfirmarSenha()
        {
            bool visivel = false;

            // Certifica propriedades básicas
            btnOlhoConfirmarSenha.BackColor = Color.FromArgb(60, 62, 80);
            btnOlhoConfirmarSenha.SizeMode = PictureBoxSizeMode.CenterImage;
            btnOlhoConfirmarSenha.Cursor = Cursors.Hand;
            btnOlhoConfirmarSenha.Enabled = true;
            btnOlhoConfirmarSenha.TabStop = false;
            btnOlhoConfirmarSenha.Visible = true;

            // Configura evento click
            btnOlhoConfirmarSenha.Click += (s, e) =>
            {
                visivel = !visivel;
                AtualizarVisibilidadeSenha(tbConfirmarSenha, btnOlhoConfirmarSenha, visivel);
            };
        }

        private void AtualizarVisibilidadeSenha(telebip_erp.Controls.PlaceholderTextBox textBox, PictureBox btn, bool visivel)
        {
            try
            {
                if (visivel)
                {
                    textBox.UseSystemPasswordChar = false;
                    textBox.PasswordChar = '\0';
                    btn.Image = eyeOpenBmp;
                    btn.AccessibleDescription = "Ocultar senha";
                }
                else
                {
                    textBox.UseSystemPasswordChar = true;
                    textBox.PasswordChar = '●';
                    btn.Image = eyeClosedBmp;
                    btn.AccessibleDescription = "Mostrar senha";
                }

                // Mantém o foco no TextBox
                textBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alternar visibilidade: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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