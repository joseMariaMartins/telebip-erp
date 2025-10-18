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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            pnlContainer = new Panel();
            pnlDgv = new Panel();
            dgvVendas = new DataGridView();
            pnlBottom = new Panel();
            lbTotal = new Label();
            pnlFiltros = new Panel();
            btnLimpar = new Guna.UI2.WinForms.Guna2Button();
            btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            tbPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            cbCondicao = new Guna.UI2.WinForms.Guna2ComboBox();
            cbPesquisaCampo = new Guna.UI2.WinForms.Guna2ComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            pnlBottom.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlDgv);
            pnlContainer.Controls.Add(pnlBottom);
            pnlContainer.Controls.Add(pnlFiltros);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1597, 707);
            pnlContainer.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.FromArgb(28, 29, 40);
            pnlDgv.Controls.Add(dgvVendas);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 128);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1597, 475);
            pnlDgv.TabIndex = 4;
            // 
            // dgvVendas
            // 
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvVendas.BorderStyle = BorderStyle.None;
            dgvVendas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVendas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVendas.ColumnHeadersHeight = 40;
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVendas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.EnableHeadersVisualStyles = false;
            dgvVendas.GridColor = Color.FromArgb(50, 52, 67);
            dgvVendas.Location = new Point(15, 15);
            dgvVendas.MultiSelect = false;
            dgvVendas.Name = "dgvVendas";
            dgvVendas.ReadOnly = true;
            dgvVendas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVendas.RowHeadersVisible = false;
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvVendas.RowTemplate.Height = 35;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.Size = new Size(1567, 445);
            dgvVendas.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lbTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 603);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1597, 104);
            pnlBottom.TabIndex = 5;
            // 
            // lbTotal
            // 
            lbTotal.Dock = DockStyle.Right;
            lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(1382, 15);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(200, 74);
            lbTotal.TabIndex = 0;
            lbTotal.Text = "Total: 0 vendas";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(btnPesquisar);
            pnlFiltros.Controls.Add(tbPesquisa);
            pnlFiltros.Controls.Add(cbCondicao);
            pnlFiltros.Controls.Add(cbPesquisaCampo);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 71);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10, 10, 10, 15);
            pnlFiltros.Size = new Size(1597, 57);
            pnlFiltros.TabIndex = 7;
            // 
            // btnLimpar
            // 
            btnLimpar.BorderRadius = 8;
            btnLimpar.CustomizableEdges = customizableEdges1;
            btnLimpar.DisabledState.BorderColor = Color.DarkGray;
            btnLimpar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLimpar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLimpar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLimpar.FillColor = Color.FromArgb(120, 40, 40);
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnLimpar.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnLimpar.Location = new Point(759, 10);
            btnLimpar.Margin = new Padding(3, 0, 10, 0);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLimpar.Size = new Size(120, 36);
            btnLimpar.TabIndex = 14;
            btnLimpar.Text = "Limpar";
            // 
            // btnPesquisar
            // 
            btnPesquisar.BorderRadius = 8;
            btnPesquisar.CustomizableEdges = customizableEdges3;
            btnPesquisar.DisabledState.BorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPesquisar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPesquisar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPesquisar.FillColor = Color.FromArgb(40, 120, 80);
            btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnPesquisar.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnPesquisar.Location = new Point(626, 10);
            btnPesquisar.Margin = new Padding(3, 0, 10, 0);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPesquisar.Size = new Size(120, 36);
            btnPesquisar.TabIndex = 9;
            btnPesquisar.Text = "Pesquisar";
            // 
            // tbPesquisa
            // 
            tbPesquisa.BorderColor = Color.FromArgb(60, 62, 80);
            tbPesquisa.BorderRadius = 8;
            tbPesquisa.CustomizableEdges = customizableEdges5;
            tbPesquisa.DefaultText = "";
            tbPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisa.FillColor = Color.FromArgb(40, 41, 52);
            tbPesquisa.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisa.Font = new Font("Segoe UI", 9F);
            tbPesquisa.ForeColor = Color.White;
            tbPesquisa.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisa.Location = new Point(378, 10);
            tbPesquisa.Margin = new Padding(3, 0, 10, 0);
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.PlaceholderForeColor = Color.Gray;
            tbPesquisa.PlaceholderText = "Digite para pesquisar...";
            tbPesquisa.SelectedText = "";
            tbPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbPesquisa.Size = new Size(235, 36);
            tbPesquisa.TabIndex = 7;
            // 
            // cbCondicao
            // 
            cbCondicao.BackColor = Color.Transparent;
            cbCondicao.BorderColor = Color.FromArgb(60, 62, 80);
            cbCondicao.BorderRadius = 8;
            cbCondicao.CustomizableEdges = customizableEdges7;
            cbCondicao.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FillColor = Color.FromArgb(40, 41, 52);
            cbCondicao.FocusedColor = Color.FromArgb(100, 150, 200);
            cbCondicao.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbCondicao.Font = new Font("Segoe UI", 9F);
            cbCondicao.ForeColor = Color.White;
            cbCondicao.ItemHeight = 30;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(195, 10);
            cbCondicao.Margin = new Padding(3, 0, 10, 0);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbCondicao.Size = new Size(170, 36);
            cbCondicao.TabIndex = 11;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackColor = Color.Transparent;
            cbPesquisaCampo.BorderColor = Color.FromArgb(60, 62, 80);
            cbPesquisaCampo.BorderRadius = 8;
            cbPesquisaCampo.CustomizableEdges = customizableEdges9;
            cbPesquisaCampo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FillColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.FocusedColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampo.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampo.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampo.ForeColor = Color.White;
            cbPesquisaCampo.ItemHeight = 30;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_Venda", "Nome_Funcionario", "Data_Hora", "Desconto", "Valor_Total" });
            cbPesquisaCampo.Location = new Point(13, 10);
            cbPesquisaCampo.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cbPesquisaCampo.Size = new Size(170, 36);
            cbPesquisaCampo.TabIndex = 12;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1597, 71);
            pnlHeader.TabIndex = 6;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1567, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerenciamento de Vendas";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1597, 707);
            ControlBox = false;
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormVendas";
            Text = "FormVendas";
            pnlContainer.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlDgv;
        private DataGridView dgvVendas;
        private Panel pnlBottom;
        private Label lbTotal;
        private Panel pnlFiltros;
        private Guna.UI2.WinForms.Guna2Button btnLimpar;
        private Guna.UI2.WinForms.Guna2Button btnPesquisar;
        private Guna.UI2.WinForms.Guna2TextBox tbPesquisa;
        private Guna.UI2.WinForms.Guna2ComboBox cbCondicao;
        private Guna.UI2.WinForms.Guna2ComboBox cbPesquisaCampo;
        private Panel pnlHeader;
        private Label lblTitulo;
    }
}