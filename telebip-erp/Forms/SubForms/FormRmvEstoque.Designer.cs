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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            cbFuncionarios = new Guna.UI2.WinForms.Guna2ComboBox();
            lblFuncionario = new Label();
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
            pnlContainer.Size = new Size(455, 385);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(cbFuncionarios);
            pnlMain.Controls.Add(lblFuncionario);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(cbExcluirProduto);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Controls.Add(btnConfirmar);
            pnlMain.Controls.Add(tbQuantidadeRemover);
            pnlMain.Controls.Add(lblQuantidade);
            pnlMain.Controls.Add(lbNomeProduto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(455, 325);
            pnlMain.TabIndex = 1;
            // 
            // cbFuncionarios
            // 
            cbFuncionarios.BackColor = Color.Transparent;
            cbFuncionarios.BorderColor = Color.FromArgb(60, 62, 80);
            cbFuncionarios.BorderRadius = 8;
            cbFuncionarios.CustomizableEdges = customizableEdges1;
            cbFuncionarios.DrawMode = DrawMode.OwnerDrawFixed;
            cbFuncionarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionarios.FillColor = Color.FromArgb(40, 41, 52);
            cbFuncionarios.FocusedColor = Color.FromArgb(100, 150, 200);
            cbFuncionarios.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbFuncionarios.Font = new Font("Segoe UI", 9F);
            cbFuncionarios.ForeColor = Color.White;
            cbFuncionarios.ItemHeight = 30;
            cbFuncionarios.Location = new Point(33, 178);
            cbFuncionarios.Name = "cbFuncionarios";
            cbFuncionarios.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbFuncionarios.Size = new Size(391, 36);
            cbFuncionarios.TabIndex = 9;
            // 
            // lblFuncionario
            // 
            lblFuncionario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFuncionario.ForeColor = Color.White;
            lblFuncionario.Location = new Point(33, 155);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(300, 20);
            lblFuncionario.TabIndex = 8;
            lblFuncionario.Text = "Funcionário Responsável *";
            // 
            // lbQuantidadeAtual
            // 
            lbQuantidadeAtual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbQuantidadeAtual.ForeColor = Color.LightGreen;
            lbQuantidadeAtual.Location = new Point(33, 45);
            lbQuantidadeAtual.Name = "lbQuantidadeAtual";
            lbQuantidadeAtual.Size = new Size(409, 20);
            lbQuantidadeAtual.TabIndex = 6;
            lbQuantidadeAtual.Text = "Estoque atual: 0 unidades";
            lbQuantidadeAtual.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbExcluirProduto
            // 
            cbExcluirProduto.AutoSize = true;
            cbExcluirProduto.CheckedState.BorderColor = Color.FromArgb(100, 150, 200);
            cbExcluirProduto.CheckedState.BorderRadius = 2;
            cbExcluirProduto.CheckedState.BorderThickness = 0;
            cbExcluirProduto.CheckedState.FillColor = Color.FromArgb(100, 150, 200);
            cbExcluirProduto.Font = new Font("Segoe UI", 9F);
            cbExcluirProduto.ForeColor = Color.White;
            cbExcluirProduto.Location = new Point(33, 230);
            cbExcluirProduto.Name = "cbExcluirProduto";
            cbExcluirProduto.Size = new Size(172, 19);
            cbExcluirProduto.TabIndex = 5;
            cbExcluirProduto.Text = "Excluir produto do sistema?";
            cbExcluirProduto.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            cbExcluirProduto.UncheckedState.BorderRadius = 2;
            cbExcluirProduto.UncheckedState.BorderThickness = 1;
            cbExcluirProduto.UncheckedState.FillColor = Color.Transparent;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 8;
            btnCancelar.CustomizableEdges = customizableEdges3;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.FromArgb(120, 40, 40);
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnCancelar.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnCancelar.Location = new Point(33, 265);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancelar.Size = new Size(185, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BorderRadius = 8;
            btnConfirmar.CustomizableEdges = customizableEdges5;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.FromArgb(40, 120, 80);
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnConfirmar.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnConfirmar.Location = new Point(239, 265);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnConfirmar.Size = new Size(185, 40);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            // 
            // tbQuantidadeRemover
            // 
            tbQuantidadeRemover.BorderColor = Color.FromArgb(60, 62, 80);
            tbQuantidadeRemover.BorderRadius = 8;
            tbQuantidadeRemover.CustomizableEdges = customizableEdges7;
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
            tbQuantidadeRemover.Location = new Point(33, 111);
            tbQuantidadeRemover.Margin = new Padding(3, 0, 10, 0);
            tbQuantidadeRemover.MaxLength = 5;
            tbQuantidadeRemover.Name = "tbQuantidadeRemover";
            tbQuantidadeRemover.PlaceholderForeColor = Color.Gray;
            tbQuantidadeRemover.PlaceholderText = "Ex: 5";
            tbQuantidadeRemover.SelectedText = "";
            tbQuantidadeRemover.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbQuantidadeRemover.Size = new Size(140, 36);
            tbQuantidadeRemover.TabIndex = 2;
            // 
            // lblQuantidade
            // 
            lblQuantidade.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantidade.ForeColor = Color.White;
            lblQuantidade.Location = new Point(33, 85);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(200, 20);
            lblQuantidade.TabIndex = 1;
            lblQuantidade.Text = "Quantidade a remover *";
            // 
            // lbNomeProduto
            // 
            lbNomeProduto.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lbNomeProduto.ForeColor = Color.White;
            lbNomeProduto.Location = new Point(33, 15);
            lbNomeProduto.Name = "lbNomeProduto";
            lbNomeProduto.Size = new Size(409, 25);
            lbNomeProduto.TabIndex = 0;
            lbNomeProduto.Text = "Produto: [Nome do Produto]";
            lbNomeProduto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(455, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(425, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Remover do Estoque";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRmvEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(461, 412);
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
        private Label lblFuncionario;
        private Guna.UI2.WinForms.Guna2ComboBox cbFuncionarios;
    }
}