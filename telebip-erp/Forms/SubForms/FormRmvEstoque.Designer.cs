namespace telebip_erp.Forms.SubForms
{
    partial class FormRmvEstoque
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            lbQuantidadeAtual = new Label();
            cbExcluirProduto = new Guna.UI2.WinForms.Guna2CheckBox();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            tbQuantidadeRemover = new Guna.UI2.WinForms.Guna2TextBox();
            lblQuantidade = new Label();
            lbNomeProduto = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
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
            pnlContainer.Size = new Size(375, 285);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(cbExcluirProduto);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Controls.Add(btnConfirmar);
            pnlMain.Controls.Add(tbQuantidadeRemover);
            pnlMain.Controls.Add(lblQuantidade);
            pnlMain.Controls.Add(lbNomeProduto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 50);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(25);
            pnlMain.Size = new Size(375, 235);
            pnlMain.TabIndex = 1;
            // 
            // lbQuantidadeAtual
            // 
            lbQuantidadeAtual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbQuantidadeAtual.ForeColor = Color.LightGreen;
            lbQuantidadeAtual.Location = new Point(172, 81);
            lbQuantidadeAtual.Name = "lbQuantidadeAtual";
            lbQuantidadeAtual.Size = new Size(175, 20);
            lbQuantidadeAtual.TabIndex = 6;
            lbQuantidadeAtual.Text = "Estoque atual: 0 unidades";
            lbQuantidadeAtual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbExcluirProduto
            // 
            cbExcluirProduto.AutoSize = true;
            cbExcluirProduto.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbExcluirProduto.CheckedState.BorderRadius = 0;
            cbExcluirProduto.CheckedState.BorderThickness = 0;
            cbExcluirProduto.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            cbExcluirProduto.Font = new Font("Segoe UI", 9F);
            cbExcluirProduto.ForeColor = Color.White;
            cbExcluirProduto.Location = new Point(35, 130);
            cbExcluirProduto.Name = "cbExcluirProduto";
            cbExcluirProduto.Size = new Size(172, 19);
            cbExcluirProduto.TabIndex = 5;
            cbExcluirProduto.Text = "Excluir produto do sistema?";
            cbExcluirProduto.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            cbExcluirProduto.UncheckedState.BorderRadius = 0;
            cbExcluirProduto.UncheckedState.BorderThickness = 0;
            cbExcluirProduto.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 8;
            btnCancelar.CustomizableEdges = customizableEdges1;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.FromArgb(120, 40, 40);
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnCancelar.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnCancelar.Location = new Point(35, 165);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCancelar.Size = new Size(146, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BorderRadius = 8;
            btnConfirmar.CustomizableEdges = customizableEdges3;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.FromArgb(40, 120, 80);
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnConfirmar.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnConfirmar.Location = new Point(201, 165);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirmar.Size = new Size(146, 40);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            // 
            // tbQuantidadeRemover
            // 
            tbQuantidadeRemover.BorderColor = Color.FromArgb(60, 62, 80);
            tbQuantidadeRemover.BorderRadius = 8;
            tbQuantidadeRemover.CustomizableEdges = customizableEdges5;
            tbQuantidadeRemover.DefaultText = "";
            tbQuantidadeRemover.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQuantidadeRemover.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbQuantidadeRemover.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbQuantidadeRemover.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQuantidadeRemover.FillColor = Color.FromArgb(40, 41, 52);
            tbQuantidadeRemover.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQuantidadeRemover.Font = new Font("Segoe UI", 9F);
            tbQuantidadeRemover.ForeColor = Color.White;
            tbQuantidadeRemover.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQuantidadeRemover.Location = new Point(35, 81);
            tbQuantidadeRemover.Margin = new Padding(3, 0, 10, 0);
            tbQuantidadeRemover.Name = "tbQuantidadeRemover";
            tbQuantidadeRemover.PlaceholderForeColor = Color.Gray;
            tbQuantidadeRemover.PlaceholderText = "Quantidade";
            tbQuantidadeRemover.SelectedText = "";
            tbQuantidadeRemover.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbQuantidadeRemover.Size = new Size(100, 36);
            tbQuantidadeRemover.TabIndex = 2;
            // 
            // lblQuantidade
            // 
            lblQuantidade.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantidade.ForeColor = Color.White;
            lblQuantidade.Location = new Point(35, 56);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(200, 20);
            lblQuantidade.TabIndex = 1;
            lblQuantidade.Text = "Quantidade a remover:";
            // 
            // lbNomeProduto
            // 
            lbNomeProduto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lbNomeProduto.ForeColor = Color.White;
            lbNomeProduto.Location = new Point(35, 26);
            lbNomeProduto.Name = "lbNomeProduto";
            lbNomeProduto.Size = new Size(344, 20);
            lbNomeProduto.TabIndex = 0;
            lbNomeProduto.Text = "Produto: [Nome do Produto]";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(375, 50);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(345, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Remover do Estoque";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRmvEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(381, 312);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            Name = "FormRmvEstoque";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormRmvEstoque";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlMain;
        public Guna.UI2.WinForms.Guna2TextBox tbQuantidadeRemover;
        public Guna.UI2.WinForms.Guna2Button btnConfirmar;
        public Guna.UI2.WinForms.Guna2CheckBox cbExcluirProduto;
        public Label lbQuantidadeAtual;
        private Label lblQuantidade;
        public Label lbNomeProduto;
        public Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}