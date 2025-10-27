using Guna.UI2.WinForms.Suite;
using System.Reflection.PortableExecutable;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddVendasConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            CustomizableEdges customizableEdges7 = new CustomizableEdges();
            CustomizableEdges customizableEdges8 = new CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            lbidVendaSelecionada = new Label();
            label1 = new Label();
            tbForma = new TextBox();
            tbEstado = new TextBox();
            tbFuncionario = new TextBox();
            lbValorSuper = new Label();
            lblValorTotal = new Label();
            btnCancelarVendas = new Guna.UI2.WinForms.Guna2Button();
            pnlProdutos = new Panel();
            dgvProdutoTemporarios = new DataGridView();
            mkDataHora = new MaskedTextBox();
            lblEstadoPagamento = new Label();
            lblFormaPagamento = new Label();
            lblDataHora = new Label();
            lblDesconto = new Label();
            tbDesconto = new Guna.UI2.WinForms.Guna2TextBox();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).BeginInit();
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
            pnlMain.Controls.Add(lbidVendaSelecionada);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(tbForma);
            pnlMain.Controls.Add(tbEstado);
            pnlMain.Controls.Add(tbFuncionario);
            pnlMain.Controls.Add(lbValorSuper);
            pnlMain.Controls.Add(lblValorTotal);
            pnlMain.Controls.Add(btnCancelarVendas);
            pnlMain.Controls.Add(pnlProdutos);
            pnlMain.Controls.Add(mkDataHora);
            pnlMain.Controls.Add(lblEstadoPagamento);
            pnlMain.Controls.Add(lblFormaPagamento);
            pnlMain.Controls.Add(lblDataHora);
            pnlMain.Controls.Add(lblDesconto);
            pnlMain.Controls.Add(tbDesconto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(922, 603);
            pnlMain.TabIndex = 1;
            // 
            // lbidVendaSelecionada
            // 
            lbidVendaSelecionada.AutoSize = true;
            lbidVendaSelecionada.ForeColor = Color.White;
            lbidVendaSelecionada.Location = new Point(61, 30);
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
            // tbForma
            // 
            tbForma.AccessibleDescription = "";
            tbForma.Location = new Point(191, 293);
            tbForma.Name = "tbForma";
            tbForma.Size = new Size(125, 23);
            tbForma.TabIndex = 55;
            // 
            // tbEstado
            // 
            tbEstado.AccessibleDescription = "";
            tbEstado.Location = new Point(33, 293);
            tbEstado.Name = "tbEstado";
            tbEstado.Size = new Size(127, 23);
            tbEstado.TabIndex = 54;
            // 
            // tbFuncionario
            // 
            tbFuncionario.AccessibleDescription = "";
            tbFuncionario.Location = new Point(33, 103);
            tbFuncionario.Name = "tbFuncionario";
            tbFuncionario.Size = new Size(809, 23);
            tbFuncionario.TabIndex = 53;
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
            btnCancelarVendas.BorderRadius = 8;
            btnCancelarVendas.CustomizableEdges = customizableEdges5;
            btnCancelarVendas.DisabledState.BorderColor = Color.DarkGray;
            btnCancelarVendas.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelarVendas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelarVendas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelarVendas.FillColor = Color.FromArgb(120, 40, 40);
            btnCancelarVendas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelarVendas.ForeColor = Color.White;
            btnCancelarVendas.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnCancelarVendas.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnCancelarVendas.Location = new Point(757, 530);
            btnCancelarVendas.Name = "btnCancelarVendas";
            btnCancelarVendas.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancelarVendas.Size = new Size(120, 40);
            btnCancelarVendas.TabIndex = 46;
            btnCancelarVendas.Text = "Sair";
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
            // mkDataHora
            // 
            mkDataHora.BackColor = Color.FromArgb(40, 41, 52);
            mkDataHora.BorderStyle = BorderStyle.None;
            mkDataHora.Font = new Font("Segoe UI", 10F);
            mkDataHora.ForeColor = Color.White;
            mkDataHora.Location = new Point(33, 208);
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
            lblEstadoPagamento.Location = new Point(33, 270);
            lblEstadoPagamento.Name = "lblEstadoPagamento";
            lblEstadoPagamento.Size = new Size(127, 20);
            lblEstadoPagamento.TabIndex = 36;
            lblEstadoPagamento.Text = "Estado do Pagamento *";
            // 
            // lblFormaPagamento
            // 
            lblFormaPagamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFormaPagamento.ForeColor = Color.White;
            lblFormaPagamento.Location = new Point(188, 270);
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
            lblDesconto.Location = new Point(419, 270);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(143, 20);
            lblDesconto.TabIndex = 29;
            lblDesconto.Text = "Desconto sobre o Total";
            // 
            // tbDesconto
            // 
            tbDesconto.BorderColor = Color.FromArgb(60, 62, 80);
            tbDesconto.BorderRadius = 8;
            tbDesconto.CustomizableEdges = customizableEdges7;
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
            tbDesconto.Location = new Point(419, 290);
            tbDesconto.Margin = new Padding(3, 0, 10, 0);
            tbDesconto.MaxLength = 11;
            tbDesconto.Name = "tbDesconto";
            tbDesconto.PlaceholderForeColor = Color.Gray;
            tbDesconto.PlaceholderText = "";
            tbDesconto.SelectedText = "";
            tbDesconto.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbDesconto.Size = new Size(130, 36);
            tbDesconto.TabIndex = 28;
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
            pnlProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutoTemporarios).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        public Guna.UI2.WinForms.Guna2TextBox tbDesconto;
        private Label lblDesconto;
        private Label lblDataHora;
        private Label lblFormaPagamento;
        private Label lblEstadoPagamento;
        private MaskedTextBox mkDataHora;
        private DataGridView dgvProdutoTemporarios;
        private Guna.UI2.WinForms.Guna2Button btnCancelarVendas;
        private Label lbValorSuper;
        private Label lblValorTotal;
        private Panel pnlProdutos;
        private TextBox tbForma;
        private TextBox tbEstado;
        private TextBox tbFuncionario;
        private Label label1;
        private Label lbidVendaSelecionada;
    }
}