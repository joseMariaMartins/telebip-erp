using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEstoque));
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlWrapperFuncionarios = new telebip_erp.Controls.RoundedPanel();
            pictureBox1 = new PictureBox();
            cbFuncionarios = new telebip_erp.Controls.NeoFlatComboBox();
            lblFuncionario = new Label();
            pnlWrapperNome = new telebip_erp.Controls.RoundedPanel();
            tbNome = new telebip_erp.Controls.PlaceholderTextBox();
            lblNome = new Label();
            pnlWrapperMarca = new telebip_erp.Controls.RoundedPanel();
            tbMarca = new telebip_erp.Controls.PlaceholderTextBox();
            lblMarca = new Label();
            pnlWrapperPreco = new telebip_erp.Controls.RoundedPanel();
            tbPreco = new telebip_erp.Controls.PlaceholderTextBox();
            lblPreco = new Label();
            pnlWrapperQEstoque = new telebip_erp.Controls.RoundedPanel();
            tbQEstoque = new telebip_erp.Controls.PlaceholderTextBox();
            lblQEstoque = new Label();
            pnlWrapperQAviso = new telebip_erp.Controls.RoundedPanel();
            tbQAviso = new telebip_erp.Controls.PlaceholderTextBox();
            lblQAviso = new Label();
            pnlWrapperObservacao = new telebip_erp.Controls.RoundedPanel();
            tbObservacao = new telebip_erp.Controls.PlaceholderTextBox();
            lblObservacao = new Label();
            lbQuantidadeAtual = new Label();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            btnAdicionar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlWrapperFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlWrapperNome.SuspendLayout();
            pnlWrapperMarca.SuspendLayout();
            pnlWrapperPreco.SuspendLayout();
            pnlWrapperQEstoque.SuspendLayout();
            pnlWrapperQAviso.SuspendLayout();
            pnlWrapperObservacao.SuspendLayout();
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
            pnlContainer.Size = new Size(652, 507);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(pnlWrapperFuncionarios);
            pnlMain.Controls.Add(lblFuncionario);
            pnlMain.Controls.Add(pnlWrapperNome);
            pnlMain.Controls.Add(lblNome);
            pnlMain.Controls.Add(pnlWrapperMarca);
            pnlMain.Controls.Add(lblMarca);
            pnlMain.Controls.Add(pnlWrapperPreco);
            pnlMain.Controls.Add(lblPreco);
            pnlMain.Controls.Add(pnlWrapperQEstoque);
            pnlMain.Controls.Add(lblQEstoque);
            pnlMain.Controls.Add(pnlWrapperQAviso);
            pnlMain.Controls.Add(lblQAviso);
            pnlMain.Controls.Add(pnlWrapperObservacao);
            pnlMain.Controls.Add(lblObservacao);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Controls.Add(btnAdicionar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(652, 447);
            pnlMain.TabIndex = 1;
            // 
            // pnlWrapperFuncionarios
            // 
            pnlWrapperFuncionarios.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperFuncionarios.BorderThickness = 1;
            pnlWrapperFuncionarios.Controls.Add(pictureBox1);
            pnlWrapperFuncionarios.Controls.Add(cbFuncionarios);
            pnlWrapperFuncionarios.CornerRadius = 8;
            pnlWrapperFuncionarios.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.Location = new Point(33, 55);
            pnlWrapperFuncionarios.Name = "pnlWrapperFuncionarios";
            pnlWrapperFuncionarios.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperFuncionarios.Size = new Size(588, 36);
            pnlWrapperFuncionarios.TabIndex = 100;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(558, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 162;
            pictureBox1.TabStop = false;
            // 
            // cbFuncionarios
            // 
            cbFuncionarios.AutoSelectFirst = false;
            cbFuncionarios.BackColor = Color.FromArgb(40, 41, 52);
            cbFuncionarios.DrawMode = DrawMode.OwnerDrawFixed;
            cbFuncionarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncionarios.FlatStyle = FlatStyle.Flat;
            cbFuncionarios.Font = new Font("Segoe UI", 8F);
            cbFuncionarios.ForeColor = Color.White;
            cbFuncionarios.FormattingEnabled = true;
            cbFuncionarios.ItemEntryHeight = 30;
            cbFuncionarios.ItemHeight = 13;
            cbFuncionarios.Location = new Point(8, 9);
            cbFuncionarios.Margin = new Padding(0);
            cbFuncionarios.Name = "cbFuncionarios";
            cbFuncionarios.Placeholder = "Selecione...";
            cbFuncionarios.ShowPlaceholder = true;
            cbFuncionarios.Size = new Size(573, 19);
            cbFuncionarios.TabIndex = 161;
            // 
            // lblFuncionario
            // 
            lblFuncionario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFuncionario.ForeColor = Color.White;
            lblFuncionario.Location = new Point(33, 30);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(200, 20);
            lblFuncionario.TabIndex = 18;
            lblFuncionario.Text = "Funcionário Responsável *";
            // 
            // pnlWrapperNome
            // 
            pnlWrapperNome.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperNome.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperNome.BorderThickness = 1;
            pnlWrapperNome.Controls.Add(tbNome);
            pnlWrapperNome.CornerRadius = 8;
            pnlWrapperNome.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperNome.Location = new Point(33, 145);
            pnlWrapperNome.Name = "pnlWrapperNome";
            pnlWrapperNome.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperNome.Size = new Size(300, 36);
            pnlWrapperNome.TabIndex = 110;
            // 
            // tbNome
            // 
            tbNome.BackColor = Color.FromArgb(40, 41, 52);
            tbNome.BorderStyle = BorderStyle.None;
            tbNome.Font = new Font("Segoe UI", 9F);
            tbNome.ForeColor = Color.White;
            tbNome.Location = new Point(8, 10);
            tbNome.Margin = new Padding(3, 0, 10, 0);
            tbNome.Name = "tbNome";
            tbNome.Placeholder = "Ex: Capinha";
            tbNome.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbNome.Size = new Size(284, 16);
            tbNome.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(33, 120);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(100, 20);
            lblNome.TabIndex = 12;
            lblNome.Text = "Produto *";
            // 
            // pnlWrapperMarca
            // 
            pnlWrapperMarca.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperMarca.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperMarca.BorderThickness = 1;
            pnlWrapperMarca.Controls.Add(tbMarca);
            pnlWrapperMarca.CornerRadius = 8;
            pnlWrapperMarca.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperMarca.Location = new Point(381, 145);
            pnlWrapperMarca.Name = "pnlWrapperMarca";
            pnlWrapperMarca.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperMarca.Size = new Size(240, 36);
            pnlWrapperMarca.TabIndex = 120;
            // 
            // tbMarca
            // 
            tbMarca.BackColor = Color.FromArgb(40, 41, 52);
            tbMarca.BorderStyle = BorderStyle.None;
            tbMarca.Font = new Font("Segoe UI", 9F);
            tbMarca.ForeColor = Color.White;
            tbMarca.Location = new Point(7, 10);
            tbMarca.Margin = new Padding(3, 0, 10, 0);
            tbMarca.Name = "tbMarca";
            tbMarca.Placeholder = "Ex: Sony";
            tbMarca.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbMarca.Size = new Size(228, 16);
            tbMarca.TabIndex = 2;
            // 
            // lblMarca
            // 
            lblMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(381, 120);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(100, 20);
            lblMarca.TabIndex = 13;
            lblMarca.Text = "Marca *";
            // 
            // pnlWrapperPreco
            // 
            pnlWrapperPreco.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPreco.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperPreco.BorderThickness = 1;
            pnlWrapperPreco.Controls.Add(tbPreco);
            pnlWrapperPreco.CornerRadius = 8;
            pnlWrapperPreco.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperPreco.Location = new Point(33, 220);
            pnlWrapperPreco.Name = "pnlWrapperPreco";
            pnlWrapperPreco.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperPreco.Size = new Size(100, 36);
            pnlWrapperPreco.TabIndex = 130;
            // 
            // tbPreco
            // 
            tbPreco.BackColor = Color.FromArgb(40, 41, 52);
            tbPreco.BorderStyle = BorderStyle.None;
            tbPreco.Font = new Font("Segoe UI", 9F);
            tbPreco.ForeColor = Color.White;
            tbPreco.Location = new Point(8, 10);
            tbPreco.Margin = new Padding(3, 0, 10, 0);
            tbPreco.Name = "tbPreco";
            tbPreco.Placeholder = "0,00";
            tbPreco.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbPreco.Size = new Size(84, 16);
            tbPreco.TabIndex = 3;
            // 
            // lblPreco
            // 
            lblPreco.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreco.ForeColor = Color.White;
            lblPreco.Location = new Point(33, 195);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(100, 20);
            lblPreco.TabIndex = 10;
            lblPreco.Text = "Preço *";
            // 
            // pnlWrapperQEstoque
            // 
            pnlWrapperQEstoque.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQEstoque.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperQEstoque.BorderThickness = 1;
            pnlWrapperQEstoque.Controls.Add(tbQEstoque);
            pnlWrapperQEstoque.CornerRadius = 8;
            pnlWrapperQEstoque.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQEstoque.Location = new Point(230, 220);
            pnlWrapperQEstoque.Name = "pnlWrapperQEstoque";
            pnlWrapperQEstoque.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperQEstoque.Size = new Size(100, 36);
            pnlWrapperQEstoque.TabIndex = 140;
            // 
            // tbQEstoque
            // 
            tbQEstoque.BackColor = Color.FromArgb(40, 41, 52);
            tbQEstoque.BorderStyle = BorderStyle.None;
            tbQEstoque.Font = new Font("Segoe UI", 9F);
            tbQEstoque.ForeColor = Color.White;
            tbQEstoque.Location = new Point(8, 10);
            tbQEstoque.Margin = new Padding(3, 0, 10, 0);
            tbQEstoque.Name = "tbQEstoque";
            tbQEstoque.Placeholder = "0";
            tbQEstoque.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbQEstoque.Size = new Size(84, 16);
            tbQEstoque.TabIndex = 4;
            // 
            // lblQEstoque
            // 
            lblQEstoque.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQEstoque.ForeColor = Color.White;
            lblQEstoque.Location = new Point(230, 195);
            lblQEstoque.Name = "lblQEstoque";
            lblQEstoque.Size = new Size(100, 20);
            lblQEstoque.TabIndex = 11;
            lblQEstoque.Text = "Quantidade *";
            // 
            // pnlWrapperQAviso
            // 
            pnlWrapperQAviso.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQAviso.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperQAviso.BorderThickness = 1;
            pnlWrapperQAviso.Controls.Add(tbQAviso);
            pnlWrapperQAviso.CornerRadius = 8;
            pnlWrapperQAviso.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperQAviso.Location = new Point(381, 220);
            pnlWrapperQAviso.Name = "pnlWrapperQAviso";
            pnlWrapperQAviso.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperQAviso.Size = new Size(100, 36);
            pnlWrapperQAviso.TabIndex = 150;
            // 
            // tbQAviso
            // 
            tbQAviso.BackColor = Color.FromArgb(40, 41, 52);
            tbQAviso.BorderStyle = BorderStyle.None;
            tbQAviso.Font = new Font("Segoe UI", 9F);
            tbQAviso.ForeColor = Color.White;
            tbQAviso.Location = new Point(8, 10);
            tbQAviso.Margin = new Padding(3, 0, 10, 0);
            tbQAviso.Name = "tbQAviso";
            tbQAviso.Placeholder = "0";
            tbQAviso.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbQAviso.Size = new Size(84, 16);
            tbQAviso.TabIndex = 5;
            // 
            // lblQAviso
            // 
            lblQAviso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQAviso.ForeColor = Color.White;
            lblQAviso.Location = new Point(381, 195);
            lblQAviso.Name = "lblQAviso";
            lblQAviso.Size = new Size(200, 20);
            lblQAviso.TabIndex = 9;
            lblQAviso.Text = "Qtd. Aviso *";
            // 
            // pnlWrapperObservacao
            // 
            pnlWrapperObservacao.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperObservacao.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperObservacao.BorderThickness = 1;
            pnlWrapperObservacao.Controls.Add(tbObservacao);
            pnlWrapperObservacao.CornerRadius = 8;
            pnlWrapperObservacao.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperObservacao.Location = new Point(33, 322);
            pnlWrapperObservacao.Name = "pnlWrapperObservacao";
            pnlWrapperObservacao.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperObservacao.Size = new Size(588, 40);
            pnlWrapperObservacao.TabIndex = 160;
            // 
            // tbObservacao
            // 
            tbObservacao.BackColor = Color.FromArgb(40, 41, 52);
            tbObservacao.BorderStyle = BorderStyle.None;
            tbObservacao.Font = new Font("Segoe UI", 9F);
            tbObservacao.ForeColor = Color.White;
            tbObservacao.Location = new Point(8, 12);
            tbObservacao.Margin = new Padding(3, 0, 10, 0);
            tbObservacao.Multiline = true;
            tbObservacao.Name = "tbObservacao";
            tbObservacao.Placeholder = "Ex: Em Estoque";
            tbObservacao.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbObservacao.Size = new Size(572, 16);
            tbObservacao.TabIndex = 6;
            // 
            // lblObservacao
            // 
            lblObservacao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObservacao.ForeColor = Color.White;
            lblObservacao.Location = new Point(33, 292);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(200, 20);
            lblObservacao.TabIndex = 7;
            lblObservacao.Text = "Observação";
            // 
            // lbQuantidadeAtual
            // 
            lbQuantidadeAtual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbQuantidadeAtual.ForeColor = Color.LightGreen;
            lbQuantidadeAtual.Location = new Point(381, 289);
            lbQuantidadeAtual.Name = "lbQuantidadeAtual";
            lbQuantidadeAtual.Size = new Size(240, 20);
            lbQuantidadeAtual.TabIndex = 17;
            lbQuantidadeAtual.Text = "Quantidade atual: 0";
            lbQuantidadeAtual.TextAlign = ContentAlignment.MiddleRight;
            lbQuantidadeAtual.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.CheckButton = false;
            btnCancelar.Checked = false;
            btnCancelar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnCancelar.CheckedForeColor = Color.White;
            btnCancelar.CheckedImageTint = Color.White;
            btnCancelar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnCancelar.Content = "Cancelar";
            btnCancelar.DialogResult = DialogResult.None;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverBackground = Color.White;
            btnCancelar.HoverForeColor = Color.Black;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(381, 384);
            btnCancelar.Margin = new Padding(3, 0, 10, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NormalBackground = Color.FromArgb(120, 40, 40);
            btnCancelar.NormalForeColor = Color.White;
            btnCancelar.NormalImageTint = Color.White;
            btnCancelar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.OutlineThickness = 1F;
            btnCancelar.PressedBackground = Color.WhiteSmoke;
            btnCancelar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnCancelar.PressedImageTint = Color.White;
            btnCancelar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.Rounding = new Padding(8);
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 16;
            btnCancelar.TextAlignment = StringAlignment.Center;
            btnCancelar.TextOffset = new Point(0, 0);
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
            btnAdicionar.Location = new Point(511, 384);
            btnAdicionar.Margin = new Padding(3, 0, 10, 0);
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
            btnAdicionar.Size = new Size(110, 40);
            btnAdicionar.TabIndex = 15;
            btnAdicionar.TextAlignment = StringAlignment.Center;
            btnAdicionar.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(652, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(622, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Adicionar Produto";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(658, 534);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(658, 534);
            MinimumSize = new Size(658, 534);
            Name = "FormAddEstoque";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddEstoque";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlWrapperFuncionarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlWrapperNome.ResumeLayout(false);
            pnlWrapperNome.PerformLayout();
            pnlWrapperMarca.ResumeLayout(false);
            pnlWrapperMarca.PerformLayout();
            pnlWrapperPreco.ResumeLayout(false);
            pnlWrapperPreco.PerformLayout();
            pnlWrapperQEstoque.ResumeLayout(false);
            pnlWrapperQEstoque.PerformLayout();
            pnlWrapperQAviso.ResumeLayout(false);
            pnlWrapperQAviso.PerformLayout();
            pnlWrapperObservacao.ResumeLayout(false);
            pnlWrapperObservacao.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

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

        // Designer fields
        private Panel pnlContainer;
        private Panel pnlMain;
        private telebip_erp.Controls.RoundedPanel pnlWrapperFuncionarios;
        public Controls.NeoFlatComboBox cbFuncionarios;

        private telebip_erp.Controls.RoundedPanel pnlWrapperNome;
        public telebip_erp.Controls.PlaceholderTextBox tbNome;

        private telebip_erp.Controls.RoundedPanel pnlWrapperMarca;
        public telebip_erp.Controls.PlaceholderTextBox tbMarca;

        private telebip_erp.Controls.RoundedPanel pnlWrapperPreco;
        public telebip_erp.Controls.PlaceholderTextBox tbPreco;

        private telebip_erp.Controls.RoundedPanel pnlWrapperQEstoque;
        public telebip_erp.Controls.PlaceholderTextBox tbQEstoque;

        private telebip_erp.Controls.RoundedPanel pnlWrapperQAviso;
        public telebip_erp.Controls.PlaceholderTextBox tbQAviso;

        private telebip_erp.Controls.RoundedPanel pnlWrapperObservacao;
        public telebip_erp.Controls.PlaceholderTextBox tbObservacao;

        private Label lblFuncionario;
        private Label lblNome;
        private Label lblMarca;
        private Label lblPreco;
        private Label lblQEstoque;
        private Label lblQAviso;
        private Label lblObservacao;

        public Label lbQuantidadeAtual;
        private CuoreUI.Controls.cuiButton btnCancelar;
        private CuoreUI.Controls.cuiButton btnAdicionar;

        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox pictureBox1;
    }
}
