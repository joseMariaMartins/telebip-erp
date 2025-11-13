using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.Auth
{
    public partial class FormRecuperacaoSenha : MaterialForm
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

            // ---------------------------
            // Tenta localizar o panel "wrapper" do tbId de forma segura:
            // sobe na hierarquia a partir de tbId até encontrar um Panel cujo nome
            // contenha "wrapper" ou comece com "pnl".
            // ---------------------------
            try
            {
                Panel wrapper = FindWrapperPanelFromControl(tbId);
                if (wrapper != null)
                {
                    // aplica estilo arredondado e comportamento de foco
                    StyleTextboxWrapperPanel(wrapper, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

                    // avisa visualmente quando o textbox ganhar/perder foco
                    tbId.GotFocus += (s, e) => SetWrapperFocused(wrapper, true);
                    tbId.LostFocus += (s, e) => SetWrapperFocused(wrapper, false);

                    // estado inicial
                    SetWrapperFocused(wrapper, false);

                    // garante redraw após load (evita Width=0 em design-time)
                    this.Load += (s, e) => { try { wrapper.Invalidate(); } catch { } };
                }
            }
            catch
            {
                // silencioso — não queremos quebrar a lógica principal se algo falhar aqui
            }
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

        // ==========================
        // Helpers visuais: bordas arredondadas e foco
        // ==========================
        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(0, radius * 2);
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            if (wrapper == null) return;
            wrapper.BackColor = fill;
            wrapper.Tag = border; // guardamos a cor da borda no Tag para o paint handler
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;
            wrapper.Resize -= (s, e) => wrapper.Invalidate();
            wrapper.Resize += (s, e) => wrapper.Invalidate();
        }

        private void Wrapper_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Panel wrapper)) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
            using (var path = GetRoundedRect(rect, 8))
            using (var pen = new Pen((Color)wrapper.Tag, 1))
            {
                // preencher fundo com a cor do wrapper para evitar artefatos
                using (var fillBrush = new SolidBrush(wrapper.BackColor))
                    e.Graphics.FillPath(fillBrush, path);

                e.Graphics.DrawPath(pen, path);
            }
        }

        private void SetWrapperFocused(Panel wrapper, bool focused)
        {
            if (wrapper == null) return;
            Color active = Color.FromArgb(100, 150, 255);
            Color normal = Color.FromArgb(60, 62, 80);
            wrapper.Tag = focused ? active : normal;
            try { wrapper.Invalidate(); } catch { }
        }

        // ----------------------------
        // Procura um Panel "wrapper" subindo na hierarquia a partir de um controle
        // ----------------------------
        private Panel FindWrapperPanelFromControl(Control start)
        {
            if (start == null) return null;

            Control current = start.Parent;
            while (current != null)
            {
                // prefer panels com nomes que indiquem wrapper/pnl
                if (current is Panel p)
                {
                    string name = (p.Name ?? "").ToLowerInvariant();
                    if (name.Contains("wrapper") || name.StartsWith("pnl") || name.Contains("panel"))
                        return p;
                }
                current = current.Parent;
            }

            // se não encontrou nada significativo, tenta retornar o immediate parent (se panel)
            return start.Parent as Panel;
        }
    }
}
