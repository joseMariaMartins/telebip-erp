using Guna.UI2.WinForms.Suite;

namespace telebip_erp.Forms.SubSubForms
{
    partial class FormAddProdutoVendas
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
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            CustomizableEdges customizableEdges7 = new CustomizableEdges();
            CustomizableEdges customizableEdges8 = new CustomizableEdges();
            CustomizableEdges customizableEdges9 = new CustomizableEdges();
            CustomizableEdges customizableEdges10 = new CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            dgvProdutosMini = new DataGridView();
            pnlPesquisa = new Panel();
            btnLimparMini = new Guna.UI2.WinForms.Guna2Button();
            btnPesquisarMini = new Guna.UI2.WinForms.Guna2Button();
            tbPesquisaMini = new Guna.UI2.WinForms.Guna2TextBox();
            cbCondicaoMini = new Guna.UI2.WinForms.Guna2ComboBox();
            cbPesquisaCampoMini = new Guna.UI2.WinForms.Guna2ComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).BeginInit();
            pnlPesquisa.SuspendLayout();
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
            pnlContainer.Size = new Size(814, 405);
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
            pnlMain.Size = new Size(814, 345);
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
            dgvProdutosMini.Size = new Size(774, 244);
            dgvProdutosMini.TabIndex = 20;
            // 
            // pnlPesquisa
            // 
            pnlPesquisa.BackColor = Color.FromArgb(32, 33, 39);
            pnlPesquisa.Controls.Add(btnLimparMini);
            pnlPesquisa.Controls.Add(btnPesquisarMini);
            pnlPesquisa.Controls.Add(tbPesquisaMini);
            pnlPesquisa.Controls.Add(cbCondicaoMini);
            pnlPesquisa.Controls.Add(cbPesquisaCampoMini);
            pnlPesquisa.Dock = DockStyle.Top;
            pnlPesquisa.Location = new Point(20, 20);
            pnlPesquisa.Name = "pnlPesquisa";
            pnlPesquisa.Padding = new Padding(10);
            pnlPesquisa.Size = new Size(774, 61);
            pnlPesquisa.TabIndex = 19;
            // 
            // btnLimparMini
            // 
            btnLimparMini.BorderRadius = 8;
            btnLimparMini.CustomizableEdges = customizableEdges1;
            btnLimparMini.DisabledState.BorderColor = Color.DarkGray;
            btnLimparMini.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLimparMini.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLimparMini.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLimparMini.FillColor = Color.FromArgb(120, 40, 40);
            btnLimparMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimparMini.ForeColor = Color.White;
            btnLimparMini.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnLimparMini.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnLimparMini.Location = new Point(682, 12);
            btnLimparMini.Name = "btnLimparMini";
            btnLimparMini.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLimparMini.Size = new Size(79, 36);
            btnLimparMini.TabIndex = 21;
            btnLimparMini.Text = "Limpar";
            // 
            // btnPesquisarMini
            // 
            btnPesquisarMini.BorderRadius = 8;
            btnPesquisarMini.CustomizableEdges = customizableEdges3;
            btnPesquisarMini.DisabledState.BorderColor = Color.DarkGray;
            btnPesquisarMini.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPesquisarMini.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPesquisarMini.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPesquisarMini.FillColor = Color.FromArgb(40, 120, 80);
            btnPesquisarMini.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisarMini.ForeColor = Color.White;
            btnPesquisarMini.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnPesquisarMini.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnPesquisarMini.Location = new Point(597, 13);
            btnPesquisarMini.Name = "btnPesquisarMini";
            btnPesquisarMini.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPesquisarMini.Size = new Size(79, 36);
            btnPesquisarMini.TabIndex = 20;
            btnPesquisarMini.Text = "Pesquisar";
            // 
            // tbPesquisaMini
            // 
            tbPesquisaMini.BorderColor = Color.FromArgb(60, 62, 80);
            tbPesquisaMini.BorderRadius = 8;
            tbPesquisaMini.CustomizableEdges = customizableEdges5;
            tbPesquisaMini.DefaultText = "";
            tbPesquisaMini.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPesquisaMini.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPesquisaMini.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisaMini.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPesquisaMini.FillColor = Color.FromArgb(40, 41, 52);
            tbPesquisaMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisaMini.Font = new Font("Segoe UI", 9F);
            tbPesquisaMini.ForeColor = Color.White;
            tbPesquisaMini.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPesquisaMini.Location = new Point(349, 13);
            tbPesquisaMini.Margin = new Padding(3, 0, 10, 0);
            tbPesquisaMini.Name = "tbPesquisaMini";
            tbPesquisaMini.PlaceholderForeColor = Color.Gray;
            tbPesquisaMini.PlaceholderText = "Digite para pesquisar...";
            tbPesquisaMini.SelectedText = "";
            tbPesquisaMini.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbPesquisaMini.Size = new Size(235, 36);
            tbPesquisaMini.TabIndex = 19;
            // 
            // cbCondicaoMini
            // 
            cbCondicaoMini.BackColor = Color.Transparent;
            cbCondicaoMini.BorderColor = Color.FromArgb(60, 62, 80);
            cbCondicaoMini.BorderRadius = 8;
            cbCondicaoMini.CustomizableEdges = customizableEdges7;
            cbCondicaoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicaoMini.FillColor = Color.FromArgb(40, 41, 52);
            cbCondicaoMini.FocusedColor = Color.FromArgb(100, 150, 200);
            cbCondicaoMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbCondicaoMini.Font = new Font("Segoe UI", 9F);
            cbCondicaoMini.ForeColor = Color.White;
            cbCondicaoMini.ItemHeight = 30;
            cbCondicaoMini.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicaoMini.Location = new Point(186, 13);
            cbCondicaoMini.Margin = new Padding(3, 0, 10, 0);
            cbCondicaoMini.Name = "cbCondicaoMini";
            cbCondicaoMini.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbCondicaoMini.Size = new Size(150, 36);
            cbCondicaoMini.TabIndex = 18;
            // 
            // cbPesquisaCampoMini
            // 
            cbPesquisaCampoMini.BackColor = Color.Transparent;
            cbPesquisaCampoMini.BorderColor = Color.FromArgb(60, 62, 80);
            cbPesquisaCampoMini.BorderRadius = 8;
            cbPesquisaCampoMini.CustomizableEdges = customizableEdges9;
            cbPesquisaCampoMini.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampoMini.FillColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampoMini.FocusedColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampoMini.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbPesquisaCampoMini.Font = new Font("Segoe UI", 9F);
            cbPesquisaCampoMini.ForeColor = Color.White;
            cbPesquisaCampoMini.ItemHeight = 30;
            cbPesquisaCampoMini.Items.AddRange(new object[] { "ID_PRODUTO", "NOME", "MARCA", "PRECO", "QTD_ESTOQUE", "QTD_AVISO", "OBSERVACAO" });
            cbPesquisaCampoMini.Location = new Point(13, 13);
            cbPesquisaCampoMini.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampoMini.Name = "cbPesquisaCampoMini";
            cbPesquisaCampoMini.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cbPesquisaCampoMini.Size = new Size(160, 36);
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
            pnlHeader.Size = new Size(814, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(784, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecionar Produto";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddProdutoVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(820, 432);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(820, 432);
            MinimumSize = new Size(820, 432);
            Name = "FormAddProdutoVendas";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddProdutoVendas";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutosMini).EndInit();
            pnlPesquisa.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnLimparMini;
        private Guna.UI2.WinForms.Guna2Button btnPesquisarMini;
        private Guna.UI2.WinForms.Guna2TextBox tbPesquisaMini;
        private Guna.UI2.WinForms.Guna2ComboBox cbCondicaoMini;
        private Guna.UI2.WinForms.Guna2ComboBox cbPesquisaCampoMini;
        private DataGridView dgvProdutosMini;
    }
}