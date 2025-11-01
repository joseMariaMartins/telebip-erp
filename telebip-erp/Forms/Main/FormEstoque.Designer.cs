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
            pnlContainer = new Panel();
            pnlDgv = new Panel();
            dgvEstoque = new DataGridView();
            pnlBottom = new Panel();
            lbTotal = new Label();
            pnlFiltros = new Panel();
            btnLimpar = new CuoreUI.Controls.cuiButton();
            btnPesquisar = new CuoreUI.Controls.cuiButton();
            tbPesquisa = new CuoreUI.Controls.cuiTextBox();
            cbCondicao = new CuoreUI.Controls.cuiComboBox();
            cbPesquisaCampo = new CuoreUI.Controls.cuiComboBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
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
            pnlContainer.Size = new Size(1358, 660);
            pnlContainer.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.FromArgb(28, 29, 40);
            pnlDgv.Controls.Add(dgvEstoque);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 128);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1358, 428);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEstoque.ColumnHeadersHeight = 40;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvEstoque.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvEstoque.RowTemplate.Height = 35;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.Size = new Size(1328, 398);
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
            pnlFiltros.Controls.Add(tbPesquisa);
            pnlFiltros.Controls.Add(cbCondicao);
            pnlFiltros.Controls.Add(cbPesquisaCampo);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 71);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10, 10, 10, 15);
            pnlFiltros.Size = new Size(1358, 57);
            pnlFiltros.TabIndex = 7;
            // 
            // btnLimpar
            // 
            btnLimpar.CheckButton = false;
            btnLimpar.Checked = false;
            btnLimpar.CheckedBackground = Color.FromArgb(120, 40, 40);
            btnLimpar.CheckedForeColor = Color.White;
            btnLimpar.CheckedImageTint = Color.White;
            btnLimpar.CheckedOutline = Color.FromArgb(120, 40, 40);
            btnLimpar.Content = "Limpar";
            btnLimpar.DialogResult = DialogResult.None;
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.HoverBackground = Color.FromArgb(160, 60, 60);
            btnLimpar.HoverForeColor = Color.White;
            btnLimpar.HoverImageTint = Color.White;
            btnLimpar.HoverOutline = Color.FromArgb(200, 80, 80);
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
            btnLimpar.NormalOutline = Color.FromArgb(120, 40, 40);
            btnLimpar.OutlineThickness = 1F;
            btnLimpar.PressedBackground = Color.FromArgb(100, 30, 30);
            btnLimpar.PressedForeColor = Color.White;
            btnLimpar.PressedImageTint = Color.White;
            btnLimpar.PressedOutline = Color.FromArgb(100, 30, 30);
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
            btnPesquisar.CheckedBackground = Color.FromArgb(40, 120, 80);
            btnPesquisar.CheckedForeColor = Color.White;
            btnPesquisar.CheckedImageTint = Color.White;
            btnPesquisar.CheckedOutline = Color.FromArgb(40, 120, 80);
            btnPesquisar.Content = "Pesquisar";
            btnPesquisar.DialogResult = DialogResult.None;
            btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.HoverBackground = Color.FromArgb(60, 160, 100);
            btnPesquisar.HoverForeColor = Color.White;
            btnPesquisar.HoverImageTint = Color.White;
            btnPesquisar.HoverOutline = Color.FromArgb(80, 200, 120);
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
            btnPesquisar.NormalOutline = Color.FromArgb(40, 120, 80);
            btnPesquisar.OutlineThickness = 1F;
            btnPesquisar.PressedBackground = Color.FromArgb(30, 100, 60);
            btnPesquisar.PressedForeColor = Color.White;
            btnPesquisar.PressedImageTint = Color.White;
            btnPesquisar.PressedOutline = Color.FromArgb(30, 100, 60);
            btnPesquisar.Rounding = new Padding(8);
            btnPesquisar.Size = new Size(120, 36);
            btnPesquisar.TabIndex = 9;
            btnPesquisar.TextAlignment = StringAlignment.Center;
            btnPesquisar.TextOffset = new Point(0, 0);
            // 
            // tbPesquisa
            // 
            tbPesquisa.BackColor = Color.FromArgb(40, 41, 52);
            tbPesquisa.BackgroundColor = Color.White;
            tbPesquisa.Content = "";
            tbPesquisa.Cursor = Cursors.IBeam;
            tbPesquisa.FocusBackgroundColor = Color.White;
            tbPesquisa.FocusImageTint = Color.FromArgb(40, 41, 52);
            tbPesquisa.FocusOutlineColor = Color.FromArgb(40, 41, 52);
            tbPesquisa.Font = new Font("Segoe UI", 9F);
            tbPesquisa.ForeColor = Color.Black;
            tbPesquisa.Image = null;
            tbPesquisa.ImageExpand = new Point(0, 0);
            tbPesquisa.ImageOffset = new Point(0, 0);
            tbPesquisa.Location = new Point(378, 10);
            tbPesquisa.Margin = new Padding(3, 0, 10, 0);
            tbPesquisa.Multiline = false;
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.NormalImageTint = Color.FromArgb(40, 41, 52);
            tbPesquisa.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            tbPesquisa.Padding = new Padding(16, 10, 16, 0);
            tbPesquisa.PasswordChar = false;
            tbPesquisa.PlaceholderColor = SystemColors.WindowText;
            tbPesquisa.PlaceholderText = "Digite para pesquisar...";
            tbPesquisa.Rounding = new Padding(8);
            tbPesquisa.Size = new Size(235, 36);
            tbPesquisa.TabIndex = 7;
            tbPesquisa.TextOffset = new Size(0, 0);
            tbPesquisa.UnderlinedStyle = true;
            // 
            // cbCondicao
            // 
            cbCondicao.BackgroundColor = Color.FromArgb(40, 41, 52);
            cbCondicao.ButtonCursor = Cursors.Arrow;
            cbCondicao.ButtonHoverBackground = Color.FromArgb(18, 18, 18);
            cbCondicao.ButtonHoverOutline = Color.Empty;
            cbCondicao.ButtonNormalBackground = Color.FromArgb(35, 34, 42);
            cbCondicao.ButtonNormalOutline = Color.Empty;
            cbCondicao.ButtonPressedBackground = Color.FromArgb(60, 59, 67);
            cbCondicao.ButtonPressedOutline = Color.Empty;
            cbCondicao.DropDownBackgroundColor = Color.FromArgb(40, 41, 52);
            cbCondicao.DropDownOutlineColor = Color.FromArgb(30, 255, 255, 255);
            cbCondicao.ExpandArrowColor = Color.White;
            cbCondicao.ForeColor = Color.White;
            cbCondicao.Items = new string[]
    {
    "Inicia com",
    "Contendo",
    "Diferente de"
    };
            cbCondicao.Location = new Point(195, 10);
            cbCondicao.Margin = new Padding(3, 0, 10, 0);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.NoSelectionDropdownText = "Selecione a condição";
            cbCondicao.NoSelectionText = "";
            cbCondicao.OutlineColor = Color.FromArgb(60, 62, 80);
            cbCondicao.OutlineThickness = 1F;
            cbCondicao.Rounding = 8;
            cbCondicao.Size = new Size(169, 36);
            cbCondicao.TabIndex = 11;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackgroundColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.ButtonCursor = Cursors.Arrow;
            cbPesquisaCampo.ButtonHoverBackground = Color.FromArgb(18, 18, 18);
            cbPesquisaCampo.ButtonHoverOutline = Color.Empty;
            cbPesquisaCampo.ButtonNormalBackground = Color.FromArgb(35, 34, 42);
            cbPesquisaCampo.ButtonNormalOutline = Color.Empty;
            cbPesquisaCampo.ButtonPressedBackground = Color.FromArgb(60, 59, 67);
            cbPesquisaCampo.ButtonPressedOutline = Color.Empty;
            cbPesquisaCampo.DropDownBackgroundColor = Color.FromArgb(40, 41, 52);
            cbPesquisaCampo.DropDownOutlineColor = Color.FromArgb(30, 255, 255, 255);
            cbPesquisaCampo.ExpandArrowColor = Color.White;
            cbPesquisaCampo.ForeColor = Color.White;
            cbPesquisaCampo.Items = new string[]
    {
    "ID",
    "Nome",
    "Marca",
    "Preço",
    "Qtd do estoque",
    "Qtd de aviso",
    "Observação"
    };
            cbPesquisaCampo.Location = new Point(13, 10);
            cbPesquisaCampo.Margin = new Padding(3, 0, 10, 0);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.NoSelectionDropdownText = "Selecione o campo";
            cbPesquisaCampo.NoSelectionText = "";
            cbPesquisaCampo.OutlineColor = Color.FromArgb(60, 62, 80);
            cbPesquisaCampo.OutlineThickness = 1F;
            cbPesquisaCampo.Rounding = 8;
            cbPesquisaCampo.Size = new Size(169, 36);
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
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlDgv;
        private DataGridView dgvEstoque;
        private Panel pnlBottom;
        private Label lbTotal;
        private Panel pnlFiltros;
        private CuoreUI.Controls.cuiButton btnLimpar;
        private CuoreUI.Controls.cuiButton btnPesquisar;
        private CuoreUI.Controls.cuiTextBox tbPesquisa;
        private CuoreUI.Controls.cuiComboBox cbCondicao;
        private CuoreUI.Controls.cuiComboBox cbPesquisaCampo;
        private Panel pnlHeader;
        private Label lblTitulo;
    }
}