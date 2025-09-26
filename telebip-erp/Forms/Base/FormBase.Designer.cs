﻿namespace telebip_erp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            btnHam = new PictureBox();
            pnlSidebar = new FlowLayoutPanel();
            pnlHome = new Panel();
            btnHome = new Button();
            pnlVendas = new Panel();
            panel3 = new Panel();
            btnVendas = new Button();
            panel5 = new Panel();
            rmvVenda = new Button();
            panel2 = new Panel();
            addVenda = new Button();
            pnlEstoque = new Panel();
            panel10 = new Panel();
            btnEstoque = new Button();
            panel11 = new Panel();
            rmvEstoque = new Button();
            panel12 = new Panel();
            addEstoque = new Button();
            pnlRelatorios = new Panel();
            panel6 = new Panel();
            btnRelatorios = new Button();
            pnlFuncionarios = new Panel();
            panel9 = new Panel();
            btnFuncionarios = new Button();
            pnlConfiguracoes = new Panel();
            panel8 = new Panel();
            btnConfiguracoes = new Button();
            menuTransitionVendas = new System.Windows.Forms.Timer(components);
            sidebarTransition = new System.Windows.Forms.Timer(components);
            MenuTransitionEstoque = new System.Windows.Forms.Timer(components);
            pnlContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlHome.SuspendLayout();
            pnlVendas.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            pnlEstoque.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            pnlRelatorios.SuspendLayout();
            panel6.SuspendLayout();
            pnlFuncionarios.SuspendLayout();
            panel9.SuspendLayout();
            pnlConfiguracoes.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // btnHam
            // 
            btnHam.BackColor = Color.Transparent;
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(13, 3);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(25, 20);
            btnHam.SizeMode = PictureBoxSizeMode.Zoom;
            btnHam.TabIndex = 1;
            btnHam.TabStop = false;
            btnHam.Click += btnHam_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(23, 24, 29);
            pnlSidebar.Controls.Add(pnlHome);
            pnlSidebar.Controls.Add(pnlVendas);
            pnlSidebar.Controls.Add(pnlEstoque);
            pnlSidebar.Controls.Add(pnlRelatorios);
            pnlSidebar.Controls.Add(pnlFuncionarios);
            pnlSidebar.Controls.Add(pnlConfiguracoes);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(3, 24);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(277, 679);
            pnlSidebar.TabIndex = 1;
            // 
            // pnlHome
            // 
            pnlHome.Controls.Add(btnHome);
            pnlHome.Location = new Point(3, 30);
            pnlHome.Margin = new Padding(3, 30, 3, 0);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(270, 50);
            pnlHome.TabIndex = 6;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(23, 24, 29);
            btnHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnHome.ForeColor = SystemColors.ControlLight;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(-4, -8);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(9, 0, 0, 0);
            btnHome.Size = new Size(287, 63);
            btnHome.TabIndex = 3;
            btnHome.Text = "                    Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pnlVendas
            // 
            pnlVendas.BackColor = Color.FromArgb(23, 24, 29);
            pnlVendas.Controls.Add(panel3);
            pnlVendas.Controls.Add(panel5);
            pnlVendas.Controls.Add(panel2);
            pnlVendas.Dock = DockStyle.Top;
            pnlVendas.ForeColor = Color.Transparent;
            pnlVendas.Location = new Point(0, 90);
            pnlVendas.Margin = new Padding(0, 10, 0, 0);
            pnlVendas.Name = "pnlVendas";
            pnlVendas.Size = new Size(270, 148);
            pnlVendas.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnVendas);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(228, 47);
            panel3.TabIndex = 3;
            // 
            // btnVendas
            // 
            btnVendas.BackColor = Color.FromArgb(23, 24, 29);
            btnVendas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVendas.ForeColor = SystemColors.ControlLight;
            btnVendas.Image = (Image)resources.GetObject("btnVendas.Image");
            btnVendas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVendas.Location = new Point(-4, -4);
            btnVendas.Margin = new Padding(0);
            btnVendas.Name = "btnVendas";
            btnVendas.Padding = new Padding(9, 0, 0, 0);
            btnVendas.Size = new Size(251, 55);
            btnVendas.TabIndex = 4;
            btnVendas.Text = "                    Vendas";
            btnVendas.TextAlign = ContentAlignment.MiddleLeft;
            btnVendas.UseVisualStyleBackColor = false;
            btnVendas.Click += btnVendas_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(rmvVenda);
            panel5.Location = new Point(2, 101);
            panel5.Name = "panel5";
            panel5.Size = new Size(274, 50);
            panel5.TabIndex = 6;
            // 
            // rmvVenda
            // 
            rmvVenda.BackColor = Color.FromArgb(32, 33, 36);
            rmvVenda.FlatStyle = FlatStyle.Popup;
            rmvVenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rmvVenda.ForeColor = SystemColors.ControlLight;
            rmvVenda.Image = (Image)resources.GetObject("rmvVenda.Image");
            rmvVenda.ImageAlign = ContentAlignment.MiddleLeft;
            rmvVenda.Location = new Point(0, -7);
            rmvVenda.Margin = new Padding(0);
            rmvVenda.Name = "rmvVenda";
            rmvVenda.Padding = new Padding(13, 0, 0, 0);
            rmvVenda.Size = new Size(274, 58);
            rmvVenda.TabIndex = 4;
            rmvVenda.Text = "                    Remover";
            rmvVenda.TextAlign = ContentAlignment.MiddleLeft;
            rmvVenda.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(addVenda);
            panel2.Location = new Point(2, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 50);
            panel2.TabIndex = 2;
            // 
            // addVenda
            // 
            addVenda.BackColor = Color.FromArgb(32, 33, 36);
            addVenda.FlatStyle = FlatStyle.Popup;
            addVenda.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            addVenda.ForeColor = SystemColors.ControlLight;
            addVenda.Image = (Image)resources.GetObject("addVenda.Image");
            addVenda.ImageAlign = ContentAlignment.MiddleLeft;
            addVenda.Location = new Point(0, -8);
            addVenda.Margin = new Padding(0);
            addVenda.Name = "addVenda";
            addVenda.Padding = new Padding(13, 0, 0, 0);
            addVenda.Size = new Size(274, 62);
            addVenda.TabIndex = 3;
            addVenda.Text = "                    Adicionar";
            addVenda.TextAlign = ContentAlignment.MiddleLeft;
            addVenda.UseVisualStyleBackColor = false;
            // 
            // pnlEstoque
            // 
            pnlEstoque.BackColor = Color.FromArgb(23, 24, 29);
            pnlEstoque.Controls.Add(panel10);
            pnlEstoque.Controls.Add(panel11);
            pnlEstoque.Controls.Add(panel12);
            pnlEstoque.ForeColor = Color.Transparent;
            pnlEstoque.Location = new Point(0, 248);
            pnlEstoque.Margin = new Padding(0, 10, 0, 0);
            pnlEstoque.Name = "pnlEstoque";
            pnlEstoque.Size = new Size(267, 152);
            pnlEstoque.TabIndex = 8;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnEstoque);
            panel10.Location = new Point(3, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(228, 47);
            panel10.TabIndex = 3;
            // 
            // btnEstoque
            // 
            btnEstoque.BackColor = Color.FromArgb(23, 24, 29);
            btnEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEstoque.ForeColor = SystemColors.ControlLight;
            btnEstoque.Image = (Image)resources.GetObject("btnEstoque.Image");
            btnEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstoque.Location = new Point(-4, -10);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Padding = new Padding(9, 0, 0, 0);
            btnEstoque.Size = new Size(251, 69);
            btnEstoque.TabIndex = 4;
            btnEstoque.Text = "                    Estoque";
            btnEstoque.TextAlign = ContentAlignment.MiddleLeft;
            btnEstoque.UseVisualStyleBackColor = false;
            btnEstoque.Click += btnEstoque_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(rmvEstoque);
            panel11.Location = new Point(2, 101);
            panel11.Name = "panel11";
            panel11.Size = new Size(274, 50);
            panel11.TabIndex = 6;
            // 
            // rmvEstoque
            // 
            rmvEstoque.BackColor = Color.FromArgb(32, 33, 36);
            rmvEstoque.FlatStyle = FlatStyle.Popup;
            rmvEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rmvEstoque.ForeColor = SystemColors.ControlLight;
            rmvEstoque.Image = (Image)resources.GetObject("rmvEstoque.Image");
            rmvEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            rmvEstoque.Location = new Point(0, -7);
            rmvEstoque.Name = "rmvEstoque";
            rmvEstoque.Padding = new Padding(13, 0, 0, 0);
            rmvEstoque.Size = new Size(271, 62);
            rmvEstoque.TabIndex = 4;
            rmvEstoque.Text = "                    Remover";
            rmvEstoque.TextAlign = ContentAlignment.MiddleLeft;
            rmvEstoque.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.Controls.Add(addEstoque);
            panel12.Location = new Point(2, 53);
            panel12.Name = "panel12";
            panel12.Size = new Size(274, 50);
            panel12.TabIndex = 2;
            // 
            // addEstoque
            // 
            addEstoque.BackColor = Color.FromArgb(32, 33, 36);
            addEstoque.FlatStyle = FlatStyle.Popup;
            addEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            addEstoque.ForeColor = SystemColors.ControlLight;
            addEstoque.Image = (Image)resources.GetObject("addEstoque.Image");
            addEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            addEstoque.Location = new Point(0, -11);
            addEstoque.Name = "addEstoque";
            addEstoque.Padding = new Padding(13, 0, 0, 0);
            addEstoque.Size = new Size(271, 69);
            addEstoque.TabIndex = 3;
            addEstoque.Text = "                    Adicionar";
            addEstoque.TextAlign = ContentAlignment.MiddleLeft;
            addEstoque.UseVisualStyleBackColor = false;
            // 
            // pnlRelatorios
            // 
            pnlRelatorios.BackColor = Color.FromArgb(23, 24, 29);
            pnlRelatorios.Controls.Add(panel6);
            pnlRelatorios.ForeColor = Color.Transparent;
            pnlRelatorios.Location = new Point(0, 410);
            pnlRelatorios.Margin = new Padding(0, 10, 0, 0);
            pnlRelatorios.Name = "pnlRelatorios";
            pnlRelatorios.Size = new Size(267, 51);
            pnlRelatorios.TabIndex = 9;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnRelatorios);
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(228, 47);
            panel6.TabIndex = 3;
            // 
            // btnRelatorios
            // 
            btnRelatorios.BackColor = Color.FromArgb(23, 24, 29);
            btnRelatorios.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRelatorios.ForeColor = SystemColors.ControlLight;
            btnRelatorios.Image = (Image)resources.GetObject("btnRelatorios.Image");
            btnRelatorios.ImageAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.Location = new Point(-4, -11);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Padding = new Padding(9, 0, 0, 0);
            btnRelatorios.Size = new Size(251, 69);
            btnRelatorios.TabIndex = 4;
            btnRelatorios.Text = "                    Relatórios";
            btnRelatorios.TextAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.UseVisualStyleBackColor = false;
            btnRelatorios.Click += btnRelatorios_Click_1;
            // 
            // pnlFuncionarios
            // 
            pnlFuncionarios.BackColor = Color.FromArgb(23, 24, 29);
            pnlFuncionarios.Controls.Add(panel9);
            pnlFuncionarios.ForeColor = Color.Transparent;
            pnlFuncionarios.Location = new Point(0, 471);
            pnlFuncionarios.Margin = new Padding(0, 10, 0, 0);
            pnlFuncionarios.Name = "pnlFuncionarios";
            pnlFuncionarios.Size = new Size(267, 51);
            pnlFuncionarios.TabIndex = 10;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnFuncionarios);
            panel9.Location = new Point(3, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(228, 47);
            panel9.TabIndex = 3;
            // 
            // btnFuncionarios
            // 
            btnFuncionarios.BackColor = Color.FromArgb(23, 24, 29);
            btnFuncionarios.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFuncionarios.ForeColor = SystemColors.ControlLight;
            btnFuncionarios.Image = (Image)resources.GetObject("btnFuncionarios.Image");
            btnFuncionarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnFuncionarios.Location = new Point(-4, -10);
            btnFuncionarios.Name = "btnFuncionarios";
            btnFuncionarios.Padding = new Padding(9, 0, 0, 0);
            btnFuncionarios.Size = new Size(251, 69);
            btnFuncionarios.TabIndex = 4;
            btnFuncionarios.Text = "                    Funcionários";
            btnFuncionarios.TextAlign = ContentAlignment.MiddleLeft;
            btnFuncionarios.UseVisualStyleBackColor = false;
            btnFuncionarios.Click += btnFuncionarios_Click_1;
            // 
            // pnlConfiguracoes
            // 
            pnlConfiguracoes.BackColor = Color.FromArgb(23, 24, 29);
            pnlConfiguracoes.Controls.Add(panel8);
            pnlConfiguracoes.ForeColor = Color.Transparent;
            pnlConfiguracoes.Location = new Point(0, 532);
            pnlConfiguracoes.Margin = new Padding(0, 10, 0, 0);
            pnlConfiguracoes.Name = "pnlConfiguracoes";
            pnlConfiguracoes.Size = new Size(267, 51);
            pnlConfiguracoes.TabIndex = 11;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnConfiguracoes);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(228, 47);
            panel8.TabIndex = 3;
            // 
            // btnConfiguracoes
            // 
            btnConfiguracoes.BackColor = Color.FromArgb(23, 24, 29);
            btnConfiguracoes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnConfiguracoes.ForeColor = SystemColors.ControlLight;
            btnConfiguracoes.Image = (Image)resources.GetObject("btnConfiguracoes.Image");
            btnConfiguracoes.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracoes.Location = new Point(-4, -10);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Padding = new Padding(9, 0, 0, 0);
            btnConfiguracoes.Size = new Size(251, 69);
            btnConfiguracoes.TabIndex = 4;
            btnConfiguracoes.Text = "                    Configurações";
            btnConfiguracoes.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracoes.UseVisualStyleBackColor = false;
            btnConfiguracoes.Click += btnConfiguracoes_Click_1;
            // 
            // menuTransitionVendas
            // 
            menuTransitionVendas.Interval = 10;
            menuTransitionVendas.Tick += menuTransitionVendas_Tick;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // MenuTransitionEstoque
            // 
            MenuTransitionEstoque.Interval = 10;
            MenuTransitionEstoque.Tick += MenuTransitionEstoque_Tick;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(34, 33, 39);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(280, 24);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1200, 679);
            pnlContainer.TabIndex = 3;
            // 
            // FormBase
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1483, 706);
            Controls.Add(pnlContainer);
            Controls.Add(pnlSidebar);
            Controls.Add(btnHam);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormStyle = FormStyles.ActionBar_None;
            IsMdiContainer = true;
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1198, 671);
            Name = "FormBase";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlHome.ResumeLayout(false);
            pnlVendas.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnlEstoque.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            pnlRelatorios.ResumeLayout(false);
            panel6.ResumeLayout(false);
            pnlFuncionarios.ResumeLayout(false);
            panel9.ResumeLayout(false);
            pnlConfiguracoes.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        protected DataGridView dgvDados;
        protected Label label4;
        private Panel panel2;
        private Button addVenda;
        private Button btnVendas;
        private Button rmvVenda;
        private Button btnHome;
        private Panel pnlVendas;
        private System.Windows.Forms.Timer menuTransitionVendas;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel pnlEstoque;
        private Button btnEstoque;
        private Button rmvEstoque;
        private Button addEstoque;
        private Panel pnlRelatorios;
        private Button btnRelatorios;
        private Panel pnlFuncionarios;
        private Button btnFuncionarios;
        private Panel pnlConfiguracoes;
        private Button btnConfiguracoes;
        protected PictureBox btnHam;
        protected FlowLayoutPanel pnlSidebar;
        protected Panel panel3;
        protected Panel panel5;
        protected Panel pnlHome;
        protected Panel panel10;
        protected Panel panel11;
        protected Panel panel12;
        protected Panel panel6;
        protected Panel panel9;
        protected Panel panel8;
        private System.Windows.Forms.Timer MenuTransitionEstoque;
        private Panel pnlContainer;
    }
}