namespace telebip_erp
{
    partial class FormBase
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            pnlMenu = new Panel();
            lblOrganizer = new Label();
            btnLogout = new Button();
            btnConfiguracoes = new Button();
            lblTelebip = new Label();
            btnFuncionarios = new Button();
            btnRelatorios = new Button();
            btnEstoque = new Button();
            btnVendas = new Button();
            pnlContent = new Panel();
            lblVersao = new Label();
            lblNome = new Label();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(lblOrganizer);
            pnlMenu.Controls.Add(btnLogout);
            pnlMenu.Controls.Add(btnConfiguracoes);
            pnlMenu.Controls.Add(lblTelebip);
            pnlMenu.Controls.Add(btnFuncionarios);
            pnlMenu.Controls.Add(btnRelatorios);
            pnlMenu.Controls.Add(btnEstoque);
            pnlMenu.Controls.Add(btnVendas);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(232, 700);
            pnlMenu.TabIndex = 0;
            // 
            // lblOrganizer
            // 
            lblOrganizer.AutoSize = true;
            lblOrganizer.BackColor = Color.Transparent;
            lblOrganizer.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblOrganizer.ForeColor = Color.White;
            lblOrganizer.Location = new Point(18, 73);
            lblOrganizer.Name = "lblOrganizer";
            lblOrganizer.Size = new Size(198, 51);
            lblOrganizer.TabIndex = 8;
            lblOrganizer.Text = "Organizer";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BackgroundImage = (Image)resources.GetObject("btnLogout.BackgroundImage");
            btnLogout.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = Properties.Resources.configurações;
            btnLogout.Location = new Point(60, 646);
            btnLogout.Name = "btnLogout";
            btnLogout.RightToLeft = RightToLeft.No;
            btnLogout.Size = new Size(40, 40);
            btnLogout.TabIndex = 7;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnConfiguracoes
            // 
            btnConfiguracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConfiguracoes.BackColor = Color.Transparent;
            btnConfiguracoes.BackgroundImage = Properties.Resources.configurações;
            btnConfiguracoes.BackgroundImageLayout = ImageLayout.Zoom;
            btnConfiguracoes.FlatAppearance.BorderSize = 0;
            btnConfiguracoes.FlatStyle = FlatStyle.Flat;
            btnConfiguracoes.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnConfiguracoes.ForeColor = Color.White;
            btnConfiguracoes.Image = Properties.Resources.configurações;
            btnConfiguracoes.Location = new Point(14, 646);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.RightToLeft = RightToLeft.No;
            btnConfiguracoes.Size = new Size(40, 40);
            btnConfiguracoes.TabIndex = 6;
            btnConfiguracoes.UseVisualStyleBackColor = false;
            // 
            // lblTelebip
            // 
            lblTelebip.AutoSize = true;
            lblTelebip.BackColor = Color.Transparent;
            lblTelebip.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTelebip.ForeColor = Color.White;
            lblTelebip.Location = new Point(45, 22);
            lblTelebip.Name = "lblTelebip";
            lblTelebip.Size = new Size(153, 51);
            lblTelebip.TabIndex = 4;
            lblTelebip.Text = "Telebip";
            // 
            // btnFuncionarios
            // 
            btnFuncionarios.BackColor = Color.FromArgb(20, 20, 20);
            btnFuncionarios.FlatAppearance.BorderSize = 0;
            btnFuncionarios.FlatStyle = FlatStyle.Flat;
            btnFuncionarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFuncionarios.ForeColor = Color.White;
            btnFuncionarios.Location = new Point(10, 369);
            btnFuncionarios.Name = "btnFuncionarios";
            btnFuncionarios.Size = new Size(212, 57);
            btnFuncionarios.TabIndex = 3;
            btnFuncionarios.Text = "Funcionários";
            btnFuncionarios.UseVisualStyleBackColor = false;
            // 
            // btnRelatorios
            // 
            btnRelatorios.BackColor = Color.FromArgb(20, 20, 20);
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRelatorios.ForeColor = Color.White;
            btnRelatorios.Location = new Point(10, 306);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(212, 57);
            btnRelatorios.TabIndex = 2;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = false;
            // 
            // btnEstoque
            // 
            btnEstoque.BackColor = Color.FromArgb(20, 20, 20);
            btnEstoque.FlatAppearance.BorderSize = 0;
            btnEstoque.FlatStyle = FlatStyle.Flat;
            btnEstoque.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnEstoque.ForeColor = Color.White;
            btnEstoque.Location = new Point(10, 243);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Size = new Size(212, 57);
            btnEstoque.TabIndex = 1;
            btnEstoque.Text = "Estoque";
            btnEstoque.UseVisualStyleBackColor = false;
            // 
            // btnVendas
            // 
            btnVendas.BackColor = Color.FromArgb(20, 20, 20);
            btnVendas.FlatAppearance.BorderSize = 0;
            btnVendas.FlatStyle = FlatStyle.Flat;
            btnVendas.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnVendas.ForeColor = Color.White;
            btnVendas.Location = new Point(10, 180);
            btnVendas.Name = "btnVendas";
            btnVendas.Size = new Size(212, 57);
            btnVendas.TabIndex = 0;
            btnVendas.Text = "Vendas";
            btnVendas.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblVersao);
            pnlContent.Controls.Add(lblNome);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(232, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1346, 700);
            pnlContent.TabIndex = 1;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersao.ForeColor = Color.White;
            lblVersao.Location = new Point(1196, 837);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(103, 15);
            lblVersao.TabIndex = 10;
            lblVersao.Text = "Telebip Organizer:";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(12, 837);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(73, 15);
            lblNome.TabIndex = 9;
            lblNome.Text = "Funcionário:";

            // BOTÃO CONFIGURAÇÕES (USANDO RECURSOS)
            btnConfiguracoes = new Button();
            btnConfiguracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConfiguracoes.BackColor = Color.Transparent;
            btnConfiguracoes.FlatAppearance.BorderSize = 0;
            btnConfiguracoes.FlatStyle = FlatStyle.Flat;
            btnConfiguracoes.Font = new Font("Segoe UI", 10F);
            btnConfiguracoes.ForeColor = Color.White;
            btnConfiguracoes.Location = new Point(14, 646);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Size = new Size(40, 40);
            btnConfiguracoes.TabIndex = 6;
            btnConfiguracoes.UseVisualStyleBackColor = false;

            //FALTA COLOCAR A IMAGEM CORRETAMENTE AQUI

            // USA IMAGEM DOS RECURSOS
            btnConfiguracoes.Image = Properties.Resources.configurações;
            btnConfiguracoes.ImageAlign = ContentAlignment.MiddleCenter;

            // BOTÃO LOGOUT (USANDO RECURSOS)
            btnLogout = new Button();
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(60, 646);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(40, 40);
            btnLogout.TabIndex = 7;
            btnLogout.UseVisualStyleBackColor = false;

            // USA IMAGEM DOS RECURSOS
            btnLogout.ImageAlign = ContentAlignment.MiddleCenter;
            // FormBase
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1578, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            MaximumSize = new Size(1598, 894);
            MinimumSize = new Size(1198, 694);
            Name = "FormBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblVersao;
        private Label lblNome;
        private Button btnConfiguracoes;
        private Button btnLogout;
        protected Panel pnlMenu;
        protected Panel pnlContent;
        protected DataGridView dgvDados;
        protected Button btnVendas;
        protected Button btnFuncionarios;
        protected Button btnRelatorios;
        protected Button btnEstoque;
        protected Label label4;
        protected Label lblTelebip;
        protected Label lblOrganizer;
    }
}