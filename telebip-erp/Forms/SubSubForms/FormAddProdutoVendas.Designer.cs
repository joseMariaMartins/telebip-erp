namespace telebip_erp.Forms.SubSubForms
{
    partial class FormAddProdutoVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cbPesquisaCampoMini = new Guna.UI2.WinForms.Guna2ComboBox();
            cbCondicaoMini = new Guna.UI2.WinForms.Guna2ComboBox();
            tbPesquisaMini = new Guna.UI2.WinForms.Guna2TextBox();
            btnPesquisarMini = new Guna.UI2.WinForms.Guna2Button();
            btnLimparMini = new Guna.UI2.WinForms.Guna2Button();
            dgvProdutosMini = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).BeginInit();
            SuspendLayout();
            // 
            // cbPesquisaCampoMini
            // 
            cbPesquisaCampoMini.BackColor = Color.Transparent;
            cbPesquisaCampoMini.BorderColor = Color.FromArgb(60, 62, 80);
            cbPesquisaCampoMini.BorderRadius = 8;
            cbPesquisaCampoMini.CustomizableEdges = customizableEdges1;
            cbPesquisaCampoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampoMini.FillColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampoMini.FocusedColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampoMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampoMini.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampoMini.ForeColor = Color.White;
            cbPesquisaCampoMini.ItemHeight = 30;
            cbPesquisaCampoMini.Items.AddRange(new object[] { "ID_PRODUTO", "NOME", "MARCA", "PRECO", "QTD_ESTOQUE", "QTD_AVISO", "OBSERVACAO" });
            cbPesquisaCampoMini.Location = new Point(12, 25);
            cbPesquisaCampoMini.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampoMini.Name = "cbPesquisaCampoMini";
            cbPesquisaCampoMini.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbPesquisaCampoMini.Size = new Size(133, 36);
            cbPesquisaCampoMini.TabIndex = 13;
            // 
            // cbCondicaoMini
            // 
            cbCondicaoMini.BackColor = Color.Transparent;
            cbCondicaoMini.BorderColor = Color.FromArgb(60, 62, 80);
            cbCondicaoMini.BorderRadius = 8;
            cbCondicaoMini.CustomizableEdges = customizableEdges3;
            cbCondicaoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicaoMini.FillColor = Color.FromArgb(40, 41, 52);
            cbCondicaoMini.FocusedColor = Color.FromArgb(100, 150, 200);
            cbCondicaoMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbCondicaoMini.Font = new Font("Segoe UI", 9F);
            cbCondicaoMini.ForeColor = Color.White;
            cbCondicaoMini.ItemHeight = 30;
            cbCondicaoMini.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicaoMini.Location = new Point(158, 25);
            cbCondicaoMini.Margin = new Padding(3, 0, 10, 0);
            cbCondicaoMini.Name = "cbCondicaoMini";
            cbCondicaoMini.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbCondicaoMini.Size = new Size(133, 36);
            cbCondicaoMini.TabIndex = 14;
            // 
            // tbPesquisaMini
            // 
            tbPesquisaMini.BorderColor = Color.FromArgb(60, 62, 80);
            tbPesquisaMini.BorderRadius = 8;
            tbPesquisaMini.CustomizableEdges = customizableEdges5;
            tbPesquisaMini.DefaultText = "";
            tbPesquisaMini.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPesquisaMini.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPesquisaMini.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisaMini.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisaMini.FillColor = Color.FromArgb(40, 41, 52);
            tbPesquisaMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisaMini.Font = new Font("Segoe UI", 9F);
            tbPesquisaMini.ForeColor = Color.White;
            tbPesquisaMini.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisaMini.Location = new Point(304, 25);
            tbPesquisaMini.Margin = new Padding(3, 0, 10, 0);
            tbPesquisaMini.Name = "tbPesquisaMini";
            tbPesquisaMini.PlaceholderForeColor = Color.Gray;
            tbPesquisaMini.PlaceholderText = "Digite para pesquisar...";
            tbPesquisaMini.SelectedText = "";
            tbPesquisaMini.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbPesquisaMini.Size = new Size(235, 36);
            tbPesquisaMini.TabIndex = 15;
            // 
            // btnPesquisarMini
            // 
            btnPesquisarMini.BorderRadius = 8;
            btnPesquisarMini.CustomizableEdges = customizableEdges7;
            btnPesquisarMini.DisabledState.BorderColor = Color.DarkGray;
            btnPesquisarMini.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPesquisarMini.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPesquisarMini.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPesquisarMini.FillColor = Color.FromArgb(40, 120, 80);
            btnPesquisarMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisarMini.ForeColor = Color.White;
            btnPesquisarMini.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnPesquisarMini.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnPesquisarMini.Location = new Point(563, 25);
            btnPesquisarMini.Margin = new Padding(3, 0, 10, 0);
            btnPesquisarMini.Name = "btnPesquisarMini";
            btnPesquisarMini.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnPesquisarMini.Size = new Size(79, 36);
            btnPesquisarMini.TabIndex = 16;
            btnPesquisarMini.Text = "Pesquisar";
            // 
            // btnLimparMini
            // 
            btnLimparMini.BorderRadius = 8;
            btnLimparMini.CustomizableEdges = customizableEdges9;
            btnLimparMini.DisabledState.BorderColor = Color.DarkGray;
            btnLimparMini.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLimparMini.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLimparMini.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLimparMini.FillColor = Color.FromArgb(120, 40, 40);
            btnLimparMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimparMini.ForeColor = Color.White;
            btnLimparMini.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnLimparMini.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnLimparMini.Location = new Point(655, 25);
            btnLimparMini.Margin = new Padding(3, 0, 10, 0);
            btnLimparMini.Name = "btnLimparMini";
            btnLimparMini.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLimparMini.Size = new Size(79, 36);
            btnLimparMini.TabIndex = 17;
            btnLimparMini.Text = "Limpar";
            // 
            // dgvProdutosMini
            // 
            dgvProdutosMini.AllowUserToAddRows = false;
            dgvProdutosMini.AllowUserToDeleteRows = false;
            dgvProdutosMini.AllowUserToResizeColumns = false;
            dgvProdutosMini.AllowUserToResizeRows = false;
            dgvProdutosMini.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutosMini.Location = new Point(12, 117);
            dgvProdutosMini.Name = "dgvProdutosMini";
            dgvProdutosMini.ReadOnly = true;
            dgvProdutosMini.RowHeadersVisible = false;
            dgvProdutosMini.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutosMini.Size = new Size(748, 228);
            dgvProdutosMini.TabIndex = 18;
            // 
            // FormAddProdutoVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 432);
            Controls.Add(dgvProdutosMini);
            Controls.Add(btnLimparMini);
            Controls.Add(btnPesquisarMini);
            Controls.Add(tbPesquisaMini);
            Controls.Add(cbCondicaoMini);
            Controls.Add(cbPesquisaCampoMini);
            MaximizeBox = false;
            Name = "FormAddProdutoVendas";
            Text = "FormAddProdutoVendas";
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbPesquisaCampoMini;
        private Guna.UI2.WinForms.Guna2ComboBox cbCondicaoMini;
        private Guna.UI2.WinForms.Guna2TextBox tbPesquisaMini;
        private Guna.UI2.WinForms.Guna2Button btnPesquisarMini;
        private Guna.UI2.WinForms.Guna2Button btnLimparMini;
        private DataGridView dgvProdutosMini;
    }
}