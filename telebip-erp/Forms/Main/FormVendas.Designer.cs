namespace telebip_erp.Forms.Modules
{
    partial class FormVendas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            flpTop = new FlowLayoutPanel();
            cbPesquisaCampo = new ReaLTaiizor.Controls.ComboBoxEdit();
            cbCondicao = new ReaLTaiizor.Controls.ComboBoxEdit();
            tbPesquisa = new ReaLTaiizor.Controls.DungeonTextBox();
            btnPesquisar = new ReaLTaiizor.Controls.AloneButton();
            pnlDgv = new Panel();
            dgvVendas = new DataGridView();
            flpTop.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
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
            flpTop.Margin = new Padding(3, 3, 3, 0);
            flpTop.Name = "flpTop";
            flpTop.Padding = new Padding(15, 15, 15, 0);
            flpTop.Size = new Size(1597, 59);
            flpTop.TabIndex = 0;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackColor = Color.FromArgb(34, 35, 49);
            cbPesquisaCampo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampo.DropDownHeight = 100;
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.Font = new Font("Segoe UI", 10F);
            cbPesquisaCampo.ForeColor = Color.FromArgb(142, 142, 142);
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.HoverSelectionColor = Color.Silver;
            cbPesquisaCampo.IntegralHeight = false;
            cbPesquisaCampo.ItemHeight = 20;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_Venda", "Nome_Funcionario", "Data_Hora", "Desconto", "Valor_Total" });
            cbPesquisaCampo.Location = new Point(18, 18);
            cbPesquisaCampo.Margin = new Padding(3, 3, 10, 3);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(170, 26);
            cbPesquisaCampo.StartIndex = 0;
            cbPesquisaCampo.TabIndex = 1;
            // 
            // cbCondicao
            // 
            cbCondicao.BackColor = Color.FromArgb(34, 35, 49);
            cbCondicao.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicao.DropDownHeight = 100;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.Font = new Font("Segoe UI", 10F);
            cbCondicao.ForeColor = Color.FromArgb(142, 142, 142);
            cbCondicao.FormattingEnabled = true;
            cbCondicao.HoverSelectionColor = Color.Silver;
            cbCondicao.IntegralHeight = false;
            cbCondicao.ItemHeight = 20;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(201, 18);
            cbCondicao.Margin = new Padding(3, 3, 10, 3);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(170, 26);
            cbCondicao.StartIndex = 0;
            cbCondicao.TabIndex = 2;
            // 
            // tbPesquisa
            // 
            tbPesquisa.BackColor = Color.Transparent;
            tbPesquisa.BorderColor = Color.FromArgb(180, 180, 180);
            tbPesquisa.EdgeColor = Color.White;
            tbPesquisa.Font = new Font("Tahoma", 11F);
            tbPesquisa.ForeColor = Color.DimGray;
            tbPesquisa.Location = new Point(384, 18);
            tbPesquisa.Margin = new Padding(3, 3, 10, 3);
            tbPesquisa.MaxLength = 32767;
            tbPesquisa.Multiline = false;
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.ReadOnly = false;
            tbPesquisa.Size = new Size(235, 28);
            tbPesquisa.TabIndex = 3;
            tbPesquisa.TextAlignment = HorizontalAlignment.Left;
            tbPesquisa.UseSystemPasswordChar = false;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.Transparent;
            btnPesquisar.EnabledCalc = true;
            btnPesquisar.Font = new Font("Segoe UI", 9.75F);
            btnPesquisar.ForeColor = Color.Black;
            btnPesquisar.Location = new Point(632, 18);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(172, 28);
            btnPesquisar.TabIndex = 4;
            btnPesquisar.Text = "Pesquisar";
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvVendas);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 59);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15, 0, 15, 15);
            pnlDgv.Size = new Size(1597, 648);
            pnlDgv.TabIndex = 6;
            // 
            // dgvVendas
            // 
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.Location = new Point(15, 0);
            dgvVendas.MultiSelect = false;
            dgvVendas.Name = "dgvVendas";
            dgvVendas.ReadOnly = true;
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.Size = new Size(1567, 633);
            dgvVendas.TabIndex = 5;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1597, 707);
            Controls.Add(pnlDgv);
            Controls.Add(flpTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormVendas";
            Text = "FormVendas";
            flpTop.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTop;
        private ReaLTaiizor.Controls.ComboBoxEdit cbPesquisaCampo;
        private ReaLTaiizor.Controls.ComboBoxEdit cbCondicao;
        private ReaLTaiizor.Controls.DungeonTextBox tbPesquisa;
        private ReaLTaiizor.Controls.AloneButton btnPesquisar;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvVendas;
    }
}
