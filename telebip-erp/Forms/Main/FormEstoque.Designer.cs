namespace telebip_erp.Forms.Modules
{
    partial class FormEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstoque));
            pnlContainer = new Panel();
            pnlDgv = new Panel();
            dgvEstoque = new DataGridView();
            pnlBottom = new Panel();
            lbTotal = new Label();
            pnlFiltros = new Panel();
            pnlWrapperCampo = new telebip_erp.Controls.RoundedPanel();
            cbPesquisaCampo = new telebip_erp.Controls.NeoFlatComboBox();
            PictureImage2 = new PictureBox();
            pnlWrapperCondicao = new telebip_erp.Controls.RoundedPanel();
            cbCondicao = new telebip_erp.Controls.NeoFlatComboBox();
            pictureBox1 = new PictureBox();
            pnlWrapperPesquisa = new telebip_erp.Controls.RoundedPanel();
            tbPesquisa = new TextBox();
            picSearch = new PictureBox();
            btnLimpar = new CuoreUI.Controls.cuiButton();
            btnPesquisar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            pnlBottom.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlWrapperCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureImage2).BeginInit();
            pnlWrapperCondicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlWrapperPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
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
            pnlContainer.Size = new Size(1358, 660);
            pnlContainer.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.FromArgb(28, 29, 40);
            pnlDgv.Controls.Add(dgvEstoque);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 126);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1358, 485);
            pnlDgv.TabIndex = 4;
            // 
            // dgvEstoque
            // 
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEstoque.ColumnHeadersHeight = 40;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEstoque.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEstoque.Dock = DockStyle.Fill;
            dgvEstoque.EnableHeadersVisualStyles = false;
            dgvEstoque.GridColor = Color.FromArgb(50, 52, 67);
            dgvEstoque.Location = new Point(15, 15);
            dgvEstoque.MultiSelect = false;
            dgvEstoque.Name = "dgvEstoque";
            dgvEstoque.ReadOnly = true;
            dgvEstoque.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvEstoque.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvEstoque.RowTemplate.Height = 36;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.Size = new Size(1328, 455);
            dgvEstoque.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lbTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 611);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1358, 49);
            pnlBottom.TabIndex = 5;
            // 
            // lbTotal
            // 
            lbTotal.Dock = DockStyle.Right;
            lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(1143, 15);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(200, 19);
            lbTotal.TabIndex = 0;
            lbTotal.Text = "Total: 0 produtos";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(pnlWrapperCampo);
            pnlFiltros.Controls.Add(pnlWrapperCondicao);
            pnlFiltros.Controls.Add(pnlWrapperPesquisa);
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(btnPesquisar);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 71);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10, 10, 10, 15);
            pnlFiltros.Size = new Size(1358, 55);
            pnlFiltros.TabIndex = 7;
            // 
            // pnlWrapperCampo
            // 
            pnlWrapperCampo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCampo.BorderThickness = 1;
            pnlWrapperCampo.Controls.Add(cbPesquisaCampo);
            pnlWrapperCampo.Controls.Add(PictureImage2);
            pnlWrapperCampo.CornerRadius = 8;
            pnlWrapperCampo.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.Location = new Point(13, 10);
            pnlWrapperCampo.Name = "pnlWrapperCampo";
            pnlWrapperCampo.Size = new Size(150, 36);
            pnlWrapperCampo.TabIndex = 18;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.AutoSelectFirst = false;
            cbPesquisaCampo.BackColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FlatStyle = FlatStyle.Flat;
            cbPesquisaCampo.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampo.ForeColor = Color.White;
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.ItemEntryHeight = 24;
            cbPesquisaCampo.ItemHeight = 24;
            cbPesquisaCampo.Location = new Point(8, 6);
            cbPesquisaCampo.Margin = new Padding(0);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Placeholder = "Selecione...";
            cbPesquisaCampo.ShowPlaceholder = true;
            cbPesquisaCampo.Size = new Size(120, 30);
            cbPesquisaCampo.TabIndex = 0;
            // 
            // PictureImage2
            // 
            PictureImage2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureImage2.Image = (Image)resources.GetObject("PictureImage2.Image");
            PictureImage2.Location = new Point(128, 11);
            PictureImage2.Name = "PictureImage2";
            PictureImage2.Size = new Size(15, 15);
            PictureImage2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureImage2.TabIndex = 17;
            PictureImage2.TabStop = false;
            // 
            // pnlWrapperCondicao
            // 
            pnlWrapperCondicao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCondicao.BorderThickness = 1;
            pnlWrapperCondicao.Controls.Add(cbCondicao);
            pnlWrapperCondicao.Controls.Add(pictureBox1);
            pnlWrapperCondicao.CornerRadius = 8;
            pnlWrapperCondicao.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.Location = new Point(169, 10);
            pnlWrapperCondicao.Name = "pnlWrapperCondicao";
            pnlWrapperCondicao.Size = new Size(150, 36);
            pnlWrapperCondicao.TabIndex = 19;
            // 
            // cbCondicao
            // 
            cbCondicao.AutoSelectFirst = false;
            cbCondicao.BackColor = Color.FromArgb(40, 41, 52);
            cbCondicao.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FlatStyle = FlatStyle.Flat;
            cbCondicao.Font = new Font("Segoe UI", 9F);
            cbCondicao.ForeColor = Color.White;
            cbCondicao.FormattingEnabled = true;
            cbCondicao.ItemEntryHeight = 24;
            cbCondicao.ItemHeight = 24;
            cbCondicao.Location = new Point(8, 3);
            cbCondicao.Margin = new Padding(0);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Placeholder = "Selecione...";
            cbCondicao.ShowPlaceholder = true;
            cbCondicao.Size = new Size(120, 30);
            cbCondicao.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(128, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pnlWrapperPesquisa
            // 
            pnlWrapperPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperPesquisa.BorderThickness = 1;
            pnlWrapperPesquisa.Controls.Add(tbPesquisa);
            pnlWrapperPesquisa.Controls.Add(picSearch);
            pnlWrapperPesquisa.CornerRadius = 8;
            pnlWrapperPesquisa.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.Location = new Point(325, 10);
            pnlWrapperPesquisa.Name = "pnlWrapperPesquisa";
            pnlWrapperPesquisa.Size = new Size(295, 36);
            pnlWrapperPesquisa.TabIndex = 20;
            // 
            // tbPesquisa
            // 
            tbPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            tbPesquisa.BorderStyle = BorderStyle.None;
            tbPesquisa.Font = new Font("Segoe UI", 9F);
            tbPesquisa.ForeColor = Color.White;
            tbPesquisa.Location = new Point(10, 10);
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.Size = new Size(260, 16);
            tbPesquisa.TabIndex = 2;
            // 
            // picSearch
            // 
            picSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picSearch.BackColor = Color.Transparent;
            picSearch.Image = (Image)resources.GetObject("picSearch.Image");
            picSearch.Location = new Point(270, 9);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(15, 15);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 1;
            picSearch.TabStop = false;
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
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1358, 71);
            pnlHeader.TabIndex = 6;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1328, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerenciamento de Estoque";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1358, 660);
            ControlBox = false;
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEstoque";
            pnlContainer.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlWrapperCampo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureImage2).EndInit();
            pnlWrapperCondicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlWrapperPesquisa.ResumeLayout(false);
            pnlWrapperPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlDgv;
        public System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Panel pnlFiltros;
        private CuoreUI.Controls.cuiButton btnLimpar;
        private CuoreUI.Controls.cuiButton btnPesquisar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;

        // Controles customizados
        private telebip_erp.Controls.RoundedPanel pnlWrapperCampo;
        private telebip_erp.Controls.NeoFlatComboBox cbPesquisaCampo;
        private System.Windows.Forms.PictureBox PictureImage2;
        private telebip_erp.Controls.RoundedPanel pnlWrapperCondicao;
        private telebip_erp.Controls.NeoFlatComboBox cbCondicao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private telebip_erp.Controls.RoundedPanel pnlWrapperPesquisa;
        private System.Windows.Forms.TextBox tbPesquisa;
        private System.Windows.Forms.PictureBox picSearch;
    }
}