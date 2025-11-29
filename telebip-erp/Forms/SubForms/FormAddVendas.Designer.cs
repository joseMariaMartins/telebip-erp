using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddVendas
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddVendas));
            pnlContainer = new Panel();
            pnlMain = new Panel();
            label1 = new Label();
            btnAdicionarItem = new CuoreUI.Controls.cuiButton();
            roundedPanel4 = new telebip_erp.Controls.RoundedPanel();
            tbPrecoProduto = new telebip_erp.Controls.PlaceholderTextBox();
            btnRemoverItem = new CuoreUI.Controls.cuiButton();
            roundedPanel3 = new telebip_erp.Controls.RoundedPanel();
            tbDesconto = new telebip_erp.Controls.PlaceholderTextBox();
            roundedPanel2 = new telebip_erp.Controls.RoundedPanel();
            tbQProduto = new telebip_erp.Controls.PlaceholderTextBox();
            lbValorSuper = new Label();
            lblValorTotal = new Label();
            btnAdicionarVendas = new CuoreUI.Controls.cuiButton();
            btnCancelarVendas = new CuoreUI.Controls.cuiButton();
            pnlProdutos = new Panel();
            dgvProdutoTemporarios = new DataGridView();
            lbMarcaProduto = new Label();
            lbIdProduto = new Label();
            lbQuantidadeAtual = new Label();
            pnlWrapperData = new telebip_erp.Controls.RoundedPanel();
            mkDataHora = new MaskedTextBox();
            lblDataHora = new Label();
            pnlWrapperEstado = new telebip_erp.Controls.RoundedPanel();
            pictureBox2 = new PictureBox();
            cbEstado = new telebip_erp.Controls.NeoFlatComboBox();
            lblEstadoPagamento = new Label();
            pnlWrapperForma = new telebip_erp.Controls.RoundedPanel();
            pictureBox3 = new PictureBox();
            cbForma = new telebip_erp.Controls.NeoFlatComboBox();
            lblFormaPagamento = new Label();
            pnlWrapperFuncionarios = new telebip_erp.Controls.RoundedPanel();
            pictureBox1 = new PictureBox();
            cbFuncionariosVenda = new telebip_erp.Controls.NeoFlatComboBox();
            lblFuncionario = new Label();
            roundedPanel1 = new telebip_erp.Controls.RoundedPanel();
            tbNomeProduto = new telebip_erp.Controls.PlaceholderTextBox();
            btnMaisInformacao = new PictureBox();
            lblProduto = new Label();
            lblPreco = new Label();
            lblQuantidadeVendida = new Label();
            lblDesconto = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            roundedPanel4.SuspendLayout();
            roundedPanel3.SuspendLayout();
            roundedPanel2.SuspendLayout();
            pnlProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).BeginInit();
            pnlWrapperData.SuspendLayout();
            pnlWrapperEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlWrapperForma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlWrapperFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnMaisInformacao).BeginInit();
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
            pnlContainer.Size = new Size(922, 743);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(btnAdicionarItem);
            pnlMain.Controls.Add(roundedPanel4);
            pnlMain.Controls.Add(btnRemoverItem);
            pnlMain.Controls.Add(roundedPanel3);
            pnlMain.Controls.Add(roundedPanel2);
            pnlMain.Controls.Add(lbValorSuper);
            pnlMain.Controls.Add(lblValorTotal);
            pnlMain.Controls.Add(btnAdicionarVendas);
            pnlMain.Controls.Add(btnCancelarVendas);
            pnlMain.Controls.Add(pnlProdutos);
            pnlMain.Controls.Add(lbMarcaProduto);
            pnlMain.Controls.Add(lbIdProduto);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(pnlWrapperData);
            pnlMain.Controls.Add(lblDataHora);
            pnlMain.Controls.Add(pnlWrapperEstado);
            pnlMain.Controls.Add(lblEstadoPagamento);
            pnlMain.Controls.Add(pnlWrapperForma);
            pnlMain.Controls.Add(lblFormaPagamento);
            pnlMain.Controls.Add(pnlWrapperFuncionarios);
            pnlMain.Controls.Add(lblFuncionario);
            pnlMain.Controls.Add(roundedPanel1);
            pnlMain.Controls.Add(lblProduto);
            pnlMain.Controls.Add(lblPreco);
            pnlMain.Controls.Add(lblQuantidadeVendida);
            pnlMain.Controls.Add(lblDesconto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(922, 683);
            pnlMain.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 366);
            label1.Name = "label1";
            label1.Size = new Size(219, 20);
            label1.TabIndex = 226;
            label1.Text = "Produtos *";
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.CheckButton = false;
            btnAdicionarItem.Checked = false;
            btnAdicionarItem.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnAdicionarItem.CheckedForeColor = Color.White;
            btnAdicionarItem.CheckedImageTint = Color.White;
            btnAdicionarItem.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnAdicionarItem.Content = "+ Adicionar";
            btnAdicionarItem.DialogResult = DialogResult.None;
            btnAdicionarItem.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnAdicionarItem.ForeColor = Color.White;
            btnAdicionarItem.HoverBackground = Color.White;
            btnAdicionarItem.HoverForeColor = Color.Black;
            btnAdicionarItem.HoverImageTint = Color.White;
            btnAdicionarItem.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnAdicionarItem.Image = null;
            btnAdicionarItem.ImageAutoCenter = true;
            btnAdicionarItem.ImageExpand = new Point(0, 0);
            btnAdicionarItem.ImageOffset = new Point(0, 0);
            btnAdicionarItem.Location = new Point(143, 389);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.NormalBackground = Color.FromArgb(40, 167, 69);
            btnAdicionarItem.NormalForeColor = Color.White;
            btnAdicionarItem.NormalImageTint = Color.White;
            btnAdicionarItem.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionarItem.OutlineThickness = 1F;
            btnAdicionarItem.PressedBackground = Color.WhiteSmoke;
            btnAdicionarItem.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnAdicionarItem.PressedImageTint = Color.White;
            btnAdicionarItem.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionarItem.Rounding = new Padding(6);
            btnAdicionarItem.Size = new Size(109, 36);
            btnAdicionarItem.TabIndex = 1;
            btnAdicionarItem.TextAlignment = StringAlignment.Center;
            btnAdicionarItem.TextOffset = new Point(0, 0);
            // 
            // roundedPanel4
            // 
            roundedPanel4.BackColor = Color.FromArgb(40, 41, 52);
            roundedPanel4.BorderColor = Color.FromArgb(60, 62, 80);
            roundedPanel4.BorderThickness = 1;
            roundedPanel4.Controls.Add(tbPrecoProduto);
            roundedPanel4.CornerRadius = 8;
            roundedPanel4.FillColor = Color.FromArgb(40, 41, 52);
            roundedPanel4.Location = new Point(33, 296);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Padding = new Padding(8, 6, 30, 6);
            roundedPanel4.Size = new Size(140, 36);
            roundedPanel4.TabIndex = 225;
            // 
            // tbPrecoProduto
            // 
            tbPrecoProduto.BackColor = Color.FromArgb(40, 41, 52);
            tbPrecoProduto.BorderStyle = BorderStyle.None;
            tbPrecoProduto.Font = new Font("Segoe UI", 9F);
            tbPrecoProduto.ForeColor = Color.White;
            tbPrecoProduto.Location = new Point(7, 10);
            tbPrecoProduto.MaxLength = 11;
            tbPrecoProduto.Name = "tbPrecoProduto";
            tbPrecoProduto.Placeholder = "0,00";
            tbPrecoProduto.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbPrecoProduto.Size = new Size(125, 16);
            tbPrecoProduto.TabIndex = 22;
            // 
            // btnRemoverItem
            // 
            btnRemoverItem.CheckButton = false;
            btnRemoverItem.Checked = false;
            btnRemoverItem.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnRemoverItem.CheckedForeColor = Color.White;
            btnRemoverItem.CheckedImageTint = Color.White;
            btnRemoverItem.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnRemoverItem.Content = "─ Remover";
            btnRemoverItem.DialogResult = DialogResult.None;
            btnRemoverItem.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnRemoverItem.ForeColor = Color.White;
            btnRemoverItem.HoverBackground = Color.White;
            btnRemoverItem.HoverForeColor = Color.Black;
            btnRemoverItem.HoverImageTint = Color.White;
            btnRemoverItem.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnRemoverItem.Image = null;
            btnRemoverItem.ImageAutoCenter = true;
            btnRemoverItem.ImageExpand = new Point(0, 0);
            btnRemoverItem.ImageOffset = new Point(0, 0);
            btnRemoverItem.Location = new Point(33, 389);
            btnRemoverItem.Name = "btnRemoverItem";
            btnRemoverItem.NormalBackground = Color.FromArgb(220, 53, 69);
            btnRemoverItem.NormalForeColor = Color.White;
            btnRemoverItem.NormalImageTint = Color.White;
            btnRemoverItem.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnRemoverItem.OutlineThickness = 1F;
            btnRemoverItem.PressedBackground = Color.WhiteSmoke;
            btnRemoverItem.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnRemoverItem.PressedImageTint = Color.White;
            btnRemoverItem.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnRemoverItem.Rounding = new Padding(6);
            btnRemoverItem.Size = new Size(104, 36);
            btnRemoverItem.TabIndex = 0;
            btnRemoverItem.TextAlignment = StringAlignment.Center;
            btnRemoverItem.TextOffset = new Point(0, 0);
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.FromArgb(40, 41, 52);
            roundedPanel3.BorderColor = Color.FromArgb(60, 62, 80);
            roundedPanel3.BorderThickness = 1;
            roundedPanel3.Controls.Add(tbDesconto);
            roundedPanel3.CornerRadius = 8;
            roundedPanel3.FillColor = Color.FromArgb(40, 41, 52);
            roundedPanel3.Location = new Point(505, 296);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Padding = new Padding(8, 6, 30, 6);
            roundedPanel3.Size = new Size(140, 36);
            roundedPanel3.TabIndex = 224;
            // 
            // tbDesconto
            // 
            tbDesconto.BackColor = Color.FromArgb(40, 41, 52);
            tbDesconto.BorderStyle = BorderStyle.None;
            tbDesconto.Font = new Font("Segoe UI", 9F);
            tbDesconto.ForeColor = Color.White;
            tbDesconto.Location = new Point(7, 10);
            tbDesconto.MaxLength = 11;
            tbDesconto.Name = "tbDesconto";
            tbDesconto.Placeholder = "0,00";
            tbDesconto.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbDesconto.Size = new Size(130, 16);
            tbDesconto.TabIndex = 28;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.FromArgb(40, 41, 52);
            roundedPanel2.BorderColor = Color.FromArgb(60, 62, 80);
            roundedPanel2.BorderThickness = 1;
            roundedPanel2.Controls.Add(tbQProduto);
            roundedPanel2.CornerRadius = 8;
            roundedPanel2.FillColor = Color.FromArgb(40, 41, 52);
            roundedPanel2.Location = new Point(706, 155);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Padding = new Padding(8, 6, 30, 6);
            roundedPanel2.Size = new Size(181, 36);
            roundedPanel2.TabIndex = 223;
            // 
            // tbQProduto
            // 
            tbQProduto.BackColor = Color.FromArgb(40, 41, 52);
            tbQProduto.BorderStyle = BorderStyle.None;
            tbQProduto.Font = new Font("Segoe UI", 9F);
            tbQProduto.ForeColor = Color.White;
            tbQProduto.Location = new Point(11, 10);
            tbQProduto.MaxLength = 5;
            tbQProduto.Name = "tbQProduto";
            tbQProduto.Placeholder = "0";
            tbQProduto.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbQProduto.Size = new Size(160, 16);
            tbQProduto.TabIndex = 23;
            // 
            // lbValorSuper
            // 
            lbValorSuper.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbValorSuper.ForeColor = Color.LightGreen;
            lbValorSuper.Location = new Point(114, 618);
            lbValorSuper.Name = "lbValorSuper";
            lbValorSuper.Size = new Size(150, 40);
            lbValorSuper.TabIndex = 48;
            lbValorSuper.Text = "R$ 0,00";
            lbValorSuper.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorTotal
            // 
            lblValorTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValorTotal.ForeColor = Color.White;
            lblValorTotal.Location = new Point(33, 618);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(87, 40);
            lblValorTotal.TabIndex = 49;
            lblValorTotal.Text = "Valor Total:";
            lblValorTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAdicionarVendas
            // 
            btnAdicionarVendas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarVendas.CheckButton = false;
            btnAdicionarVendas.Checked = false;
            btnAdicionarVendas.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnAdicionarVendas.CheckedForeColor = Color.White;
            btnAdicionarVendas.CheckedImageTint = Color.White;
            btnAdicionarVendas.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnAdicionarVendas.Content = "Finalizar Venda";
            btnAdicionarVendas.DialogResult = DialogResult.None;
            btnAdicionarVendas.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnAdicionarVendas.ForeColor = Color.White;
            btnAdicionarVendas.HoverBackground = Color.White;
            btnAdicionarVendas.HoverForeColor = Color.Black;
            btnAdicionarVendas.HoverImageTint = Color.White;
            btnAdicionarVendas.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnAdicionarVendas.Image = null;
            btnAdicionarVendas.ImageAutoCenter = true;
            btnAdicionarVendas.ImageExpand = new Point(0, 0);
            btnAdicionarVendas.ImageOffset = new Point(0, 0);
            btnAdicionarVendas.Location = new Point(767, 618);
            btnAdicionarVendas.Name = "btnAdicionarVendas";
            btnAdicionarVendas.NormalBackground = Color.FromArgb(40, 120, 80);
            btnAdicionarVendas.NormalForeColor = Color.White;
            btnAdicionarVendas.NormalImageTint = Color.White;
            btnAdicionarVendas.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionarVendas.OutlineThickness = 1F;
            btnAdicionarVendas.PressedBackground = Color.WhiteSmoke;
            btnAdicionarVendas.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnAdicionarVendas.PressedImageTint = Color.White;
            btnAdicionarVendas.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnAdicionarVendas.Rounding = new Padding(8);
            btnAdicionarVendas.Size = new Size(120, 40);
            btnAdicionarVendas.TabIndex = 47;
            btnAdicionarVendas.TextAlignment = StringAlignment.Center;
            btnAdicionarVendas.TextOffset = new Point(0, 0);
            // 
            // btnCancelarVendas
            // 
            btnCancelarVendas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarVendas.CheckButton = false;
            btnCancelarVendas.Checked = false;
            btnCancelarVendas.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnCancelarVendas.CheckedForeColor = Color.White;
            btnCancelarVendas.CheckedImageTint = Color.White;
            btnCancelarVendas.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnCancelarVendas.Content = "Cancelar";
            btnCancelarVendas.DialogResult = DialogResult.None;
            btnCancelarVendas.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnCancelarVendas.ForeColor = Color.White;
            btnCancelarVendas.HoverBackground = Color.White;
            btnCancelarVendas.HoverForeColor = Color.Black;
            btnCancelarVendas.HoverImageTint = Color.White;
            btnCancelarVendas.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelarVendas.Image = null;
            btnCancelarVendas.ImageAutoCenter = true;
            btnCancelarVendas.ImageExpand = new Point(0, 0);
            btnCancelarVendas.ImageOffset = new Point(0, 0);
            btnCancelarVendas.Location = new Point(641, 618);
            btnCancelarVendas.Name = "btnCancelarVendas";
            btnCancelarVendas.NormalBackground = Color.FromArgb(120, 40, 40);
            btnCancelarVendas.NormalForeColor = Color.White;
            btnCancelarVendas.NormalImageTint = Color.White;
            btnCancelarVendas.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelarVendas.OutlineThickness = 1F;
            btnCancelarVendas.PressedBackground = Color.WhiteSmoke;
            btnCancelarVendas.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnCancelarVendas.PressedImageTint = Color.White;
            btnCancelarVendas.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelarVendas.Rounding = new Padding(8);
            btnCancelarVendas.Size = new Size(120, 40);
            btnCancelarVendas.TabIndex = 46;
            btnCancelarVendas.TextAlignment = StringAlignment.Center;
            btnCancelarVendas.TextOffset = new Point(0, 0);
            // 
            // pnlProdutos
            // 
            pnlProdutos.BackColor = Color.FromArgb(32, 33, 39);
            pnlProdutos.Controls.Add(dgvProdutoTemporarios);
            pnlProdutos.Location = new Point(33, 442);
            pnlProdutos.Name = "pnlProdutos";
            pnlProdutos.Padding = new Padding(10);
            pnlProdutos.Size = new Size(854, 150);
            pnlProdutos.TabIndex = 45;
            // 
            // dgvProdutoTemporarios
            // 
            dgvProdutoTemporarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvProdutoTemporarios.BorderStyle = BorderStyle.None;
            dgvProdutoTemporarios.Dock = DockStyle.Fill;
            dgvProdutoTemporarios.Location = new Point(10, 10);
            dgvProdutoTemporarios.Name = "dgvProdutoTemporarios";
            dgvProdutoTemporarios.RowHeadersVisible = false;
            dgvProdutoTemporarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutoTemporarios.Size = new Size(834, 130);
            dgvProdutoTemporarios.TabIndex = 0;
            // 
            // lbMarcaProduto
            // 
            lbMarcaProduto.Location = new Point(855, 32);
            lbMarcaProduto.Name = "lbMarcaProduto";
            lbMarcaProduto.Size = new Size(100, 23);
            lbMarcaProduto.TabIndex = 57;
            lbMarcaProduto.Text = "1";
            lbMarcaProduto.Visible = false;
            // 
            // lbIdProduto
            // 
            lbIdProduto.Location = new Point(855, 6);
            lbIdProduto.Name = "lbIdProduto";
            lbIdProduto.Size = new Size(100, 23);
            lbIdProduto.TabIndex = 58;
            lbIdProduto.Text = "0";
            lbIdProduto.Visible = false;
            // 
            // lbQuantidadeAtual
            // 
            lbQuantidadeAtual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbQuantidadeAtual.ForeColor = Color.LightGreen;
            lbQuantidadeAtual.Location = new Point(706, 199);
            lbQuantidadeAtual.Name = "lbQuantidadeAtual";
            lbQuantidadeAtual.Size = new Size(181, 20);
            lbQuantidadeAtual.TabIndex = 59;
            lbQuantidadeAtual.Text = "Quantidade atual: 0";
            // 
            // pnlWrapperData
            // 
            pnlWrapperData.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperData.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperData.BorderThickness = 1;
            pnlWrapperData.Controls.Add(mkDataHora);
            pnlWrapperData.CornerRadius = 8;
            pnlWrapperData.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperData.Location = new Point(33, 231);
            pnlWrapperData.Name = "pnlWrapperData";
            pnlWrapperData.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperData.Size = new Size(125, 36);
            pnlWrapperData.TabIndex = 38;
            // 
            // mkDataHora
            // 
            mkDataHora.BackColor = Color.FromArgb(40, 41, 52);
            mkDataHora.BorderStyle = BorderStyle.None;
            mkDataHora.Font = new Font("Segoe UI", 10F);
            mkDataHora.ForeColor = Color.White;
            mkDataHora.Location = new Point(8, 9);
            mkDataHora.Mask = "00-00-0000 00:00";
            mkDataHora.Name = "mkDataHora";
            mkDataHora.Size = new Size(109, 18);
            mkDataHora.TabIndex = 300;
            mkDataHora.ValidatingType = typeof(DateTime);
            // 
            // lblDataHora
            // 
            lblDataHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDataHora.ForeColor = Color.White;
            lblDataHora.Location = new Point(33, 208);
            lblDataHora.Name = "lblDataHora";
            lblDataHora.Size = new Size(125, 20);
            lblDataHora.TabIndex = 60;
            lblDataHora.Text = "Data e Hora *";
            // 
            // pnlWrapperEstado
            // 
            pnlWrapperEstado.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperEstado.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperEstado.BorderThickness = 1;
            pnlWrapperEstado.Controls.Add(pictureBox2);
            pnlWrapperEstado.Controls.Add(cbEstado);
            pnlWrapperEstado.CornerRadius = 8;
            pnlWrapperEstado.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperEstado.Location = new Point(199, 296);
            pnlWrapperEstado.Name = "pnlWrapperEstado";
            pnlWrapperEstado.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperEstado.Size = new Size(125, 36);
            pnlWrapperEstado.TabIndex = 35;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(97, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(10, 10);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 225;
            pictureBox2.TabStop = false;
            // 
            // cbEstado
            // 
            cbEstado.AutoSelectFirst = false;
            cbEstado.BackColor = Color.FromArgb(40, 41, 52);
            cbEstado.DrawMode = DrawMode.OwnerDrawFixed;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FlatStyle = FlatStyle.Flat;
            cbEstado.Font = new Font("Segoe UI", 8F);
            cbEstado.ForeColor = Color.White;
            cbEstado.FormattingEnabled = true;
            cbEstado.ItemEntryHeight = 30;
            cbEstado.ItemHeight = 13;
            cbEstado.Items.AddRange(new object[] { "PAGO ", "PENDENTE" });
            cbEstado.Location = new Point(8, 9);
            cbEstado.Margin = new Padding(0);
            cbEstado.Name = "cbEstado";
            cbEstado.Placeholder = "Selecione...";
            cbEstado.ShowPlaceholder = true;
            cbEstado.Size = new Size(112, 19);
            cbEstado.TabIndex = 221;
            // 
            // lblEstadoPagamento
            // 
            lblEstadoPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoPagamento.ForeColor = Color.White;
            lblEstadoPagamento.Location = new Point(197, 273);
            lblEstadoPagamento.Name = "lblEstadoPagamento";
            lblEstadoPagamento.Size = new Size(127, 20);
            lblEstadoPagamento.TabIndex = 36;
            lblEstadoPagamento.Text = "Estado do Pagamento *";
            // 
            // pnlWrapperForma
            // 
            pnlWrapperForma.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperForma.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperForma.BorderThickness = 1;
            pnlWrapperForma.Controls.Add(pictureBox3);
            pnlWrapperForma.Controls.Add(cbForma);
            pnlWrapperForma.CornerRadius = 8;
            pnlWrapperForma.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperForma.Location = new Point(350, 296);
            pnlWrapperForma.Name = "pnlWrapperForma";
            pnlWrapperForma.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperForma.Size = new Size(128, 36);
            pnlWrapperForma.TabIndex = 33;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(100, 13);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(10, 10);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 215;
            pictureBox3.TabStop = false;
            // 
            // cbForma
            // 
            cbForma.AutoSelectFirst = false;
            cbForma.BackColor = Color.FromArgb(40, 41, 52);
            cbForma.DrawMode = DrawMode.OwnerDrawFixed;
            cbForma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbForma.FlatStyle = FlatStyle.Flat;
            cbForma.Font = new Font("Segoe UI", 8F);
            cbForma.ForeColor = Color.White;
            cbForma.FormattingEnabled = true;
            cbForma.ItemEntryHeight = 30;
            cbForma.ItemHeight = 13;
            cbForma.Items.AddRange(new object[] { "DINHEIRO", "CREDITO", "DEBITO", "PIX QR", "PIX", "AUSENTE" });
            cbForma.Location = new Point(8, 8);
            cbForma.Margin = new Padding(0);
            cbForma.Name = "cbForma";
            cbForma.Placeholder = "Selecione...";
            cbForma.ShowPlaceholder = true;
            cbForma.Size = new Size(113, 19);
            cbForma.TabIndex = 211;
            // 
            // lblFormaPagamento
            // 
            lblFormaPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFormaPagamento.ForeColor = Color.White;
            lblFormaPagamento.Location = new Point(350, 273);
            lblFormaPagamento.Name = "lblFormaPagamento";
            lblFormaPagamento.Size = new Size(128, 20);
            lblFormaPagamento.TabIndex = 34;
            lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // pnlWrapperFuncionarios
            // 
            pnlWrapperFuncionarios.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperFuncionarios.BorderThickness = 1;
            pnlWrapperFuncionarios.Controls.Add(pictureBox1);
            pnlWrapperFuncionarios.Controls.Add(cbFuncionariosVenda);
            pnlWrapperFuncionarios.CornerRadius = 8;
            pnlWrapperFuncionarios.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.Location = new Point(33, 55);
            pnlWrapperFuncionarios.Name = "pnlWrapperFuncionarios";
            pnlWrapperFuncionarios.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperFuncionarios.Size = new Size(854, 36);
            pnlWrapperFuncionarios.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(821, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 206;
            pictureBox1.TabStop = false;
            // 
            // cbFuncionariosVenda
            // 
            cbFuncionariosVenda.AutoSelectFirst = false;
            cbFuncionariosVenda.BackColor = Color.FromArgb(40, 41, 52);
            cbFuncionariosVenda.DrawMode = DrawMode.OwnerDrawFixed;
            cbFuncionariosVenda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionariosVenda.FlatStyle = FlatStyle.Flat;
            cbFuncionariosVenda.Font = new Font("Segoe UI", 8F);
            cbFuncionariosVenda.ForeColor = Color.White;
            cbFuncionariosVenda.FormattingEnabled = true;
            cbFuncionariosVenda.ItemEntryHeight = 30;
            cbFuncionariosVenda.ItemHeight = 13;
            cbFuncionariosVenda.Location = new Point(8, 8);
            cbFuncionariosVenda.Margin = new Padding(0);
            cbFuncionariosVenda.Name = "cbFuncionariosVenda";
            cbFuncionariosVenda.Placeholder = "Selecione...";
            cbFuncionariosVenda.ShowPlaceholder = true;
            cbFuncionariosVenda.Size = new Size(836, 19);
            cbFuncionariosVenda.TabIndex = 202;
            // 
            // lblFuncionario
            // 
            lblFuncionario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFuncionario.ForeColor = Color.White;
            lblFuncionario.Location = new Point(33, 32);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(142, 20);
            lblFuncionario.TabIndex = 1;
            lblFuncionario.Text = "Funcionário Responsável *";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.FromArgb(40, 41, 52);
            roundedPanel1.BorderColor = Color.FromArgb(60, 62, 80);
            roundedPanel1.BorderThickness = 1;
            roundedPanel1.Controls.Add(tbNomeProduto);
            roundedPanel1.Controls.Add(btnMaisInformacao);
            roundedPanel1.CornerRadius = 8;
            roundedPanel1.FillColor = Color.FromArgb(40, 41, 52);
            roundedPanel1.Location = new Point(33, 155);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(8, 6, 30, 6);
            roundedPanel1.Size = new Size(472, 36);
            roundedPanel1.TabIndex = 203;
            // 
            // tbNomeProduto
            // 
            tbNomeProduto.BackColor = Color.FromArgb(40, 41, 52);
            tbNomeProduto.BorderStyle = BorderStyle.None;
            tbNomeProduto.Font = new Font("Segoe UI", 9F);
            tbNomeProduto.ForeColor = Color.White;
            tbNomeProduto.Location = new Point(8, 10);
            tbNomeProduto.MaxLength = 100;
            tbNomeProduto.Name = "tbNomeProduto";
            tbNomeProduto.Placeholder = "Ex: Capinha";
            tbNomeProduto.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbNomeProduto.Size = new Size(426, 16);
            tbNomeProduto.TabIndex = 21;
            // 
            // btnMaisInformacao
            // 
            btnMaisInformacao.BackColor = Color.Transparent;
            btnMaisInformacao.Image = (Image)resources.GetObject("btnMaisInformacao.Image");
            btnMaisInformacao.Location = new Point(443, 9);
            btnMaisInformacao.Name = "btnMaisInformacao";
            btnMaisInformacao.Size = new Size(20, 18);
            btnMaisInformacao.SizeMode = PictureBoxSizeMode.Zoom;
            btnMaisInformacao.TabIndex = 53;
            btnMaisInformacao.TabStop = false;
            // 
            // lblProduto
            // 
            lblProduto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProduto.ForeColor = Color.White;
            lblProduto.Location = new Point(33, 132);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(101, 20);
            lblProduto.TabIndex = 25;
            lblProduto.Text = "Produto Vendido *";
            // 
            // lblPreco
            // 
            lblPreco.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreco.ForeColor = Color.White;
            lblPreco.Location = new Point(33, 273);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(41, 20);
            lblPreco.TabIndex = 26;
            lblPreco.Text = "Preço *";
            // 
            // lblQuantidadeVendida
            // 
            lblQuantidadeVendida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantidadeVendida.ForeColor = Color.White;
            lblQuantidadeVendida.Location = new Point(706, 132);
            lblQuantidadeVendida.Name = "lblQuantidadeVendida";
            lblQuantidadeVendida.Size = new Size(116, 20);
            lblQuantidadeVendida.TabIndex = 27;
            lblQuantidadeVendida.Text = "Quantidade Vendida*";
            // 
            // lblDesconto
            // 
            lblDesconto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesconto.ForeColor = Color.White;
            lblDesconto.Location = new Point(502, 273);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(143, 20);
            lblDesconto.TabIndex = 29;
            lblDesconto.Text = "Desconto sobre o Total";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(922, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(892, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Adicionar Venda";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(928, 770);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            Name = "FormAddVendas";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddVendas";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            roundedPanel4.ResumeLayout(false);
            roundedPanel4.PerformLayout();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            pnlProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).EndInit();
            pnlWrapperData.ResumeLayout(false);
            pnlWrapperData.PerformLayout();
            pnlWrapperEstado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlWrapperForma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlWrapperFuncionarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnMaisInformacao).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox btnMaisInformacao;
        private Label lbValorSuper;
        private Label lblValorTotal;

        private CuoreUI.Controls.cuiButton btnAdicionarVendas;
        private CuoreUI.Controls.cuiButton btnCancelarVendas;

        private Panel pnlProdutos;
        private DataGridView dgvProdutoTemporarios;
        private CuoreUI.Controls.cuiButton btnRemoverItem;
        private CuoreUI.Controls.cuiButton btnAdicionarItem;

        private Label lbMarcaProduto;
        private Label lbIdProduto;
        private Label lbQuantidadeAtual;

        // Wrappers (rounded panels) for ComboBoxes and Date/MaskedBox
        private telebip_erp.Controls.RoundedPanel pnlWrapperFuncionarios;
        public telebip_erp.Controls.NeoFlatComboBox cbFuncionariosVenda;

        private telebip_erp.Controls.RoundedPanel pnlWrapperForma;
        public telebip_erp.Controls.NeoFlatComboBox cbForma;

        private telebip_erp.Controls.RoundedPanel pnlWrapperEstado;
        public telebip_erp.Controls.NeoFlatComboBox cbEstado;

        private telebip_erp.Controls.RoundedPanel pnlWrapperData;
        public MaskedTextBox mkDataHora;

        // Product name rounded input
        private telebip_erp.Controls.RoundedPanel roundedPanel1;
        public telebip_erp.Controls.PlaceholderTextBox tbNomeProduto;

        // Placeholder TextBoxes (borderless)
        public telebip_erp.Controls.PlaceholderTextBox tbPrecoProduto;
        public telebip_erp.Controls.PlaceholderTextBox tbQProduto;
        public telebip_erp.Controls.PlaceholderTextBox tbDesconto;

        // Labels and misc
        private Label lblProduto;
        private Label lblPreco;
        private Label lblQuantidadeVendida;
        private Label lblDesconto;
        private Label lblDataHora;
        private Label lblFormaPagamento;
        private Label lblEstadoPagamento;
        private Label lblFuncionario;
        private Controls.RoundedPanel roundedPanel2;
        private Controls.RoundedPanel roundedPanel4;
        private Controls.RoundedPanel roundedPanel3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
    }
}