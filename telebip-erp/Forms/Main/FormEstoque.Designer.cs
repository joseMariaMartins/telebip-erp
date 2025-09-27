namespace telebip_erp.Forms.Modules
{
    partial class FormEstoque
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
            flpTop = new FlowLayoutPanel();
            cbPesquisaCampo = new ComboBox();
            cbCondicao = new ComboBox();
            tbPesquisa = new TextBox();
            btnPesquisar = new Button();
            pnlDgv = new Panel();
            dgvEstoque = new DataGridView();
            flpTop.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            SuspendLayout();
            // 
            // flpTop
            // 
            flpTop.Controls.Add(cbPesquisaCampo);
            flpTop.Controls.Add(cbCondicao);
            flpTop.Controls.Add(tbPesquisa);
            flpTop.Controls.Add(btnPesquisar);
            flpTop.Dock = DockStyle.Top;
            flpTop.Location = new Point(0, 0);
            flpTop.Margin = new Padding(2);
            flpTop.Name = "flpTop";
            flpTop.Size = new Size(1120, 81);
            flpTop.TabIndex = 0;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_Produto", "Nome", "Marca", "Descricão", "Preco", "QTD_Estoque" });
            cbPesquisaCampo.Location = new Point(3, 3);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(111, 23);
            cbPesquisaCampo.TabIndex = 1;
            // 
            // cbCondicao
            // 
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FormattingEnabled = true;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(120, 3);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(167, 23);
            cbCondicao.TabIndex = 2;
            // 
            // tbPesquisa
            // 
            tbPesquisa.Location = new Point(293, 3);
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.Size = new Size(259, 23);
            tbPesquisa.TabIndex = 3;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(558, 3);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 4;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvEstoque);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 81);
            pnlDgv.Margin = new Padding(2);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(10, 9, 10, 9);
            pnlDgv.Size = new Size(1120, 459);
            pnlDgv.TabIndex = 1;
            // 
            // dgvEstoque
            // 
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstoque.Dock = DockStyle.Fill;
            dgvEstoque.Location = new Point(10, 9);
            dgvEstoque.Margin = new Padding(2);
            dgvEstoque.MultiSelect = false;
            dgvEstoque.Name = "dgvEstoque";
            dgvEstoque.ReadOnly = true;
            dgvEstoque.RowHeadersWidth = 62;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.Size = new Size(1100, 441);
            dgvEstoque.TabIndex = 0;
            // 
            // FormEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1120, 540);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(flpTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEstoque";
            Text = "FormEstoque";
            flpTop.ResumeLayout(false);
            flpTop.PerformLayout();
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTop;
        private Panel pnlDgv;
        private DataGridView dgvEstoque;
        private ComboBox cbPesquisaCampo;
        private TextBox tbPesquisa;
        private ComboBox cbCondicao;
        private Button btnPesquisar;
    }
}