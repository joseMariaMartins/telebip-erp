namespace telebip_erp.Forms.Modules
{
    partial class FormVendas
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
            pnlTop = new Panel();
            btnPesquisar = new Button();
            tbPesquisa = new TextBox();
            cbPesquisaCampo = new ComboBox();
            cbCondicao = new ComboBox();
            pnlDgv = new Panel();
            dgvVendas = new DataGridView();
            pnlTop.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(btnPesquisar);
            pnlTop.Controls.Add(tbPesquisa);
            pnlTop.Controls.Add(cbPesquisaCampo);
            pnlTop.Controls.Add(cbCondicao);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1120, 81);
            pnlTop.TabIndex = 3;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(538, 3);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // tbPesquisa
            // 
            tbPesquisa.Location = new Point(298, 3);
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.Size = new Size(203, 23);
            tbPesquisa.TabIndex = 4;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_Venda", "Nome_Funcionario", "Data_Hora", "Desconto", "Valor_Total" });
            cbPesquisaCampo.Location = new Point(0, 3);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(121, 23);
            cbPesquisaCampo.TabIndex = 3;
            // 
            // cbCondicao
            // 
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FormattingEnabled = true;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(140, 3);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(121, 23);
            cbCondicao.TabIndex = 2;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.Transparent;
            pnlDgv.Controls.Add(dgvVendas);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 81);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(10, 9, 10, 9);
            pnlDgv.Size = new Size(1120, 459);
            pnlDgv.TabIndex = 4;
            // 
            // dgvVendas
            // 
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.Location = new Point(10, 9);
            dgvVendas.MultiSelect = false;
            dgvVendas.Name = "dgvVendas";
            dgvVendas.ReadOnly = true;
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.Size = new Size(1100, 441);
            dgvVendas.TabIndex = 0;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1120, 540);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVendas";
            Text = "FormVendas";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlTop;
        private Panel pnlDgv;
        private DataGridView dgvVendas;
        private ComboBox cbPesquisaCampo;
        private ComboBox cbCondicao;
        private TextBox tbPesquisa;
        private Button btnPesquisar;
    }
}