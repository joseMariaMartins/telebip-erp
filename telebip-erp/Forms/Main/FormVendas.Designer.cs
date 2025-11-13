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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendas));
            pnlContainer = new Panel();
            pnlDgv = new Panel();
            dgvVendas = new DataGridView();
            pnlBottom = new Panel();
            lbTotal = new Label();
            pnlFiltros = new Panel();
            btnLimpar = new CuoreUI.Controls.cuiButton();
            btnPesquisar = new CuoreUI.Controls.cuiButton();
            pnlWrapperPesquisa = new telebip_erp.Controls.RoundedPanel();
            picSearch = new PictureBox();
            tbPesquisa = new TextBox();
            pnlWrapperCondicao = new telebip_erp.Controls.RoundedPanel();
            panel3 = new Panel();
            panel7 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pnlWrapperCampo = new telebip_erp.Controls.RoundedPanel();
            pictureBox2 = new PictureBox();
            panel8 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            cbCondicao = new ComboBox();
            cbPesquisaCampo = new ComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            pnlBottom.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlWrapperPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlWrapperCondicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlWrapperCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            pnlDgv.Size = new Size(1597, 532);
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
            dgvVendas.Size = new Size(1567, 502);
            dgvVendas.TabIndex = 0;
            dgvVendas.CellDoubleClick += dgvVendas_CellDoubleClick;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lbTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 660);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1597, 47);
            pnlBottom.TabIndex = 5;
            // 
            // lbTotal
            // 
            lbTotal.Dock = DockStyle.Right;
            lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(1382, 15);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(200, 17);
            lbTotal.TabIndex = 0;
            lbTotal.Text = "Total: 0 vendas";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(btnPesquisar);
            pnlFiltros.Controls.Add(pnlWrapperPesquisa);
            pnlFiltros.Controls.Add(pnlWrapperCondicao);
            pnlFiltros.Controls.Add(pnlWrapperCampo);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 71);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10, 10, 10, 15);
            pnlFiltros.Size = new Size(1597, 57);
            pnlFiltros.TabIndex = 7;
            // 
            // btnLimpar
            // 
            btnLimpar.CheckButton = false;
            btnLimpar.Checked = false;
            btnLimpar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnLimpar.CheckedForeColor = Color.White;
            btnLimpar.CheckedImageTint = Color.White;
            btnLimpar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnLimpar.Content = "Limpar";
            btnLimpar.DialogResult = DialogResult.None;
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.HoverBackground = Color.White;
            btnLimpar.HoverForeColor = Color.Black;
            btnLimpar.HoverImageTint = Color.White;
            btnLimpar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLimpar.Image = null;
            btnLimpar.ImageAutoCenter = true;
            btnLimpar.ImageExpand = new Point(0, 0);
            btnLimpar.ImageOffset = new Point(0, 0);
            btnLimpar.Location = new Point(759, 10);
            btnLimpar.Margin = new Padding(3, 0, 10, 0);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.NormalBackground = Color.FromArgb(120, 40, 40);
            btnLimpar.NormalForeColor = Color.White;
            btnLimpar.NormalImageTint = Color.White;
            btnLimpar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimpar.OutlineThickness = 1F;
            btnLimpar.PressedBackground = Color.WhiteSmoke;
            btnLimpar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnLimpar.PressedImageTint = Color.White;
            btnLimpar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimpar.Rounding = new Padding(8);
            btnLimpar.Size = new Size(120, 36);
            btnLimpar.TabIndex = 14;
            btnLimpar.TextAlignment = StringAlignment.Center;
            btnLimpar.TextOffset = new Point(0, 0);
            // 
            // btnPesquisar
            // 
            btnPesquisar.CheckButton = false;
            btnPesquisar.Checked = false;
            btnPesquisar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnPesquisar.CheckedForeColor = Color.White;
            btnPesquisar.CheckedImageTint = Color.White;
            btnPesquisar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnPesquisar.Content = "Pesquisar";
            btnPesquisar.DialogResult = DialogResult.None;
            btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.HoverBackground = Color.White;
            btnPesquisar.HoverForeColor = Color.Black;
            btnPesquisar.HoverImageTint = Color.White;
            btnPesquisar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnPesquisar.Image = null;
            btnPesquisar.ImageAutoCenter = true;
            btnPesquisar.ImageExpand = new Point(0, 0);
            btnPesquisar.ImageOffset = new Point(0, 0);
            btnPesquisar.Location = new Point(626, 10);
            btnPesquisar.Margin = new Padding(3, 0, 10, 0);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnPesquisar.NormalForeColor = Color.White;
            btnPesquisar.NormalImageTint = Color.White;
            btnPesquisar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisar.OutlineThickness = 1F;
            btnPesquisar.PressedBackground = Color.WhiteSmoke;
            btnPesquisar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnPesquisar.PressedImageTint = Color.White;
            btnPesquisar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisar.Rounding = new Padding(8);
            btnPesquisar.Size = new Size(120, 36);
            btnPesquisar.TabIndex = 9;
            btnPesquisar.TextAlignment = StringAlignment.Center;
            btnPesquisar.TextOffset = new Point(0, 0);
            // 
            // pnlWrapperPesquisa
            // 
            pnlWrapperPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperPesquisa.BorderThickness = 1;
            pnlWrapperPesquisa.Controls.Add(picSearch);
            pnlWrapperPesquisa.Controls.Add(tbPesquisa);
            pnlWrapperPesquisa.CornerRadius = 8;
            pnlWrapperPesquisa.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.Location = new Point(378, 10);
            pnlWrapperPesquisa.Name = "pnlWrapperPesquisa";
            pnlWrapperPesquisa.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperPesquisa.Size = new Size(235, 36);
            pnlWrapperPesquisa.TabIndex = 7;
            // 
            // picSearch
            // 
            picSearch.BackColor = Color.Transparent;
            picSearch.Dock = DockStyle.Right;
            picSearch.Image = (Image)resources.GetObject("picSearch.Image");
            picSearch.Location = new Point(212, 6);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(15, 24);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 8;
            picSearch.TabStop = false;
            // 
            // tbPesquisa
            // 
            tbPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            tbPesquisa.BorderStyle = BorderStyle.None;
            tbPesquisa.Font = new Font("Segoe UI", 9F);
            tbPesquisa.ForeColor = Color.White;
            tbPesquisa.Location = new Point(8, 10);
            tbPesquisa.Margin = new Padding(3, 0, 10, 0);
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.Size = new Size(219, 16);
            tbPesquisa.TabIndex = 7;
            // 
            // pnlWrapperCondicao
            // 
            pnlWrapperCondicao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCondicao.BorderThickness = 1;
            pnlWrapperCondicao.Controls.Add(panel3);
            pnlWrapperCondicao.Controls.Add(panel7);
            pnlWrapperCondicao.Controls.Add(panel2);
            pnlWrapperCondicao.Controls.Add(pictureBox1);
            pnlWrapperCondicao.Controls.Add(panel1);
            pnlWrapperCondicao.Controls.Add(cbCondicao);
            pnlWrapperCondicao.CornerRadius = 8;
            pnlWrapperCondicao.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.Location = new Point(195, 10);
            pnlWrapperCondicao.Name = "pnlWrapperCondicao";
            pnlWrapperCondicao.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperCondicao.Size = new Size(170, 36);
            pnlWrapperCondicao.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(4, 30);
            panel3.TabIndex = 21;
            // 
            // panel7
            // 
            panel7.Location = new Point(158, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(6, 27);
            panel7.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Location = new Point(7, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(157, 7);
            panel2.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(143, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(6, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(159, 7);
            panel1.TabIndex = 17;
            // 
            // pnlWrapperCampo
            // 
            pnlWrapperCampo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCampo.BorderThickness = 1;
            pnlWrapperCampo.Controls.Add(pictureBox2);
            pnlWrapperCampo.Controls.Add(panel8);
            pnlWrapperCampo.Controls.Add(panel6);
            pnlWrapperCampo.Controls.Add(panel5);
            pnlWrapperCampo.Controls.Add(panel4);
            pnlWrapperCampo.Controls.Add(cbPesquisaCampo);
            pnlWrapperCampo.CornerRadius = 8;
            pnlWrapperCampo.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.Location = new Point(13, 10);
            pnlWrapperCampo.Name = "pnlWrapperCampo";
            pnlWrapperCampo.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperCampo.Size = new Size(170, 36);
            pnlWrapperCampo.TabIndex = 12;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(144, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(15, 10);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            // 
            // panel8
            // 
            panel8.Location = new Point(159, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(6, 27);
            panel8.TabIndex = 21;
            // 
            // panel6
            // 
            panel6.Location = new Point(8, 23);
            panel6.Name = "panel6";
            panel6.Size = new Size(157, 7);
            panel6.TabIndex = 24;
            // 
            // panel5
            // 
            panel5.Location = new Point(5, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(157, 7);
            panel5.TabIndex = 23;
            // 
            // panel4
            // 
            panel4.Location = new Point(8, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(4, 30);
            panel4.TabIndex = 22;
            // 
            // cbCondicao
            // 
            cbCondicao.BackColor = Color.FromArgb(40, 41, 52);
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FlatStyle = FlatStyle.Flat;
            cbCondicao.Font = new Font("Segoe UI", 9F);
            cbCondicao.ForeColor = Color.White;
            cbCondicao.FormattingEnabled = true;
            cbCondicao.Items.AddRange(new object[] { "Identico a", "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(8, 6);
            cbCondicao.Margin = new Padding(3, 0, 10, 0);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(154, 23);
            cbCondicao.TabIndex = 11;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FlatStyle = FlatStyle.Flat;
            cbPesquisaCampo.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampo.ForeColor = Color.White;
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID", "Funcionário", "Data", "Valor total", "Desconto" });
            cbPesquisaCampo.Location = new Point(8, 6);
            cbPesquisaCampo.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(154, 23);
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
            pnlWrapperPesquisa.ResumeLayout(false);
            pnlWrapperPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlWrapperCondicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlWrapperCampo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlDgv;
        public DataGridView dgvVendas;
        private Panel pnlBottom;
        private Label lbTotal;
        private Panel pnlFiltros;
        private CuoreUI.Controls.cuiButton btnLimpar;
        private CuoreUI.Controls.cuiButton btnPesquisar;

        // wrappers convertidos para RoundedPanel + controles WinForms
        private telebip_erp.Controls.RoundedPanel pnlWrapperCampo;
        private ComboBox cbPesquisaCampo;

        private telebip_erp.Controls.RoundedPanel pnlWrapperCondicao;
        private ComboBox cbCondicao;

        private telebip_erp.Controls.RoundedPanel pnlWrapperPesquisa;
        private TextBox tbPesquisa;

        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox picSearch;
        private Panel panel7;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Panel panel8;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
    }
}
