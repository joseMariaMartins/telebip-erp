using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaGerente : MaterialForm
    {
        private Bitmap eyeOpenBmp;
        private Bitmap eyeClosedBmp;

        // Usaremos uma classe wrapper para armazenar os estados
        private class CampoVisibilidade
        {
            public bool Visivel { get; set; }
            public PictureBox Botao { get; set; }
            public telebip_erp.Controls.PlaceholderTextBox TextBox { get; set; }

            public CampoVisibilidade(PictureBox botao, telebip_erp.Controls.PlaceholderTextBox textBox)
            {
                Botao = botao;
                TextBox = textBox;
                Visivel = false;
            }
        }

        public FormAlteracaoSenhaGerente()
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
                btnOlhoSenhaAtual.Image = eyeClosedBmp;
                btnOlhoNovaSenha.Image = eyeClosedBmp;
                btnOlhoConfirmarSenha.Image = eyeClosedBmp;

                // Configura tooltips
                btnOlhoSenhaAtual.AccessibleDescription = "Mostrar senha";
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
            // Cria os wrappers para cada campo
            var campoSenhaAtual = new CampoVisibilidade(btnOlhoSenhaAtual, tbSenhaAtual);
            var campoNovaSenha = new CampoVisibilidade(btnOlhoNovaSenha, tbNovaSenha);
            var campoConfirmarSenha = new CampoVisibilidade(btnOlhoConfirmarSenha, tbConfirmarSenha);

            // Configura os eventos
            ConfigurarEventoOlho(campoSenhaAtual);
            ConfigurarEventoOlho(campoNovaSenha);
            ConfigurarEventoOlho(campoConfirmarSenha);
        }

        private void ConfigurarEventoOlho(CampoVisibilidade campo)
        {
            // Certifica propriedades básicas
            campo.Botao.BackColor = Color.FromArgb(60, 62, 80);
            campo.Botao.SizeMode = PictureBoxSizeMode.CenterImage;
            campo.Botao.Cursor = Cursors.Hand;
            campo.Botao.Enabled = true;
            campo.Botao.TabStop = false;
            campo.Botao.Visible = true;
            campo.Botao.BringToFront();

            // Configura evento click
            campo.Botao.Click += (s, e) =>
            {
                campo.Visivel = !campo.Visivel;
                AtualizarVisibilidadeSenha(campo.TextBox, campo.Botao, campo.Visivel);
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
            tbSenhaAtual.KeyDown += (s, e) => HandleKeyDown(e, tbSenhaAtual, tbNovaSenha);
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
                else
                {
                    nextControl.Focus();
                }
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAtual = tbSenhaAtual.Text.Trim();
            string novaSenha = tbNovaSenha.Text.Trim();
            string confirmarSenha = tbConfirmarSenha.Text.Trim();

            // Validação da senha atual (só acontece aqui no botão Confirmar)
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