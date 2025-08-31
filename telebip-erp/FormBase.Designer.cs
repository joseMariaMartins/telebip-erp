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
            btnLogout = new Button();
            btnConfigurações = new Button();
            label4 = new Label();
            label3 = new Label();
            btnFuncionarios = new Button();
            btnRelatorios = new Button();
            btnEstoque = new Button();
            btnVendas = new Button();
            pnlContent = new Panel();
            lblVersao = new Label();
            lblNome = new Label();
            txbPesquisar = new TextBox();
            btnBuscar = new Button();
            lblPesquisar = new Label();
            cmbParametro = new ComboBox();
            lblParametro = new Label();
            cmbFiltrar = new ComboBox();
            lblFiltro = new Label();
            dgvDados = new DataGridView();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnLogout);
            pnlMenu.Controls.Add(btnConfigurações);
            pnlMenu.Controls.Add(label4);
            pnlMenu.Controls.Add(label3);
            pnlMenu.Controls.Add(btnFuncionarios);
            pnlMenu.Controls.Add(btnRelatorios);
            pnlMenu.Controls.Add(btnEstoque);
            pnlMenu.Controls.Add(btnVendas);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(232, 861);
            pnlMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BackgroundImage = (Image)resources.GetObject("btnLogout.BackgroundImage");
            btnLogout.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = Properties.Resources.configurações;
            btnLogout.Location = new Point(75, 801);
            btnLogout.Name = "btnLogout";
            btnLogout.RightToLeft = RightToLeft.No;
            btnLogout.Size = new Size(60, 53);
            btnLogout.TabIndex = 7;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnConfigurações
            // 
            btnConfigurações.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnConfigurações.BackColor = Color.Transparent;
            btnConfigurações.BackgroundImage = Properties.Resources.configurações;
            btnConfigurações.BackgroundImageLayout = ImageLayout.Zoom;
            btnConfigurações.FlatAppearance.BorderSize = 0;
            btnConfigurações.FlatStyle = FlatStyle.Flat;
            btnConfigurações.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnConfigurações.ForeColor = Color.White;
            btnConfigurações.Image = Properties.Resources.configurações;
            btnConfigurações.Location = new Point(9, 799);
            btnConfigurações.Name = "btnConfigurações";
            btnConfigurações.RightToLeft = RightToLeft.No;
            btnConfigurações.Size = new Size(60, 53);
            btnConfigurações.TabIndex = 6;
            btnConfigurações.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(24, 72);
            label4.Name = "label4";
            label4.Size = new Size(198, 51);
            label4.TabIndex = 5;
            label4.Text = "Organizer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(45, 22);
            label3.Name = "label3";
            label3.Size = new Size(153, 51);
            label3.TabIndex = 4;
            label3.Text = "Telebip";
            // 
            // btnFuncionarios
            // 
            btnFuncionarios.BackColor = Color.FromArgb(20, 20, 20);
            btnFuncionarios.FlatAppearance.BorderSize = 0;
            btnFuncionarios.FlatStyle = FlatStyle.Flat;
            btnFuncionarios.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnFuncionarios.ForeColor = Color.White;
            btnFuncionarios.Location = new Point(14, 394);
            btnFuncionarios.Name = "btnFuncionarios";
            btnFuncionarios.Size = new Size(218, 57);
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
            btnRelatorios.Location = new Point(14, 321);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(218, 57);
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
            btnEstoque.Location = new Point(14, 247);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Size = new Size(218, 57);
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
            btnVendas.Location = new Point(14, 180);
            btnVendas.Name = "btnVendas";
            btnVendas.Size = new Size(218, 57);
            btnVendas.TabIndex = 0;
            btnVendas.Text = "Vendas";
            btnVendas.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblVersao);
            pnlContent.Controls.Add(lblNome);
            pnlContent.Controls.Add(txbPesquisar);
            pnlContent.Controls.Add(btnBuscar);
            pnlContent.Controls.Add(lblPesquisar);
            pnlContent.Controls.Add(cmbParametro);
            pnlContent.Controls.Add(lblParametro);
            pnlContent.Controls.Add(cmbFiltrar);
            pnlContent.Controls.Add(lblFiltro);
            pnlContent.Controls.Add(dgvDados);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(232, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1352, 861);
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
            // 
            // txbPesquisar
            // 
            txbPesquisar.BackColor = Color.White;
            txbPesquisar.Location = new Point(458, 42);
            txbPesquisar.Name = "txbPesquisar";
            txbPesquisar.Size = new Size(232, 23);
            txbPesquisar.TabIndex = 8;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(749, 35);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(92, 30);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPesquisar.ForeColor = Color.White;
            lblPesquisar.Location = new Point(456, 22);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(72, 17);
            lblPesquisar.TabIndex = 5;
            lblPesquisar.Text = "Pesquisar:";
            // 
            // cmbParametro
            // 
            cmbParametro.BackColor = Color.White;
            cmbParametro.FormattingEnabled = true;
            cmbParametro.Location = new Point(236, 42);
            cmbParametro.Name = "cmbParametro";
            cmbParametro.Size = new Size(163, 23);
            cmbParametro.TabIndex = 4;
            // 
            // lblParametro
            // 
            lblParametro.AutoSize = true;
            lblParametro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblParametro.ForeColor = Color.White;
            lblParametro.Location = new Point(235, 22);
            lblParametro.Name = "lblParametro";
            lblParametro.Size = new Size(76, 17);
            lblParametro.TabIndex = 3;
            lblParametro.Text = "Parâmetro:";
            // 
            // cmbFiltrar
            // 
            cmbFiltrar.BackColor = Color.White;
            cmbFiltrar.FormattingEnabled = true;
            cmbFiltrar.Location = new Point(15, 42);
            cmbFiltrar.Name = "cmbFiltrar";
            cmbFiltrar.Size = new Size(163, 23);
            cmbFiltrar.TabIndex = 2;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltro.ForeColor = Color.White;
            lblFiltro.Location = new Point(14, 22);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(75, 17);
            lblFiltro.TabIndex = 1;
            lblFiltro.Text = "Filtrar por:";
            // 
            // dgvDados
            // 
            dgvDados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(13, 88);
            dgvDados.Margin = new Padding(20);
            dgvDados.MultiSelect = false;
            dgvDados.Name = "dgvDados";
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDados.Size = new Size(1310, 744);
            dgvDados.TabIndex = 0;
            // 
            // FormBase
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1584, 861);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            MaximumSize = new Size(1600, 900);
            MinimumSize = new Size(1200, 700);
            Name = "FormBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlContent;
        private DataGridView dgvDados;
        private Label lblFiltro;
        private Button btnBuscar;
        private Label lblPesquisar;
        private ComboBox cmbParametro;
        private Label lblParametro;
        private ComboBox cmbFiltrar;
        private Button btnVendas;
        private TextBox txbPesquisar;
        private Button btnFuncionarios;
        private Button btnRelatorios;
        private Button btnEstoque;
        private Label label4;
        private Label label3;
        private Label lblVersao;
        private Label lblNome;
        private Button btnConfigurações;
        private Button btnLogout;
    }
}