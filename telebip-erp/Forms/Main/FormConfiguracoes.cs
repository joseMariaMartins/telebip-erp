using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using telebip_erp.Forms.SubForms;
using telebip_erp.Forms.Main;
using System.Collections.Generic;
using System.Data.SQLite;

namespace telebip_erp.Forms.Modules
{
    public partial class FormConfiguracoes : Form
    {
        private readonly string caminhoBanco = Path.Combine(Application.StartupPath, "Database", "TeleBipDB.db");

        private string ultimaPastaBackup = "";
        private string emailAtual = "";

        // Cue banner (placeholder compatível Win32)
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public FormConfiguracoes()
        {
            InitializeComponent();

            // carregar settings iniciais (se existir)
            ultimaPastaBackup = ConfigHelper.GetSetting("UltimaPastaBackup") ?? "";
            emailAtual = ConfigHelper.GetSetting("EmailRecuperacao") ?? "";

            tbEmail.Text = emailAtual;

            // Eventos: backup / restore
            if (btnBackup != null) btnBackup.Click += BtnBackup_Click;
            if (btnRestaurarBackup != null) btnRestaurarBackup.Click += BtnRestaurarBackup_Click;

            // Suporte: label e link
            if (lbSuporte != null) lbSuporte.Click += LbSuporte_Click;
            if (lnkSuporte != null) lnkSuporte.LinkClicked += LnkSuporte_LinkClicked;

            // Apenas o botão "Alterar e-mail de envio" fará a confirmação/salvamento
            if (btnAlterarEmail != null) btnAlterarEmail.Click += BtnAlterarEmail_Click;

            // Alteração de senha
            if (btnGerente != null) btnGerente.Click += BtnGerente_Click;
            if (btnFuncionario != null) btnFuncionario.Click += BtnFuncionario_Click;

            // Enter no campo de e-mail confirma também
            if (tbEmail != null) tbEmail.KeyDown += TbEmail_KeyDown;

            // Botão de logout
            if (btnLogout != null) btnLogout.Click += BtnLogout_Click;

            // Ao carregar, aplicar placeholder compatível
            Load += FormConfiguracoes_Load;
        }

        private void FormConfiguracoes_Load(object sender, EventArgs e)
        {
            // aplica cue banner (placeholder) de fallback para .NET Framework/Win32
            try
            {
                if (tbEmail != null)
                    SetCueBanner(tbEmail, "seu-email@empresa.com");
            }
            catch
            {
                // ignore se não funcionar no runtime atual
            }

            // Atualizar informações de backup
            AtualizarInfoBackup();
        }

        private void AtualizarInfoBackup()
        {
            try
            {
                if (lbUltimoBackup != null)
                {
                    string ultimoBackup = ConfigHelper.GetSetting("UltimoBackupData") ?? "—";
                    lbUltimoBackup.Text = $"Último backup: {ultimoBackup}";
                }

                if (lbPastaBackup != null)
                {
                    string pasta = ConfigHelper.GetSetting("UltimaPastaBackup") ?? "—";
                    if (pasta.Length > 50)
                        pasta = "..." + pasta.Substring(pasta.Length - 47);
                    lbPastaBackup.Text = $"Pasta padrão: {pasta}";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao atualizar info backup: {ex.Message}");
            }
        }

        private void SetCueBanner(TextBox tb, string cueText)
        {
            try
            {
                if (tb == null) return;
                // wParam = 1 -> mostrar mesmo quando o controle tem foco (ajuste se preferir 0)
                SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, cueText);
            }
            catch
            {
                // ambiente não suportado: silêncio
            }
        }

