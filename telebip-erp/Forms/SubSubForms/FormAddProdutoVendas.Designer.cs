using System;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Controls;
using CuoreUI.Controls;

namespace telebip_erp.Forms.SubSubForms
{
    partial class FormAddProdutoVendas
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProdutoVendas));
            pnlContainer = new Panel();
            pnlMain = new Panel();
            dgvProdutosMini = new DataGridView();
            pnlPesquisa = new Panel();
            btnLimparMini = new cuiButton();
            btnPesquisarMini = new cuiButton();
            pnlWrapperPesquisa = new RoundedPanel();
            picSearch = new PictureBox();
            tbPesquisaMini = new TextBox();
            pnlWrapperCondicao = new RoundedPanel();
            panelCondTop = new Panel();
            panelCondLeft = new Panel();
            picCond = new PictureBox();
            panelCondBottom = new Panel();
            cbCondicaoMini = new ComboBox();
            pnlWrapperCampo = new RoundedPanel();
            panelCampoTop = new Panel();
            picCampo = new PictureBox();
            panelCampoLeft = new Panel();
            panelCampoBottom = new Panel();
            cbPesquisaCampoMini = new ComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).BeginInit();
            pnlPesquisa.SuspendLayout();
            pnlWrapperPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlWrapperCondicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCond).BeginInit();
            pnlWrapperCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCampo).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlMain);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(3, 24);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(829, 405);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(dgvProdutosMini);
            pnlMain.Controls.Add(pnlPesquisa);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(829, 345);
            pnlMain.TabIndex = 1;
            // 
            // dgvProdutosMini
            // 
            dgvProdutosMini.AllowUserToAddRows = false;
            dgvProdutosMini.AllowUserToDeleteRows = false;
            dgvProdutosMini.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvProdutosMini.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProdutosMini.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvProdutosMini.BorderStyle = BorderStyle.None;
            dgvProdutosMini.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProdutosMini.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProdutosMini.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProdutosMini.ColumnHeadersHeight = 35;
            dgvProdutosMini.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProdutosMini.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProdutosMini.Dock = DockStyle.Fill;
            dgvProdutosMini.EnableHeadersVisualStyles = false;
            dgvProdutosMini.GridColor = Color.FromArgb(50, 52, 67);
            dgvProdutosMini.Location = new Point(20, 81);
            dgvProdutosMini.MultiSelect = false;
            dgvProdutosMini.Name = "dgvProdutosMini";
            dgvProdutosMini.ReadOnly = true;
            dgvProdutosMini.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProdutosMini.RowHeadersVisible = false;
            dgvProdutosMini.RowHeadersWidth = 62;
            dgvProdutosMini.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProdutosMini.RowTemplate.Height = 30;
            dgvProdutosMini.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutosMini.Size = new Size(789, 244);
            dgvProdutosMini.TabIndex = 20;
            // 
            // pnlPesquisa
            // 
            pnlPesquisa.BackColor = Color.FromArgb(32, 33, 39);
            pnlPesquisa.Controls.Add(btnLimparMini);
            pnlPesquisa.Controls.Add(btnPesquisarMini);
            pnlPesquisa.Controls.Add(pnlWrapperPesquisa);
            pnlPesquisa.Controls.Add(pnlWrapperCondicao);
            pnlPesquisa.Controls.Add(pnlWrapperCampo);
            pnlPesquisa.Dock = DockStyle.Top;
            pnlPesquisa.Location = new Point(20, 20);
            pnlPesquisa.Name = "pnlPesquisa";
            pnlPesquisa.Padding = new Padding(10);
            pnlPesquisa.Size = new Size(789, 61);
            pnlPesquisa.TabIndex = 19;
            // 
            // btnLimparMini
            // 
            btnLimparMini.CheckButton = false;
            btnLimparMini.Checked = false;
            btnLimparMini.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnLimparMini.CheckedForeColor = Color.White;
            btnLimparMini.CheckedImageTint = Color.White;
            btnLimparMini.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnLimparMini.Content = "Limpar";
            btnLimparMini.DialogResult = DialogResult.None;
            btnLimparMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimparMini.ForeColor = Color.White;
            btnLimparMini.HoverBackground = Color.White;
            btnLimparMini.HoverForeColor = Color.Black;
            btnLimparMini.HoverImageTint = Color.White;
            btnLimparMini.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLimparMini.Image = null;
            btnLimparMini.ImageAutoCenter = true;
            btnLimparMini.ImageExpand = new Point(0, 0);
            btnLimparMini.ImageOffset = new Point(0, 0);
            btnLimparMini.Location = new Point(700, 12);
            btnLimparMini.Margin = new Padding(3, 0, 10, 0);
            btnLimparMini.Name = "btnLimparMini";
            btnLimparMini.NormalBackground = Color.FromArgb(120, 40, 40);
            btnLimparMini.NormalForeColor = Color.White;
            btnLimparMini.NormalImageTint = Color.White;
            btnLimparMini.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimparMini.OutlineThickness = 1F;
            btnLimparMini.PressedBackground = Color.WhiteSmoke;
            btnLimparMini.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnLimparMini.PressedImageTint = Color.White;
            btnLimparMini.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimparMini.Rounding = new Padding(8);
            btnLimparMini.Size = new Size(79, 36);
            btnLimparMini.TabIndex = 21;
            btnLimparMini.TextAlignment = StringAlignment.Center;
            btnLimparMini.TextOffset = new Point(0, 0);
            // 
            // btnPesquisarMini
            // 
            btnPesquisarMini.CheckButton = false;
            btnPesquisarMini.Checked = false;
            btnPesquisarMini.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnPesquisarMini.CheckedForeColor = Color.White;
            btnPesquisarMini.CheckedImageTint = Color.White;
            btnPesquisarMini.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnPesquisarMini.Content = "Pesquisar";
            btnPesquisarMini.DialogResult = DialogResult.None;
            btnPesquisarMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisarMini.ForeColor = Color.White;
            btnPesquisarMini.HoverBackground = Color.White;
            btnPesquisarMini.HoverForeColor = Color.Black;
            btnPesquisarMini.HoverImageTint = Color.White;
            btnPesquisarMini.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnPesquisarMini.Image = null;
            btnPesquisarMini.ImageAutoCenter = true;
            btnPesquisarMini.ImageExpand = new Point(0, 0);
            btnPesquisarMini.ImageOffset = new Point(0, 0);
            btnPesquisarMini.Location = new Point(617, 12);
            btnPesquisarMini.Margin = new Padding(3, 0, 10, 0);
            btnPesquisarMini.Name = "btnPesquisarMini";
            btnPesquisarMini.NormalBackground = Color.FromArgb(40, 120, 80);
            btnPesquisarMini.NormalForeColor = Color.White;
            btnPesquisarMini.NormalImageTint = Color.White;
            btnPesquisarMini.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisarMini.OutlineThickness = 1F;
            btnPesquisarMini.PressedBackground = Color.WhiteSmoke;
            btnPesquisarMini.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnPesquisarMini.PressedImageTint = Color.White;
            btnPesquisarMini.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisarMini.Rounding = new Padding(8);
            btnPesquisarMini.Size = new Size(79, 36);
            btnPesquisarMini.TabIndex = 20;
            btnPesquisarMini.TextAlignment = StringAlignment.Center;
            btnPesquisarMini.TextOffset = new Point(0, 0);
            // 
            // pnlWrapperPesquisa
            // 
            pnlWrapperPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperPesquisa.BorderThickness = 1;
            pnlWrapperPesquisa.Controls.Add(picSearch);
            pnlWrapperPesquisa.Controls.Add(tbPesquisaMini);
            pnlWrapperPesquisa.CornerRadius = 8;
            pnlWrapperPesquisa.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPesquisa.Location = new Point(366, 12);
            pnlWrapperPesquisa.Name = "pnlWrapperPesquisa";
            pnlWrapperPesquisa.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperPesquisa.Size = new Size(224, 36);
            pnlWrapperPesquisa.TabIndex = 19;
            // 
            // picSearch
            // 
            picSearch.BackColor = Color.Transparent;
            picSearch.Dock = DockStyle.Right;
            picSearch.Image = (Image)resources.GetObject("picSearch.Image");
            picSearch.Location = new Point(201, 6);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(15, 24);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 1;
            picSearch.TabStop = false;
            // 
            // tbPesquisaMini
            // 
            tbPesquisaMini.BackColor = Color.FromArgb(40, 41, 52);
            tbPesquisaMini.BorderStyle = BorderStyle.None;
            tbPesquisaMini.Font = new Font("Segoe UI", 9F);
            tbPesquisaMini.ForeColor = Color.White;
            tbPesquisaMini.Location = new Point(8, 10);
            tbPesquisaMini.Margin = new Padding(3, 0, 10, 0);
            tbPesquisaMini.Name = "tbPesquisaMini";
            tbPesquisaMini.PlaceholderText = "Digite para pesquisar...";
            tbPesquisaMini.Size = new Size(196, 16);
            tbPesquisaMini.TabIndex = 19;
            // 
            // pnlWrapperCondicao
            // 
            pnlWrapperCondicao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCondicao.BorderThickness = 1;
            pnlWrapperCondicao.Controls.Add(panelCondTop);
            pnlWrapperCondicao.Controls.Add(panelCondLeft);
            pnlWrapperCondicao.Controls.Add(picCond);
            pnlWrapperCondicao.Controls.Add(panelCondBottom);
            pnlWrapperCondicao.Controls.Add(cbCondicaoMini);
            pnlWrapperCondicao.CornerRadius = 8;
            pnlWrapperCondicao.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.Location = new Point(189, 12);
            pnlWrapperCondicao.Name = "pnlWrapperCondicao";
            pnlWrapperCondicao.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCondicao.Size = new Size(160, 36);
            pnlWrapperCondicao.TabIndex = 18;
            // 
            // panelCondTop
            // 
            panelCondTop.Location = new Point(7, 6);
            panelCondTop.Name = "panelCondTop";
            panelCondTop.Size = new Size(150, 7);
            panelCondTop.TabIndex = 0;
            // 
            // panelCondLeft
            // 
            panelCondLeft.Location = new Point(6, 3);
            panelCondLeft.Name = "panelCondLeft";
            panelCondLeft.Size = new Size(4, 30);
            panelCondLeft.TabIndex = 1;
            // 
            // picCond
            // 
            picCond.BackColor = Color.Transparent;
            picCond.Location = new Point(128, 13);
            picCond.Name = "picCond";
            picCond.Size = new Size(27, 10);
            picCond.SizeMode = PictureBoxSizeMode.Zoom;
            picCond.TabIndex = 15;
            picCond.TabStop = false;
            // 
            // panelCondBottom
            // 
            panelCondBottom.Location = new Point(6, 23);
            panelCondBottom.Name = "panelCondBottom";
            panelCondBottom.Size = new Size(150, 7);
            panelCondBottom.TabIndex = 16;
            // 
            // cbCondicaoMini
            // 
            cbCondicaoMini.BackColor = Color.FromArgb(40, 41, 52);
            cbCondicaoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicaoMini.FlatStyle = FlatStyle.Flat;
            cbCondicaoMini.Font = new Font("Segoe UI", 9F);
            cbCondicaoMini.ForeColor = Color.White;
            cbCondicaoMini.FormattingEnabled = true;
            cbCondicaoMini.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicaoMini.Location = new Point(8, 6);
            cbCondicaoMini.Margin = new Padding(3, 0, 10, 0);
            cbCondicaoMini.Name = "cbCondicaoMini";
            cbCondicaoMini.Size = new Size(144, 24);
            cbCondicaoMini.TabIndex = 18;
            // 
            // pnlWrapperCampo
            // 
            pnlWrapperCampo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCampo.BorderThickness = 1;
            pnlWrapperCampo.Controls.Add(panelCampoTop);
            pnlWrapperCampo.Controls.Add(picCampo);
            pnlWrapperCampo.Controls.Add(panelCampoLeft);
            pnlWrapperCampo.Controls.Add(panelCampoBottom);
            pnlWrapperCampo.Controls.Add(cbPesquisaCampoMini);
            pnlWrapperCampo.CornerRadius = 8;
            pnlWrapperCampo.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.Location = new Point(13, 12);
            pnlWrapperCampo.Name = "pnlWrapperCampo";
            pnlWrapperCampo.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCampo.Size = new Size(160, 36);
            pnlWrapperCampo.TabIndex = 17;
            // 
            // panelCampoTop
            // 
            panelCampoTop.Location = new Point(5, 6);
            panelCampoTop.Name = "panelCampoTop";
            panelCampoTop.Size = new Size(150, 7);
            panelCampoTop.TabIndex = 0;
            // 
            // picCampo
            // 
            picCampo.BackColor = Color.Transparent;
            picCampo.Location = new Point(133, 13);
            picCampo.Name = "picCampo";
            picCampo.Size = new Size(23, 10);
            picCampo.SizeMode = PictureBoxSizeMode.Zoom;
            picCampo.TabIndex = 16;
            picCampo.TabStop = false;
            // 
            // panelCampoLeft
            // 
            panelCampoLeft.Location = new Point(6, 3);
            panelCampoLeft.Name = "panelCampoLeft";
            panelCampoLeft.Size = new Size(4, 30);
            panelCampoLeft.TabIndex = 17;
            // 
            // panelCampoBottom
            // 
            panelCampoBottom.Location = new Point(6, 23);
            panelCampoBottom.Name = "panelCampoBottom";
            panelCampoBottom.Size = new Size(150, 7);
            panelCampoBottom.TabIndex = 18;
            // 
            // cbPesquisaCampoMini
            // 
            cbPesquisaCampoMini.BackColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampoMini.FlatStyle = FlatStyle.Flat;
            cbPesquisaCampoMini.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampoMini.ForeColor = Color.White;
            cbPesquisaCampoMini.FormattingEnabled = true;
            cbPesquisaCampoMini.Items.AddRange(new object[] { "ID", "Nome", "Marca", "Preço", "Qtd do estoque", "Qtd de aviso", "Observação" });
            cbPesquisaCampoMini.Location = new Point(8, 6);
            cbPesquisaCampoMini.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampoMini.Name = "cbPesquisaCampoMini";
            cbPesquisaCampoMini.Size = new Size(144, 24);
            cbPesquisaCampoMini.TabIndex = 17;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(829, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(799, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecionar Produto";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddProdutoVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(835, 432);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(835, 432);
            MinimumSize = new Size(835, 432);
            Name = "FormAddProdutoVendas";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddProdutoVendas";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).EndInit();
            pnlPesquisa.ResumeLayout(false);
            pnlWrapperPesquisa.ResumeLayout(false);
            pnlWrapperPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlWrapperCondicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCond).EndInit();
            pnlWrapperCampo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCampo).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Designer fields
        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;

        private Panel pnlPesquisa;
        private DataGridView dgvProdutosMini;

        // Converted buttons
        private cuiButton btnLimparMini;
        private cuiButton btnPesquisarMini;

        // Wrappers and child controls (padrão FormEstoque)
        private RoundedPanel pnlWrapperCampo;
        private Panel panelCampoTop;
        private PictureBox picCampo;
        private Panel panelCampoLeft;
        private Panel panelCampoBottom;
        private ComboBox cbPesquisaCampoMini;

        private RoundedPanel pnlWrapperCondicao;
        private Panel panelCondTop;
        private Panel panelCondLeft;
        private PictureBox picCond;
        private Panel panelCondBottom;
        private ComboBox cbCondicaoMini;

        private RoundedPanel pnlWrapperPesquisa;
        private PictureBox picSearch;
        public TextBox tbPesquisaMini;

    }
}
