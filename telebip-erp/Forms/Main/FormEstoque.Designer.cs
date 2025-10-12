namespace telebip_erp.Forms.Modules
{
    partial class FormEstoque
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvEstoque = new DataGridView();
            flpTop = new FlowLayoutPanel();
            cbPesquisaCampo = new ReaLTaiizor.Controls.ComboBoxEdit();
            cbCondicao = new ReaLTaiizor.Controls.ComboBoxEdit();
            tbPesquisa = new ReaLTaiizor.Controls.DungeonTextBox();
            btnPesquisar = new ReaLTaiizor.Controls.AloneButton();
            btnLimpar = new ReaLTaiizor.Controls.AloneButton();
            pnlDgv = new Panel();
            lbTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            flpTop.SuspendLayout();
            pnlDgv.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEstoque
            // 
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeColumns = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dgvEstoque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEstoque.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEstoque.Dock = DockStyle.Fill;
            dgvEstoque.Location = new Point(15, 0);
            dgvEstoque.Margin = new Padding(2);
            dgvEstoque.MultiSelect = false;
            dgvEstoque.Name = "dgvEstoque";
            dgvEstoque.ReadOnly = true;
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvEstoque.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.Size = new Size(1567, 725);
            dgvEstoque.TabIndex = 0;
            // 
            // flpTop
            // 
            flpTop.Controls.Add(cbPesquisaCampo);
            flpTop.Controls.Add(cbCondicao);
            flpTop.Controls.Add(tbPesquisa);
            flpTop.Controls.Add(btnPesquisar);
            flpTop.Controls.Add(btnLimpar);
            flpTop.Dock = DockStyle.Top;
            flpTop.Location = new Point(0, 0);
            flpTop.Name = "flpTop";
            flpTop.Padding = new Padding(15, 15, 15, 0);
            flpTop.Size = new Size(1597, 59);
            flpTop.TabIndex = 2;
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
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_PRODUTO ", "NOME", "MARCA ", "PRECO ", "QTD_ESTOQUE ", "QUANTIDADE_AVISO ", "OBSERVACAO " });
            cbPesquisaCampo.Location = new Point(18, 18);
            cbPesquisaCampo.Margin = new Padding(3, 3, 10, 3);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(170, 26);
            cbPesquisaCampo.StartIndex = 0;
            cbPesquisaCampo.TabIndex = 12;
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
            cbCondicao.TabIndex = 11;
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
            tbPesquisa.TabIndex = 7;
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
            btnPesquisar.Size = new Size(117, 28);
            btnPesquisar.TabIndex = 9;
            btnPesquisar.Text = "Pesquisar";
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(255, 128, 128);
            btnLimpar.EnabledCalc = true;
            btnLimpar.Font = new Font("Segoe UI", 9.75F);
            btnLimpar.ForeColor = Color.Black;
            btnLimpar.Location = new Point(755, 18);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(117, 28);
            btnLimpar.TabIndex = 13;
            btnLimpar.Text = "Limpar";
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(lbTotal);
            pnlDgv.Controls.Add(dgvEstoque);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 59);
            pnlDgv.Margin = new Padding(3, 0, 3, 3);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15, 0, 15, 17);
            pnlDgv.Size = new Size(1597, 742);
            pnlDgv.TabIndex = 3;
            // 
            // lbTotal
            // 
            lbTotal.BackColor = Color.Transparent;
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(15, 722);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(97, 17);
            lbTotal.TabIndex = 1;
            lbTotal.Text = "guna2HtmlLabel1";
            // 
            // FormEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1597, 801);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(flpTop);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEstoque";
            Text = "FormEstoque";
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            flpTop.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            pnlDgv.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTop;
        private System.Windows.Forms.Panel pnlDgv;
        private ReaLTaiizor.Controls.ComboBoxEdit cbPesquisaCampo;
        private ReaLTaiizor.Controls.ComboBoxEdit cbCondicao;
        private ReaLTaiizor.Controls.DungeonTextBox tbPesquisa;
        private ReaLTaiizor.Controls.AloneButton btnPesquisar;
        public System.Windows.Forms.DataGridView dgvEstoque;
        private ReaLTaiizor.Controls.AloneButton btnLimpar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTotal;
    }
}
