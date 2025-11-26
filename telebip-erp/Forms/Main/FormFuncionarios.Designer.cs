// FormFuncionarios.Designer.cs
using System;
using System.Windows.Forms;
using System.Drawing;

namespace telebip_erp.Forms.Modules
{
    partial class FormFuncionarios
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFuncionarios));
            pnlContainer = new Panel();
            pnlDgv = new Panel();
            dgvFuncionarios = new DataGridView();
            pnlRight = new Panel();
            pnlDetailsCard = new Panel();
            tblCard = new TableLayoutPanel();
            pnlCardHeader = new Panel();
            lblCardCargo = new Label();
            lblCardNome = new Label();
            picCardAvatar = new PictureBox();
            pnlCardDivider = new Panel();
            tblInfo = new TableLayoutPanel();
            lblCardDataNascimento = new Label();
            flowCardButtons = new FlowLayoutPanel();
            btnAdicionar = new CuoreUI.Controls.cuiButton();
            btnEditar = new CuoreUI.Controls.cuiButton();
            btnRemover = new CuoreUI.Controls.cuiButton();
            pnlBottom = new Panel();
            lbTotal = new Label();
            flowFiltros = new FlowLayoutPanel();
            btnPesquisar = new CuoreUI.Controls.cuiButton();
            btnLimpar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            PictureImage2 = new PictureBox();
            picSearch = new PictureBox();
            tbSearch = new TextBox();
            pnlContainer.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            pnlRight.SuspendLayout();
            pnlDetailsCard.SuspendLayout();
            tblCard.SuspendLayout();
            pnlCardHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCardAvatar).BeginInit();
            tblInfo.SuspendLayout();
            flowCardButtons.SuspendLayout();
            pnlBottom.SuspendLayout();
            flowFiltros.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureImage2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlDgv);
            pnlContainer.Controls.Add(pnlBottom);
            pnlContainer.Controls.Add(flowFiltros);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1467, 800);
            pnlContainer.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.FromArgb(28, 29, 40);
            pnlDgv.Controls.Add(dgvFuncionarios);
            pnlDgv.Controls.Add(pnlRight);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 130);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1467, 605);
            pnlDgv.TabIndex = 4;
            // 
            // dgvFuncionarios
            // 
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.AllowUserToResizeRows = false;
            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvFuncionarios.BorderStyle = BorderStyle.None;
            dgvFuncionarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFuncionarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFuncionarios.ColumnHeadersHeight = 40;
            dgvFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFuncionarios.Dock = DockStyle.Fill;
            dgvFuncionarios.EnableHeadersVisualStyles = false;
            dgvFuncionarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvFuncionarios.Location = new Point(15, 15);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.Name = "dgvFuncionarios";
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.RowTemplate.Height = 36;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.Size = new Size(1106, 575);
            dgvFuncionarios.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(40, 41, 52);
            pnlRight.Controls.Add(pnlDetailsCard);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(1121, 15);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(12);
            pnlRight.Size = new Size(331, 575);
            pnlRight.TabIndex = 1;
            // 
            // pnlDetailsCard
            // 
            pnlDetailsCard.BackColor = Color.FromArgb(40, 41, 52);
            pnlDetailsCard.Controls.Add(tblCard);
            pnlDetailsCard.Dock = DockStyle.Fill;
            pnlDetailsCard.Location = new Point(12, 12);
            pnlDetailsCard.Name = "pnlDetailsCard";
            pnlDetailsCard.Padding = new Padding(8);
            pnlDetailsCard.Size = new Size(307, 551);
            pnlDetailsCard.TabIndex = 0;
            // 
            // tblCard
            // 
            tblCard.ColumnCount = 2;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            tblCard.Controls.Add(pnlCardHeader, 0, 0);
            tblCard.Controls.Add(picCardAvatar, 1, 0);
            tblCard.Controls.Add(pnlCardDivider, 0, 1);
            tblCard.Controls.Add(tblInfo, 0, 2);
            tblCard.Controls.Add(flowCardButtons, 0, 3);
            tblCard.Dock = DockStyle.Fill;
            tblCard.Location = new Point(8, 8);
            tblCard.Margin = new Padding(0);
            tblCard.Name = "tblCard";
            tblCard.RowCount = 4;
            tblCard.RowStyles.Add(new RowStyle());
            tblCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCard.RowStyles.Add(new RowStyle());
            tblCard.Size = new Size(291, 535);
            tblCard.TabIndex = 0;
            // 
            // pnlCardHeader
            // 
            pnlCardHeader.AutoSize = true;
            pnlCardHeader.Controls.Add(lblCardCargo);
            pnlCardHeader.Controls.Add(lblCardNome);
            pnlCardHeader.Dock = DockStyle.Fill;
            pnlCardHeader.Location = new Point(0, 0);
            pnlCardHeader.Margin = new Padding(0);
            pnlCardHeader.Name = "pnlCardHeader";
            pnlCardHeader.Padding = new Padding(0, 0, 8, 4);
            pnlCardHeader.Size = new Size(207, 72);
            pnlCardHeader.TabIndex = 0;
            // 
            // lblCardCargo
            // 
            lblCardCargo.AutoEllipsis = true;
            lblCardCargo.AutoSize = true;
            lblCardCargo.Dock = DockStyle.Top;
            lblCardCargo.Font = new Font("Segoe UI", 8F);
            lblCardCargo.ForeColor = Color.FromArgb(200, 200, 200);
            lblCardCargo.Location = new Point(0, 15);
            lblCardCargo.Margin = new Padding(0);
            lblCardCargo.Name = "lblCardCargo";
            lblCardCargo.Size = new Size(48, 13);
            lblCardCargo.TabIndex = 1;
            lblCardCargo.Text = "Cargo: -";
            // 
            // lblCardNome
            // 
            lblCardNome.AutoEllipsis = true;
            lblCardNome.AutoSize = true;
            lblCardNome.Dock = DockStyle.Top;
            lblCardNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCardNome.ForeColor = Color.White;
            lblCardNome.Location = new Point(0, 0);
            lblCardNome.Margin = new Padding(0, 0, 0, 4);
            lblCardNome.Name = "lblCardNome";
            lblCardNome.Size = new Size(188, 15);
            lblCardNome.TabIndex = 0;
            lblCardNome.Text = "Nome: (selecione um funcionário)";
            // 
            // picCardAvatar
            // 
            picCardAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picCardAvatar.BackColor = Color.Transparent;
            picCardAvatar.Location = new Point(215, 0);
            picCardAvatar.Margin = new Padding(8, 0, 0, 0);
            picCardAvatar.Name = "picCardAvatar";
            picCardAvatar.Size = new Size(76, 72);
            picCardAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picCardAvatar.TabIndex = 10;
            picCardAvatar.TabStop = false;
            // 
            // pnlCardDivider
            // 
            pnlCardDivider.BackColor = Color.FromArgb(60, 62, 80);
            tblCard.SetColumnSpan(pnlCardDivider, 2);
            pnlCardDivider.Dock = DockStyle.Fill;
            pnlCardDivider.Location = new Point(0, 78);
            pnlCardDivider.Margin = new Padding(0, 6, 0, 6);
            pnlCardDivider.Name = "pnlCardDivider";
            pnlCardDivider.Size = new Size(291, 1);
            pnlCardDivider.TabIndex = 11;
            // 
            // tblInfo
            // 
            tblInfo.ColumnCount = 1;
            tblInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInfo.Controls.Add(lblCardDataNascimento, 0, 0);
            tblInfo.Dock = DockStyle.Fill;
            tblInfo.Location = new Point(0, 80);
            tblInfo.Margin = new Padding(0);
            tblInfo.Name = "tblInfo";
            tblInfo.RowCount = 1;
            tblInfo.RowStyles.Add(new RowStyle());
            tblInfo.Size = new Size(207, 407);
            tblInfo.TabIndex = 12;
            // 
            // lblCardDataNascimento
            // 
            lblCardDataNascimento.AutoEllipsis = true;
            lblCardDataNascimento.AutoSize = true;
            lblCardDataNascimento.Font = new Font("Segoe UI", 9F);
            lblCardDataNascimento.ForeColor = Color.White;
            lblCardDataNascimento.Location = new Point(0, 0);
            lblCardDataNascimento.Margin = new Padding(0, 0, 0, 6);
            lblCardDataNascimento.Name = "lblCardDataNascimento";
            lblCardDataNascimento.Size = new Size(125, 15);
            lblCardDataNascimento.TabIndex = 2;
            lblCardDataNascimento.Text = "Data de Nascimento: -";
            // 
            // flowCardButtons
            // 
            flowCardButtons.AutoSize = true;
            flowCardButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblCard.SetColumnSpan(flowCardButtons, 2);
            flowCardButtons.Controls.Add(btnAdicionar);
            flowCardButtons.Controls.Add(btnEditar);
            flowCardButtons.Controls.Add(btnRemover);
            flowCardButtons.Dock = DockStyle.Fill;
            flowCardButtons.FlowDirection = FlowDirection.RightToLeft;
            flowCardButtons.Location = new Point(0, 487);
            flowCardButtons.Margin = new Padding(0);
            flowCardButtons.Name = "flowCardButtons";
            flowCardButtons.Padding = new Padding(0, 8, 0, 0);
            flowCardButtons.Size = new Size(291, 48);
            flowCardButtons.TabIndex = 13;
            flowCardButtons.WrapContents = false;
            // 
            // btnAdicionar
            // 
            btnAdicionar.CheckButton = false;
            btnAdicionar.Checked = false;
            btnAdicionar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnAdicionar.CheckedForeColor = Color.White;
            btnAdicionar.CheckedImageTint = Color.White;
            btnAdicionar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnAdicionar.Content = "Adicionar";
            btnAdicionar.DialogResult = DialogResult.None;
            btnAdicionar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.HoverBackground = Color.White;
            btnAdicionar.HoverForeColor = Color.Black;
            btnAdicionar.HoverImageTint = Color.White;
            btnAdicionar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnAdicionar.Image = null;
            btnAdicionar.ImageAutoCenter = true;
            btnAdicionar.ImageExpand = new Point(0, 0);
            btnAdicionar.ImageOffset = new Point(0, 0);
            btnAdicionar.Location = new Point(196, 10);
            btnAdicionar.Margin = new Padding(3, 2, 6, 2);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnAdicionar.NormalForeColor = Color.White;
            btnAdicionar.NormalImageTint = Color.White;
            btnAdicionar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionar.OutlineThickness = 1F;
            btnAdicionar.PressedBackground = Color.WhiteSmoke;
            btnAdicionar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnAdicionar.PressedImageTint = Color.White;
            btnAdicionar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionar.Rounding = new Padding(8);
            btnAdicionar.Size = new Size(89, 36);
            btnAdicionar.TabIndex = 15;
            btnAdicionar.TextAlignment = StringAlignment.Center;
            btnAdicionar.TextOffset = new Point(0, 0);
            // 
            // btnEditar
            // 
            btnEditar.CheckButton = false;
            btnEditar.Checked = false;
            btnEditar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnEditar.CheckedForeColor = Color.White;
            btnEditar.CheckedImageTint = Color.White;
            btnEditar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnEditar.Content = "Editar";
            btnEditar.DialogResult = DialogResult.None;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverBackground = Color.White;
            btnEditar.HoverForeColor = Color.Black;
            btnEditar.HoverImageTint = Color.White;
            btnEditar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnEditar.Image = null;
            btnEditar.ImageAutoCenter = true;
            btnEditar.ImageExpand = new Point(0, 0);
            btnEditar.ImageOffset = new Point(0, 0);
            btnEditar.Location = new Point(100, 10);
            btnEditar.Margin = new Padding(3, 2, 4, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.NormalBackground = Color.FromArgb(60, 60, 90);
            btnEditar.NormalForeColor = Color.White;
            btnEditar.NormalImageTint = Color.White;
            btnEditar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.OutlineThickness = 1F;
            btnEditar.PressedBackground = Color.WhiteSmoke;
            btnEditar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnEditar.PressedImageTint = Color.White;
            btnEditar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.Rounding = new Padding(8);
            btnEditar.Size = new Size(89, 36);
            btnEditar.TabIndex = 16;
            btnEditar.TextAlignment = StringAlignment.Center;
            btnEditar.TextOffset = new Point(0, 0);
            // 
            // btnRemover
            // 
            btnRemover.CheckButton = false;
            btnRemover.Checked = false;
            btnRemover.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnRemover.CheckedForeColor = Color.White;
            btnRemover.CheckedImageTint = Color.White;
            btnRemover.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnRemover.Content = "Remover";
            btnRemover.DialogResult = DialogResult.None;
            btnRemover.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemover.ForeColor = Color.White;
            btnRemover.HoverBackground = Color.White;
            btnRemover.HoverForeColor = Color.Black;
            btnRemover.HoverImageTint = Color.White;
            btnRemover.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnRemover.Image = null;
            btnRemover.ImageAutoCenter = true;
            btnRemover.ImageExpand = new Point(0, 0);
            btnRemover.ImageOffset = new Point(0, 0);
            btnRemover.Location = new Point(6, 10);
            btnRemover.Margin = new Padding(4, 2, 2, 2);
            btnRemover.Name = "btnRemover";
            btnRemover.NormalBackground = Color.FromArgb(120, 40, 40);
            btnRemover.NormalForeColor = Color.White;
            btnRemover.NormalImageTint = Color.White;
            btnRemover.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnRemover.OutlineThickness = 1F;
            btnRemover.PressedBackground = Color.WhiteSmoke;
            btnRemover.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnRemover.PressedImageTint = Color.White;
            btnRemover.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnRemover.Rounding = new Padding(8);
            btnRemover.Size = new Size(89, 36);
            btnRemover.TabIndex = 17;
            btnRemover.TextAlignment = StringAlignment.Center;
            btnRemover.TextOffset = new Point(0, 0);
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lbTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 735);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1467, 65);
            pnlBottom.TabIndex = 5;
            // 
            // lbTotal
            // 
            lbTotal.Dock = DockStyle.Right;
            lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotal.ForeColor = Color.White;
            lbTotal.Location = new Point(1262, 15);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(190, 35);
            lbTotal.TabIndex = 0;
            lbTotal.Text = "Total: 0 funcionários";
            lbTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowFiltros
            // 
            flowFiltros.BackColor = Color.FromArgb(32, 33, 39);
            flowFiltros.Controls.Add(btnPesquisar);
            flowFiltros.Controls.Add(btnLimpar);
            flowFiltros.Dock = DockStyle.Top;
            flowFiltros.Location = new Point(0, 71);
            flowFiltros.Name = "flowFiltros";
            flowFiltros.Padding = new Padding(10, 10, 10, 15);
            flowFiltros.Size = new Size(1467, 59);
            flowFiltros.TabIndex = 7;
            flowFiltros.WrapContents = false;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnPesquisar.Location = new Point(18, 12);
            btnPesquisar.Margin = new Padding(8, 2, 4, 2);
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
            // btnLimpar
            // 
            btnLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnLimpar.Location = new Point(146, 12);
            btnLimpar.Margin = new Padding(4, 2, 2, 2);
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
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1467, 71);
            pnlHeader.TabIndex = 6;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1437, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerenciamento de Funcionários";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PictureImage2
            // 
            PictureImage2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureImage2.Image = (Image)resources.GetObject("PictureImage2.Image");
            PictureImage2.Location = new Point(190, 13);
            PictureImage2.Name = "PictureImage2";
            PictureImage2.Size = new Size(10, 10);
            PictureImage2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureImage2.TabIndex = 17;
            PictureImage2.TabStop = false;
            // 
            // picSearch
            // 
            picSearch.BackColor = Color.Transparent;
            picSearch.Dock = DockStyle.Right;
            picSearch.Image = (Image)resources.GetObject("picSearch.Image");
            picSearch.Location = new Point(337, 6);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(15, 24);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 1;
            picSearch.TabStop = false;
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.FromArgb(40, 41, 52);
            tbSearch.BorderStyle = BorderStyle.None;
            tbSearch.Font = new Font("Segoe UI", 9F);
            tbSearch.ForeColor = Color.White;
            tbSearch.Location = new Point(11, 11);
            tbSearch.Margin = new Padding(3, 0, 10, 0);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Nome, e-mail ou telefone";
            tbSearch.Size = new Size(330, 16);
            tbSearch.TabIndex = 7;
            // 
            // FormFuncionarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1467, 800);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormFuncionarios";
            Text = "FormFuncionarios";
            pnlContainer.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            pnlRight.ResumeLayout(false);
            pnlDetailsCard.ResumeLayout(false);
            tblCard.ResumeLayout(false);
            tblCard.PerformLayout();
            pnlCardHeader.ResumeLayout(false);
            pnlCardHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCardAvatar).EndInit();
            tblInfo.ResumeLayout(false);
            tblInfo.PerformLayout();
            flowCardButtons.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            flowFiltros.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureImage2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Exposed controls
        private Panel pnlContainer;
        private Panel pnlDgv;
        public DataGridView dgvFuncionarios;
        private Panel pnlRight;

        // reworked card controls
        private Panel pnlDetailsCard;
        private TableLayoutPanel tblCard;
        private Panel pnlCardHeader;
        private Label lblCardNome;
        private Label lblCardCargo;
        private PictureBox picCardAvatar;
        private Panel pnlCardDivider;
        private TableLayoutPanel tblInfo;
        private Label lblCardDataNascimento;
        private FlowLayoutPanel flowCardButtons;

        private Panel pnlBottom;
        private Label lbTotal;

        // Use FlowLayoutPanel para filtros (responsivo)
        private FlowLayoutPanel flowFiltros;
        private CuoreUI.Controls.cuiButton btnLimpar;
        private CuoreUI.Controls.cuiButton btnPesquisar;

        // novos botoes (kept names so events stay)
        private CuoreUI.Controls.cuiButton btnAdicionar;
        private CuoreUI.Controls.cuiButton btnEditar;
        private CuoreUI.Controls.cuiButton btnRemover;

        // wrappers + controls
        private telebip_erp.Controls.RoundedPanel pnlWrapperCargo;
        private PictureBox PictureImage2;
        private telebip_erp.Controls.NeoFlatComboBox cbFiltroCargo;

        private telebip_erp.Controls.RoundedPanel pnlWrapperPesquisa;
        private PictureBox picSearch;
        private TextBox tbSearch;

        private Panel pnlHeader;
        private Label lblTitulo;
    }
}