        // ==========================
        // VALIDAÇÃO DE EMAIL
        // ==========================
        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex que aceita subdomínios e TLDs modernos
            string padrao = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, padrao);
        }

        private void ConfirmarEmail()
        {
            if (tbEmail == null) return;

            string novoEmail = tbEmail.Text.Trim();

            if (!EmailValido(novoEmail))
            {
                MessageBox.Show("Por favor, insira um e-mail válido.",
                    "E-mail inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            if (novoEmail.Equals(emailAtual, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("O e-mail informado já está salvo.",
                    "Nenhuma alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nenhum e-mail anterior → salva direto
            if (string.IsNullOrWhiteSpace(emailAtual))
            {
                ConfigHelper.SetSetting("EmailRecuperacao", novoEmail);
                emailAtual = novoEmail;

                MessageBox.Show("E-mail de recuperação salvo com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Já existe um e-mail anterior → pede confirmação
            DialogResult result = MessageBox.Show(
                $"Deseja realmente alterar o e-mail de recuperação?\n\nDe: {emailAtual}\nPara: {novoEmail}",
                "Confirmar alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ConfigHelper.SetSetting("EmailRecuperacao", novoEmail);
                emailAtual = novoEmail;

                MessageBox.Show("E-mail de recuperação atualizado com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // reverte texto visual para o atual salvo
                tbEmail.Text = emailAtual;
            }
        }

        // Handler ligado ao btnAlterarEmail no construtor
        private void BtnAlterarEmail_Click(object sender, EventArgs e)
        {
            ConfirmarEmail();
        }

        // Permite confirmar com Enter no campo
        private void TbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarEmail();
                e.SuppressKeyPress = true;
            }
        }

        // ==========================
        // BACKUP
        // ==========================
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(caminhoBanco))
                {
                    MessageBox.Show("O arquivo do banco de dados não foi encontrado.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Selecione a pasta onde o backup será salvo";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;

                        ultimaPastaBackup = dialog.SelectedPath;
                        string nomeArquivo = $"TeleBipDB_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db";
                        string caminhoDestino = Path.Combine(ultimaPastaBackup, nomeArquivo);

                        File.Copy(caminhoBanco, caminhoDestino, true);

                        // Salvar configurações
                        ConfigHelper.SetSetting("UltimaPastaBackup", ultimaPastaBackup);
                        ConfigHelper.SetSetting("UltimoBackupData", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                        // Atualizar display
                        AtualizarInfoBackup();

                        MessageBox.Show($"Backup criado com sucesso em:\n{caminhoDestino}",
                            "Backup Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar o backup:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ==========================
        // RESTAURAR BACKUP
        // ==========================
        private void BtnRestaurarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Selecione o arquivo de backup do banco de dados";
                    dialog.Filter = "Database File (*.db)|*.db";
                    dialog.InitialDirectory = string.IsNullOrEmpty(ultimaPastaBackup)
                        ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        : ultimaPastaBackup;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string caminhoBackup = dialog.FileName;

                        DialogResult result = MessageBox.Show(
                            "Tem certeza que deseja restaurar este backup? Isso substituirá o banco de dados atual.",
                            "Confirmar Restauração",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            Cursor = Cursors.WaitCursor;

                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Copy(caminhoBackup, caminhoBanco, true);

                            MessageBox.Show("Backup restaurado com sucesso! O sistema será reiniciado.",
                                "Restauração Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reiniciar aplicação após restore
                            Application.Restart();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao restaurar backup:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ==========================
        // SUPORTE (ABRIR GMAIL)
        // ==========================
        private void LbSuporte_Click(object sender, EventArgs e)
        {
            OpenGmailSupportWindow();
        }

        private void LnkSuporte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenGmailSupportWindow();
        }

        private void OpenGmailSupportWindow()
        {
            try
            {
                string emailSuporte = "suporte@telebip.com";
                string assunto = Uri.EscapeDataString("Suporte - TeleBip ERP");
                string corpo = Uri.EscapeDataString("Olá equipe de suporte,\n\nDescreva seu problema aqui...");

                string url = $"https://mail.google.com/mail/?view=cm&fs=1&to={emailSuporte}&su={assunto}&body={corpo}";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Não foi possível abrir o Gmail. Verifique sua conexão ou navegador padrão.",
                    "Erro ao abrir suporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // ALTERAÇÃO DE SENHA
        // ==========================
        private void BtnGerente_Click(object sender, EventArgs e)
        {
            // Opcional: permitir só se for gerente logado
            if (Session.NivelAcesso == 0)
            {
                MessageBox.Show("Apenas o gerente pode alterar esta senha.",
                    "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formSenha = new FormAlteracaoSenhaGerente
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formSenha.ShowDialog();
        }

        private void BtnFuncionario_Click(object sender, EventArgs e)
        {
            var formSenhaFuncionario = new FormAlteracaoSenhaFuncionario
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formSenhaFuncionario.ShowDialog();
        }

        // ==========================
        // LOGOUT DO SISTEMA
        // ==========================
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja sair do sistema?\n\nVocê será redirecionado para a tela de login.",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Yes)
                {
                    FazerLogout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fazer logout: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FazerLogout()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // 1. Limpar a sessão atual
                LimparSessao();

                // 2. Fechar todas as forms exceto esta
                FecharTodasFormsExcetoEsta();

                // 3. Criar e mostrar o formulário de login
                var loginForm = new telebip_erp.Forms.Auth.FormLogin();
                loginForm.Show();

                // 4. Fechar esta form de configurações
                this.Close();

            }
            catch (Exception ex)
            {
                // Fallback: reiniciar a aplicação se algo der errado
                MessageBox.Show($"Reiniciando aplicação...\n{ex.Message}",
                    "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LimparSessao()
        {
            try
            {
                // Limpar os dados da sessão
                Session.NivelAcesso = 0;

                // Se você tiver outras propriedades na Session, limpe-as também
                // Session.UsuarioLogado = null;
                // Session.EmailUsuario = null;
                // Session.NomeUsuario = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao limpar sessão: {ex.Message}");
            }
        }

        private void FecharTodasFormsExcetoEsta()
        {
            try
            {
                // Criar uma lista das forms para fechar (evita modificar a coleção durante iteração)
                var formsParaFechar = new List<Form>();

                foreach (Form form in Application.OpenForms)
                {
                    // Não fechar esta form nem forms de login
                    if (form != this &&
                        form.Name != "FormLogin" &&
                        !form.Name.Contains("Login") &&
                        !form.Name.Contains("Auth"))
                    {
                        formsParaFechar.Add(form);
                    }
                }

                // Fechar as forms coletadas
                foreach (Form form in formsParaFechar)
                {
                    try
                    {
                        form.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Erro ao fechar form {form.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao fechar forms: {ex.Message}");
            }
        }
    }
}