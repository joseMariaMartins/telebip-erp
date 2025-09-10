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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            panel1 = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            btnHam = new PictureBox();
            pnlSidebar = new FlowLayoutPanel();
            pnlHome = new Panel();
            button5 = new Button();
            vendasContainer = new Panel();
            panel3 = new Panel();
            btnVendas = new Button();
            panel5 = new Panel();
            rmvVenda = new Button();
            panel2 = new Panel();
            addVenda = new Button();
            estoqueContainer = new Panel();
            panel10 = new Panel();
            btnEstoque = new Button();
            panel11 = new Panel();
            rmvEstoque = new Button();
            panel12 = new Panel();
            addEstoque = new Button();
            relatoriosContainer = new Panel();
            panel6 = new Panel();
            btnRelatorios = new Button();
            containerFuncionarios = new Panel();
            panel9 = new Panel();
            btnFuncionarios = new Button();
            configuracoesContainer = new Panel();
            panel8 = new Panel();
            btnConfiguracoes = new Button();
            menuTransitionVendas = new System.Windows.Forms.Timer(components);
            sidebarTransition = new System.Windows.Forms.Timer(components);
            MenuTransitionEstoque = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlHome.SuspendLayout();
            vendasContainer.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            estoqueContainer.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            relatoriosContainer.SuspendLayout();
            panel6.SuspendLayout();
            containerFuncionarios.SuspendLayout();
            panel9.SuspendLayout();
            configuracoesContainer.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(18, 19, 24);
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(btnHam);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1598, 32);
            panel1.TabIndex = 0;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(1459, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 2;
            // 
            // btnHam
            // 
            btnHam.BackColor = Color.Transparent;
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(8, 7);
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
            pnlSidebar.Controls.Add(vendasContainer);
            pnlSidebar.Controls.Add(estoqueContainer);
            pnlSidebar.Controls.Add(relatoriosContainer);
            pnlSidebar.Controls.Add(containerFuncionarios);
            pnlSidebar.Controls.Add(configuracoesContainer);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 32);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(44, 862);
            pnlSidebar.TabIndex = 1;
            // 
            // pnlHome
            // 
            pnlHome.Controls.Add(button5);
            pnlHome.Location = new Point(3, 30);
            pnlHome.Margin = new Padding(3, 30, 3, 0);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(257, 50);
            pnlHome.TabIndex = 6;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(23, 24, 29);
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button5.ForeColor = SystemColors.ControlLight;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(-5, -8);
            button5.Name = "button5";
            button5.Padding = new Padding(7, 0, 0, 0);
            button5.Size = new Size(278, 63);
            button5.TabIndex = 3;
            button5.Text = "                    Home";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // vendasContainer
            // 
            vendasContainer.BackColor = Color.FromArgb(23, 24, 29);
            vendasContainer.Controls.Add(panel3);
            vendasContainer.Controls.Add(panel5);
            vendasContainer.Controls.Add(panel2);
            vendasContainer.ForeColor = Color.Transparent;
            vendasContainer.Location = new Point(0, 90);
            vendasContainer.Margin = new Padding(0, 10, 0, 0);
            vendasContainer.Name = "vendasContainer";
            vendasContainer.Size = new Size(260, 51);
            vendasContainer.TabIndex = 7;
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
            btnVendas.Location = new Point(-5, -4);
            btnVendas.Margin = new Padding(0);
            btnVendas.Name = "btnVendas";
            btnVendas.Padding = new Padding(10, 0, 0, 0);
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
            // estoqueContainer
            // 
            estoqueContainer.BackColor = Color.FromArgb(23, 24, 29);
            estoqueContainer.Controls.Add(panel10);
            estoqueContainer.Controls.Add(panel11);
            estoqueContainer.Controls.Add(panel12);
            estoqueContainer.ForeColor = Color.Transparent;
            estoqueContainer.Location = new Point(3, 151);
            estoqueContainer.Margin = new Padding(3, 10, 3, 0);
            estoqueContainer.Name = "estoqueContainer";
            estoqueContainer.Size = new Size(257, 56);
            estoqueContainer.TabIndex = 8;
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
            btnEstoque.Location = new Point(-7, -10);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Padding = new Padding(10, 0, 0, 0);
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
            rmvEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rmvEstoque.ForeColor = SystemColors.ControlLight;
            rmvEstoque.Image = (Image)resources.GetObject("rmvEstoque.Image");
            rmvEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            rmvEstoque.Location = new Point(-4, -7);
            rmvEstoque.Name = "rmvEstoque";
            rmvEstoque.Padding = new Padding(13, 0, 0, 0);
            rmvEstoque.Size = new Size(275, 62);
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
            addEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            addEstoque.ForeColor = SystemColors.ControlLight;
            addEstoque.Image = (Image)resources.GetObject("addEstoque.Image");
            addEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            addEstoque.Location = new Point(-4, -11);
            addEstoque.Name = "addEstoque";
            addEstoque.Padding = new Padding(13, 0, 0, 0);
            addEstoque.Size = new Size(275, 69);
            addEstoque.TabIndex = 3;
            addEstoque.Text = "                    Adicionar";
            addEstoque.TextAlign = ContentAlignment.MiddleLeft;
            addEstoque.UseVisualStyleBackColor = false;
            // 
            // relatoriosContainer
            // 
            relatoriosContainer.BackColor = Color.FromArgb(23, 24, 29);
            relatoriosContainer.Controls.Add(panel6);
            relatoriosContainer.ForeColor = Color.Transparent;
            relatoriosContainer.Location = new Point(3, 217);
            relatoriosContainer.Margin = new Padding(3, 10, 3, 0);
            relatoriosContainer.Name = "relatoriosContainer";
            relatoriosContainer.Size = new Size(257, 51);
            relatoriosContainer.TabIndex = 9;
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
            btnRelatorios.Location = new Point(-6, -11);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Padding = new Padding(10, 0, 0, 0);
            btnRelatorios.Size = new Size(251, 69);
            btnRelatorios.TabIndex = 4;
            btnRelatorios.Text = "                    Relatórios";
            btnRelatorios.TextAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.UseVisualStyleBackColor = false;
            // 
            // containerFuncionarios
            // 
            containerFuncionarios.BackColor = Color.FromArgb(23, 24, 29);
            containerFuncionarios.Controls.Add(panel9);
            containerFuncionarios.ForeColor = Color.Transparent;
            containerFuncionarios.Location = new Point(3, 278);
            containerFuncionarios.Margin = new Padding(3, 10, 3, 0);
            containerFuncionarios.Name = "containerFuncionarios";
            containerFuncionarios.Size = new Size(257, 51);
            containerFuncionarios.TabIndex = 10;
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
            btnFuncionarios.Location = new Point(-8, -10);
            btnFuncionarios.Name = "btnFuncionarios";
            btnFuncionarios.Padding = new Padding(10, 0, 0, 0);
            btnFuncionarios.Size = new Size(251, 69);
            btnFuncionarios.TabIndex = 4;
            btnFuncionarios.Text = "                    Funcionários";
            btnFuncionarios.TextAlign = ContentAlignment.MiddleLeft;
            btnFuncionarios.UseVisualStyleBackColor = false;
            // 
            // configuracoesContainer
            // 
            configuracoesContainer.BackColor = Color.FromArgb(23, 24, 29);
            configuracoesContainer.Controls.Add(panel8);
            configuracoesContainer.ForeColor = Color.Transparent;
            configuracoesContainer.Location = new Point(3, 339);
            configuracoesContainer.Margin = new Padding(3, 10, 3, 0);
            configuracoesContainer.Name = "configuracoesContainer";
            configuracoesContainer.Size = new Size(257, 51);
            configuracoesContainer.TabIndex = 11;
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
            btnConfiguracoes.Location = new Point(-8, -10);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracoes.Size = new Size(251, 69);
            btnConfiguracoes.TabIndex = 4;
            btnConfiguracoes.Text = "                    Configurações";
            btnConfiguracoes.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracoes.UseVisualStyleBackColor = false;
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
            // FormBase
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1598, 894);
            Controls.Add(pnlSidebar);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1598, 894);
            MinimumSize = new Size(1198, 671);
            Name = "FormBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBase";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlHome.ResumeLayout(false);
            vendasContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            estoqueContainer.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            relatoriosContainer.ResumeLayout(false);
            panel6.ResumeLayout(false);
            containerFuncionarios.ResumeLayout(false);
            panel9.ResumeLayout(false);
            configuracoesContainer.ResumeLayout(false);
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
        private Button button5;
        private Panel vendasContainer;
        private System.Windows.Forms.Timer menuTransitionVendas;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel estoqueContainer;
        private Button btnEstoque;
        private Button rmvEstoque;
        private Button addEstoque;
        private Panel relatoriosContainer;
        private Button btnRelatorios;
        private Panel containerFuncionarios;
        private Button btnFuncionarios;
        private Panel configuracoesContainer;
        private Button btnConfiguracoes;
        protected Panel panel1;
        protected PictureBox btnHam;
        protected FlowLayoutPanel pnlSidebar;
        protected ReaLTaiizor.Controls.NightControlBox nightControlBox1;
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
    }
}