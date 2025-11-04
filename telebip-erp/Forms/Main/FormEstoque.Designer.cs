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
            btnLimpar = new CuoreUI.Controls.cuiButton();
            btnPesquisar = new CuoreUI.Controls.cuiButton();
            pnlWrapperCampo = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            picArrowCampo = new PictureBox();
            cbPesquisaCampo = new ComboBox();
            pnlWrapperCondicao = new Panel();
            picArrowCondicao = new PictureBox();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            cbCondicao = new ComboBox();
            pnlWrapperPesquisa = new Panel();
            picSearch = new PictureBox();
            tbPesquisa = new TextBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            pnlBottom.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlWrapperCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picArrowCampo).BeginInit();
            pnlWrapperCondicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picArrowCondicao).BeginInit();
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
            pnlDgv.Size = new Size(1358, 430);
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
            dgvEstoque.Size = new Size(1328, 400);
            dgvEstoque.TabIndex = 0;
            dgvEstoque.CellDoubleClick += DgvEstoque_CellDoubleClick;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lbTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 556);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1358, 104);
            pnlBottom.TabIndex = 5;
            // 
            // lbTotal
            // 
            lbTotal.Dock = DockStyle.Right;
            lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(1143, 15);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(200, 74);
            lbTotal.TabIndex = 0;
            lbTotal.Text = "Total: 0 produtos";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(btnPesquisar);
            pnlFiltros.Controls.Add(pnlWrapperCampo);
            pnlFiltros.Controls.Add(pnlWrapperCondicao);
            pnlFiltros.Controls.Add(pnlWrapperPesquisa);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 71);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10, 10, 10, 15);
            pnlFiltros.Size = new Size(1358, 55);
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
            // pnlWrapperCampo
            // 
            pnlWrapperCampo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.Controls.Add(panel6);
            pnlWrapperCampo.Controls.Add(panel5);
            pnlWrapperCampo.Controls.Add(panel4);
            pnlWrapperCampo.Controls.Add(picArrowCampo);
            pnlWrapperCampo.Controls.Add(cbPesquisaCampo);
            pnlWrapperCampo.Location = new Point(13, 10);
            pnlWrapperCampo.Name = "pnlWrapperCampo";
            pnlWrapperCampo.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCampo.Size = new Size(169, 36);
            pnlWrapperCampo.TabIndex = 50;
            // 
            // panel6
            // 
            panel6.Location = new Point(5, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(157, 4);
            panel6.TabIndex = 15;
            // 
            // panel5
            // 
            panel5.Location = new Point(6, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(4, 30);
            panel5.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.Location = new Point(6, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(157, 6);
            panel4.TabIndex = 13;
            // 
            // picArrowCampo
            // 
            picArrowCampo.BackColor = Color.FromArgb(40, 41, 52);
            picArrowCampo.Location = new Point(141, 6);
            picArrowCampo.Name = "picArrowCampo";
            picArrowCampo.Size = new Size(24, 24);
            picArrowCampo.SizeMode = PictureBoxSizeMode.CenterImage;
            picArrowCampo.TabIndex = 1;
            picArrowCampo.TabStop = false;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.FlatStyle = FlatStyle.Flat;
            cbPesquisaCampo.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampo.ForeColor = Color.White;
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID", "Nome", "Marca", "Preço", "Qtd do estoque", "Qtd de aviso", "Observação" });
            cbPesquisaCampo.Location = new Point(8, 6);
            cbPesquisaCampo.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(156, 24);
            cbPesquisaCampo.TabIndex = 12;
            // 
            // pnlWrapperCondicao
            // 
            pnlWrapperCondicao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.Controls.Add(picArrowCondicao);
            pnlWrapperCondicao.Controls.Add(panel3);
            pnlWrapperCondicao.Controls.Add(panel2);
            pnlWrapperCondicao.Controls.Add(panel1);
            pnlWrapperCondicao.Controls.Add(cbCondicao);
            pnlWrapperCondicao.Location = new Point(195, 10);
            pnlWrapperCondicao.Name = "pnlWrapperCondicao";
            pnlWrapperCondicao.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCondicao.Size = new Size(169, 36);
            pnlWrapperCondicao.TabIndex = 51;
            // 
            // picArrowCondicao
            // 
            picArrowCondicao.BackColor = Color.FromArgb(40, 41, 52);
            picArrowCondicao.ErrorImage = (Image)resources.GetObject("picArrowCondicao.ErrorImage");
            picArrowCondicao.Location = new Point(140, 6);
            picArrowCondicao.Name = "picArrowCondicao";
            picArrowCondicao.Size = new Size(24, 24);
            picArrowCondicao.SizeMode = PictureBoxSizeMode.Zoom;
            picArrowCondicao.TabIndex = 1;
            picArrowCondicao.TabStop = false;
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(4, 30);
            panel3.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Location = new Point(7, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(157, 4);
            panel2.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Location = new Point(6, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(157, 6);
            panel1.TabIndex = 12;
            // 
            // cbCondicao
            // 
            cbCondicao.BackColor = Color.FromArgb(40, 41, 52);
            cbCondicao.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.FlatStyle = FlatStyle.Flat;
            cbCondicao.Font = new Font("Segoe UI", 9F);
            cbCondicao.ForeColor = Color.White;
            cbCondicao.FormattingEnabled = true;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(8, 6);
            cbCondicao.Margin = new Padding(3, 0, 10, 0);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(156, 24);
            cbCondicao.TabIndex = 11;
            // 
            // pnlWrapperPesquisa
            // 
            pnlWrapperPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.Controls.Add(picSearch);
            pnlWrapperPesquisa.Controls.Add(tbPesquisa);
            pnlWrapperPesquisa.Location = new Point(377, 10);
            pnlWrapperPesquisa.Name = "pnlWrapperPesquisa";
            pnlWrapperPesquisa.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperPesquisa.Size = new Size(235, 36);
            pnlWrapperPesquisa.TabIndex = 52;
            // 
            // picSearch
            // 
            picSearch.BackColor = Color.Transparent;
            picSearch.Dock = DockStyle.Right;
            picSearch.Location = new Point(203, 6);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(24, 24);
            picSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picSearch.TabIndex = 1;
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
            Text = "FormEstoque";
            pnlContainer.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlWrapperCampo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picArrowCampo).EndInit();
            pnlWrapperCondicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picArrowCondicao).EndInit();
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

        // novos wrappers e controles para "maquiagem"
        private System.Windows.Forms.Panel pnlWrapperCampo;
        private System.Windows.Forms.PictureBox picArrowCampo;
        private System.Windows.Forms.ComboBox cbPesquisaCampo;

        private System.Windows.Forms.Panel pnlWrapperCondicao;
        private System.Windows.Forms.PictureBox picArrowCondicao;
        private System.Windows.Forms.ComboBox cbCondicao;

        private System.Windows.Forms.Panel pnlWrapperPesquisa;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox tbPesquisa;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel6;
    }
}