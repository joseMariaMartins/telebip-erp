using System;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telebip_erp.Forms.Auth
{
    public partial class FormRecuperacaoSenha : Form
    {
        private const string RemetenteSuporte = "telebip.suporte@gmail.com";

        public FormRecuperacaoSenha()
        {
            InitializeComponent();

            tbId.KeyPress += TbId_KeyPress;
            tbId.TextChanged += TbId_TextChanged;
            tbId.KeyDown += TbId_KeyDown;

            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        // ==========================
        // ACEITA APENAS NÚMEROS
        // ==========================
        private void TbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TbId_TextChanged(object sender, EventArgs e)
        {
            string apenasNumeros = System.Text.RegularExpressions.Regex.Replace(tbId.Text, "[^0-9]", "");
            if (tbId.Text != apenasNumeros)
            {
                int pos = tbId.SelectionStart - (tbId.Text.Length - apenasNumeros.Length);
                tbId.Text = apenasNumeros;
                tbId.SelectionStart = Math.Max(0, pos);
            }
        }

        private void TbId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnConfirmar_Click(btnConfirmar, EventArgs.Empty);
            }
        }

        // ==========================
        // BOTÃO CONFIRMAR
        // ==========================
        private async void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string idUsuario = tbId.Text.Trim();

            if (string.IsNullOrWhiteSpace(idUsuario))
            {
                MessageBox.Show("Por favor, insira o ID do usuário (login numérico).",
                    "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "SELECT NIVEL_ACESSO FROM USUARIO WHERE LOGIN = @login";
                var param = new SQLiteParameter[]
                {
                    new SQLiteParameter("@login", idUsuario)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, param);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuário não encontrado. Verifique o ID digitado.",
                        "Usuário inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int nivel = Convert.ToInt32(dt.Rows[0]["NIVEL_ACESSO"]);
                string emailConfigurado = ConfigHelper.GetSetting("EmailRecuperacao") ?? "";

                if (string.IsNullOrWhiteSpace(emailConfigurado))
                {
                    MessageBox.Show(
                        "Não há e-mail de recuperação cadastrado nas configurações.\n\n" +
                        "Entre em contato com o suporte: telebip.suporte@gmail.com",
                        "Suporte necessário",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // ==========================
                // GERENTE (NÍVEL 1)
                // ==========================
                if (nivel == 1)
                {
                    string novaSenhaPlano = GerarSenhaAleatoria(8);
                    string novaSenhaHash = CryptoHelper.GerarHashSHA256(novaSenhaPlano);

                    // 🕐 Dá uma leve pausa visual
                    await Task.Delay(100);

                    // 🔹 Primeiro tenta enviar o e-mail
                    bool enviado = EnviarEmailRecuperacao(emailConfigurado, novaSenhaPlano);

                    if (enviado)
                    {
                        // Só atualiza o banco se o e-mail for enviado com sucesso
                        string sqlUpdate = "UPDATE USUARIO SET SENHA = @senha WHERE NIVEL_ACESSO = 1 AND LOGIN = @login";
                        var paramUpdate = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@senha", novaSenhaHash),
                            new SQLiteParameter("@login", idUsuario)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlUpdate, paramUpdate);

                        MessageBox.Show(
                            $"Uma nova senha foi enviada para o e-mail:\n\n{emailConfigurado}",
                            "Recuperação de senha do gerente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Erro ao enviar o e-mail de recuperação. Verifique sua conexão com a internet.",
                            "Falha no envio",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "A recuperação de senha de funcionários deve ser feita pelo gerente, " +
                        "na aba de Configurações do sistema.",
                        "Acesso restrito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar recuperar a senha:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // GERAR SENHA ALEATÓRIA
        // ==========================
        private string GerarSenhaAleatoria(int tamanho)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var senha = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
                senha[i] = chars[random.Next(chars.Length)];

            return new string(senha);
        }

        // ==========================
        // ENVIO DE E-MAIL COM SENHA RECUPERADA
        // ==========================
        private bool EnviarEmailRecuperacao(string destino, string novaSenhaPlano)
        {
            try
            {
                string senhaCriptografada = ConfigHelper.GetSetting("SenhaAppGmailCriptografada") ?? "";

                if (string.IsNullOrWhiteSpace(senhaCriptografada))
                {
                    MessageBox.Show("A senha do e-mail de recuperação não está configurada. Contate o suporte.",
                        "Erro de configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string senhaApp = CryptoHelper.DescriptografarAES(senhaCriptografada);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(RemetenteSuporte, "TeleBip ERP - Recuperação");
                    mail.To.Add(destino);
                    mail.Subject = "Recuperação de Senha - TeleBip ERP";
                    mail.Body =
                        "Olá!\n\n" +
                        $"Sua nova senha de acesso é: {novaSenhaPlano}\n\n" +
                        "Por favor, altere-a assim que fizer login (Configurações > Alterar senha).\n\n" +
                        "Atenciosamente,\nEquipe TeleBip.";
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(RemetenteSuporte, senhaApp);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao enviar o e-mail: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
