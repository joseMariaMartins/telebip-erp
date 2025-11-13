using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CuoreUI.Controls;

namespace telebip_erp.Forms.Modules
{
    partial class FormConfiguracoes
    {
        private IContainer components = null;

        #region Designer

        private Panel pnlRoot;
        private Panel pnlHeader;
        private Label lblTitulo;

        private TableLayoutPanel tblMain;
        private Panel pnlLeft;
        private Panel pnlRight;

        // Left controls
        private GroupBox grpEmail;
        private Label lblEmail;
        private TextBox tbEmail;
        private Label lblEmailHelp;
        private Label lblExemplos;

        private GroupBox grpSenha;
        private cuiButton btnGerente;
        private cuiButton btnFuncionario;

        // Right controls
        private GroupBox grpBackup;
        private Label lblBackupTitle;
        private Label lbUltimoBackup;
        private Label lbPastaBackup;
        private cuiButton btnBackup;
        private cuiButton btnRestaurarBackup;

        private cuiButton btnConfirmar;

        private Label lbSuporte;
        private LinkLabel lnkSuporte;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlRoot = new Panel();
            tblMain = new TableLayoutPanel();
            pnlLeft = new Panel();
            grpEmail = new GroupBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblEmailHelp = new Label();
            lblExemplos = new Label();
            grpSenha = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnGerente = new cuiButton();
            btnFuncionario = new cuiButton();
            pnlRight = new Panel();
            grpBackup = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnBackup = new cuiButton();
            btnRestaurarBackup = new cuiButton();
            lblBackupTitle = new Label();
            lbUltimoBackup = new Label();
            lbPastaBackup = new Label();
            lbSuporte = new Label();
            lnkSuporte = new LinkLabel();
            btnConfirmar = new cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlRoot.SuspendLayout();
            tblMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpEmail.SuspendLayout();
            grpSenha.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlRight.SuspendLayout();
            grpBackup.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoot
            // 
            pnlRoot.BackColor = Color.FromArgb(28, 29, 40);
            pnlRoot.Controls.Add(tblMain);
            pnlRoot.Controls.Add(pnlHeader);
            pnlRoot.Dock = DockStyle.Fill;
            pnlRoot.Location = new Point(3, 0);
            pnlRoot.Name = "pnlRoot";
            pnlRoot.Padding = new Padding(12);
            pnlRoot.Size = new Size(1365, 797);
            pnlRoot.TabIndex = 0;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblMain.Controls.Add(pnlLeft, 0, 0);
            tblMain.Controls.Add(pnlRight, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(12, 84);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(8);
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1341, 701);
            tblMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(28, 29, 40);
            pnlLeft.Controls.Add(grpEmail);
            pnlLeft.Controls.Add(grpSenha);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(11, 11);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(8);
            pnlLeft.Size = new Size(855, 679);
            pnlLeft.TabIndex = 0;
            // 
            // grpEmail
            // 
            grpEmail.BackColor = Color.FromArgb(28, 29, 40);
            grpEmail.Controls.Add(lblEmail);
            grpEmail.Controls.Add(lbSuporte);
            grpEmail.Controls.Add(tbEmail);
            grpEmail.Controls.Add(lnkSuporte);
            grpEmail.Controls.Add(lblEmailHelp);
            grpEmail.Controls.Add(lblExemplos);
            grpEmail.Dock = DockStyle.Top;
            grpEmail.ForeColor = Color.White;
            grpEmail.Location = new Point(8, 128);
            grpEmail.Name = "grpEmail";
            grpEmail.Size = new Size(839, 198);
            grpEmail.TabIndex = 0;
            grpEmail.TabStop = false;
            grpEmail.Text = "Configuração de E-mail";
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.WhiteSmoke;
            lblEmail.Location = new Point(12, 22);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "E-mail de envio (SMTP)";
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.FromArgb(40, 41, 52);
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.ForeColor = Color.White;
            tbEmail.Location = new Point(12, 45);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(400, 23);
            tbEmail.TabIndex = 1;
            // 
            // lblEmailHelp
            // 
            lblEmailHelp.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblEmailHelp.ForeColor = Color.LightGray;
            lblEmailHelp.Location = new Point(12, 75);
            lblEmailHelp.Name = "lblEmailHelp";
            lblEmailHelp.Size = new Size(400, 18);
            lblEmailHelp.TabIndex = 2;
            lblEmailHelp.Text = "E-mail usado para notificações e recuperação.";
            // 
            // lblExemplos
            // 
            lblExemplos.Font = new Font("Segoe UI", 9F);
            lblExemplos.ForeColor = Color.Gainsboro;
            lblExemplos.Location = new Point(12, 110);
            lblExemplos.Name = "lblExemplos";
            lblExemplos.Size = new Size(400, 60);
            lblExemplos.TabIndex = 3;
            lblExemplos.Text = "Exemplos:\n• Gmail: usuario@gmail.com\n• Outlook: usuario@empresa.com\nDica: prefira um e-mail dedicado.";
            // 
            // grpSenha
            // 
            grpSenha.BackColor = Color.FromArgb(28, 29, 40);
            grpSenha.Controls.Add(tableLayoutPanel1);
            grpSenha.Dock = DockStyle.Top;
            grpSenha.ForeColor = Color.White;
            grpSenha.Location = new Point(8, 8);
            grpSenha.Name = "grpSenha";
            grpSenha.Size = new Size(839, 120);
            grpSenha.TabIndex = 1;
            grpSenha.TabStop = false;
            grpSenha.Text = "Alteração de Senha";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnGerente, 0, 0);
            tableLayoutPanel1.Controls.Add(btnFuncionario, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(6, 20, 6, 20);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(833, 98);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGerente
            // 
            btnGerente.CheckButton = false;
            btnGerente.Checked = false;
            btnGerente.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGerente.CheckedForeColor = Color.White;
            btnGerente.CheckedImageTint = Color.White;
            btnGerente.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGerente.Content = "Alterar senha (Gerente)";
            btnGerente.DialogResult = DialogResult.None;
            btnGerente.Dock = DockStyle.Fill;
            btnGerente.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnGerente.ForeColor = Color.White;
            btnGerente.HoverBackground = Color.White;
            btnGerente.HoverForeColor = Color.Black;
            btnGerente.HoverImageTint = Color.White;
            btnGerente.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGerente.Image = null;
            btnGerente.ImageAutoCenter = true;
            btnGerente.ImageExpand = new Point(0, 0);
            btnGerente.ImageOffset = new Point(0, 0);
            btnGerente.Location = new Point(12, 26);
            btnGerente.Margin = new Padding(6);
            btnGerente.Name = "btnGerente";
            btnGerente.NormalBackground = Color.FromArgb(40, 41, 52);
            btnGerente.NormalForeColor = Color.White;
            btnGerente.NormalImageTint = Color.White;
            btnGerente.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerente.OutlineThickness = 1F;
            btnGerente.PressedBackground = Color.WhiteSmoke;
            btnGerente.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnGerente.PressedImageTint = Color.White;
            btnGerente.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerente.Rounding = new Padding(6);
            btnGerente.Size = new Size(398, 46);
            btnGerente.TabIndex = 0;
            btnGerente.TextAlignment = StringAlignment.Center;
            btnGerente.TextOffset = new Point(0, 0);
            // 
            // btnFuncionario
            // 
            btnFuncionario.CheckButton = false;
            btnFuncionario.Checked = false;
            btnFuncionario.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnFuncionario.CheckedForeColor = Color.White;
            btnFuncionario.CheckedImageTint = Color.White;
            btnFuncionario.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnFuncionario.Content = "Alterar senha (Funcionário)";
            btnFuncionario.DialogResult = DialogResult.None;
            btnFuncionario.Dock = DockStyle.Fill;
            btnFuncionario.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnFuncionario.ForeColor = Color.White;
            btnFuncionario.HoverBackground = Color.White;
            btnFuncionario.HoverForeColor = Color.Black;
            btnFuncionario.HoverImageTint = Color.White;
            btnFuncionario.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFuncionario.Image = null;
            btnFuncionario.ImageAutoCenter = true;
            btnFuncionario.ImageExpand = new Point(0, 0);
            btnFuncionario.ImageOffset = new Point(0, 0);
            btnFuncionario.Location = new Point(422, 26);
            btnFuncionario.Margin = new Padding(6);
            btnFuncionario.Name = "btnFuncionario";
            btnFuncionario.NormalBackground = Color.FromArgb(40, 41, 52);
            btnFuncionario.NormalForeColor = Color.White;
            btnFuncionario.NormalImageTint = Color.White;
            btnFuncionario.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnFuncionario.OutlineThickness = 1F;
            btnFuncionario.Padding = new Padding(40);
            btnFuncionario.PressedBackground = Color.WhiteSmoke;
            btnFuncionario.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnFuncionario.PressedImageTint = Color.White;
            btnFuncionario.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFuncionario.Rounding = new Padding(6);
            btnFuncionario.Size = new Size(399, 46);
            btnFuncionario.TabIndex = 1;
            btnFuncionario.TextAlignment = StringAlignment.Center;
            btnFuncionario.TextOffset = new Point(0, 0);
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(28, 29, 40);
            pnlRight.Controls.Add(grpBackup);
            pnlRight.Controls.Add(btnConfirmar);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(872, 11);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(8);
            pnlRight.Size = new Size(458, 679);
            pnlRight.TabIndex = 1;
            // 
            // grpBackup
            // 
            grpBackup.BackColor = Color.FromArgb(28, 29, 40);
            grpBackup.Controls.Add(tableLayoutPanel2);
            grpBackup.Controls.Add(lblBackupTitle);
            grpBackup.Controls.Add(lbUltimoBackup);
            grpBackup.Controls.Add(lbPastaBackup);
            grpBackup.Dock = DockStyle.Top;
            grpBackup.ForeColor = Color.White;
            grpBackup.Location = new Point(8, 8);
            grpBackup.Name = "grpBackup";
            grpBackup.Size = new Size(442, 165);
            grpBackup.TabIndex = 0;
            grpBackup.TabStop = false;
            grpBackup.Text = "Backup & Restauração";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnBackup, 0, 0);
            tableLayoutPanel2.Controls.Add(btnRestaurarBackup, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(3, 96);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 8, 0, 3);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(436, 66);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // btnBackup
            // 
            btnBackup.CheckButton = false;
            btnBackup.Checked = false;
            btnBackup.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnBackup.CheckedForeColor = Color.White;
            btnBackup.CheckedImageTint = Color.White;
            btnBackup.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnBackup.Content = "Fazer Backup";
            btnBackup.DialogResult = DialogResult.None;
            btnBackup.Dock = DockStyle.Fill;
            btnBackup.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnBackup.ForeColor = Color.White;
            btnBackup.HoverBackground = Color.White;
            btnBackup.HoverForeColor = Color.Black;
            btnBackup.HoverImageTint = Color.White;
            btnBackup.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnBackup.Image = null;
            btnBackup.ImageAutoCenter = true;
            btnBackup.ImageExpand = new Point(0, 0);
            btnBackup.ImageOffset = new Point(0, 0);
            btnBackup.Location = new Point(6, 14);
            btnBackup.Margin = new Padding(6);
            btnBackup.Name = "btnBackup";
            btnBackup.NormalBackground = Color.FromArgb(40, 120, 80);
            btnBackup.NormalForeColor = Color.White;
            btnBackup.NormalImageTint = Color.White;
            btnBackup.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnBackup.OutlineThickness = 1F;
            btnBackup.PressedBackground = Color.WhiteSmoke;
            btnBackup.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnBackup.PressedImageTint = Color.White;
            btnBackup.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnBackup.Rounding = new Padding(6);
            btnBackup.Size = new Size(206, 43);
            btnBackup.TabIndex = 0;
            btnBackup.TextAlignment = StringAlignment.Center;
            btnBackup.TextOffset = new Point(0, 0);
            // 
            // btnRestaurarBackup
            // 
            btnRestaurarBackup.CheckButton = false;
            btnRestaurarBackup.Checked = false;
            btnRestaurarBackup.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnRestaurarBackup.CheckedForeColor = Color.White;
            btnRestaurarBackup.CheckedImageTint = Color.White;
            btnRestaurarBackup.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnRestaurarBackup.Content = "Restaurar Backup";
            btnRestaurarBackup.DialogResult = DialogResult.None;
            btnRestaurarBackup.Dock = DockStyle.Fill;
            btnRestaurarBackup.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnRestaurarBackup.ForeColor = Color.White;
            btnRestaurarBackup.HoverBackground = Color.White;
            btnRestaurarBackup.HoverForeColor = Color.Black;
            btnRestaurarBackup.HoverImageTint = Color.White;
            btnRestaurarBackup.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnRestaurarBackup.Image = null;
            btnRestaurarBackup.ImageAutoCenter = true;
            btnRestaurarBackup.ImageExpand = new Point(0, 0);
            btnRestaurarBackup.ImageOffset = new Point(0, 0);
            btnRestaurarBackup.Location = new Point(224, 14);
            btnRestaurarBackup.Margin = new Padding(6);
            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.NormalBackground = Color.FromArgb(200, 80, 50);
            btnRestaurarBackup.NormalForeColor = Color.White;
            btnRestaurarBackup.NormalImageTint = Color.White;
            btnRestaurarBackup.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnRestaurarBackup.OutlineThickness = 1F;
            btnRestaurarBackup.PressedBackground = Color.WhiteSmoke;
            btnRestaurarBackup.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnRestaurarBackup.PressedImageTint = Color.White;
            btnRestaurarBackup.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnRestaurarBackup.Rounding = new Padding(6);
            btnRestaurarBackup.Size = new Size(206, 43);
            btnRestaurarBackup.TabIndex = 1;
            btnRestaurarBackup.TextAlignment = StringAlignment.Center;
            btnRestaurarBackup.TextOffset = new Point(0, 0);
            // 
            // lblBackupTitle
            // 
            lblBackupTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBackupTitle.ForeColor = Color.White;
            lblBackupTitle.Location = new Point(12, 22);
            lblBackupTitle.Name = "lblBackupTitle";
            lblBackupTitle.Size = new Size(100, 23);
            lblBackupTitle.TabIndex = 0;
            lblBackupTitle.Text = "Backup & Restauração";
            // 
            // lbUltimoBackup
            // 
            lbUltimoBackup.ForeColor = Color.Gainsboro;
            lbUltimoBackup.Location = new Point(12, 50);
            lbUltimoBackup.Name = "lbUltimoBackup";
            lbUltimoBackup.Size = new Size(100, 23);
            lbUltimoBackup.TabIndex = 1;
            lbUltimoBackup.Text = "Último backup: —";
            // 
            // lbPastaBackup
            // 
            lbPastaBackup.ForeColor = Color.Gainsboro;
            lbPastaBackup.Location = new Point(12, 70);
            lbPastaBackup.Name = "lbPastaBackup";
            lbPastaBackup.Size = new Size(100, 23);
            lbPastaBackup.TabIndex = 2;
            lbPastaBackup.Text = "Pasta padrão: —";
            // 
            // lbSuporte
            // 
            lbSuporte.ForeColor = Color.Gainsboro;
            lbSuporte.Location = new Point(12, 172);
            lbSuporte.Name = "lbSuporte";
            lbSuporte.Size = new Size(53, 23);
            lbSuporte.TabIndex = 1;
            lbSuporte.Text = "Suporte:";
            // 
            // lnkSuporte
            // 
            lnkSuporte.LinkColor = Color.LightSkyBlue;
            lnkSuporte.Location = new Point(62, 172);
            lnkSuporte.Name = "lnkSuporte";
            lnkSuporte.Size = new Size(125, 23);
            lnkSuporte.TabIndex = 2;
            lnkSuporte.TabStop = true;
            lnkSuporte.Text = "suporte@telebip.com";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.CheckButton = false;
            btnConfirmar.Checked = false;
            btnConfirmar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnConfirmar.CheckedForeColor = Color.White;
            btnConfirmar.CheckedImageTint = Color.White;
            btnConfirmar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnConfirmar.Content = "Salvar";
            btnConfirmar.DialogResult = DialogResult.None;
            btnConfirmar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverBackground = Color.White;
            btnConfirmar.HoverForeColor = Color.Black;
            btnConfirmar.HoverImageTint = Color.White;
            btnConfirmar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnConfirmar.Image = null;
            btnConfirmar.ImageAutoCenter = true;
            btnConfirmar.ImageExpand = new Point(0, 0);
            btnConfirmar.ImageOffset = new Point(0, 0);
            btnConfirmar.Location = new Point(368, 999);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnConfirmar.NormalForeColor = Color.White;
            btnConfirmar.NormalImageTint = Color.White;
            btnConfirmar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.OutlineThickness = 1F;
            btnConfirmar.PressedBackground = Color.WhiteSmoke;
            btnConfirmar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnConfirmar.PressedImageTint = Color.White;
            btnConfirmar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.Rounding = new Padding(6);
            btnConfirmar.Size = new Size(160, 44);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(28, 29, 40);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(12, 12);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12);
            pnlHeader.Size = new Size(1341, 72);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(12, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1317, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configurações";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormConfiguracoes
            // 
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1371, 800);
            Controls.Add(pnlRoot);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormStyle = FormStyles.StatusAndActionBar_None;
            MinimumSize = new Size(900, 700);
            Name = "FormConfiguracoes";
            Padding = new Padding(3, 0, 3, 3);
            Text = "Configurações";
            pnlRoot.ResumeLayout(false);
            tblMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            grpEmail.ResumeLayout(false);
            grpEmail.PerformLayout();
            grpSenha.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            grpBackup.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
