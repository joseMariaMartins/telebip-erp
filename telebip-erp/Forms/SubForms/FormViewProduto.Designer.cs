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
            pnlContainer = new Panel();
            pnlMain = new Panel();
            btnFechar = new CuoreUI.Controls.cuiButton();
            pnlWrapperObservacao = new Panel();
            tbObservacao = new TextBox();
            lblObservacao = new Label();
            pnlWrapperQAviso = new Panel();
            tbQAviso = new TextBox();
            pnlWrapperQEstoque = new Panel();
            tbQEstoque = new TextBox();
            pnlWrapperPreco = new Panel();
            tbPreco = new TextBox();
            pnlWrapperMarca = new Panel();
            tbMarca = new TextBox();
            pnlWrapperNome = new Panel();
            tbNome = new TextBox();
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
            pnlWrapperObservacao.SuspendLayout();
            pnlWrapperQAviso.SuspendLayout();
            pnlWrapperQEstoque.SuspendLayout();
            pnlWrapperPreco.SuspendLayout();
            pnlWrapperMarca.SuspendLayout();
            pnlWrapperNome.SuspendLayout();
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
            pnlMain.Controls.Add(pnlWrapperObservacao);
            pnlMain.Controls.Add(lblObservacao);
            pnlMain.Controls.Add(pnlWrapperQAviso);
            pnlMain.Controls.Add(pnlWrapperQEstoque);
            pnlMain.Controls.Add(pnlWrapperPreco);
            pnlMain.Controls.Add(pnlWrapperMarca);
            pnlMain.Controls.Add(pnlWrapperNome);
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
            btnFechar.CheckButton = false;
            btnFechar.Checked = false;
            btnFechar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnFechar.CheckedForeColor = Color.White;
            btnFechar.CheckedImageTint = Color.White;
            btnFechar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnFechar.Content = "Fechar";
            btnFechar.DialogResult = DialogResult.None;
            btnFechar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.HoverBackground = Color.White;
            btnFechar.HoverForeColor = Color.Black;
            btnFechar.HoverImageTint = Color.White;
            btnFechar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFechar.Image = null;
            btnFechar.ImageAutoCenter = true;
            btnFechar.ImageExpand = new Point(0, 0);
            btnFechar.ImageOffset = new Point(0, 0);
            btnFechar.Location = new Point(450, 380);
            btnFechar.Name = "btnFechar";
            btnFechar.NormalBackground = Color.FromArgb(120, 40, 40);
            btnFechar.NormalForeColor = Color.White;
            btnFechar.NormalImageTint = Color.White;
            btnFechar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnFechar.OutlineThickness = 1F;
            btnFechar.PressedBackground = Color.WhiteSmoke;
            btnFechar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnFechar.PressedImageTint = Color.White;
            btnFechar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFechar.Rounding = new Padding(8);
            btnFechar.Size = new Size(120, 40);
            btnFechar.TabIndex = 36;
            btnFechar.TextAlignment = StringAlignment.Center;
            btnFechar.TextOffset = new Point(0, 0);
            btnFechar.Click += btnFechar_Click;
            // 
            // pnlWrapperObservacao
            // 
            pnlWrapperObservacao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperObservacao.Controls.Add(tbObservacao);
            pnlWrapperObservacao.Location = new Point(33, 322);
            pnlWrapperObservacao.Name = "pnlWrapperObservacao";
            pnlWrapperObservacao.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperObservacao.Size = new Size(537, 40);
            pnlWrapperObservacao.TabIndex = 31;
            // 
            // tbObservacao
            // 
            tbObservacao.BackColor = Color.FromArgb(40, 41, 52);
            tbObservacao.BorderStyle = BorderStyle.None;
            tbObservacao.Font = new Font("Segoe UI", 9F);
            tbObservacao.ForeColor = Color.FromArgb(180, 180, 180);
            tbObservacao.Location = new Point(8, 10);
            tbObservacao.Multiline = true;
            tbObservacao.Name = "tbObservacao";
            tbObservacao.ReadOnly = true;
            tbObservacao.Size = new Size(521, 20);
            tbObservacao.TabIndex = 0;
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
            // pnlWrapperQAviso
            // 
            pnlWrapperQAviso.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQAviso.Controls.Add(tbQAviso);
            pnlWrapperQAviso.Location = new Point(430, 220);
            pnlWrapperQAviso.Name = "pnlWrapperQAviso";
            pnlWrapperQAviso.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperQAviso.Size = new Size(140, 36);
            pnlWrapperQAviso.TabIndex = 35;
            // 
            // tbQAviso
            // 
            tbQAviso.BackColor = Color.FromArgb(40, 41, 52);
            tbQAviso.BorderStyle = BorderStyle.None;
            tbQAviso.Font = new Font("Segoe UI", 9F);
            tbQAviso.ForeColor = Color.FromArgb(180, 180, 180);
            tbQAviso.Location = new Point(8, 10);
            tbQAviso.Name = "tbQAviso";
            tbQAviso.ReadOnly = true;
            tbQAviso.Size = new Size(124, 16);
            tbQAviso.TabIndex = 0;
            // 
            // pnlWrapperQEstoque
            // 
            pnlWrapperQEstoque.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQEstoque.Controls.Add(tbQEstoque);
            pnlWrapperQEstoque.Location = new Point(230, 220);
            pnlWrapperQEstoque.Name = "pnlWrapperQEstoque";
            pnlWrapperQEstoque.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperQEstoque.Size = new Size(140, 36);
            pnlWrapperQEstoque.TabIndex = 34;
            // 
            // tbQEstoque
            // 
            tbQEstoque.BackColor = Color.FromArgb(40, 41, 52);
            tbQEstoque.BorderStyle = BorderStyle.None;
            tbQEstoque.Font = new Font("Segoe UI", 9F);
            tbQEstoque.ForeColor = Color.FromArgb(180, 180, 180);
            tbQEstoque.Location = new Point(8, 10);
            tbQEstoque.Name = "tbQEstoque";
            tbQEstoque.ReadOnly = true;
            tbQEstoque.Size = new Size(124, 16);
            tbQEstoque.TabIndex = 0;
            // 
            // pnlWrapperPreco
            // 
            pnlWrapperPreco.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPreco.Controls.Add(tbPreco);
            pnlWrapperPreco.Location = new Point(33, 220);
            pnlWrapperPreco.Name = "pnlWrapperPreco";
            pnlWrapperPreco.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperPreco.Size = new Size(140, 36);
            pnlWrapperPreco.TabIndex = 33;
            // 
            // tbPreco
            // 
            tbPreco.BackColor = Color.FromArgb(40, 41, 52);
            tbPreco.BorderStyle = BorderStyle.None;
            tbPreco.Font = new Font("Segoe UI", 9F);
            tbPreco.ForeColor = Color.FromArgb(180, 180, 180);
            tbPreco.Location = new Point(8, 10);
            tbPreco.Name = "tbPreco";
            tbPreco.ReadOnly = true;
            tbPreco.Size = new Size(124, 16);
            tbPreco.TabIndex = 0;
            // 
            // pnlWrapperMarca
            // 
            pnlWrapperMarca.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperMarca.Controls.Add(tbMarca);
            pnlWrapperMarca.Location = new Point(33, 145);
            pnlWrapperMarca.Name = "pnlWrapperMarca";
            pnlWrapperMarca.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperMarca.Size = new Size(537, 36);
            pnlWrapperMarca.TabIndex = 32;
            // 
            // tbMarca
            // 
            tbMarca.BackColor = Color.FromArgb(40, 41, 52);
            tbMarca.BorderStyle = BorderStyle.None;
            tbMarca.Font = new Font("Segoe UI", 9F);
            tbMarca.ForeColor = Color.FromArgb(180, 180, 180);
            tbMarca.Location = new Point(8, 10);
            tbMarca.Name = "tbMarca";
            tbMarca.ReadOnly = true;
            tbMarca.Size = new Size(521, 16);
            tbMarca.TabIndex = 0;
            // 
            // pnlWrapperNome
            // 
            pnlWrapperNome.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperNome.Controls.Add(tbNome);
            pnlWrapperNome.Location = new Point(33, 70);
            pnlWrapperNome.Name = "pnlWrapperNome";
            pnlWrapperNome.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperNome.Size = new Size(537, 36);
            pnlWrapperNome.TabIndex = 31;
            // 
            // tbNome
            // 
            tbNome.BackColor = Color.FromArgb(40, 41, 52);
            tbNome.BorderStyle = BorderStyle.None;
            tbNome.Font = new Font("Segoe UI", 9F);
            tbNome.ForeColor = Color.FromArgb(180, 180, 180);
            tbNome.Location = new Point(8, 10);
            tbNome.Name = "tbNome";
            tbNome.ReadOnly = true;
            tbNome.Size = new Size(521, 16);
            tbNome.TabIndex = 0;
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
            pnlWrapperObservacao.ResumeLayout(false);
            pnlWrapperObservacao.PerformLayout();
            pnlWrapperQAviso.ResumeLayout(false);
            pnlWrapperQAviso.PerformLayout();
            pnlWrapperQEstoque.ResumeLayout(false);
            pnlWrapperQEstoque.PerformLayout();
            pnlWrapperPreco.ResumeLayout(false);
            pnlWrapperPreco.PerformLayout();
            pnlWrapperMarca.ResumeLayout(false);
            pnlWrapperMarca.PerformLayout();
            pnlWrapperNome.ResumeLayout(false);
            pnlWrapperNome.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlMain;
        private Label lblQAviso;
        private Label lblQEstoque;
        private Label lblPreco;
        private Label lblMarca;
        private Label lblNome;
        private Label lblID;
        private Label lblIdTitulo;
        private Label lblObservacao;
        private Panel pnlWrapperNome;
        private TextBox tbNome;
        private Panel pnlWrapperMarca;
        private TextBox tbMarca;
        private Panel pnlWrapperPreco;
        private TextBox tbPreco;
        private Panel pnlWrapperQEstoque;
        private TextBox tbQEstoque;
        private Panel pnlWrapperQAviso;
        private TextBox tbQAviso;
        private Panel pnlWrapperObservacao;
        private TextBox tbObservacao;
        private CuoreUI.Controls.cuiButton btnFechar;
    }
}