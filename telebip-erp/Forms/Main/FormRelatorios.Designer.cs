namespace telebip_erp.Forms.Modules
{
    partial class FormRelatorios
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
            pnlMain = new Panel();
            pnlTabela = new Panel();
            dgvRelatorios = new DataGridView();
            pnlAcoes = new Panel();
            btnImprimir = new CuoreUI.Controls.cuiButton();
            btnExportarExcel = new CuoreUI.Controls.cuiButton();
            pnlMetricas = new Panel();
            tblMetricas = new TableLayoutPanel();
            pnlMetrica1 = new Panel();
            lblValor1 = new Label();
            lblTitulo1 = new Label();
            pnlMetrica2 = new Panel();
            lblValor2 = new Label();
            lblTitulo2 = new Label();
            pnlMetrica3 = new Panel();
            lblValor3 = new Label();
            lblTitulo3 = new Label();
            pnlMetrica4 = new Panel();
            lblValor4 = new Label();
            lblTitulo4 = new Label();
            pnlFiltros = new Panel();
            btnGerarRelatorio = new CuoreUI.Controls.cuiButton();
            cbPeriodo = new CuoreUI.Controls.cuiComboBox();
            lblPeriodo = new Label();
            cbTipoRelatorio = new CuoreUI.Controls.cuiComboBox();
            lblRelatorio = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlTabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRelatorios).BeginInit();
            pnlAcoes.SuspendLayout();
            pnlMetricas.SuspendLayout();
            tblMetricas.SuspendLayout();
            pnlMetrica1.SuspendLayout();
            pnlMetrica2.SuspendLayout();
            pnlMetrica3.SuspendLayout();
            pnlMetrica4.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlMain);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1597, 801);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(pnlTabela);
            pnlMain.Controls.Add(pnlAcoes);
            pnlMain.Controls.Add(pnlMetricas);
            pnlMain.Controls.Add(pnlFiltros);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 71);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1597, 730);
            pnlMain.TabIndex = 1;
            // 
            // pnlTabela
            // 
            pnlTabela.BackColor = Color.FromArgb(28, 29, 40);
            pnlTabela.Controls.Add(dgvRelatorios);
            pnlTabela.Dock = DockStyle.Fill;
            pnlTabela.Location = new Point(0, 157);
            pnlTabela.Name = "pnlTabela";
            pnlTabela.Padding = new Padding(15);
            pnlTabela.Size = new Size(1597, 498);
            pnlTabela.TabIndex = 3;
            // 
            // dgvRelatorios
            // 
            dgvRelatorios.AllowUserToAddRows = false;
            dgvRelatorios.AllowUserToDeleteRows = false;
            dgvRelatorios.AllowUserToResizeRows = false;
            dgvRelatorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRelatorios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvRelatorios.BorderStyle = BorderStyle.None;
            dgvRelatorios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRelatorios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRelatorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRelatorios.ColumnHeadersHeight = 40;
            dgvRelatorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRelatorios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRelatorios.Dock = DockStyle.Fill;
            dgvRelatorios.EnableHeadersVisualStyles = false;
            dgvRelatorios.GridColor = Color.FromArgb(50, 52, 67);
            dgvRelatorios.Location = new Point(15, 15);
            dgvRelatorios.MultiSelect = false;
            dgvRelatorios.Name = "dgvRelatorios";
            dgvRelatorios.ReadOnly = true;
            dgvRelatorios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRelatorios.RowHeadersVisible = false;
            dgvRelatorios.RowHeadersWidth = 62;
            dgvRelatorios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvRelatorios.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvRelatorios.RowTemplate.Height = 35;
            dgvRelatorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRelatorios.Size = new Size(1567, 468);
            dgvRelatorios.TabIndex = 0;
            // 
            // pnlAcoes
            // 
            pnlAcoes.BackColor = Color.FromArgb(32, 33, 39);
            pnlAcoes.Controls.Add(btnImprimir);
            pnlAcoes.Controls.Add(btnExportarExcel);
            pnlAcoes.Dock = DockStyle.Bottom;
            pnlAcoes.Location = new Point(0, 655);
            pnlAcoes.Name = "pnlAcoes";
            pnlAcoes.Padding = new Padding(15, 10, 15, 15);
            pnlAcoes.Size = new Size(1597, 75);
            pnlAcoes.TabIndex = 2;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimir.CheckButton = false;
            btnImprimir.Checked = false;
            btnImprimir.CheckedBackground = Color.FromArgb(40, 100, 180);
            btnImprimir.CheckedForeColor = Color.White;
            btnImprimir.CheckedImageTint = Color.White;
            btnImprimir.CheckedOutline = Color.FromArgb(40, 100, 180);
            btnImprimir.Content = "Imprimir";
            btnImprimir.DialogResult = DialogResult.None;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.HoverBackground = Color.FromArgb(60, 120, 180);
            btnImprimir.HoverForeColor = Color.White;
            btnImprimir.HoverImageTint = Color.White;
            btnImprimir.HoverOutline = Color.FromArgb(80, 140, 200);
            btnImprimir.Image = null;
            btnImprimir.ImageAutoCenter = true;
            btnImprimir.ImageExpand = new Point(0, 0);
            btnImprimir.ImageOffset = new Point(0, 0);
            btnImprimir.Location = new Point(1459, 17);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.NormalBackground = Color.FromArgb(40, 100, 180);
            btnImprimir.NormalForeColor = Color.White;
            btnImprimir.NormalImageTint = Color.White;
            btnImprimir.NormalOutline = Color.FromArgb(40, 100, 180);
            btnImprimir.OutlineThickness = 1F;
            btnImprimir.PressedBackground = Color.FromArgb(30, 90, 160);
            btnImprimir.PressedForeColor = Color.White;
            btnImprimir.PressedImageTint = Color.White;
            btnImprimir.PressedOutline = Color.FromArgb(30, 90, 160);
            btnImprimir.Rounding = new Padding(8);
            btnImprimir.Size = new Size(120, 40);
            btnImprimir.TabIndex = 1;
            btnImprimir.TextAlignment = StringAlignment.Center;
            btnImprimir.TextOffset = new Point(0, 0);
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcel.CheckButton = false;
            btnExportarExcel.Checked = false;
            btnExportarExcel.CheckedBackground = Color.FromArgb(40, 120, 80);
            btnExportarExcel.CheckedForeColor = Color.White;
            btnExportarExcel.CheckedImageTint = Color.White;
            btnExportarExcel.CheckedOutline = Color.FromArgb(40, 120, 80);
            btnExportarExcel.Content = "Exportar Excel";
            btnExportarExcel.DialogResult = DialogResult.None;
            btnExportarExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.HoverBackground = Color.FromArgb(60, 160, 100);
            btnExportarExcel.HoverForeColor = Color.White;
            btnExportarExcel.HoverImageTint = Color.White;
            btnExportarExcel.HoverOutline = Color.FromArgb(80, 200, 120);
            btnExportarExcel.Image = null;
            btnExportarExcel.ImageAutoCenter = true;
            btnExportarExcel.ImageExpand = new Point(0, 0);
            btnExportarExcel.ImageOffset = new Point(0, 0);
            btnExportarExcel.Location = new Point(1321, 17);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.NormalBackground = Color.FromArgb(40, 120, 80);
            btnExportarExcel.NormalForeColor = Color.White;
            btnExportarExcel.NormalImageTint = Color.White;
            btnExportarExcel.NormalOutline = Color.FromArgb(40, 120, 80);
            btnExportarExcel.OutlineThickness = 1F;
            btnExportarExcel.PressedBackground = Color.FromArgb(30, 100, 60);
            btnExportarExcel.PressedForeColor = Color.White;
            btnExportarExcel.PressedImageTint = Color.White;
            btnExportarExcel.PressedOutline = Color.FromArgb(30, 100, 60);
            btnExportarExcel.Rounding = new Padding(8);
            btnExportarExcel.Size = new Size(120, 40);
            btnExportarExcel.TabIndex = 0;
            btnExportarExcel.TextAlignment = StringAlignment.Center;
            btnExportarExcel.TextOffset = new Point(0, 0);
            // 
            // pnlMetricas
            // 
            pnlMetricas.BackColor = Color.FromArgb(28, 29, 40);
            pnlMetricas.Controls.Add(tblMetricas);
            pnlMetricas.Dock = DockStyle.Top;
            pnlMetricas.Location = new Point(0, 57);
            pnlMetricas.Name = "pnlMetricas";
            pnlMetricas.Padding = new Padding(15, 10, 15, 10);
            pnlMetricas.Size = new Size(1597, 100);
            pnlMetricas.TabIndex = 1;
            // 
            // tblMetricas
            // 
            tblMetricas.ColumnCount = 4;
            tblMetricas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMetricas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMetricas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMetricas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMetricas.Controls.Add(pnlMetrica1, 0, 0);
            tblMetricas.Controls.Add(pnlMetrica2, 1, 0);
            tblMetricas.Controls.Add(pnlMetrica3, 2, 0);
            tblMetricas.Controls.Add(pnlMetrica4, 3, 0);
            tblMetricas.Dock = DockStyle.Fill;
            tblMetricas.Location = new Point(15, 10);
            tblMetricas.Name = "tblMetricas";
            tblMetricas.RowCount = 1;
            tblMetricas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMetricas.Size = new Size(1567, 80);
            tblMetricas.TabIndex = 0;
            // 
            // pnlMetrica1
            // 
            pnlMetrica1.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica1.Controls.Add(lblValor1);
            pnlMetrica1.Controls.Add(lblTitulo1);
            pnlMetrica1.Dock = DockStyle.Fill;
            pnlMetrica1.Location = new Point(3, 3);
            pnlMetrica1.Name = "pnlMetrica1";
            pnlMetrica1.Size = new Size(385, 74);
            pnlMetrica1.TabIndex = 0;
            // 
            // lblValor1
            // 
            lblValor1.Dock = DockStyle.Fill;
            lblValor1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor1.ForeColor = Color.White;
            lblValor1.Location = new Point(0, 25);
            lblValor1.Name = "lblValor1";
            lblValor1.Size = new Size(385, 49);
            lblValor1.TabIndex = 1;
            lblValor1.Text = "R$ 0,00";
            lblValor1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo1
            // 
            lblTitulo1.Dock = DockStyle.Top;
            lblTitulo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo1.ForeColor = Color.LightGray;
            lblTitulo1.Location = new Point(0, 0);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new Size(385, 25);
            lblTitulo1.TabIndex = 0;
            lblTitulo1.Text = "Faturamento Total";
            lblTitulo1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMetrica2
            // 
            pnlMetrica2.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica2.Controls.Add(lblValor2);
            pnlMetrica2.Controls.Add(lblTitulo2);
            pnlMetrica2.Dock = DockStyle.Fill;
            pnlMetrica2.Location = new Point(394, 3);
            pnlMetrica2.Name = "pnlMetrica2";
            pnlMetrica2.Size = new Size(385, 74);
            pnlMetrica2.TabIndex = 1;
            // 
            // lblValor2
            // 
            lblValor2.Dock = DockStyle.Fill;
            lblValor2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor2.ForeColor = Color.White;
            lblValor2.Location = new Point(0, 25);
            lblValor2.Name = "lblValor2";
            lblValor2.Size = new Size(385, 49);
            lblValor2.TabIndex = 1;
            lblValor2.Text = "0";
            lblValor2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo2
            // 
            lblTitulo2.Dock = DockStyle.Top;
            lblTitulo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo2.ForeColor = Color.LightGray;
            lblTitulo2.Location = new Point(0, 0);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(385, 25);
            lblTitulo2.TabIndex = 0;
            lblTitulo2.Text = "Produtos em Alerta";
            lblTitulo2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMetrica3
            // 
            pnlMetrica3.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica3.Controls.Add(lblValor3);
            pnlMetrica3.Controls.Add(lblTitulo3);
            pnlMetrica3.Dock = DockStyle.Fill;
            pnlMetrica3.Location = new Point(785, 3);
            pnlMetrica3.Name = "pnlMetrica3";
            pnlMetrica3.Size = new Size(385, 74);
            pnlMetrica3.TabIndex = 2;
            // 
            // lblValor3
            // 
            lblValor3.Dock = DockStyle.Fill;
            lblValor3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor3.ForeColor = Color.White;
            lblValor3.Location = new Point(0, 25);
            lblValor3.Name = "lblValor3";
            lblValor3.Size = new Size(385, 49);
            lblValor3.TabIndex = 1;
            lblValor3.Text = "0";
            lblValor3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo3
            // 
            lblTitulo3.Dock = DockStyle.Top;
            lblTitulo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo3.ForeColor = Color.LightGray;
            lblTitulo3.Location = new Point(0, 0);
            lblTitulo3.Name = "lblTitulo3";
            lblTitulo3.Size = new Size(385, 25);
            lblTitulo3.TabIndex = 0;
            lblTitulo3.Text = "Total de Vendas";
            lblTitulo3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMetrica4
            // 
            pnlMetrica4.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica4.Controls.Add(lblValor4);
            pnlMetrica4.Controls.Add(lblTitulo4);
            pnlMetrica4.Dock = DockStyle.Fill;
            pnlMetrica4.Location = new Point(1176, 3);
            pnlMetrica4.Name = "pnlMetrica4";
            pnlMetrica4.Size = new Size(388, 74);
            pnlMetrica4.TabIndex = 3;
            // 
            // lblValor4
            // 
            lblValor4.Dock = DockStyle.Fill;
            lblValor4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor4.ForeColor = Color.White;
            lblValor4.Location = new Point(0, 25);
            lblValor4.Name = "lblValor4";
            lblValor4.Size = new Size(388, 49);
            lblValor4.TabIndex = 1;
            lblValor4.Text = "R$ 0,00";
            lblValor4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo4
            // 
            lblTitulo4.Dock = DockStyle.Top;
            lblTitulo4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo4.ForeColor = Color.LightGray;
            lblTitulo4.Location = new Point(0, 0);
            lblTitulo4.Name = "lblTitulo4";
            lblTitulo4.Size = new Size(388, 25);
            lblTitulo4.TabIndex = 0;
            lblTitulo4.Text = "Ticket Médio";
            lblTitulo4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(btnGerarRelatorio);
            pnlFiltros.Controls.Add(cbPeriodo);
            pnlFiltros.Controls.Add(lblPeriodo);
            pnlFiltros.Controls.Add(cbTipoRelatorio);
            pnlFiltros.Controls.Add(lblRelatorio);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(15, 15, 15, 10);
            pnlFiltros.Size = new Size(1597, 57);
            pnlFiltros.TabIndex = 0;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.CheckButton = false;
            btnGerarRelatorio.Checked = false;
            btnGerarRelatorio.CheckedBackground = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.CheckedForeColor = Color.White;
            btnGerarRelatorio.CheckedImageTint = Color.White;
            btnGerarRelatorio.CheckedOutline = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.Content = "Gerar Relatório";
            btnGerarRelatorio.DialogResult = DialogResult.None;
            btnGerarRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGerarRelatorio.ForeColor = Color.White;
            btnGerarRelatorio.HoverBackground = Color.FromArgb(60, 160, 100);
            btnGerarRelatorio.HoverForeColor = Color.White;
            btnGerarRelatorio.HoverImageTint = Color.White;
            btnGerarRelatorio.HoverOutline = Color.FromArgb(80, 200, 120);
            btnGerarRelatorio.Image = null;
            btnGerarRelatorio.ImageAutoCenter = true;
            btnGerarRelatorio.ImageExpand = new Point(0, 0);
            btnGerarRelatorio.ImageOffset = new Point(0, 0);
            btnGerarRelatorio.Location = new Point(759, 10);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.NormalBackground = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.NormalForeColor = Color.White;
            btnGerarRelatorio.NormalImageTint = Color.White;
            btnGerarRelatorio.NormalOutline = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.OutlineThickness = 1F;
            btnGerarRelatorio.PressedBackground = Color.FromArgb(30, 100, 60);
            btnGerarRelatorio.PressedForeColor = Color.White;
            btnGerarRelatorio.PressedImageTint = Color.White;
            btnGerarRelatorio.PressedOutline = Color.FromArgb(30, 100, 60);
            btnGerarRelatorio.Rounding = new Padding(8);
            btnGerarRelatorio.Size = new Size(120, 36);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.TextAlignment = StringAlignment.Center;
            btnGerarRelatorio.TextOffset = new Point(0, 0);
            // 
            // cbPeriodo
            // 
            cbPeriodo.BackgroundColor = Color.FromArgb(40, 41, 52);
            cbPeriodo.ButtonCursor = Cursors.Arrow;
            cbPeriodo.ButtonHoverBackground = Color.FromArgb(18, 18, 18);
            cbPeriodo.ButtonHoverOutline = Color.Empty;
            cbPeriodo.ButtonNormalBackground = Color.FromArgb(35, 34, 42);
            cbPeriodo.ButtonNormalOutline = Color.Empty;
            cbPeriodo.ButtonPressedBackground = Color.FromArgb(60, 59, 67);
            cbPeriodo.ButtonPressedOutline = Color.Empty;
            cbPeriodo.DropDownBackgroundColor = Color.FromArgb(40, 41, 52);
            cbPeriodo.DropDownOutlineColor = Color.FromArgb(30, 255, 255, 255);
            cbPeriodo.ExpandArrowColor = Color.White;
            cbPeriodo.ForeColor = Color.White;
            cbPeriodo.Items = new string[]
    {
    "Hoje",
    "Ontem",
    "Últimos 7 dias",
    "Últimos 30 dias",
    "Este mês",
    "Mês passado",
    "Ano atual"
    };
            cbPeriodo.Location = new Point(451, 10);
            cbPeriodo.Margin = new Padding(4, 3, 4, 3);
            cbPeriodo.Name = "cbPeriodo";
            cbPeriodo.NoSelectionDropdownText = "Selecione um período";
            cbPeriodo.NoSelectionText = "Selecione";
            cbPeriodo.OutlineColor = Color.FromArgb(60, 62, 80);
            cbPeriodo.OutlineThickness = 1F;
            cbPeriodo.Rounding = 8;
            cbPeriodo.Size = new Size(280, 36);
            cbPeriodo.TabIndex = 3;
            // 
            // lblPeriodo
            // 
            lblPeriodo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPeriodo.ForeColor = Color.White;
            lblPeriodo.Location = new Point(378, 10);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(70, 36);
            lblPeriodo.TabIndex = 2;
            lblPeriodo.Text = "Período:";
            lblPeriodo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbTipoRelatorio
            // 
            cbTipoRelatorio.BackgroundColor = Color.FromArgb(40, 41, 52);
            cbTipoRelatorio.ButtonCursor = Cursors.Arrow;
            cbTipoRelatorio.ButtonHoverBackground = Color.FromArgb(18, 18, 18);
            cbTipoRelatorio.ButtonHoverOutline = Color.Empty;
            cbTipoRelatorio.ButtonNormalBackground = Color.FromArgb(35, 34, 42);
            cbTipoRelatorio.ButtonNormalOutline = Color.Empty;
            cbTipoRelatorio.ButtonPressedBackground = Color.FromArgb(60, 59, 67);
            cbTipoRelatorio.ButtonPressedOutline = Color.Empty;
            cbTipoRelatorio.DropDownBackgroundColor = Color.FromArgb(40, 41, 52);
            cbTipoRelatorio.DropDownOutlineColor = Color.FromArgb(30, 255, 255, 255);
            cbTipoRelatorio.ExpandArrowColor = Color.White;
            cbTipoRelatorio.ForeColor = Color.White;
            cbTipoRelatorio.Items = new string[]
    {
    "Vendas do período",
    "Produtos mais vendidos",
    "Vendas por categoria",
    "Lucro bruto por produto",
    "Formas de pagamento",
    "Vendas por funcionário",
    "Produtos com baixo estoque",
    "Movimentação de estoque",
    "Tendência de vendas"
    };
            cbTipoRelatorio.Location = new Point(92, 10);
            cbTipoRelatorio.Margin = new Padding(4, 3, 4, 3);
            cbTipoRelatorio.Name = "cbTipoRelatorio";
            cbTipoRelatorio.NoSelectionDropdownText = "Selecione um relatório";
            cbTipoRelatorio.NoSelectionText = "Selecione";
            cbTipoRelatorio.OutlineColor = Color.FromArgb(60, 62, 80);
            cbTipoRelatorio.OutlineThickness = 1F;
            cbTipoRelatorio.Rounding = 8;
            cbTipoRelatorio.Size = new Size(260, 36);
            cbTipoRelatorio.TabIndex = 1;
            // 
            // lblRelatorio
            // 
            lblRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRelatorio.ForeColor = Color.White;
            lblRelatorio.Location = new Point(15, 10);
            lblRelatorio.Name = "lblRelatorio";
            lblRelatorio.Size = new Size(75, 36);
            lblRelatorio.TabIndex = 0;
            lblRelatorio.Text = "Relatório:";
            lblRelatorio.TextAlign = ContentAlignment.MiddleLeft;
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
            pnlHeader.TabIndex = 0;
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
            lblTitulo.Text = "Relatórios e Análises";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1597, 801);
            ControlBox = false;
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRelatorios";
            Text = "FormRelatorios";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlTabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRelatorios).EndInit();
            pnlAcoes.ResumeLayout(false);
            pnlMetricas.ResumeLayout(false);
            tblMetricas.ResumeLayout(false);
            pnlMetrica1.ResumeLayout(false);
            pnlMetrica2.ResumeLayout(false);
            pnlMetrica3.ResumeLayout(false);
            pnlMetrica4.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private CuoreUI.Controls.cuiComboBox cbTipoRelatorio;
        private System.Windows.Forms.Label lblRelatorio;
        private CuoreUI.Controls.cuiButton btnGerarRelatorio;
        private CuoreUI.Controls.cuiComboBox cbPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Panel pnlMetricas;
        private System.Windows.Forms.TableLayoutPanel tblMetricas;
        private System.Windows.Forms.Panel pnlMetrica1;
        private System.Windows.Forms.Label lblValor1;
        private System.Windows.Forms.Label lblTitulo1;
        private System.Windows.Forms.Panel pnlMetrica2;
        private System.Windows.Forms.Label lblValor2;
        private System.Windows.Forms.Label lblTitulo2;
        private System.Windows.Forms.Panel pnlMetrica3;
        private System.Windows.Forms.Label lblValor3;
        private System.Windows.Forms.Label lblTitulo3;
        private System.Windows.Forms.Panel pnlMetrica4;
        private System.Windows.Forms.Label lblValor4;
        private System.Windows.Forms.Label lblTitulo4;
        private System.Windows.Forms.Panel pnlAcoes;
        private CuoreUI.Controls.cuiButton btnImprimir;
        private CuoreUI.Controls.cuiButton btnExportarExcel;
        private System.Windows.Forms.Panel pnlTabela;
        private System.Windows.Forms.DataGridView dgvRelatorios;
    }
}