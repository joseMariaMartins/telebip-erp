using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using telebip_erp.Forms.SubForms; // 👈 pra validar email

namespace telebip_erp.Forms.Modules
{
    public partial class FormConfiguracoes : Form
    {
        // Caminho dinâmico e portátil do banco de dados
        private readonly string caminhoBanco = Path.Combine(
            Application.StartupPath, "Database", "TeleBipDB.db"
        );

        private string ultimaPastaBackup = ""; // guarda o último local do backup
        private string emailAtual = ""; // guarda o e-mail atual salvo

        public FormConfiguracoes()
        {
            InitializeComponent();

            // Carrega o último e-mail e a última pasta salvos no App.config
            ultimaPastaBackup = ConfigHelper.GetSetting("UltimaPastaBackup") ?? "";
            emailAtual = ConfigHelper.GetSetting("EmailRecuperacao") ?? "";

            tbEmail.Text = emailAtual;

            // Eventos
            btnBackup.Click += BtnBackup_Click;
            btnRestaurarBackup.Click += BtnRestaurarBackup_Click;
            lbSuporte.Click += lbSuporte_Click;

            // Adiciona eventos para validação e confirmação
            tbEmail.KeyDown += TbEmail_KeyDown;
            btnConfirmar.Click += BtnConfirmar_Click;
        }

        // ==========================
        // VALIDAÇÃO DE EMAIL
        // ==========================
        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }

        private void ConfirmarEmail()
        {
            string novoEmail = tbEmail.Text.Trim();

            if (!EmailValido(novoEmail))
            {
                MessageBox.Show("Por favor, insira um e-mail válido.",
                    "E-mail inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            // Se o e-mail for o mesmo, não faz nada
            if (novoEmail.Equals(emailAtual, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("O e-mail informado já está salvo.",
                    "Nenhuma alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 👉 Se não há e-mail salvo ainda, salva direto sem perguntar
            if (string.IsNullOrWhiteSpace(emailAtual))
            {
                ConfigHelper.SetSetting("EmailRecuperacao", novoEmail);
                emailAtual = novoEmail;

                MessageBox.Show("E-mail de recuperação salvo com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Se já existe e-mail salvo, pede confirmação
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
                tbEmail.Text = emailAtual; // restaura o antigo
            }
        }


        // Pressionar Enter confirma o e-mail
        private void TbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarEmail();
                e.SuppressKeyPress = true; // evita beep
            }
        }

        // Botão Confirmar também salva o e-mail
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarEmail();
        }

        // ==========================
        // RESTO DO SEU CÓDIGO (BACKUP, RESTAURAR, SUPORTE)
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
                        ultimaPastaBackup = dialog.SelectedPath;
                        string nomeArquivo = $"TeleBipDB_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db";
                        string caminhoDestino = Path.Combine(ultimaPastaBackup, nomeArquivo);

                        File.Copy(caminhoBanco, caminhoDestino, true);

                        MessageBox.Show($"Backup criado com sucesso em:\n{caminhoDestino}",
                            "Backup Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ConfigHelper.SetSetting("UltimaPastaBackup", ultimaPastaBackup);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao criar o backup:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Copy(caminhoBackup, caminhoBanco, true);

                            MessageBox.Show("Backup restaurado com sucesso!",
                                "Restauração Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao restaurar backup:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbSuporte_Click(object sender, EventArgs e)
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

        private void btnGerente_Click(object sender, EventArgs e)
        {
            var formSenha = new FormAlteracaoSenhaGerente();
            formSenha.StartPosition = FormStartPosition.CenterParent;
            formSenha.ShowDialog();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            var FormSenhaFuncionario = new FormAlteracaoSenhaFuncionario();
            FormSenhaFuncionario.StartPosition = FormStartPosition.CenterParent;
            FormSenhaFuncionario.ShowDialog();
        }
    }
}
