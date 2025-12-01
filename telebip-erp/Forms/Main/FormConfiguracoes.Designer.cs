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

        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;
        private TableLayoutPanel tblMain;
        private Panel pnlLeft;
        private Panel pnlRight;

        // Left controls
        private GroupBox grpSenha;
        private TableLayoutPanel tableLayoutPanel1;
        private cuiButton btnGerente;
        private cuiButton btnFuncionario;

        private GroupBox grpEmail;
        private Label lblEmail;
        private TextBox tbEmail;
        private Label lblEmailHelp;
        private telebip_erp.Controls.RoundedPanel roundedPanel1;
        private cuiButton btnAlterarEmail;

        // Right controls
        private GroupBox grpBackup;
        private Label lblBackupTitle;
        private Label lbUltimoBackup;
        private TableLayoutPanel tableLayoutPanel2;
        private cuiButton btnBackup;
        private cuiButton btnRestaurarBackup;

        private GroupBox grpSuporte;
        private Label lbSuporte;
        private LinkLabel lnkSuporte;
        private Label lblSuporteDesc;

        // Bottom controls
        private Panel pnlBottom;
        private cuiButton btnTrocarUsuario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            tblMain = new TableLayoutPanel();
            pnlLeft = new Panel();
            grpEmail = new GroupBox();
            btnAlterarEmail = new cuiButton();
            roundedPanel1 = new telebip_erp.Controls.RoundedPanel();
            tbEmail = new TextBox();
            lblEmail = new Label();
            lblEmailHelp = new Label();
            grpSenha = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnGerente = new cuiButton();
            btnFuncionario = new cuiButton();
            pnlRight = new Panel();
            grpSuporte = new GroupBox();
            lblSuporteDesc = new Label();
            lnkSuporte = new LinkLabel();
            lbSuporte = new Label();
            grpBackup = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnBackup = new cuiButton();
            btnRestaurarBackup = new cuiButton();
            lblBackupTitle = new Label();
            lbUltimoBackup = new Label();
            pnlBottom = new Panel();
            btnTrocarUsuario = new cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            tblMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpEmail.SuspendLayout();
            roundedPanel1.SuspendLayout();
            grpSenha.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlRight.SuspendLayout();
            grpSuporte.SuspendLayout();
            grpBackup.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.AutoScroll = true;
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(tblMain);
            pnlContainer.Controls.Add(pnlBottom);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1400, 644);
            pnlContainer.TabIndex = 0;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblMain.Controls.Add(pnlLeft, 0, 0);
            tblMain.Controls.Add(pnlRight, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 71);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(15, 10, 15, 0);
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1400, 501);
            tblMain.TabIndex = 2;
            // 
            // pnlLeft
            // 
            pnlLeft.AutoScroll = true;
            pnlLeft.BackColor = Color.Transparent;
            pnlLeft.Controls.Add(grpEmail);
            pnlLeft.Controls.Add(grpSenha);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(18, 13);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(0, 0, 15, 0);
            pnlLeft.Size = new Size(816, 485);
            pnlLeft.TabIndex = 0;
            // 
            // grpEmail
            // 
            grpEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEmail.BackColor = Color.FromArgb(35, 36, 48);
            grpEmail.Controls.Add(btnAlterarEmail);
            grpEmail.Controls.Add(roundedPanel1);
            grpEmail.Controls.Add(lblEmail);
            grpEmail.Controls.Add(lblEmailHelp);
            grpEmail.FlatStyle = FlatStyle.Flat;
            grpEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpEmail.ForeColor = Color.White;
            grpEmail.Location = new Point(0, 201);
            grpEmail.Margin = new Padding(0, 0, 0, 20);
            grpEmail.Name = "grpEmail";
            grpEmail.Padding = new Padding(20);
            grpEmail.Size = new Size(801, 245);
            grpEmail.TabIndex = 0;
            grpEmail.TabStop = false;
            grpEmail.Text = "📧 CONFIGURAÇÃO DE E-MAIL";
            // 
            // btnAlterarEmail
            // 
            btnAlterarEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAlterarEmail.CheckButton = false;
            btnAlterarEmail.Checked = false;
            btnAlterarEmail.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnAlterarEmail.CheckedForeColor = Color.White;
            btnAlterarEmail.CheckedImageTint = Color.White;
            btnAlterarEmail.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnAlterarEmail.Content = "Salvar Configurações de E-mail";
            btnAlterarEmail.DialogResult = DialogResult.None;
            btnAlterarEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAlterarEmail.ForeColor = Color.White;
            btnAlterarEmail.HoverBackground = Color.FromArgb(60, 180, 120);
            btnAlterarEmail.HoverForeColor = Color.White;
            btnAlterarEmail.HoverImageTint = Color.White;
            btnAlterarEmail.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnAlterarEmail.Image = null;
            btnAlterarEmail.ImageAutoCenter = true;
            btnAlterarEmail.ImageExpand = new Point(0, 0);
            btnAlterarEmail.ImageOffset = new Point(0, 0);
            btnAlterarEmail.Location = new Point(25, 130);
            btnAlterarEmail.Margin = new Padding(3, 15, 6, 6);
            btnAlterarEmail.Name = "btnAlterarEmail";
            btnAlterarEmail.NormalBackground = Color.FromArgb(40, 120, 80);
            btnAlterarEmail.NormalForeColor = Color.White;
            btnAlterarEmail.NormalImageTint = Color.White;
            btnAlterarEmail.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnAlterarEmail.OutlineThickness = 1F;
            btnAlterarEmail.PressedBackground = Color.FromArgb(30, 100, 70);
            btnAlterarEmail.PressedForeColor = Color.White;
            btnAlterarEmail.PressedImageTint = Color.White;
            btnAlterarEmail.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnAlterarEmail.Rounding = new Padding(10);
            btnAlterarEmail.Size = new Size(750, 45);
            btnAlterarEmail.TabIndex = 5;
            btnAlterarEmail.TextAlignment = StringAlignment.Center;
            btnAlterarEmail.TextOffset = new Point(0, 0);
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.FromArgb(45, 46, 60);
            roundedPanel1.BorderColor = Color.FromArgb(70, 72, 90);
            roundedPanel1.BorderThickness = 2;
            roundedPanel1.Controls.Add(tbEmail);
            roundedPanel1.CornerRadius = 12;
            roundedPanel1.FillColor = Color.FromArgb(45, 46, 60);
            roundedPanel1.Location = new Point(25, 75);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(15, 10, 15, 10);
            roundedPanel1.Size = new Size(750, 44);
            roundedPanel1.TabIndex = 4;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.FromArgb(45, 46, 60);
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Dock = DockStyle.Fill;
            tbEmail.Font = new Font("Segoe UI", 11F);
            tbEmail.ForeColor = Color.White;
            tbEmail.Location = new Point(15, 10);
            tbEmail.Margin = new Padding(0);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(720, 20);
            tbEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEmail.ForeColor = Color.WhiteSmoke;
            lblEmail.Location = new Point(25, 45);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(750, 25);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "E-mail de envio (SMTP)";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmailHelp
            // 
            lblEmailHelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmailHelp.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblEmailHelp.ForeColor = Color.LightGray;
            lblEmailHelp.Location = new Point(25, 180);
            lblEmailHelp.Name = "lblEmailHelp";
            lblEmailHelp.Size = new Size(750, 20);
            lblEmailHelp.TabIndex = 6;
            lblEmailHelp.Text = "E-mail usado para notificações e recuperação. Use um e-mail dedicado para envio automático do sistema.";
            // 
            // grpSenha
            // 
            grpSenha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSenha.BackColor = Color.FromArgb(35, 36, 48);
            grpSenha.Controls.Add(tableLayoutPanel1);
            grpSenha.FlatStyle = FlatStyle.Flat;
            grpSenha.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpSenha.ForeColor = Color.White;
            grpSenha.Location = new Point(0, 0);
            grpSenha.Margin = new Padding(0, 0, 0, 20);
            grpSenha.Name = "grpSenha";
            grpSenha.Padding = new Padding(20);
            grpSenha.Size = new Size(801, 180);
            grpSenha.TabIndex = 1;
            grpSenha.TabStop = false;
            grpSenha.Text = "🔐 ALTERAÇÃO DE SENHA";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnGerente, 0, 0);
            tableLayoutPanel1.Controls.Add(btnFuncionario, 1, 0);
            tableLayoutPanel1.Location = new Point(20, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5, 15, 5, 15);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(761, 100);
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
            btnGerente.Content = " Alterar Senha (Gerente)";
            btnGerente.DialogResult = DialogResult.None;
            btnGerente.Dock = DockStyle.Fill;
            btnGerente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGerente.ForeColor = Color.White;
            btnGerente.HoverBackground = Color.FromArgb(70, 130, 180);
            btnGerente.HoverForeColor = Color.White;
            btnGerente.HoverImageTint = Color.White;
            btnGerente.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGerente.Image = null;
            btnGerente.ImageAutoCenter = true;
            btnGerente.ImageExpand = new Point(0, 0);
            btnGerente.ImageOffset = new Point(0, 0);
            btnGerente.Location = new Point(8, 18);
            btnGerente.Margin = new Padding(3, 3, 10, 3);
            btnGerente.Name = "btnGerente";
            btnGerente.NormalBackground = Color.FromArgb(50, 52, 70);
            btnGerente.NormalForeColor = Color.White;
            btnGerente.NormalImageTint = Color.White;
            btnGerente.NormalOutline = Color.FromArgb(70, 72, 90);
            btnGerente.OutlineThickness = 2F;
            btnGerente.PressedBackground = Color.FromArgb(40, 42, 60);
            btnGerente.PressedForeColor = Color.White;
            btnGerente.PressedImageTint = Color.White;
            btnGerente.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerente.Rounding = new Padding(12);
            btnGerente.Size = new Size(362, 64);
            btnGerente.TabIndex = 10;
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
            btnFuncionario.Content = "Alterar Senha (Funcionário)";
            btnFuncionario.DialogResult = DialogResult.None;
            btnFuncionario.Dock = DockStyle.Fill;
            btnFuncionario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFuncionario.ForeColor = Color.White;
            btnFuncionario.HoverBackground = Color.FromArgb(70, 130, 180);
            btnFuncionario.HoverForeColor = Color.White;
            btnFuncionario.HoverImageTint = Color.White;
            btnFuncionario.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFuncionario.Image = null;
            btnFuncionario.ImageAutoCenter = true;
            btnFuncionario.ImageExpand = new Point(0, 0);
            btnFuncionario.ImageOffset = new Point(0, 0);
            btnFuncionario.Location = new Point(390, 18);
            btnFuncionario.Margin = new Padding(10, 3, 3, 3);
            btnFuncionario.Name = "btnFuncionario";
            btnFuncionario.NormalBackground = Color.FromArgb(50, 52, 70);
            btnFuncionario.NormalForeColor = Color.White;
            btnFuncionario.NormalImageTint = Color.White;
            btnFuncionario.NormalOutline = Color.FromArgb(70, 72, 90);
            btnFuncionario.OutlineThickness = 2F;
            btnFuncionario.PressedBackground = Color.FromArgb(40, 42, 60);
            btnFuncionario.PressedForeColor = Color.White;
            btnFuncionario.PressedImageTint = Color.White;
            btnFuncionario.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFuncionario.Rounding = new Padding(12);
            btnFuncionario.Size = new Size(363, 64);
            btnFuncionario.TabIndex = 11;
            btnFuncionario.TextAlignment = StringAlignment.Center;
            btnFuncionario.TextOffset = new Point(0, 0);
            // 
            // pnlRight
            // 
            pnlRight.AutoScroll = true;
            pnlRight.BackColor = Color.Transparent;
            pnlRight.Controls.Add(grpSuporte);
            pnlRight.Controls.Add(grpBackup);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(840, 13);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(542, 485);
            pnlRight.TabIndex = 1;
            // 
            // grpSuporte
            // 
            grpSuporte.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSuporte.BackColor = Color.FromArgb(35, 36, 48);
            grpSuporte.Controls.Add(lblSuporteDesc);
            grpSuporte.Controls.Add(lnkSuporte);
            grpSuporte.Controls.Add(lbSuporte);
            grpSuporte.FlatStyle = FlatStyle.Flat;
            grpSuporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpSuporte.ForeColor = Color.White;
            grpSuporte.Location = new Point(0, 223);
            grpSuporte.Margin = new Padding(0, 0, 0, 20);
            grpSuporte.Name = "grpSuporte";
            grpSuporte.Padding = new Padding(20);
            grpSuporte.Size = new Size(542, 150);
            grpSuporte.TabIndex = 2;
            grpSuporte.TabStop = false;
            grpSuporte.Text = "🛠️ SUPORTE TÉCNICO";
            // 
            // lblSuporteDesc
            // 
            lblSuporteDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSuporteDesc.Font = new Font("Segoe UI", 10F);
            lblSuporteDesc.ForeColor = Color.LightGray;
            lblSuporteDesc.Location = new Point(25, 50);
            lblSuporteDesc.Name = "lblSuporteDesc";
            lblSuporteDesc.Size = new Size(492, 30);
            lblSuporteDesc.TabIndex = 11;
            lblSuporteDesc.Text = "Precisa de ajuda? Entre em contato com nossa equipe de suporte técnico especializado:";
            // 
            // lnkSuporte
            // 
            lnkSuporte.ActiveLinkColor = Color.LightSkyBlue;
            lnkSuporte.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lnkSuporte.LinkColor = Color.LightSkyBlue;
            lnkSuporte.Location = new Point(80, 102);
            lnkSuporte.Name = "lnkSuporte";
            lnkSuporte.Size = new Size(293, 25);
            lnkSuporte.TabIndex = 10;
            lnkSuporte.TabStop = true;
            lnkSuporte.Text = "telebip.suporte@telebip.com";
            lnkSuporte.VisitedLinkColor = Color.LightSkyBlue;
            // 
            // lbSuporte
            // 
            lbSuporte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSuporte.ForeColor = Color.Gainsboro;
            lbSuporte.Location = new Point(25, 100);
            lbSuporte.Name = "lbSuporte";
            lbSuporte.Size = new Size(70, 25);
            lbSuporte.TabIndex = 8;
            lbSuporte.Text = "E-mail:";
            lbSuporte.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpBackup
            // 
            grpBackup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBackup.BackColor = Color.FromArgb(35, 36, 48);
            grpBackup.Controls.Add(tableLayoutPanel2);
            grpBackup.Controls.Add(lblBackupTitle);
            grpBackup.Controls.Add(lbUltimoBackup);
            grpBackup.FlatStyle = FlatStyle.Flat;
            grpBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpBackup.ForeColor = Color.White;
            grpBackup.Location = new Point(0, 0);
            grpBackup.Margin = new Padding(0, 0, 0, 20);
            grpBackup.Name = "grpBackup";
            grpBackup.Padding = new Padding(20);
            grpBackup.Size = new Size(542, 195);
            grpBackup.TabIndex = 0;
            grpBackup.TabStop = false;
            grpBackup.Text = "💾 BACKUP & RESTAURAÇÃO";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnBackup, 0, 0);
            tableLayoutPanel2.Controls.Add(btnRestaurarBackup, 1, 0);
            tableLayoutPanel2.Location = new Point(20, 128);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(502, 51);
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
            btnBackup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBackup.ForeColor = Color.White;
            btnBackup.HoverBackground = Color.FromArgb(50, 150, 100);
            btnBackup.HoverForeColor = Color.White;
            btnBackup.HoverImageTint = Color.White;
            btnBackup.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnBackup.Image = null;
            btnBackup.ImageAutoCenter = true;
            btnBackup.ImageExpand = new Point(0, 0);
            btnBackup.ImageOffset = new Point(0, 0);
            btnBackup.Location = new Point(3, 3);
            btnBackup.Name = "btnBackup";
            btnBackup.NormalBackground = Color.FromArgb(40, 120, 80);
            btnBackup.NormalForeColor = Color.White;
            btnBackup.NormalImageTint = Color.White;
            btnBackup.NormalOutline = Color.FromArgb(70, 72, 90);
            btnBackup.OutlineThickness = 2F;
            btnBackup.PressedBackground = Color.FromArgb(30, 100, 70);
            btnBackup.PressedForeColor = Color.White;
            btnBackup.PressedImageTint = Color.White;
            btnBackup.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnBackup.Rounding = new Padding(10);
            btnBackup.Size = new Size(245, 45);
            btnBackup.TabIndex = 12;
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
            btnRestaurarBackup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRestaurarBackup.ForeColor = Color.White;
            btnRestaurarBackup.HoverBackground = Color.FromArgb(180, 80, 60);
            btnRestaurarBackup.HoverForeColor = Color.White;
            btnRestaurarBackup.HoverImageTint = Color.White;
            btnRestaurarBackup.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnRestaurarBackup.Image = null;
            btnRestaurarBackup.ImageAutoCenter = true;
            btnRestaurarBackup.ImageExpand = new Point(0, 0);
            btnRestaurarBackup.ImageOffset = new Point(0, 0);
            btnRestaurarBackup.Location = new Point(254, 3);
            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.NormalBackground = Color.FromArgb(200, 80, 50);
            btnRestaurarBackup.NormalForeColor = Color.White;
            btnRestaurarBackup.NormalImageTint = Color.White;
            btnRestaurarBackup.NormalOutline = Color.FromArgb(70, 72, 90);
            btnRestaurarBackup.OutlineThickness = 2F;
            btnRestaurarBackup.PressedBackground = Color.FromArgb(170, 60, 40);
            btnRestaurarBackup.PressedForeColor = Color.White;
            btnRestaurarBackup.PressedImageTint = Color.White;
            btnRestaurarBackup.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnRestaurarBackup.Rounding = new Padding(10);
            btnRestaurarBackup.Size = new Size(245, 45);
            btnRestaurarBackup.TabIndex = 13;
            btnRestaurarBackup.TextAlignment = StringAlignment.Center;
            btnRestaurarBackup.TextOffset = new Point(0, 0);
            // 
            // lblBackupTitle
            // 
            lblBackupTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBackupTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBackupTitle.ForeColor = Color.White;
            lblBackupTitle.Location = new Point(25, 50);
            lblBackupTitle.Name = "lblBackupTitle";
            lblBackupTitle.Size = new Size(492, 25);
            lblBackupTitle.TabIndex = 0;
            lblBackupTitle.Text = "Backup e Restauração do Sistema";
            lblBackupTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbUltimoBackup
            // 
            lbUltimoBackup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbUltimoBackup.Font = new Font("Segoe UI", 10F);
            lbUltimoBackup.ForeColor = Color.Gainsboro;
            lbUltimoBackup.Location = new Point(25, 76);
            lbUltimoBackup.Name = "lbUltimoBackup";
            lbUltimoBackup.Size = new Size(492, 20);
            lbUltimoBackup.TabIndex = 1;
            lbUltimoBackup.Text = "Salve ou restaure os dados do sitema aqui:";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 45);
            pnlBottom.Controls.Add(btnTrocarUsuario);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 572);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(20, 15, 20, 15);
            pnlBottom.Size = new Size(1400, 72);
            pnlBottom.TabIndex = 1;
            // 
            // btnTrocarUsuario
            // 
            btnTrocarUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTrocarUsuario.CheckButton = false;
            btnTrocarUsuario.Checked = false;
            btnTrocarUsuario.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnTrocarUsuario.CheckedForeColor = Color.White;
            btnTrocarUsuario.CheckedImageTint = Color.White;
            btnTrocarUsuario.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnTrocarUsuario.Content = "Trocar de usuario";
            btnTrocarUsuario.DialogResult = DialogResult.None;
            btnTrocarUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTrocarUsuario.ForeColor = Color.White;
            btnTrocarUsuario.HoverBackground = Color.FromArgb(200, 70, 70);
            btnTrocarUsuario.HoverForeColor = Color.White;
            btnTrocarUsuario.HoverImageTint = Color.White;
            btnTrocarUsuario.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnTrocarUsuario.Image = null;
            btnTrocarUsuario.ImageAutoCenter = true;
            btnTrocarUsuario.ImageExpand = new Point(0, 0);
            btnTrocarUsuario.ImageOffset = new Point(0, 0);
            btnTrocarUsuario.Location = new Point(1218, 12);
            btnTrocarUsuario.Name = "btnTrocarUsuario";
            btnTrocarUsuario.NormalBackground = Color.FromArgb(180, 60, 60);
            btnTrocarUsuario.NormalForeColor = Color.White;
            btnTrocarUsuario.NormalImageTint = Color.White;
            btnTrocarUsuario.NormalOutline = Color.FromArgb(100, 100, 100);
            btnTrocarUsuario.OutlineThickness = 2F;
            btnTrocarUsuario.PressedBackground = Color.FromArgb(160, 50, 50);
            btnTrocarUsuario.PressedForeColor = Color.White;
            btnTrocarUsuario.PressedImageTint = Color.White;
            btnTrocarUsuario.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnTrocarUsuario.Rounding = new Padding(10);
            btnTrocarUsuario.Size = new Size(159, 47);
            btnTrocarUsuario.TabIndex = 2;
            btnTrocarUsuario.TextAlignment = StringAlignment.Center;
            btnTrocarUsuario.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 45);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 15);
            pnlHeader.Size = new Size(1400, 71);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1360, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONFIGURAÇÕES DO SISTEMA";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormConfiguracoes
            // 
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1400, 644);
            Controls.Add(pnlContainer);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1000, 644);
            Name = "FormConfiguracoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações";
            pnlContainer.ResumeLayout(false);
            tblMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            grpEmail.ResumeLayout(false);
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            grpSenha.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            grpSuporte.ResumeLayout(false);
            grpBackup.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}