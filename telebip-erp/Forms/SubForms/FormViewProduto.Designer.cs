namespace telebip_erp.Forms.SubForms
{
    partial class FormViewProduto
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            btnFechar = new Guna.UI2.WinForms.Guna2Button();
            tbObservacao = new Guna.UI2.WinForms.Guna2TextBox();
            lblObservacao = new Label();
            tbQAviso = new Guna.UI2.WinForms.Guna2TextBox();
            tbQEstoque = new Guna.UI2.WinForms.Guna2TextBox();
            tbPreco = new Guna.UI2.WinForms.Guna2TextBox();
            tbMarca = new Guna.UI2.WinForms.Guna2TextBox();
            tbNome = new Guna.UI2.WinForms.Guna2TextBox();
            lblQAviso = new Label();
            lblQEstoque = new Label();
            lblPreco = new Label();
            lblMarca = new Label();
            lblNome = new Label();
            lblID = new Label();
            lblIdTitulo = new Label();
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
            pnlContainer.Size = new Size(594, 502);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(btnFechar);
            pnlMain.Controls.Add(tbObservacao);
            pnlMain.Controls.Add(lblObservacao);
            pnlMain.Controls.Add(tbQAviso);
            pnlMain.Controls.Add(tbQEstoque);
            pnlMain.Controls.Add(tbPreco);
            pnlMain.Controls.Add(tbMarca);
            pnlMain.Controls.Add(tbNome);
            pnlMain.Controls.Add(lblQAviso);
            pnlMain.Controls.Add(lblQEstoque);
            pnlMain.Controls.Add(lblPreco);
            pnlMain.Controls.Add(lblMarca);
            pnlMain.Controls.Add(lblNome);
            pnlMain.Controls.Add(lblID);
            pnlMain.Controls.Add(lblIdTitulo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(594, 442);
            pnlMain.TabIndex = 1;
            // 
            // btnFechar
            // 
            btnFechar.BorderRadius = 8;
            btnFechar.CustomizableEdges = customizableEdges1;
            btnFechar.DisabledState.BorderColor = Color.DarkGray;
            btnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFechar.FillColor = Color.FromArgb(120, 40, 40);
            btnFechar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnFechar.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnFechar.Location = new Point(450, 380);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnFechar.Size = new Size(120, 40);
            btnFechar.TabIndex = 30;
            btnFechar.Text = "Fechar";
            btnFechar.Click += btnFechar_Click;
            // 
            // tbObservacao
            // 
            tbObservacao.BorderColor = Color.FromArgb(60, 62, 80);
            tbObservacao.BorderRadius = 8;
            tbObservacao.CustomizableEdges = customizableEdges3;
            tbObservacao.DefaultText = "";
            tbObservacao.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbObservacao.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbObservacao.DisabledState.ForeColor = Color.White;
            tbObservacao.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbObservacao.Enabled = false;
            tbObservacao.FillColor = Color.FromArgb(40, 41, 52);
            tbObservacao.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbObservacao.Font = new Font("Segoe UI", 9F);
            tbObservacao.ForeColor = Color.White;
            tbObservacao.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbObservacao.Location = new Point(33, 322);
            tbObservacao.Margin = new Padding(3, 0, 10, 0);
            tbObservacao.Multiline = true;
            tbObservacao.Name = "tbObservacao";
            tbObservacao.PlaceholderForeColor = Color.Gray;
            tbObservacao.PlaceholderText = "";
            tbObservacao.ReadOnly = true;
            tbObservacao.SelectedText = "";
            tbObservacao.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbObservacao.Size = new Size(537, 40);
            tbObservacao.TabIndex = 29;
            // 
            // lblObservacao
            // 
            lblObservacao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObservacao.ForeColor = Color.White;
            lblObservacao.Location = new Point(33, 297);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(200, 20);
            lblObservacao.TabIndex = 28;
            lblObservacao.Text = "Observação";
            // 
            // tbQAviso
            // 
            tbQAviso.BorderColor = Color.FromArgb(60, 62, 80);
            tbQAviso.BorderRadius = 8;
            tbQAviso.CustomizableEdges = customizableEdges5;
            tbQAviso.DefaultText = "";
            tbQAviso.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQAviso.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbQAviso.DisabledState.ForeColor = Color.White;
            tbQAviso.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQAviso.Enabled = false;
            tbQAviso.FillColor = Color.FromArgb(40, 41, 52);
            tbQAviso.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQAviso.Font = new Font("Segoe UI", 9F);
            tbQAviso.ForeColor = Color.White;
            tbQAviso.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQAviso.Location = new Point(430, 220);
            tbQAviso.Margin = new Padding(3, 0, 10, 0);
            tbQAviso.Name = "tbQAviso";
            tbQAviso.PlaceholderForeColor = Color.Gray;
            tbQAviso.PlaceholderText = "";
            tbQAviso.ReadOnly = true;
            tbQAviso.SelectedText = "";
            tbQAviso.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbQAviso.Size = new Size(140, 36);
            tbQAviso.TabIndex = 27;
            // 
            // tbQEstoque
            // 
            tbQEstoque.BorderColor = Color.FromArgb(60, 62, 80);
            tbQEstoque.BorderRadius = 8;
            tbQEstoque.CustomizableEdges = customizableEdges7;
            tbQEstoque.DefaultText = "";
            tbQEstoque.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQEstoque.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbQEstoque.DisabledState.ForeColor = Color.White;
            tbQEstoque.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQEstoque.Enabled = false;
            tbQEstoque.FillColor = Color.FromArgb(40, 41, 52);
            tbQEstoque.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQEstoque.Font = new Font("Segoe UI", 9F);
            tbQEstoque.ForeColor = Color.White;
            tbQEstoque.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbQEstoque.Location = new Point(230, 220);
            tbQEstoque.Margin = new Padding(3, 0, 10, 0);
            tbQEstoque.Name = "tbQEstoque";
            tbQEstoque.PlaceholderForeColor = Color.Gray;
            tbQEstoque.PlaceholderText = "";
            tbQEstoque.ReadOnly = true;
            tbQEstoque.SelectedText = "";
            tbQEstoque.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbQEstoque.Size = new Size(140, 36);
            tbQEstoque.TabIndex = 26;
            // 
            // tbPreco
            // 
            tbPreco.BorderColor = Color.FromArgb(60, 62, 80);
            tbPreco.BorderRadius = 8;
            tbPreco.CustomizableEdges = customizableEdges9;
            tbPreco.DefaultText = "";
            tbPreco.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPreco.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbPreco.DisabledState.ForeColor = Color.White;
            tbPreco.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPreco.Enabled = false;
            tbPreco.FillColor = Color.FromArgb(40, 41, 52);
            tbPreco.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPreco.Font = new Font("Segoe UI", 9F);
            tbPreco.ForeColor = Color.White;
            tbPreco.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbPreco.Location = new Point(33, 220);
            tbPreco.Margin = new Padding(3, 0, 10, 0);
            tbPreco.Name = "tbPreco";
            tbPreco.PlaceholderForeColor = Color.Gray;
            tbPreco.PlaceholderText = "";
            tbPreco.ReadOnly = true;
            tbPreco.SelectedText = "";
            tbPreco.ShadowDecoration.CustomizableEdges = customizableEdges10;
            tbPreco.Size = new Size(140, 36);
            tbPreco.TabIndex = 25;
            // 
            // tbMarca
            // 
            tbMarca.BorderColor = Color.FromArgb(60, 62, 80);
            tbMarca.BorderRadius = 8;
            tbMarca.CustomizableEdges = customizableEdges11;
            tbMarca.DefaultText = "";
            tbMarca.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbMarca.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbMarca.DisabledState.ForeColor = Color.White;
            tbMarca.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbMarca.Enabled = false;
            tbMarca.FillColor = Color.FromArgb(40, 41, 52);
            tbMarca.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbMarca.Font = new Font("Segoe UI", 9F);
            tbMarca.ForeColor = Color.White;
            tbMarca.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbMarca.Location = new Point(33, 145);
            tbMarca.Margin = new Padding(3, 0, 10, 0);
            tbMarca.Name = "tbMarca";
            tbMarca.PlaceholderForeColor = Color.Gray;
            tbMarca.PlaceholderText = "";
            tbMarca.ReadOnly = true;
            tbMarca.SelectedText = "";
            tbMarca.ShadowDecoration.CustomizableEdges = customizableEdges12;
            tbMarca.Size = new Size(537, 36);
            tbMarca.TabIndex = 24;
            // 
            // tbNome
            // 
            tbNome.BorderColor = Color.FromArgb(60, 62, 80);
            tbNome.BorderRadius = 8;
            tbNome.CustomizableEdges = customizableEdges13;
            tbNome.DefaultText = "";
            tbNome.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbNome.DisabledState.FillColor = Color.FromArgb(40, 41, 52);
            tbNome.DisabledState.ForeColor = Color.White;
            tbNome.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbNome.Enabled = false;
            tbNome.FillColor = Color.FromArgb(40, 41, 52);
            tbNome.FocusedState.BorderColor = Color.FromArgb(100, 150, 200);
            tbNome.Font = new Font("Segoe UI", 9F);
            tbNome.ForeColor = Color.White;
            tbNome.HoverState.BorderColor = Color.FromArgb(100, 150, 200);
            tbNome.Location = new Point(33, 70);
            tbNome.Margin = new Padding(3, 0, 10, 0);
            tbNome.Name = "tbNome";
            tbNome.PlaceholderForeColor = Color.Gray;
            tbNome.PlaceholderText = "";
            tbNome.ReadOnly = true;
            tbNome.SelectedText = "";
            tbNome.ShadowDecoration.CustomizableEdges = customizableEdges14;
            tbNome.Size = new Size(537, 36);
            tbNome.TabIndex = 23;
            // 
            // lblQAviso
            // 
            lblQAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQAviso.ForeColor = Color.White;
            lblQAviso.Location = new Point(430, 195);
            lblQAviso.Name = "lblQAviso";
            lblQAviso.Size = new Size(140, 20);
            lblQAviso.TabIndex = 22;
            lblQAviso.Text = "Quantidade de Aviso";
            // 
            // lblQEstoque
            // 
            lblQEstoque.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQEstoque.ForeColor = Color.White;
            lblQEstoque.Location = new Point(230, 195);
            lblQEstoque.Name = "lblQEstoque";
            lblQEstoque.Size = new Size(140, 20);
            lblQEstoque.TabIndex = 21;
            lblQEstoque.Text = "Quantidade em Estoque";
            // 
            // lblPreco
            // 
            lblPreco.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreco.ForeColor = Color.White;
            lblPreco.Location = new Point(33, 195);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(140, 20);
            lblPreco.TabIndex = 20;
            lblPreco.Text = "Preço";
            // 
            // lblMarca
            // 
            lblMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(33, 120);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(100, 20);
            lblMarca.TabIndex = 19;
            lblMarca.Text = "Marca";
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(33, 45);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(100, 20);
            lblNome.TabIndex = 18;
            lblNome.Text = "Produto";
            // 
            // lblID
            // 
            lblID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblID.ForeColor = Color.LightBlue;
            lblID.Location = new Point(70, 15);
            lblID.Name = "lblID";
            lblID.Size = new Size(100, 20);
            lblID.TabIndex = 17;
            lblID.Text = "0";
            // 
            // lblIdTitulo
            // 
            lblIdTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIdTitulo.ForeColor = Color.White;
            lblIdTitulo.Location = new Point(33, 15);
            lblIdTitulo.Name = "lblIdTitulo";
            lblIdTitulo.Size = new Size(40, 20);
            lblIdTitulo.TabIndex = 16;
            lblIdTitulo.Text = "ID:";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(594, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(564, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Visualizar Produto";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormViewProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(600, 529);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(600, 529);
            MinimumSize = new Size(600, 529);
            Name = "FormViewProduto";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormViewProduto";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlMain;
        private Guna.UI2.WinForms.Guna2TextBox tbNome;
        private Guna.UI2.WinForms.Guna2TextBox tbMarca;
        private Guna.UI2.WinForms.Guna2TextBox tbPreco;
        private Guna.UI2.WinForms.Guna2TextBox tbQEstoque;
        private Guna.UI2.WinForms.Guna2TextBox tbQAviso;
        private Guna.UI2.WinForms.Guna2TextBox tbObservacao;
        private Label lblObservacao;
        private Label lblQAviso;
        private Label lblQEstoque;
        private Label lblPreco;
        private Label lblMarca;
        private Label lblNome;
        private Label lblID;
        private Label lblIdTitulo;
        private Guna.UI2.WinForms.Guna2Button btnFechar;
    }
}