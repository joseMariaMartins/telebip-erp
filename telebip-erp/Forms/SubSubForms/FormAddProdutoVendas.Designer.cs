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
            tbPesquisaMini = new PlaceholderTextBox();
            pnlWrapperCondicao = new RoundedPanel();
            pictureBox2 = new PictureBox();
            cbCondicaoMini = new NeoFlatComboBox();
            pnlWrapperCampo = new RoundedPanel();
            pictureBox1 = new PictureBox();
            cbPesquisaCampoMini = new NeoFlatComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).BeginInit();
            pnlPesquisa.SuspendLayout();
            pnlWrapperPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlWrapperCondicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlWrapperCampo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            pnlContainer.Size = new Size(894, 473);
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
            pnlMain.Size = new Size(894, 413);
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
            dgvProdutosMini.Size = new Size(854, 312);
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
            pnlPesquisa.Size = new Size(854, 61);
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
            btnLimparMini.HoverBackground = Color.FromArgb(150, 60, 60);
            btnLimparMini.HoverForeColor = Color.White;
            btnLimparMini.HoverImageTint = Color.White;
            btnLimparMini.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLimparMini.Image = null;
            btnLimparMini.ImageAutoCenter = true;
            btnLimparMini.ImageExpand = new Point(0, 0);
            btnLimparMini.ImageOffset = new Point(0, 0);
            btnLimparMini.Location = new Point(727, 12);
            btnLimparMini.Margin = new Padding(3, 0, 10, 0);
            btnLimparMini.Name = "btnLimparMini";
            btnLimparMini.NormalBackground = Color.FromArgb(120, 40, 40);
            btnLimparMini.NormalForeColor = Color.White;
            btnLimparMini.NormalImageTint = Color.White;
            btnLimparMini.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimparMini.OutlineThickness = 1F;
            btnLimparMini.PressedBackground = Color.FromArgb(90, 30, 30);
            btnLimparMini.PressedForeColor = Color.White;
            btnLimparMini.PressedImageTint = Color.White;
            btnLimparMini.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimparMini.Rounding = new Padding(8);
            btnLimparMini.Size = new Size(100, 36);
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
            btnPesquisarMini.HoverBackground = Color.FromArgb(50, 150, 100);
            btnPesquisarMini.HoverForeColor = Color.White;
            btnPesquisarMini.HoverImageTint = Color.White;
            btnPesquisarMini.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnPesquisarMini.Image = null;
            btnPesquisarMini.ImageAutoCenter = true;
            btnPesquisarMini.ImageExpand = new Point(0, 0);
            btnPesquisarMini.ImageOffset = new Point(0, 0);
            btnPesquisarMini.Location = new Point(614, 12);
            btnPesquisarMini.Margin = new Padding(3, 0, 10, 0);
            btnPesquisarMini.Name = "btnPesquisarMini";
            btnPesquisarMini.NormalBackground = Color.FromArgb(40, 120, 80);
            btnPesquisarMini.NormalForeColor = Color.White;
            btnPesquisarMini.NormalImageTint = Color.White;
            btnPesquisarMini.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisarMini.OutlineThickness = 1F;
            btnPesquisarMini.PressedBackground = Color.FromArgb(30, 100, 70);
            btnPesquisarMini.PressedForeColor = Color.White;
            btnPesquisarMini.PressedImageTint = Color.White;
            btnPesquisarMini.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnPesquisarMini.Rounding = new Padding(8);
            btnPesquisarMini.Size = new Size(100, 36);
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
            tbPesquisaMini.Placeholder = "Digite para pesquisar...";
            tbPesquisaMini.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbPesquisaMini.Size = new Size(196, 16);
            tbPesquisaMini.TabIndex = 19;
            // 
            // pnlWrapperCondicao
            // 
            pnlWrapperCondicao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCondicao.BorderThickness = 1;
            pnlWrapperCondicao.Controls.Add(pictureBox2);
            pnlWrapperCondicao.Controls.Add(cbCondicaoMini);
            pnlWrapperCondicao.CornerRadius = 8;
            pnlWrapperCondicao.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCondicao.Location = new Point(189, 12);
            pnlWrapperCondicao.Name = "pnlWrapperCondicao";
            pnlWrapperCondicao.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCondicao.Size = new Size(160, 36);
            pnlWrapperCondicao.TabIndex = 18;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(131, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(10, 10);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            // 
            // cbCondicaoMini
            // 
            cbCondicaoMini.AutoSelectFirst = false;
            cbCondicaoMini.BackColor = Color.FromArgb(40, 41, 52);
            cbCondicaoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicaoMini.FlatStyle = FlatStyle.Flat;
            cbCondicaoMini.Font = new Font("Segoe UI", 8F);
            cbCondicaoMini.ForeColor = Color.White;
            cbCondicaoMini.FormattingEnabled = true;
            cbCondicaoMini.ItemEntryHeight = 30;
            cbCondicaoMini.ItemHeight = 13;
            cbCondicaoMini.Items.AddRange(new object[] { "Identico a", "Inicia com", "Contendo", "Diferente de" });
            cbCondicaoMini.Location = new Point(8, 9);
            cbCondicaoMini.Margin = new Padding(3, 0, 10, 0);
            cbCondicaoMini.Name = "cbCondicaoMini";
            cbCondicaoMini.Placeholder = "Selecione...";
            cbCondicaoMini.ShowPlaceholder = true;
            cbCondicaoMini.Size = new Size(144, 19);
            cbCondicaoMini.TabIndex = 18;
            // 
            // pnlWrapperCampo
            // 
            pnlWrapperCampo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperCampo.BorderThickness = 1;
            pnlWrapperCampo.Controls.Add(pictureBox1);
            pnlWrapperCampo.Controls.Add(cbPesquisaCampoMini);
            pnlWrapperCampo.CornerRadius = 8;
            pnlWrapperCampo.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperCampo.Location = new Point(13, 12);
            pnlWrapperCampo.Name = "pnlWrapperCampo";
            pnlWrapperCampo.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperCampo.Size = new Size(160, 36);
            pnlWrapperCampo.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(131, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // cbPesquisaCampoMini
            // 
            cbPesquisaCampoMini.AutoSelectFirst = false;
            cbPesquisaCampoMini.BackColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampoMini.FlatStyle = FlatStyle.Flat;
            cbPesquisaCampoMini.Font = new Font("Segoe UI", 8F);
            cbPesquisaCampoMini.ForeColor = Color.White;
            cbPesquisaCampoMini.FormattingEnabled = true;
            cbPesquisaCampoMini.ItemEntryHeight = 30;
            cbPesquisaCampoMini.ItemHeight = 13;
            cbPesquisaCampoMini.Items.AddRange(new object[] { "ID", "Nome", "Marca", "Preço", "Qtd do estoque", "Qtd de aviso", "Observação" });
            cbPesquisaCampoMini.Location = new Point(8, 9);
            cbPesquisaCampoMini.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampoMini.Name = "cbPesquisaCampoMini";
            cbPesquisaCampoMini.Placeholder = "Selecione...";
            cbPesquisaCampoMini.ShowPlaceholder = true;
            cbPesquisaCampoMini.Size = new Size(144, 19);
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
            pnlHeader.Size = new Size(894, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(864, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecionar Produto";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddProdutoVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(900, 500);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(900, 500);
            MinimumSize = new Size(900, 500);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlWrapperCampo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private telebip_erp.Controls.NeoFlatComboBox cbPesquisaCampoMini;

        private RoundedPanel pnlWrapperCondicao;
        private telebip_erp.Controls.NeoFlatComboBox cbCondicaoMini;

        private RoundedPanel pnlWrapperPesquisa;
        private PictureBox picSearch;
        public PlaceholderTextBox tbPesquisaMini;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
