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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlTabela = new Panel();
            dgvRelatorios = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlAcoes = new Panel();
            btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            btnExportarExcel = new Guna.UI2.WinForms.Guna2Button();
            pnlMetricas = new Panel();
            tblMetricas = new TableLayoutPanel();
            pnlMetrica1 = new Guna.UI2.WinForms.Guna2Panel();
            lblValor1 = new Label();
            lblTitulo1 = new Label();
            pnlMetrica2 = new Guna.UI2.WinForms.Guna2Panel();
            lblValor2 = new Label();
            lblTitulo2 = new Label();
            pnlMetrica3 = new Guna.UI2.WinForms.Guna2Panel();
            lblValor3 = new Label();
            lblTitulo3 = new Label();
            pnlMetrica4 = new Guna.UI2.WinForms.Guna2Panel();
            lblValor4 = new Label();
            lblTitulo4 = new Label();
            pnlFiltros = new Panel();
            btnGerarRelatorio = new Guna.UI2.WinForms.Guna2Button();
            cbPeriodo = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPeriodo = new Label();
            cbTipoRelatorio = new Guna.UI2.WinForms.Guna2ComboBox();
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
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvRelatorios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRelatorios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRelatorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRelatorios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRelatorios.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRelatorios.Dock = DockStyle.Fill;
            dgvRelatorios.GridColor = Color.FromArgb(50, 52, 67);
            dgvRelatorios.Location = new Point(15, 15);
            dgvRelatorios.MultiSelect = false;
            dgvRelatorios.Name = "dgvRelatorios";
            dgvRelatorios.ReadOnly = true;
            dgvRelatorios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRelatorios.RowHeadersVisible = false;
            dgvRelatorios.RowHeadersWidth = 62;
            dgvRelatorios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvRelatorios.RowTemplate.Height = 35;
            dgvRelatorios.Size = new Size(1567, 468);
            dgvRelatorios.TabIndex = 0;
            dgvRelatorios.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvRelatorios.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvRelatorios.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvRelatorios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvRelatorios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvRelatorios.ThemeStyle.BackColor = Color.FromArgb(32, 33, 39);
            dgvRelatorios.ThemeStyle.GridColor = Color.FromArgb(50, 52, 67);
            dgvRelatorios.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvRelatorios.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRelatorios.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvRelatorios.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvRelatorios.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRelatorios.ThemeStyle.HeaderStyle.Height = 40;
            dgvRelatorios.ThemeStyle.ReadOnly = true;
            dgvRelatorios.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvRelatorios.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRelatorios.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvRelatorios.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvRelatorios.ThemeStyle.RowsStyle.Height = 35;
            dgvRelatorios.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvRelatorios.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            btnImprimir.BorderRadius = 8;
            btnImprimir.CustomizableEdges = customizableEdges1;
            btnImprimir.DisabledState.BorderColor = Color.DarkGray;
            btnImprimir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnImprimir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnImprimir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnImprimir.FillColor = Color.FromArgb(40, 100, 180);
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.HoverState.BorderColor = Color.FromArgb(80, 140, 200);
            btnImprimir.HoverState.FillColor = Color.FromArgb(60, 120, 180);
            btnImprimir.Location = new Point(1459, 17);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnImprimir.Size = new Size(120, 40);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcel.BorderRadius = 8;
            btnExportarExcel.CustomizableEdges = customizableEdges3;
            btnExportarExcel.DisabledState.BorderColor = Color.DarkGray;
            btnExportarExcel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExportarExcel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExportarExcel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExportarExcel.FillColor = Color.FromArgb(40, 120, 80);
            btnExportarExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnExportarExcel.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnExportarExcel.Location = new Point(1321, 17);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnExportarExcel.Size = new Size(120, 40);
            btnExportarExcel.TabIndex = 0;
            btnExportarExcel.Text = "Exportar Excel";
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
            pnlMetrica1.BackColor = Color.FromArgb(40, 41, 52);
            pnlMetrica1.BorderRadius = 8;
            pnlMetrica1.Controls.Add(lblValor1);
            pnlMetrica1.Controls.Add(lblTitulo1);
            pnlMetrica1.CustomizableEdges = customizableEdges5;
            pnlMetrica1.Dock = DockStyle.Fill;
            pnlMetrica1.FillColor = Color.FromArgb(50, 52, 67);
            pnlMetrica1.Location = new Point(3, 3);
            pnlMetrica1.Name = "pnlMetrica1";
            pnlMetrica1.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            pnlMetrica2.BackColor = Color.FromArgb(40, 41, 52);
            pnlMetrica2.BorderRadius = 8;
            pnlMetrica2.Controls.Add(lblValor2);
            pnlMetrica2.Controls.Add(lblTitulo2);
            pnlMetrica2.CustomizableEdges = customizableEdges7;
            pnlMetrica2.Dock = DockStyle.Fill;
            pnlMetrica2.FillColor = Color.FromArgb(50, 52, 67);
            pnlMetrica2.Location = new Point(394, 3);
            pnlMetrica2.Name = "pnlMetrica2";
            pnlMetrica2.ShadowDecoration.CustomizableEdges = customizableEdges8;
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
            pnlMetrica3.BackColor = Color.FromArgb(40, 41, 52);
            pnlMetrica3.BorderRadius = 8;
            pnlMetrica3.Controls.Add(lblValor3);
            pnlMetrica3.Controls.Add(lblTitulo3);
            pnlMetrica3.CustomizableEdges = customizableEdges9;
            pnlMetrica3.Dock = DockStyle.Fill;
            pnlMetrica3.FillColor = Color.FromArgb(50, 52, 67);
            pnlMetrica3.Location = new Point(785, 3);
            pnlMetrica3.Name = "pnlMetrica3";
            pnlMetrica3.ShadowDecoration.CustomizableEdges = customizableEdges10;
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
            pnlMetrica4.BackColor = Color.FromArgb(40, 41, 52);
            pnlMetrica4.BorderRadius = 8;
            pnlMetrica4.Controls.Add(lblValor4);
            pnlMetrica4.Controls.Add(lblTitulo4);
            pnlMetrica4.CustomizableEdges = customizableEdges11;
            pnlMetrica4.Dock = DockStyle.Fill;
            pnlMetrica4.FillColor = Color.FromArgb(50, 52, 67);
            pnlMetrica4.Location = new Point(1176, 3);
            pnlMetrica4.Name = "pnlMetrica4";
            pnlMetrica4.ShadowDecoration.CustomizableEdges = customizableEdges12;
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
            btnGerarRelatorio.BorderRadius = 8;
            btnGerarRelatorio.CustomizableEdges = customizableEdges13;
            btnGerarRelatorio.DisabledState.BorderColor = Color.DarkGray;
            btnGerarRelatorio.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGerarRelatorio.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGerarRelatorio.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGerarRelatorio.FillColor = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGerarRelatorio.ForeColor = Color.White;
            btnGerarRelatorio.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnGerarRelatorio.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnGerarRelatorio.Location = new Point(759, 10);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnGerarRelatorio.Size = new Size(120, 36);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.Text = "Gerar Relatório";
            // 
            // cbPeriodo
            // 
            cbPeriodo.BackColor = Color.Transparent;
            cbPeriodo.BorderColor = Color.FromArgb(60, 62, 80);
            cbPeriodo.BorderRadius = 8;
            cbPeriodo.CustomizableEdges = customizableEdges15;
            cbPeriodo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeriodo.FillColor = Color.FromArgb(40, 41, 52);
            cbPeriodo.FocusedColor = Color.FromArgb(100, 150, 200);
            cbPeriodo.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbPeriodo.Font = new Font("Segoe UI", 9F);
            cbPeriodo.ForeColor = Color.White;
            cbPeriodo.ItemHeight = 30;
            cbPeriodo.Items.AddRange(new object[] { "Hoje", "Ontem", "Últimos 7 dias", "Últimos 30 dias", "Este mês", "Mês passado", "Ano atual" });
            cbPeriodo.Location = new Point(451, 10);
            cbPeriodo.Name = "cbPeriodo";
            cbPeriodo.ShadowDecoration.CustomizableEdges = customizableEdges16;
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
            cbTipoRelatorio.BackColor = Color.Transparent;
            cbTipoRelatorio.BorderColor = Color.FromArgb(60, 62, 80);
            cbTipoRelatorio.BorderRadius = 8;
            cbTipoRelatorio.CustomizableEdges = customizableEdges17;
            cbTipoRelatorio.DrawMode = DrawMode.OwnerDrawFixed;
            cbTipoRelatorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoRelatorio.FillColor = Color.FromArgb(40, 41, 52);
            cbTipoRelatorio.FocusedColor = Color.FromArgb(100, 150, 200);
            cbTipoRelatorio.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbTipoRelatorio.Font = new Font("Segoe UI", 9F);
            cbTipoRelatorio.ForeColor = Color.White;
            cbTipoRelatorio.ItemHeight = 30;
            cbTipoRelatorio.Items.AddRange(new object[] { "Vendas do período", "Produtos mais vendidos", "Estoque baixo", "Faturamento total", "Ticket médio", "Resumo de produtos", "Tendência de vendas" });
            cbTipoRelatorio.Location = new Point(92, 10);
            cbTipoRelatorio.Name = "cbTipoRelatorio";
            cbTipoRelatorio.ShadowDecoration.CustomizableEdges = customizableEdges18;
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

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlFiltros;
        private Guna.UI2.WinForms.Guna2ComboBox cbTipoRelatorio;
        private Label lblRelatorio;
        private Guna.UI2.WinForms.Guna2Button btnGerarRelatorio;
        private Guna.UI2.WinForms.Guna2ComboBox cbPeriodo;
        private Label lblPeriodo;
        private Panel pnlMetricas;
        private TableLayoutPanel tblMetricas;
        private Guna.UI2.WinForms.Guna2Panel pnlMetrica1;
        private Label lblValor1;
        private Label lblTitulo1;
        private Guna.UI2.WinForms.Guna2Panel pnlMetrica2;
        private Label lblValor2;
        private Label lblTitulo2;
        private Guna.UI2.WinForms.Guna2Panel pnlMetrica3;
        private Label lblValor3;
        private Label lblTitulo3;
        private Guna.UI2.WinForms.Guna2Panel pnlMetrica4;
        private Label lblValor4;
        private Label lblTitulo4;
        private Panel pnlAcoes;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private Guna.UI2.WinForms.Guna2Button btnExportarExcel;
        private Panel pnlTabela;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRelatorios;
    }
}