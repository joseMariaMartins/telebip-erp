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
        public FormAlteracaoSenhaGerente()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // HABILITA todos os campos desde o início
            tbNovaSenha.Enabled = true;
            tbConfirmarSenha.Enabled = true;

            SetupEventHandlers();
            SetupEyeButtons();
        }

        private void SetupEyeButtons()
        {
            // Configura os botões de olho
            ConfigureEyeButton(btnOlhoSenhaAtual, tbSenhaAtual);
            ConfigureEyeButton(btnOlhoNovaSenha, tbNovaSenha);
            ConfigureEyeButton(btnOlhoConfirmarSenha, tbConfirmarSenha);
        }

        private void ConfigureEyeButton(PictureBox btn, telebip_erp.Controls.PlaceholderTextBox textBox)
        {
            // Certifica propriedades básicas para ser clicável
            btn.BackColor = Color.FromArgb(60, 62, 80);
            btn.SizeMode = PictureBoxSizeMode.CenterImage;
            btn.Cursor = Cursors.Hand;
            btn.Enabled = true;
            btn.TabStop = false;
            btn.Visible = true;
            btn.BringToFront();

            // Garante que o campo de senha esteja oculto inicialmente
            SetPasswordHiddenState(textBox, true);

            // Cria e define a imagem do olho (estado inicial = oculto)
            btn.Image = CreateEyeBitmap(btn.Width > 0 ? btn.Width : 24, btn.Height > 0 ? btn.Height : 24, true);

            // Ao clicar, alterna
            btn.Click += (s, e) =>
            {
                TogglePasswordVisibility(btn, textBox);
            };

            // Também atualiza a imagem caso o tamanho mude em tempo de execução
            btn.Resize += (s, e) =>
            {
                // recria a imagem com novo tamanho mantendo o estado atual
                bool hidden = IsPasswordHidden(textBox);
                btn.Image?.Dispose();
                btn.Image = CreateEyeBitmap(btn.Width > 0 ? btn.Width : 24, btn.Height > 0 ? btn.Height : 24, hidden);
            };
        }

        /// <summary>
        /// Cria um Bitmap simples com um "ícone" de olho desenhado (persistente).
        /// </summary>
        private Bitmap CreateEyeBitmap(int width, int height, bool passwordHidden)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(60, 62, 80));
                // Ajuste de qualidade
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Tenta uma fonte emoji (se disponível), cai para Arial se não houver
                Font font;
                try
                {
                    font = new Font("Segoe UI Emoji", Math.Max(8, Math.Min(width, height) / 2), FontStyle.Regular);
                }
                catch
                {
                    font = new Font("Arial", Math.Max(8, Math.Min(width, height) / 2), FontStyle.Bold);
                }

                using (var brush = new SolidBrush(Color.White))
                {
                    // Desenha um emoji ou um olho simples (dependendo da fonte)
                    string eyeChar = "👁"; // deve funcionar na maioria dos sistemas
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(eyeChar, font, brush, new RectangleF(0, 0, width, height), sf);

                    // Se quiser diferenciar visual quando visível vs oculto, desenha um retângulo de destaque
                    if (!passwordHidden)
                    {
                        // leve destaque ao redor quando estiver visível
                        using (var pen = new Pen(Color.FromArgb(180, 200, 220)))
                        {
                            g.DrawRectangle(pen, 1, 1, width - 3, height - 3);
                        }
                    }
                }
                font.Dispose();
            }
            return bmp;
        }

        /// <summary>
        /// Alterna a visibilidade da senha no PlaceholderTextBox.
        /// Lida com PasswordChar e UseSystemPasswordChar (se existir).
        /// </summary>
        private void TogglePasswordVisibility(PictureBox btn, telebip_erp.Controls.PlaceholderTextBox textBox)
        {
            bool currentlyHidden = IsPasswordHidden(textBox);

            // Alterna o estado
            SetPasswordHiddenState(textBox, !currentlyHidden);

            // Atualiza a imagem do botão
            btn.Image?.Dispose();
            btn.Image = CreateEyeBitmap(btn.Width > 0 ? btn.Width : 24, btn.Height > 0 ? btn.Height : 24, !currentlyHidden);
        }

        /// <summary>
        /// Retorna true se a senha está oculta no controle (tenta detectar via propriedades comuns).
        /// </summary>
        private bool IsPasswordHidden(telebip_erp.Controls.PlaceholderTextBox textBox)
        {
            // Primeiro tenta UseSystemPasswordChar
            var type = textBox.GetType();
            var propUse = type.GetProperty("UseSystemPasswordChar");
            if (propUse != null && propUse.PropertyType == typeof(bool))
            {
                return (bool)propUse.GetValue(textBox)!;
            }

            // Depois tenta PasswordChar
            var propPass = type.GetProperty("PasswordChar");
            if (propPass != null && propPass.PropertyType == typeof(char))
            {
                char c = (char)propPass.GetValue(textBox)!;
                return c != '\0';
            }

            // Se não encontrar, assume que está oculto por padrão (mais seguro)
            return true;
        }

        /// <summary>
        /// Define o estado de oculto/visível no PlaceholderTextBox.
        /// </summary>
        private void SetPasswordHiddenState(telebip_erp.Controls.PlaceholderTextBox textBox, bool hide)
        {
            var type = textBox.GetType();

            var propUse = type.GetProperty("UseSystemPasswordChar");
            if (propUse != null && propUse.PropertyType == typeof(bool))
            {
                propUse.SetValue(textBox, hide);
                return;
            }

            var propPass = type.GetProperty("PasswordChar");
            if (propPass != null && propPass.PropertyType == typeof(char))
            {
                propPass.SetValue(textBox, hide ? (object)'●' : (object)'\0');
                return;
            }

            // Caso o controle não tenha essas propriedades (raro), tenta usar reflection para campo privado:
            var field = type.GetField("_passwordChar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(textBox, hide ? (object)'●' : (object)'\0');
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