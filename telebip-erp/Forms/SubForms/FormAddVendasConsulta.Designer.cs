using System;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Controls;
using CuoreUI.Controls;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddVendasConsulta
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            roundedPanel1 = new RoundedPanel();
            mkDataHora = new MaskedTextBox();
            lbidVendaSelecionada = new Label();
            label1 = new Label();
            pnlWrapperFuncionario = new RoundedPanel();
            tbFuncionario = new TextBox();
            pnlWrapperEstado = new RoundedPanel();
            tbEstado = new TextBox();
            pnlWrapperForma = new RoundedPanel();
            tbForma = new TextBox();
            lbValorSuper = new Label();
            lblValorTotal = new Label();
            btnCancelarVendas = new cuiButton();
            pnlProdutos = new Panel();
            dgvProdutoTemporarios = new DataGridView();
            lblEstadoPagamento = new Label();
            lblFormaPagamento = new Label();
            lblDataHora = new Label();
            lblDesconto = new Label();
            pnlWrapperDesconto = new RoundedPanel();
            tbDesconto = new TextBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            roundedPanel1.SuspendLayout();
            pnlWrapperFuncionario.SuspendLayout();
            pnlWrapperEstado.SuspendLayout();
            pnlWrapperForma.SuspendLayout();
            pnlProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).BeginInit();
            pnlWrapperDesconto.SuspendLayout();
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
            pnlMain.Controls.Add(roundedPanel1);
            pnlMain.Controls.Add(lbidVendaSelecionada);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(pnlWrapperFuncionario);
            pnlMain.Controls.Add(pnlWrapperEstado);
            pnlMain.Controls.Add(pnlWrapperForma);
            pnlMain.Controls.Add(lbValorSuper);
            pnlMain.Controls.Add(lblValorTotal);
            pnlMain.Controls.Add(btnCancelarVendas);
            pnlMain.Controls.Add(pnlProdutos);
            pnlMain.Controls.Add(lblEstadoPagamento);
            pnlMain.Controls.Add(lblFormaPagamento);
            pnlMain.Controls.Add(lblDataHora);
            pnlMain.Controls.Add(lblDesconto);
            pnlMain.Controls.Add(pnlWrapperDesconto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(922, 603);
            pnlMain.TabIndex = 1;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.FromArgb(40, 41, 52);
            roundedPanel1.BorderColor = Color.FromArgb(60, 62, 80);
            roundedPanel1.BorderThickness = 1;
            roundedPanel1.Controls.Add(mkDataHora);
            roundedPanel1.CornerRadius = 8;
            roundedPanel1.FillColor = Color.FromArgb(40, 41, 52);
            roundedPanel1.Location = new Point(33, 208);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(8, 6, 8, 6);
            roundedPanel1.Size = new Size(146, 36);
            roundedPanel1.TabIndex = 104;
            // 
            // mkDataHora
            // 
            mkDataHora.BackColor = Color.FromArgb(40, 41, 52);
            mkDataHora.BorderStyle = BorderStyle.None;
            mkDataHora.Font = new Font("Segoe UI", 10F);
            mkDataHora.ForeColor = Color.White;
            mkDataHora.Location = new Point(11, 9);
            mkDataHora.Mask = "00-00-0000 00:00";
            mkDataHora.Name = "mkDataHora";
            mkDataHora.Size = new Size(125, 18);
            mkDataHora.TabIndex = 38;
            mkDataHora.ValidatingType = typeof(DateTime);
            // 
            // lbidVendaSelecionada
            // 
            lbidVendaSelecionada.AutoSize = true;
            lbidVendaSelecionada.ForeColor = Color.White;
            lbidVendaSelecionada.Location = new Point(33, 30);
            lbidVendaSelecionada.Name = "lbidVendaSelecionada";
            lbidVendaSelecionada.Size = new Size(13, 15);
            lbidVendaSelecionada.TabIndex = 57;
            lbidVendaSelecionada.Text = "0";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 69);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 56;
            label1.Text = "Funcionário";
            // 
            // pnlWrapperFuncionario
            // 
            pnlWrapperFuncionario.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionario.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperFuncionario.BorderThickness = 1;
            pnlWrapperFuncionario.Controls.Add(tbFuncionario);
            pnlWrapperFuncionario.CornerRadius = 8;
            pnlWrapperFuncionario.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionario.Location = new Point(33, 92);
            pnlWrapperFuncionario.Name = "pnlWrapperFuncionario";
            pnlWrapperFuncionario.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperFuncionario.Size = new Size(809, 36);
            pnlWrapperFuncionario.TabIndex = 101;
            // 
            // tbFuncionario
            // 
            tbFuncionario.BackColor = Color.FromArgb(40, 41, 52);
            tbFuncionario.BorderStyle = BorderStyle.None;
            tbFuncionario.Font = new Font("Segoe UI", 9F);
            tbFuncionario.ForeColor = Color.White;
            tbFuncionario.Location = new Point(8, 10);
            tbFuncionario.Margin = new Padding(3, 0, 10, 0);
            tbFuncionario.Name = "tbFuncionario";
            tbFuncionario.Size = new Size(793, 16);
            tbFuncionario.TabIndex = 1;
            // 
            // pnlWrapperEstado
            // 
            pnlWrapperEstado.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperEstado.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperEstado.BorderThickness = 1;
            pnlWrapperEstado.Controls.Add(tbEstado);
            pnlWrapperEstado.CornerRadius = 8;
            pnlWrapperEstado.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperEstado.Location = new Point(33, 313);
            pnlWrapperEstado.Name = "pnlWrapperEstado";
            pnlWrapperEstado.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperEstado.Size = new Size(127, 36);
            pnlWrapperEstado.TabIndex = 102;
            // 
            // tbEstado
            // 
            tbEstado.AutoCompleteCustomSource.AddRange(new string[] { "Pago", "Pendente" });
            tbEstado.BackColor = Color.FromArgb(40, 41, 52);
            tbEstado.BorderStyle = BorderStyle.None;
            tbEstado.Font = new Font("Segoe UI", 9F);
            tbEstado.ForeColor = Color.White;
            tbEstado.Location = new Point(8, 10);
            tbEstado.Margin = new Padding(3, 0, 10, 0);
            tbEstado.Name = "tbEstado";
            tbEstado.Size = new Size(111, 16);
            tbEstado.TabIndex = 2;
            // 
            // pnlWrapperForma
            // 
            pnlWrapperForma.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperForma.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperForma.BorderThickness = 1;
            pnlWrapperForma.Controls.Add(tbForma);
            pnlWrapperForma.CornerRadius = 8;
            pnlWrapperForma.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperForma.Location = new Point(191, 313);
            pnlWrapperForma.Name = "pnlWrapperForma";
            pnlWrapperForma.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperForma.Size = new Size(125, 36);
            pnlWrapperForma.TabIndex = 103;
            // 
            // tbForma
            // 
            tbForma.AutoCompleteCustomSource.AddRange(new string[] { "Pix", "Dinheiro", "Debito ", "Credito", "Ausente" });
            tbForma.BackColor = Color.FromArgb(40, 41, 52);
            tbForma.BorderStyle = BorderStyle.None;
            tbForma.Font = new Font("Segoe UI", 9F);
            tbForma.ForeColor = Color.White;
            tbForma.Location = new Point(8, 10);
            tbForma.Margin = new Padding(3, 0, 10, 0);
            tbForma.Name = "tbForma";
            tbForma.Size = new Size(109, 16);
            tbForma.TabIndex = 3;
            // 
            // lbValorSuper
            // 
            lbValorSuper.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbValorSuper.ForeColor = Color.LightGreen;
            lbValorSuper.Location = new Point(126, 530);
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
            lblValorTotal.Location = new Point(33, 530);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(87, 40);
            lblValorTotal.TabIndex = 49;
            lblValorTotal.Text = "Valor Total:";
            lblValorTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancelarVendas
            // 
            btnCancelarVendas.CheckButton = false;
            btnCancelarVendas.Checked = false;
            btnCancelarVendas.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnCancelarVendas.CheckedForeColor = Color.White;
            btnCancelarVendas.CheckedImageTint = Color.White;
            btnCancelarVendas.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnCancelarVendas.Content = "Sair";
            btnCancelarVendas.DialogResult = DialogResult.None;
            btnCancelarVendas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelarVendas.ForeColor = Color.White;
            btnCancelarVendas.HoverBackground = Color.White;
            btnCancelarVendas.HoverForeColor = Color.Black;
            btnCancelarVendas.HoverImageTint = Color.White;
            btnCancelarVendas.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelarVendas.Image = null;
            btnCancelarVendas.ImageAutoCenter = true;
            btnCancelarVendas.ImageExpand = new Point(0, 0);
            btnCancelarVendas.ImageOffset = new Point(0, 0);
            btnCancelarVendas.Location = new Point(762, 533);
            btnCancelarVendas.Margin = new Padding(3, 0, 10, 0);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvProdutoTemporarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProdutoTemporarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvProdutoTemporarios.BorderStyle = BorderStyle.None;
            dgvProdutoTemporarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProdutoTemporarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProdutoTemporarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProdutoTemporarios.ColumnHeadersHeight = 35;
            dgvProdutoTemporarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProdutoTemporarios.DefaultCellStyle = dataGridViewCellStyle3;
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
            // lblEstadoPagamento
            // 
            lblEstadoPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoPagamento.ForeColor = Color.White;
            lblEstadoPagamento.Location = new Point(33, 290);
            lblEstadoPagamento.Name = "lblEstadoPagamento";
            lblEstadoPagamento.Size = new Size(127, 20);
            lblEstadoPagamento.TabIndex = 36;
            lblEstadoPagamento.Text = "Estado do Pagamento *";
            // 
            // lblFormaPagamento
            // 
            lblFormaPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFormaPagamento.ForeColor = Color.White;
            lblFormaPagamento.Location = new Point(188, 290);
            lblFormaPagamento.Name = "lblFormaPagamento";
            lblFormaPagamento.Size = new Size(128, 20);
            lblFormaPagamento.TabIndex = 34;
            lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // lblDataHora
            // 
            lblDataHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDataHora.ForeColor = Color.White;
            lblDataHora.Location = new Point(33, 185);
            lblDataHora.Name = "lblDataHora";
            lblDataHora.Size = new Size(73, 20);
            lblDataHora.TabIndex = 32;
            lblDataHora.Text = "Data e Hora *";
            // 
            // lblDesconto
            // 
            lblDesconto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesconto.ForeColor = Color.White;
            lblDesconto.Location = new Point(353, 290);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(143, 20);
            lblDesconto.TabIndex = 29;
            lblDesconto.Text = "Desconto sobre o Total";
            // 
            // pnlWrapperDesconto
            // 
            pnlWrapperDesconto.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperDesconto.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperDesconto.BorderThickness = 1;
            pnlWrapperDesconto.Controls.Add(tbDesconto);
            pnlWrapperDesconto.CornerRadius = 8;
            pnlWrapperDesconto.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperDesconto.Location = new Point(353, 313);
            pnlWrapperDesconto.Name = "pnlWrapperDesconto";
            pnlWrapperDesconto.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperDesconto.Size = new Size(143, 36);
            pnlWrapperDesconto.TabIndex = 104;
            // 
            // tbDesconto
            // 
            tbDesconto.BackColor = Color.FromArgb(40, 41, 52);
            tbDesconto.BorderStyle = BorderStyle.None;
            tbDesconto.Font = new Font("Segoe UI", 9F);
            tbDesconto.ForeColor = Color.White;
            tbDesconto.Location = new Point(8, 10);
            tbDesconto.Margin = new Padding(3, 0, 10, 0);
            tbDesconto.MaxLength = 11;
            tbDesconto.Name = "tbDesconto";
            tbDesconto.Size = new Size(114, 16);
            tbDesconto.TabIndex = 4;
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
            lblTitulo.Text = "Consultar Venda";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddVendasConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(928, 690);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(928, 690);
            MinimumSize = new Size(928, 690);
            Name = "FormAddVendasConsulta";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddVendas";
            Load += FormAddVendas_Load_1;
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            pnlWrapperFuncionario.ResumeLayout(false);
            pnlWrapperFuncionario.PerformLayout();
            pnlWrapperEstado.ResumeLayout(false);
            pnlWrapperEstado.PerformLayout();
            pnlWrapperForma.ResumeLayout(false);
            pnlWrapperForma.PerformLayout();
            pnlProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).EndInit();
            pnlWrapperDesconto.ResumeLayout(false);
            pnlWrapperDesconto.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Designer fields
        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;

        private Label lbidVendaSelecionada;
        private Label label1;

        // Wrappers (RoundedPanel) substituindo controles Guna
        private RoundedPanel pnlWrapperFuncionario;
        public TextBox tbFuncionario;

        private RoundedPanel pnlWrapperForma;
        public TextBox tbForma;

        private RoundedPanel pnlWrapperEstado;
        public TextBox tbEstado;

        private RoundedPanel pnlWrapperDesconto;
        public TextBox tbDesconto;

        private Label lbValorSuper;
        private Label lblValorTotal;

        private cuiButton btnCancelarVendas;

        private Panel pnlProdutos;
        private DataGridView dgvProdutoTemporarios;

        private MaskedTextBox mkDataHora;
        private Label lblEstadoPagamento;
        private Label lblFormaPagamento;
        private Label lblDataHora;
        private Label lblDesconto;
        private RoundedPanel roundedPanel1;
    }
}
