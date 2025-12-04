// FormRelatorios.Designer.cs (atualizado)
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorios));
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlTabela = new Panel();
            dgvRelatorios = new DataGridView();
            pnlAcoes = new Panel();
            btnExportarExcel = new CuoreUI.Controls.cuiButton();
            btnImprimir = new CuoreUI.Controls.cuiButton();
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
            btnLimpar = new CuoreUI.Controls.cuiButton();
            lblRelatorio = new Label();
            pnlWrapperTipoRelatorio = new telebip_erp.Controls.RoundedPanel();
            picTipoArrow = new PictureBox();
            cbTipoRelatorio = new telebip_erp.Controls.NeoFlatComboBox();
            pnlWrapperPeriodo = new telebip_erp.Controls.RoundedPanel();
            picPeriodoArrow = new PictureBox();
            cbPeriodo = new telebip_erp.Controls.NeoFlatComboBox();
            btnGerarRelatorio = new CuoreUI.Controls.cuiButton();
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
            pnlWrapperTipoRelatorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTipoArrow).BeginInit();
            pnlWrapperPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPeriodoArrow).BeginInit();
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
            pnlContainer.Size = new Size(1362, 660);
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
            pnlMain.Size = new Size(1362, 589);
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
            pnlTabela.Size = new Size(1362, 357);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRelatorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRelatorios.ColumnHeadersHeight = 40;
            dgvRelatorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
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
            dataGridViewCellStyle3.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvRelatorios.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvRelatorios.RowTemplate.Height = 36;
            dgvRelatorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRelatorios.Size = new Size(1332, 327);
            dgvRelatorios.TabIndex = 0;
            // 
            // pnlAcoes
            // 
            pnlAcoes.BackColor = Color.FromArgb(32, 33, 39);
            pnlAcoes.Controls.Add(btnExportarExcel);
            pnlAcoes.Controls.Add(btnImprimir);
            pnlAcoes.Dock = DockStyle.Bottom;
            pnlAcoes.Location = new Point(0, 514);
            pnlAcoes.Name = "pnlAcoes";
            pnlAcoes.Padding = new Padding(15, 10, 15, 15);
            pnlAcoes.Size = new Size(1362, 75);
            pnlAcoes.TabIndex = 2;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarExcel.CheckButton = false;
            btnExportarExcel.Checked = false;
            btnExportarExcel.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnExportarExcel.CheckedForeColor = Color.White;
            btnExportarExcel.CheckedImageTint = Color.White;
            btnExportarExcel.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnExportarExcel.Content = "Exportar Excel";
            btnExportarExcel.DialogResult = DialogResult.None;
            btnExportarExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.HoverBackground = Color.FromArgb(50, 150, 100);
            btnExportarExcel.HoverForeColor = Color.White;
            btnExportarExcel.HoverImageTint = Color.White;
            btnExportarExcel.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnExportarExcel.Image = null;
            btnExportarExcel.ImageAutoCenter = true;
            btnExportarExcel.ImageExpand = new Point(0, 0);
            btnExportarExcel.ImageOffset = new Point(0, 0);
            btnExportarExcel.Location = new Point(1096, 17);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.NormalBackground = Color.FromArgb(40, 120, 80);
            btnExportarExcel.NormalForeColor = Color.White;
            btnExportarExcel.NormalImageTint = Color.White;
            btnExportarExcel.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnExportarExcel.OutlineThickness = 1F;
            btnExportarExcel.PressedBackground = Color.FromArgb(30, 100, 70);
            btnExportarExcel.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnExportarExcel.PressedImageTint = Color.White;
            btnExportarExcel.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnExportarExcel.Rounding = new Padding(8);
            btnExportarExcel.Size = new Size(120, 40);
            btnExportarExcel.TabIndex = 0;
            btnExportarExcel.TextAlignment = StringAlignment.Center;
            btnExportarExcel.TextOffset = new Point(0, 0);
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimir.CheckButton = false;
            btnImprimir.Checked = false;
            btnImprimir.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnImprimir.CheckedForeColor = Color.White;
            btnImprimir.CheckedImageTint = Color.White;
            btnImprimir.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnImprimir.Content = "Imprimir";
            btnImprimir.DialogResult = DialogResult.None;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.HoverBackground = Color.FromArgb(80, 140, 210);
            btnImprimir.HoverForeColor = Color.White;
            btnImprimir.HoverImageTint = Color.White;
            btnImprimir.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnImprimir.Image = null;
            btnImprimir.ImageAutoCenter = true;
            btnImprimir.ImageExpand = new Point(0, 0);
            btnImprimir.ImageOffset = new Point(0, 0);
            btnImprimir.Location = new Point(1224, 17);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.NormalBackground = Color.FromArgb(40, 100, 180);
            btnImprimir.NormalForeColor = Color.White;
            btnImprimir.NormalImageTint = Color.White;
            btnImprimir.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnImprimir.OutlineThickness = 1F;
            btnImprimir.PressedBackground = Color.FromArgb(20, 60, 120);
            btnImprimir.PressedForeColor = Color.White;
            btnImprimir.PressedImageTint = Color.White;
            btnImprimir.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnImprimir.Rounding = new Padding(8);
            btnImprimir.Size = new Size(120, 40);
            btnImprimir.TabIndex = 1;
            btnImprimir.TextAlignment = StringAlignment.Center;
            btnImprimir.TextOffset = new Point(0, 0);
            // 
            // pnlMetricas
            // 
            pnlMetricas.BackColor = Color.FromArgb(28, 29, 40);
            pnlMetricas.Controls.Add(tblMetricas);
            pnlMetricas.Dock = DockStyle.Top;
            pnlMetricas.Location = new Point(0, 57);
            pnlMetricas.Name = "pnlMetricas";
            pnlMetricas.Padding = new Padding(15, 10, 15, 10);
            pnlMetricas.Size = new Size(1362, 100);
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
            tblMetricas.Size = new Size(1332, 80);
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
            pnlMetrica1.Padding = new Padding(8);
            pnlMetrica1.Size = new Size(327, 74);
            pnlMetrica1.TabIndex = 0;
            // 
            // lblValor1
            // 
            lblValor1.Dock = DockStyle.Fill;
            lblValor1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor1.ForeColor = Color.White;
            lblValor1.Location = new Point(8, 30);
            lblValor1.Name = "lblValor1";
            lblValor1.Size = new Size(311, 36);
            lblValor1.TabIndex = 0;
            lblValor1.Text = "R$ 0,00";
            lblValor1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo1
            // 
            lblTitulo1.Dock = DockStyle.Top;
            lblTitulo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo1.ForeColor = Color.LightGray;
            lblTitulo1.Location = new Point(8, 8);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new Size(311, 22);
            lblTitulo1.TabIndex = 1;
            lblTitulo1.Text = "Faturamento";
            // 
            // pnlMetrica2
            // 
            pnlMetrica2.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica2.Controls.Add(lblValor2);
            pnlMetrica2.Controls.Add(lblTitulo2);
            pnlMetrica2.Dock = DockStyle.Fill;
            pnlMetrica2.Location = new Point(336, 3);
            pnlMetrica2.Name = "pnlMetrica2";
            pnlMetrica2.Padding = new Padding(8);
            pnlMetrica2.Size = new Size(327, 74);
            pnlMetrica2.TabIndex = 1;
            // 
            // lblValor2
            // 
            lblValor2.Dock = DockStyle.Fill;
            lblValor2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor2.ForeColor = Color.White;
            lblValor2.Location = new Point(8, 30);
            lblValor2.Name = "lblValor2";
            lblValor2.Size = new Size(311, 36);
            lblValor2.TabIndex = 0;
            lblValor2.Text = "0";
            lblValor2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo2
            // 
            lblTitulo2.Dock = DockStyle.Top;
            lblTitulo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo2.ForeColor = Color.LightGray;
            lblTitulo2.Location = new Point(8, 8);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(311, 22);
            lblTitulo2.TabIndex = 1;
            lblTitulo2.Text = "Total de vendas";
            // 
            // pnlMetrica3
            // 
            pnlMetrica3.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica3.Controls.Add(lblValor3);
            pnlMetrica3.Controls.Add(lblTitulo3);
            pnlMetrica3.Dock = DockStyle.Fill;
            pnlMetrica3.Location = new Point(669, 3);
            pnlMetrica3.Name = "pnlMetrica3";
            pnlMetrica3.Padding = new Padding(8);
            pnlMetrica3.Size = new Size(327, 74);
            pnlMetrica3.TabIndex = 2;
            // 
            // lblValor3
            // 
            lblValor3.Dock = DockStyle.Fill;
            lblValor3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor3.ForeColor = Color.White;
            lblValor3.Location = new Point(8, 30);
            lblValor3.Name = "lblValor3";
            lblValor3.Size = new Size(311, 36);
            lblValor3.TabIndex = 0;
            lblValor3.Text = "R$ 0,00";
            lblValor3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo3
            // 
            lblTitulo3.Dock = DockStyle.Top;
            lblTitulo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo3.ForeColor = Color.LightGray;
            lblTitulo3.Location = new Point(8, 8);
            lblTitulo3.Name = "lblTitulo3";
            lblTitulo3.Size = new Size(311, 22);
            lblTitulo3.TabIndex = 1;
            lblTitulo3.Text = "Ticket médio";
            // 
            // pnlMetrica4
            // 
            pnlMetrica4.BackColor = Color.FromArgb(50, 52, 67);
            pnlMetrica4.Controls.Add(lblValor4);
            pnlMetrica4.Controls.Add(lblTitulo4);
            pnlMetrica4.Dock = DockStyle.Fill;
            pnlMetrica4.Location = new Point(1002, 3);
            pnlMetrica4.Name = "pnlMetrica4";
            pnlMetrica4.Padding = new Padding(8);
            pnlMetrica4.Size = new Size(327, 74);
            pnlMetrica4.TabIndex = 3;
            // 
            // lblValor4
            // 
            lblValor4.Dock = DockStyle.Fill;
            lblValor4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValor4.ForeColor = Color.White;
            lblValor4.Location = new Point(8, 30);
            lblValor4.Name = "lblValor4";
            lblValor4.Size = new Size(311, 36);
            lblValor4.TabIndex = 0;
            lblValor4.Text = "-";
            lblValor4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo4
            // 
            lblTitulo4.Dock = DockStyle.Top;
            lblTitulo4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo4.ForeColor = Color.LightGray;
            lblTitulo4.Location = new Point(8, 8);
            lblTitulo4.Name = "lblTitulo4";
            lblTitulo4.Size = new Size(311, 22);
            lblTitulo4.TabIndex = 1;
            lblTitulo4.Text = "Período";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(32, 33, 39);
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(lblRelatorio);
            pnlFiltros.Controls.Add(pnlWrapperTipoRelatorio);
            pnlFiltros.Controls.Add(pnlWrapperPeriodo);
            pnlFiltros.Controls.Add(btnGerarRelatorio);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(15, 15, 15, 10);
            pnlFiltros.Size = new Size(1362, 57);
            pnlFiltros.TabIndex = 0;
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
            btnLimpar.HoverBackground = Color.FromArgb(150, 60, 60);
            btnLimpar.HoverForeColor = Color.White;
            btnLimpar.HoverImageTint = Color.White;
            btnLimpar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLimpar.Image = null;
            btnLimpar.ImageAutoCenter = true;
            btnLimpar.ImageExpand = new Point(0, 0);
            btnLimpar.ImageOffset = new Point(0, 0);
            btnLimpar.Location = new Point(808, 10);
            btnLimpar.Margin = new Padding(3, 0, 10, 0);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.NormalBackground = Color.FromArgb(120, 40, 40);
            btnLimpar.NormalForeColor = Color.White;
            btnLimpar.NormalImageTint = Color.White;
            btnLimpar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimpar.OutlineThickness = 1F;
            btnLimpar.PressedBackground = Color.FromArgb(90, 30, 30);
            btnLimpar.PressedForeColor = Color.White;
            btnLimpar.PressedImageTint = Color.White;
            btnLimpar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLimpar.Rounding = new Padding(8);
            btnLimpar.Size = new Size(120, 36);
            btnLimpar.TabIndex = 15;
            btnLimpar.TextAlignment = StringAlignment.Center;
            btnLimpar.TextOffset = new Point(0, 0);
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lblRelatorio
            // 
            lblRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRelatorio.ForeColor = Color.White;
            lblRelatorio.Location = new Point(15, 10);
            lblRelatorio.Name = "lblRelatorio";
            lblRelatorio.Size = new Size(75, 36);
            lblRelatorio.TabIndex = 0;
            lblRelatorio.Text = "Filtros:";
            lblRelatorio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWrapperTipoRelatorio
            // 
            pnlWrapperTipoRelatorio.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperTipoRelatorio.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperTipoRelatorio.BorderThickness = 1;
            pnlWrapperTipoRelatorio.Controls.Add(picTipoArrow);
            pnlWrapperTipoRelatorio.Controls.Add(cbTipoRelatorio);
            pnlWrapperTipoRelatorio.CornerRadius = 8;
            pnlWrapperTipoRelatorio.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperTipoRelatorio.Location = new Point(92, 10);
            pnlWrapperTipoRelatorio.Name = "pnlWrapperTipoRelatorio";
            pnlWrapperTipoRelatorio.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperTipoRelatorio.Size = new Size(320, 36);
            pnlWrapperTipoRelatorio.TabIndex = 1;
            // 
            // picTipoArrow
            // 
            picTipoArrow.Image = (Image)resources.GetObject("picTipoArrow.Image");
            picTipoArrow.Location = new Point(290, 12);
            picTipoArrow.Name = "picTipoArrow";
            picTipoArrow.Size = new Size(10, 10);
            picTipoArrow.SizeMode = PictureBoxSizeMode.Zoom;
            picTipoArrow.TabIndex = 17;
            picTipoArrow.TabStop = false;
            // 
            // cbTipoRelatorio
            // 
            cbTipoRelatorio.AutoSelectFirst = false;
            cbTipoRelatorio.BackColor = Color.FromArgb(40, 41, 52);
            cbTipoRelatorio.DrawMode = DrawMode.OwnerDrawFixed;
            cbTipoRelatorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoRelatorio.FlatStyle = FlatStyle.Flat;
            cbTipoRelatorio.Font = new Font("Segoe UI", 10F);
            cbTipoRelatorio.ForeColor = Color.White;
            cbTipoRelatorio.FormattingEnabled = true;
            cbTipoRelatorio.ItemEntryHeight = 24;
            cbTipoRelatorio.ItemHeight = 17;
            cbTipoRelatorio.Items.AddRange(new object[] { "Vendas do período", "Produtos mais vendidos", "Vendas por funcionário", "Produtos com baixo estoque", "Formas de pagamento", "Vendas por Marca", "Movimentação de estoque" });
            cbTipoRelatorio.Location = new Point(6, 6);
            cbTipoRelatorio.Margin = new Padding(0);
            cbTipoRelatorio.Name = "cbTipoRelatorio";
            cbTipoRelatorio.Placeholder = "Selecione...";
            cbTipoRelatorio.ShowPlaceholder = true;
            cbTipoRelatorio.Size = new Size(308, 23);
            cbTipoRelatorio.TabIndex = 0;
            // 
            // pnlWrapperPeriodo
            // 
            pnlWrapperPeriodo.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPeriodo.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperPeriodo.BorderThickness = 1;
            pnlWrapperPeriodo.Controls.Add(picPeriodoArrow);
            pnlWrapperPeriodo.Controls.Add(cbPeriodo);
            pnlWrapperPeriodo.CornerRadius = 8;
            pnlWrapperPeriodo.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPeriodo.Location = new Point(425, 10);
            pnlWrapperPeriodo.Name = "pnlWrapperPeriodo";
            pnlWrapperPeriodo.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperPeriodo.Size = new Size(240, 36);
            pnlWrapperPeriodo.TabIndex = 3;
            // 
            // picPeriodoArrow
            // 
            picPeriodoArrow.Image = (Image)resources.GetObject("picPeriodoArrow.Image");
            picPeriodoArrow.Location = new Point(208, 13);
            picPeriodoArrow.Name = "picPeriodoArrow";
            picPeriodoArrow.Size = new Size(10, 10);
            picPeriodoArrow.SizeMode = PictureBoxSizeMode.Zoom;
            picPeriodoArrow.TabIndex = 15;
            picPeriodoArrow.TabStop = false;
            // 
            // cbPeriodo
            // 
            cbPeriodo.AutoSelectFirst = false;
            cbPeriodo.BackColor = Color.FromArgb(40, 41, 52);
            cbPeriodo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeriodo.FlatStyle = FlatStyle.Flat;
            cbPeriodo.Font = new Font("Segoe UI", 10F);
            cbPeriodo.ForeColor = Color.White;
            cbPeriodo.FormattingEnabled = true;
            cbPeriodo.ItemEntryHeight = 24;
            cbPeriodo.ItemHeight = 17;
            cbPeriodo.Items.AddRange(new object[] { "Hoje", "Esta Semana", "Este mês", "Este Bimestre", "Este Semestre", "Semestre Passado", "Este Ano", "Ultimos anos" });
            cbPeriodo.Location = new Point(8, 6);
            cbPeriodo.Margin = new Padding(3, 0, 10, 0);
            cbPeriodo.Name = "cbPeriodo";
            cbPeriodo.Placeholder = "Selecione...";
            cbPeriodo.ShowPlaceholder = true;
            cbPeriodo.Size = new Size(224, 23);
            cbPeriodo.TabIndex = 11;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.CheckButton = false;
            btnGerarRelatorio.Checked = false;
            btnGerarRelatorio.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGerarRelatorio.CheckedForeColor = Color.White;
            btnGerarRelatorio.CheckedImageTint = Color.White;
            btnGerarRelatorio.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGerarRelatorio.Content = "Gerar Relatório";
            btnGerarRelatorio.DialogResult = DialogResult.None;
            btnGerarRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGerarRelatorio.ForeColor = Color.White;
            btnGerarRelatorio.HoverBackground = Color.FromArgb(50, 150, 100);
            btnGerarRelatorio.HoverForeColor = Color.White;
            btnGerarRelatorio.HoverImageTint = Color.White;
            btnGerarRelatorio.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGerarRelatorio.Image = null;
            btnGerarRelatorio.ImageAutoCenter = true;
            btnGerarRelatorio.ImageExpand = new Point(0, 0);
            btnGerarRelatorio.ImageOffset = new Point(0, 0);
            btnGerarRelatorio.Location = new Point(682, 10);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.NormalBackground = Color.FromArgb(40, 120, 80);
            btnGerarRelatorio.NormalForeColor = Color.White;
            btnGerarRelatorio.NormalImageTint = Color.White;
            btnGerarRelatorio.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerarRelatorio.OutlineThickness = 1F;
            btnGerarRelatorio.PressedBackground = Color.FromArgb(30, 100, 70);
            btnGerarRelatorio.PressedForeColor = Color.White;
            btnGerarRelatorio.PressedImageTint = Color.White;
            btnGerarRelatorio.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerarRelatorio.Rounding = new Padding(8);
            btnGerarRelatorio.Size = new Size(120, 36);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.TextAlignment = StringAlignment.Center;
            btnGerarRelatorio.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(28, 29, 40);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1362, 71);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1332, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Relatórios e Análises";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 660);
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
            pnlWrapperTipoRelatorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTipoArrow).EndInit();
            pnlWrapperPeriodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPeriodoArrow).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;

        private Panel pnlMain;
        private Panel pnlFiltros;
        private Label lblRelatorio;

        // ComboBoxes convertidas para NeoFlatComboBox
        private telebip_erp.Controls.RoundedPanel pnlWrapperTipoRelatorio;
        private telebip_erp.Controls.NeoFlatComboBox cbTipoRelatorio;
        private PictureBox picTipoArrow;

        private telebip_erp.Controls.RoundedPanel pnlWrapperPeriodo;
        private telebip_erp.Controls.NeoFlatComboBox cbPeriodo;
        private PictureBox picPeriodoArrow;

        private CuoreUI.Controls.cuiButton btnGerarRelatorio;

        private Panel pnlMetricas;
        private TableLayoutPanel tblMetricas;
        private Panel pnlMetrica1;
        private Label lblValor1;
        private Label lblTitulo1;
        private Panel pnlMetrica2;
        private Label lblValor2;
        private Label lblTitulo2;
        private Panel pnlMetrica3;
        private Label lblValor3;
        private Label lblTitulo3;
        private Panel pnlMetrica4;
        private Label lblValor4;
        private Label lblTitulo4;

        private Panel pnlTabela;
        public DataGridView dgvRelatorios;

        private Panel pnlAcoes;
        private CuoreUI.Controls.cuiButton btnExportarExcel;
        private CuoreUI.Controls.cuiButton btnImprimir;
        private CuoreUI.Controls.cuiButton btnLimpar;
    }
}