using Guna.UI2.WinForms.Suite;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddVendas));
            CustomizableEdges customizableEdges22 = new CustomizableEdges();
            CustomizableEdges customizableEdges23 = new CustomizableEdges();
            CustomizableEdges customizableEdges24 = new CustomizableEdges();
            CustomizableEdges customizableEdges25 = new CustomizableEdges();
            CustomizableEdges customizableEdges26 = new CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            CustomizableEdges customizableEdges27 = new CustomizableEdges();
            CustomizableEdges customizableEdges28 = new CustomizableEdges();
            CustomizableEdges customizableEdges29 = new CustomizableEdges();
            CustomizableEdges customizableEdges30 = new CustomizableEdges();
            CustomizableEdges customizableEdges31 = new CustomizableEdges();
            CustomizableEdges customizableEdges32 = new CustomizableEdges();
            CustomizableEdges customizableEdges33 = new CustomizableEdges();
            CustomizableEdges customizableEdges34 = new CustomizableEdges();
            CustomizableEdges customizableEdges35 = new CustomizableEdges();
            CustomizableEdges customizableEdges36 = new CustomizableEdges();
            CustomizableEdges customizableEdges37 = new CustomizableEdges();
            CustomizableEdges customizableEdges38 = new CustomizableEdges();
            CustomizableEdges customizableEdges39 = new CustomizableEdges();
            CustomizableEdges customizableEdges40 = new CustomizableEdges();
            CustomizableEdges customizableEdges41 = new CustomizableEdges();
            CustomizableEdges customizableEdges42 = new CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnMaisInformacao = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            lbValorSuper = new Label();
            lblValorTotal = new Label();
            btnAdicionarVendas = new Guna.UI2.WinForms.Guna2Button();
            btnCancelarVendas = new Guna.UI2.WinForms.Guna2Button();
            pnlProdutos = new Panel();
            dgvProdutoTemporarios = new DataGridView();
            pnlBotoesProduto = new Panel();
            btnTirarProduto = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            btnAdicaoProduto = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            lbMarcaProduto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbIdProduto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbQuantidadeAtual = new Label();
            mkDataHora = new MaskedTextBox();
            lblEstadoPagamento = new Label();
            cbEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            lblFormaPagamento = new Label();
            cbForma = new Guna.UI2.WinForms.Guna2ComboBox();
            lblDataHora = new Label();
            lblDesconto = new Label();
            tbDesconto = new Guna.UI2.WinForms.Guna2TextBox();
            lblQuantidadeVendida = new Label();
            lblPreco = new Label();
            lblProduto = new Label();
            tbQProduto = new Guna.UI2.WinForms.Guna2TextBox();
            tbPrecoProduto = new Guna.UI2.WinForms.Guna2TextBox();
            tbNomeProduto = new Guna.UI2.WinForms.Guna2TextBox();
            cbFuncionariosVenda = new Guna.UI2.WinForms.Guna2ComboBox();
            lblFuncionario = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lbIdvenda = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).BeginInit();
            pnlBotoesProduto.SuspendLayout();
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
            pnlContainer.Size = new Size(922, 663);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(lbIdvenda);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(btnMaisInformacao);
            pnlMain.Controls.Add(lbValorSuper);
            pnlMain.Controls.Add(lblValorTotal);
            pnlMain.Controls.Add(btnAdicionarVendas);
            pnlMain.Controls.Add(btnCancelarVendas);
            pnlMain.Controls.Add(pnlProdutos);
            pnlMain.Controls.Add(pnlBotoesProduto);
            pnlMain.Controls.Add(lbMarcaProduto);
            pnlMain.Controls.Add(lbIdProduto);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(mkDataHora);
            pnlMain.Controls.Add(lblEstadoPagamento);
            pnlMain.Controls.Add(cbEstado);
            pnlMain.Controls.Add(lblFormaPagamento);
            pnlMain.Controls.Add(cbForma);
            pnlMain.Controls.Add(lblDataHora);
            pnlMain.Controls.Add(lblDesconto);
            pnlMain.Controls.Add(tbDesconto);
            pnlMain.Controls.Add(lblQuantidadeVendida);
            pnlMain.Controls.Add(lblPreco);
            pnlMain.Controls.Add(lblProduto);
            pnlMain.Controls.Add(tbQProduto);
            pnlMain.Controls.Add(tbPrecoProduto);
            pnlMain.Controls.Add(tbNomeProduto);
            pnlMain.Controls.Add(cbFuncionariosVenda);
            pnlMain.Controls.Add(lblFuncionario);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(922, 603);
            pnlMain.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(706, 270);
            label2.Name = "label2";
            label2.Size = new Size(15, 20);
            label2.TabIndex = 55;
            label2.Text = "+";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(651, 270);
            label1.Name = "label1";
            label1.Size = new Size(15, 20);
            label1.TabIndex = 54;
            label1.Text = "-";
            // 
            // btnMaisInformacao
            // 
            btnMaisInformacao.BackColor = Color.Transparent;
            btnMaisInformacao.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            btnMaisInformacao.Image = (Image)resources.GetObject("btnMaisInformacao.Image");
            btnMaisInformacao.ImageOffset = new Point(0, 0);
            btnMaisInformacao.ImageRotate = 0F;
            btnMaisInformacao.Location = new Point(425, 154);
            btnMaisInformacao.Name = "btnMaisInformacao";
            btnMaisInformacao.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnMaisInformacao.Size = new Size(30, 30);
            btnMaisInformacao.TabIndex = 53;
            btnMaisInformacao.UseTransparentBackground = true;
            // 
            // lbValorSuper
            // 
            lbValorSuper.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbValorSuper.ForeColor = Color.LightGreen;
            lbValorSuper.Location = new Point(462, 538);
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
            lblValorTotal.Location = new Point(369, 538);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(87, 40);
            lblValorTotal.TabIndex = 49;
            lblValorTotal.Text = "Valor Total:";
            lblValorTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAdicionarVendas
            // 
            btnAdicionarVendas.BorderRadius = 8;
            btnAdicionarVendas.CustomizableEdges = customizableEdges23;
            btnAdicionarVendas.DisabledState.BorderColor = Color.DarkGray;
            btnAdicionarVendas.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdicionarVendas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdicionarVendas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdicionarVendas.FillColor = Color.FromArgb(40, 120, 80);
            btnAdicionarVendas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdicionarVendas.ForeColor = Color.White;
            btnAdicionarVendas.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnAdicionarVendas.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnAdicionarVendas.Location = new Point(752, 538);
            btnAdicionarVendas.Name = "btnAdicionarVendas";
            btnAdicionarVendas.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnAdicionarVendas.Size = new Size(120, 40);
            btnAdicionarVendas.TabIndex = 47;
            btnAdicionarVendas.Text = "Adicionar";
            btnAdicionarVendas.Click += btnAdicionarVendas_Click_1;
            // 
            // btnCancelarVendas
            // 
            btnCancelarVendas.BorderRadius = 8;
            btnCancelarVendas.CustomizableEdges = customizableEdges25;
            btnCancelarVendas.DisabledState.BorderColor = Color.DarkGray;
            btnCancelarVendas.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelarVendas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelarVendas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelarVendas.FillColor = Color.FromArgb(120, 40, 40);
            btnCancelarVendas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelarVendas.ForeColor = Color.White;
            btnCancelarVendas.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnCancelarVendas.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnCancelarVendas.Location = new Point(622, 538);
            btnCancelarVendas.Name = "btnCancelarVendas";
            btnCancelarVendas.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnCancelarVendas.Size = new Size(120, 40);
            btnCancelarVendas.TabIndex = 46;
            btnCancelarVendas.Text = "Cancelar";
            btnCancelarVendas.Click += btnCancelarVendas_Click_1;
            // 
            // pnlProdutos
            // 
            pnlProdutos.BackColor = Color.FromArgb(32, 33, 39);
            pnlProdutos.Controls.Add(dgvProdutoTemporarios);
            pnlProdutos.Location = new Point(33, 368);
            pnlProdutos.Name = "pnlProdutos";
            pnlProdutos.Padding = new Padding(10);
            pnlProdutos.Size = new Size(854, 150);
            pnlProdutos.TabIndex = 45;
            // 
            // dgvProdutoTemporarios
            // 
            dgvProdutoTemporarios.AllowUserToAddRows = false;
            dgvProdutoTemporarios.AllowUserToDeleteRows = false;
            dgvProdutoTemporarios.AllowUserToResizeColumns = false;
            dgvProdutoTemporarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvProdutoTemporarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvProdutoTemporarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvProdutoTemporarios.BorderStyle = BorderStyle.None;
            dgvProdutoTemporarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProdutoTemporarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvProdutoTemporarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvProdutoTemporarios.ColumnHeadersHeight = 35;
            dgvProdutoTemporarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvProdutoTemporarios.DefaultCellStyle = dataGridViewCellStyle6;
            dgvProdutoTemporarios.Dock = DockStyle.Fill;
            dgvProdutoTemporarios.EnableHeadersVisualStyles = false;
            dgvProdutoTemporarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvProdutoTemporarios.Location = new Point(10, 10);
            dgvProdutoTemporarios.MultiSelect = false;
            dgvProdutoTemporarios.Name = "dgvProdutoTemporarios";
            dgvProdutoTemporarios.ReadOnly = true;
            dgvProdutoTemporarios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProdutoTemporarios.RowHeadersVisible = false;
            dgvProdutoTemporarios.RowHeadersWidth = 62;
            dgvProdutoTemporarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProdutoTemporarios.RowTemplate.Height = 30;
            dgvProdutoTemporarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutoTemporarios.Size = new Size(834, 130);
            dgvProdutoTemporarios.TabIndex = 41;
            // 
            // pnlBotoesProduto
            // 
            pnlBotoesProduto.Controls.Add(btnTirarProduto);
            pnlBotoesProduto.Controls.Add(btnAdicaoProduto);
            pnlBotoesProduto.Location = new Point(631, 293);
            pnlBotoesProduto.Name = "pnlBotoesProduto";
            pnlBotoesProduto.Size = new Size(114, 36);
            pnlBotoesProduto.TabIndex = 50;
            // 
            // btnTirarProduto
            // 
            btnTirarProduto.BackColor = Color.Transparent;
            btnTirarProduto.Image = (Image)resources.GetObject("btnTirarProduto.Image");
            btnTirarProduto.ImageOffset = new Point(0, 0);
            btnTirarProduto.ImageRotate = 0F;
            btnTirarProduto.Location = new Point(5, 5);
            btnTirarProduto.Name = "btnTirarProduto";
            btnTirarProduto.ShadowDecoration.CustomizableEdges = customizableEdges27;
            btnTirarProduto.Size = new Size(48, 28);
            btnTirarProduto.TabIndex = 40;
            btnTirarProduto.UseTransparentBackground = true;
            // 
            // btnAdicaoProduto
            // 
            btnAdicaoProduto.BackColor = Color.Transparent;
            btnAdicaoProduto.Image = (Image)resources.GetObject("btnAdicaoProduto.Image");
            btnAdicaoProduto.ImageOffset = new Point(0, 0);
            btnAdicaoProduto.ImageRotate = 0F;
            btnAdicaoProduto.Location = new Point(59, 5);
            btnAdicaoProduto.Name = "btnAdicaoProduto";
            btnAdicaoProduto.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnAdicaoProduto.Size = new Size(48, 28);
            btnAdicaoProduto.TabIndex = 40;
            btnAdicaoProduto.UseTransparentBackground = true;
            // 
            // lbMarcaProduto
            // 
            lbMarcaProduto.BackColor = Color.Transparent;
            lbMarcaProduto.ForeColor = Color.White;
            lbMarcaProduto.Location = new Point(855, 32);
            lbMarcaProduto.Name = "lbMarcaProduto";
            lbMarcaProduto.Size = new Size(9, 17);
            lbMarcaProduto.TabIndex = 44;
            lbMarcaProduto.Text = "1";
            lbMarcaProduto.Visible = false;
            // 
            // lbIdProduto
            // 
            lbIdProduto.BackColor = Color.Transparent;
            lbIdProduto.ForeColor = Color.White;
            lbIdProduto.Location = new Point(855, 6);
            lbIdProduto.Name = "lbIdProduto";
            lbIdProduto.Size = new Size(9, 17);
            lbIdProduto.TabIndex = 43;
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
            lbQuantidadeAtual.TabIndex = 39;
            lbQuantidadeAtual.Text = "Quantidade atual: 0";
            // 
            // mkDataHora
            // 
            mkDataHora.BackColor = Color.FromArgb(40, 41, 52);
            mkDataHora.BorderStyle = BorderStyle.None;
            mkDataHora.Font = new Font("Segoe UI", 10F);
            mkDataHora.ForeColor = Color.White;
            mkDataHora.Location = new Point(33, 231);
            mkDataHora.Mask = "00-00-0000 00:00";
            mkDataHora.Name = "mkDataHora";
            mkDataHora.Size = new Size(125, 18);
            mkDataHora.TabIndex = 38;
            mkDataHora.ValidatingType = typeof(DateTime);
            // 
            // lblEstadoPagamento
            // 
            lblEstadoPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoPagamento.ForeColor = Color.White;
            lblEstadoPagamento.Location = new Point(178, 270);
            lblEstadoPagamento.Name = "lblEstadoPagamento";
            lblEstadoPagamento.Size = new Size(127, 20);
            lblEstadoPagamento.TabIndex = 36;
            lblEstadoPagamento.Text = "Estado do Pagamento *";
            // 
            // cbEstado
            // 
            cbEstado.BackColor = Color.Transparent;
            cbEstado.BorderColor = Color.FromArgb(60, 62, 80);
            cbEstado.BorderRadius = 8;
            cbEstado.CustomizableEdges = customizableEdges29;
            cbEstado.DrawMode = DrawMode.OwnerDrawFixed;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FillColor = Color.FromArgb(40, 41, 52);
            cbEstado.FocusedColor = Color.FromArgb(100, 150, 200);
            cbEstado.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbEstado.Font = new Font("Segoe UI", 9F);
            cbEstado.ForeColor = Color.White;
            cbEstado.ItemHeight = 30;
            cbEstado.Items.AddRange(new object[] { "Pago", "Pendente" });
            cbEstado.Location = new Point(180, 293);
            cbEstado.Name = "cbEstado";
            cbEstado.ShadowDecoration.CustomizableEdges = customizableEdges30;
            cbEstado.Size = new Size(125, 36);
            cbEstado.TabIndex = 35;
            // 
            // lblFormaPagamento
            // 
            lblFormaPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFormaPagamento.ForeColor = Color.White;
            lblFormaPagamento.Location = new Point(331, 270);
            lblFormaPagamento.Name = "lblFormaPagamento";
            lblFormaPagamento.Size = new Size(128, 20);
            lblFormaPagamento.TabIndex = 34;
            lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // cbForma
            // 
            cbForma.BackColor = Color.Transparent;
            cbForma.BorderColor = Color.FromArgb(60, 62, 80);
            cbForma.BorderRadius = 8;
            cbForma.CustomizableEdges = customizableEdges31;
            cbForma.DrawMode = DrawMode.OwnerDrawFixed;
            cbForma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbForma.FillColor = Color.FromArgb(40, 41, 52);
            cbForma.FocusedColor = Color.FromArgb(100, 150, 200);
            cbForma.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbForma.Font = new Font("Segoe UI", 9F);
            cbForma.ForeColor = Color.White;
            cbForma.ItemHeight = 30;
            cbForma.Items.AddRange(new object[] { "Dinheiro", "Cartao", "Pix", "Ausente" });
            cbForma.Location = new Point(331, 293);
            cbForma.Name = "cbForma";
            cbForma.ShadowDecoration.CustomizableEdges = customizableEdges32;
            cbForma.Size = new Size(128, 36);
            cbForma.TabIndex = 33;
            // 
            // lblDataHora
            // 
            lblDataHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDataHora.ForeColor = Color.White;
            lblDataHora.Location = new Point(33, 208);
            lblDataHora.Name = "lblDataHora";
            lblDataHora.Size = new Size(73, 20);
            lblDataHora.TabIndex = 32;
            lblDataHora.Text = "Data e Hora *";
            // 
            // lblDesconto
            // 
            lblDesconto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesconto.ForeColor = Color.White;
            lblDesconto.Location = new Point(482, 273);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(143, 20);
            lblDesconto.TabIndex = 29;
            lblDesconto.Text = "Desconto sobre o Total";
            // 
            // tbDesconto
            // 
            tbDesconto.BorderColor = Color.FromArgb(60, 62, 80);
            tbDesconto.BorderRadius = 8;
            tbDesconto.CustomizableEdges = customizableEdges33;
            tbDesconto.DefaultText = "";
            tbDesconto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbDesconto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbDesconto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbDesconto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbDesconto.FillColor = Color.FromArgb(40, 41, 52);
            tbDesconto.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbDesconto.Font = new Font("Segoe UI", 9F);
            tbDesconto.ForeColor = Color.White;
            tbDesconto.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbDesconto.Location = new Point(482, 293);
            tbDesconto.Margin = new Padding(3, 0, 10, 0);
            tbDesconto.MaxLength = 11;
            tbDesconto.Name = "tbDesconto";
            tbDesconto.PlaceholderForeColor = Color.Gray;
            tbDesconto.PlaceholderText = "";
            tbDesconto.SelectedText = "";
            tbDesconto.ShadowDecoration.CustomizableEdges = customizableEdges34;
            tbDesconto.Size = new Size(130, 36);
            tbDesconto.TabIndex = 28;
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
            // tbQProduto
            // 
            tbQProduto.BorderColor = Color.FromArgb(60, 62, 80);
            tbQProduto.BorderRadius = 8;
            tbQProduto.CustomizableEdges = customizableEdges35;
            tbQProduto.DefaultText = "";
            tbQProduto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQProduto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbQProduto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbQProduto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQProduto.FillColor = Color.FromArgb(40, 41, 52);
            tbQProduto.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQProduto.Font = new Font("Segoe UI", 9F);
            tbQProduto.ForeColor = Color.White;
            tbQProduto.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQProduto.Location = new Point(706, 152);
            tbQProduto.Margin = new Padding(3, 0, 10, 0);
            tbQProduto.MaxLength = 5;
            tbQProduto.Name = "tbQProduto";
            tbQProduto.PlaceholderForeColor = Color.Gray;
            tbQProduto.PlaceholderText = "Ex: 10";
            tbQProduto.SelectedText = "";
            tbQProduto.ShadowDecoration.CustomizableEdges = customizableEdges36;
            tbQProduto.Size = new Size(181, 36);
            tbQProduto.TabIndex = 23;
            // 
            // tbPrecoProduto
            // 
            tbPrecoProduto.BorderColor = Color.FromArgb(60, 62, 80);
            tbPrecoProduto.BorderRadius = 8;
            tbPrecoProduto.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            tbPrecoProduto.CustomizableEdges = customizableEdges37;
            tbPrecoProduto.DefaultText = "";
            tbPrecoProduto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPrecoProduto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPrecoProduto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPrecoProduto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPrecoProduto.FillColor = Color.FromArgb(40, 41, 52);
            tbPrecoProduto.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPrecoProduto.Font = new Font("Segoe UI", 9F);
            tbPrecoProduto.ForeColor = Color.White;
            tbPrecoProduto.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPrecoProduto.Location = new Point(33, 293);
            tbPrecoProduto.MaxLength = 11;
            tbPrecoProduto.Name = "tbPrecoProduto";
            tbPrecoProduto.PlaceholderForeColor = Color.Gray;
            tbPrecoProduto.PlaceholderText = "";
            tbPrecoProduto.SelectedText = "";
            tbPrecoProduto.ShadowDecoration.CustomizableEdges = customizableEdges38;
            tbPrecoProduto.Size = new Size(125, 36);
            tbPrecoProduto.TabIndex = 22;
            tbPrecoProduto.TextChanged += TbPrecoProduto_TextChanged;
            // 
            // tbNomeProduto
            // 
            tbNomeProduto.BorderColor = Color.FromArgb(60, 62, 80);
            tbNomeProduto.BorderRadius = 8;
            tbNomeProduto.CustomizableEdges = customizableEdges39;
            tbNomeProduto.DefaultText = "";
            tbNomeProduto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbNomeProduto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbNomeProduto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbNomeProduto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbNomeProduto.FillColor = Color.FromArgb(40, 41, 52);
            tbNomeProduto.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbNomeProduto.Font = new Font("Segoe UI", 9F);
            tbNomeProduto.ForeColor = Color.White;
            tbNomeProduto.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbNomeProduto.Location = new Point(33, 152);
            tbNomeProduto.Margin = new Padding(3, 0, 10, 0);
            tbNomeProduto.MaxLength = 100;
            tbNomeProduto.Name = "tbNomeProduto";
            tbNomeProduto.PlaceholderForeColor = Color.Gray;
            tbNomeProduto.PlaceholderText = "Ex: Carregador USB-C";
            tbNomeProduto.SelectedText = "";
            tbNomeProduto.ShadowDecoration.CustomizableEdges = customizableEdges40;
            tbNomeProduto.Size = new Size(426, 36);
            tbNomeProduto.TabIndex = 21;
            tbNomeProduto.KeyDown += tbNomeProduto_KeyDown;
            // 
            // cbFuncionariosVenda
            // 
            cbFuncionariosVenda.BackColor = Color.Transparent;
            cbFuncionariosVenda.BorderColor = Color.FromArgb(60, 62, 80);
            cbFuncionariosVenda.BorderRadius = 8;
            cbFuncionariosVenda.CustomizableEdges = customizableEdges41;
            cbFuncionariosVenda.DrawMode = DrawMode.OwnerDrawFixed;
            cbFuncionariosVenda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionariosVenda.FillColor = Color.FromArgb(40, 41, 52);
            cbFuncionariosVenda.FocusedColor = Color.FromArgb(100, 150, 200);
            cbFuncionariosVenda.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbFuncionariosVenda.Font = new Font("Segoe UI", 9F);
            cbFuncionariosVenda.ForeColor = Color.White;
            cbFuncionariosVenda.ItemHeight = 30;
            cbFuncionariosVenda.Location = new Point(33, 55);
            cbFuncionariosVenda.Name = "cbFuncionariosVenda";
            cbFuncionariosVenda.ShadowDecoration.CustomizableEdges = customizableEdges42;
            cbFuncionariosVenda.Size = new Size(854, 36);
            cbFuncionariosVenda.TabIndex = 20;
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
            // lbIdvenda
            // 
            lbIdvenda.BackColor = Color.Transparent;
            lbIdvenda.ForeColor = Color.White;
            lbIdvenda.Location = new Point(813, 6);
            lbIdvenda.Name = "lbIdvenda";
            lbIdvenda.Size = new Size(9, 17);
            lbIdvenda.TabIndex = 56;
            lbIdvenda.Text = "1";
            lbIdvenda.Visible = false;
            // 
            // FormAddVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(928, 690);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(928, 690);
            MinimumSize = new Size(928, 690);
            Name = "FormAddVendas";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddVendas";
            Load += FormAddVendas_Load_1;
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).EndInit();
            pnlBotoesProduto.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblFuncionario;
        public Guna.UI2.WinForms.Guna2ComboBox cbFuncionariosVenda;
        public Guna.UI2.WinForms.Guna2TextBox tbNomeProduto;
        public Guna.UI2.WinForms.Guna2TextBox tbPrecoProduto;
        public Guna.UI2.WinForms.Guna2TextBox tbQProduto;
        private Label lblProduto;
        private Label lblPreco;
        private Label lblQuantidadeVendida;
        public Guna.UI2.WinForms.Guna2TextBox tbDesconto;
        private Label lblDesconto;
        private Label lblDataHora;
        public Guna.UI2.WinForms.Guna2ComboBox cbForma;
        private Label lblFormaPagamento;
        public Guna.UI2.WinForms.Guna2ComboBox cbEstado;
        private Label lblEstadoPagamento;
        private MaskedTextBox mkDataHora;
        private Label lbQuantidadeAtual;
        private DataGridView dgvProdutoTemporarios;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbIdProduto;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMarcaProduto;
        private Guna.UI2.WinForms.Guna2Button btnCancelarVendas;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarVendas;
        private Label lbValorSuper;
        private Label lblValorTotal;
        private Panel pnlProdutos;
        private Panel pnlBotoesProduto;
        private Guna.UI2.WinForms.Guna2ImageRadioButton btnAdicaoProduto;
        private Guna.UI2.WinForms.Guna2ImageRadioButton btnTirarProduto;
        private Guna.UI2.WinForms.Guna2ImageRadioButton btnMaisInformacao;
        private Label label2;
        private Label label1;
        public Guna.UI2.WinForms.Guna2HtmlLabel lbIdvenda;
    }
}