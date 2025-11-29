using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    partial class FormRmvEstoque
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRmvEstoque));
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlWrapperFuncionarios = new telebip_erp.Controls.RoundedPanel();
            picArrowFuncionarios = new PictureBox();
            cbFuncionarios = new telebip_erp.Controls.NeoFlatComboBox();
            lblFuncionario = new Label();
            lbQuantidadeAtual = new Label();
            cbExcluirProduto = new CheckBox();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            btnConfirmar = new CuoreUI.Controls.cuiButton();
            pnlBgQuantidade = new telebip_erp.Controls.RoundedPanel();
            tbQuantidadeRemover = new telebip_erp.Controls.PlaceholderTextBox();
            lblQuantidade = new Label();
            lbNomeProduto = new Label();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlWrapperFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picArrowFuncionarios).BeginInit();
            pnlBgQuantidade.SuspendLayout();
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
            pnlMain.Controls.Add(pnlWrapperFuncionarios);
            pnlMain.Controls.Add(lblFuncionario);
            pnlMain.Controls.Add(lbQuantidadeAtual);
            pnlMain.Controls.Add(cbExcluirProduto);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Controls.Add(btnConfirmar);
            pnlMain.Controls.Add(pnlBgQuantidade);
            pnlMain.Controls.Add(lblQuantidade);
            pnlMain.Controls.Add(lbNomeProduto);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(455, 325);
            pnlMain.TabIndex = 1;
            // 
            // pnlWrapperFuncionarios
            // 
            pnlWrapperFuncionarios.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperFuncionarios.BorderThickness = 1;
            pnlWrapperFuncionarios.Controls.Add(picArrowFuncionarios);
            pnlWrapperFuncionarios.Controls.Add(cbFuncionarios);
            pnlWrapperFuncionarios.CornerRadius = 8;
            pnlWrapperFuncionarios.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperFuncionarios.Location = new Point(33, 178);
            pnlWrapperFuncionarios.Name = "pnlWrapperFuncionarios";
            pnlWrapperFuncionarios.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperFuncionarios.Size = new Size(391, 36);
            pnlWrapperFuncionarios.TabIndex = 9;
            // 
            // picArrowFuncionarios
            // 
            picArrowFuncionarios.BackColor = Color.Transparent;
            picArrowFuncionarios.Image = (Image)resources.GetObject("picArrowFuncionarios.Image");
            picArrowFuncionarios.Location = new Point(361, 13);
            picArrowFuncionarios.Name = "picArrowFuncionarios";
            picArrowFuncionarios.Size = new Size(10, 10);
            picArrowFuncionarios.SizeMode = PictureBoxSizeMode.Zoom;
            picArrowFuncionarios.TabIndex = 103;
            picArrowFuncionarios.TabStop = false;
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
            cbFuncionarios.Location = new Point(8, 8);
            cbFuncionarios.Margin = new Padding(0);
            cbFuncionarios.Name = "cbFuncionarios";
            cbFuncionarios.Placeholder = "Selecione...";
            cbFuncionarios.ShowPlaceholder = true;
            cbFuncionarios.Size = new Size(374, 19);
            cbFuncionarios.TabIndex = 104;
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
            cbExcluirProduto.BackColor = Color.Transparent;
            cbExcluirProduto.Font = new Font("Segoe UI", 9F);
            cbExcluirProduto.ForeColor = Color.White;
            cbExcluirProduto.Location = new Point(33, 230);
            cbExcluirProduto.Name = "cbExcluirProduto";
            cbExcluirProduto.Size = new Size(171, 19);
            cbExcluirProduto.TabIndex = 5;
            cbExcluirProduto.Text = "Excluir produto do sistema?";
            cbExcluirProduto.UseVisualStyleBackColor = false;
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
            btnCancelar.Location = new Point(33, 265);
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
            btnCancelar.Size = new Size(185, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.TextAlignment = StringAlignment.Center;
            btnCancelar.TextOffset = new Point(0, 0);
            // 
            // btnConfirmar
            // 
            btnConfirmar.CheckButton = false;
            btnConfirmar.Checked = false;
            btnConfirmar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnConfirmar.CheckedForeColor = Color.White;
            btnConfirmar.CheckedImageTint = Color.White;
            btnConfirmar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnConfirmar.Content = "Confirmar";
            btnConfirmar.DialogResult = DialogResult.None;
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverBackground = Color.White;
            btnConfirmar.HoverForeColor = Color.Black;
            btnConfirmar.HoverImageTint = Color.White;
            btnConfirmar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnConfirmar.Image = null;
            btnConfirmar.ImageAutoCenter = true;
            btnConfirmar.ImageExpand = new Point(0, 0);
            btnConfirmar.ImageOffset = new Point(0, 0);
            btnConfirmar.Location = new Point(239, 265);
            btnConfirmar.Margin = new Padding(3, 0, 10, 0);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnConfirmar.NormalForeColor = Color.White;
            btnConfirmar.NormalImageTint = Color.White;
            btnConfirmar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.OutlineThickness = 1F;
            btnConfirmar.PressedBackground = Color.WhiteSmoke;
            btnConfirmar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnConfirmar.PressedImageTint = Color.White;
            btnConfirmar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.Rounding = new Padding(8);
            btnConfirmar.Size = new Size(185, 40);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // pnlBgQuantidade
            // 
            pnlBgQuantidade.BackColor = Color.FromArgb(40, 41, 52);
            pnlBgQuantidade.BorderColor = Color.FromArgb(60, 62, 80);
            pnlBgQuantidade.BorderThickness = 1;
            pnlBgQuantidade.Controls.Add(tbQuantidadeRemover);
            pnlBgQuantidade.CornerRadius = 8;
            pnlBgQuantidade.FillColor = Color.FromArgb(40, 41, 52);
            pnlBgQuantidade.Location = new Point(33, 108);
            pnlBgQuantidade.Name = "pnlBgQuantidade";
            pnlBgQuantidade.Padding = new Padding(8, 6, 8, 6);
            pnlBgQuantidade.Size = new Size(140, 36);
            pnlBgQuantidade.TabIndex = 200;
            // 
            // tbQuantidadeRemover
            // 
            tbQuantidadeRemover.BackColor = Color.FromArgb(40, 41, 52);
            tbQuantidadeRemover.BorderStyle = BorderStyle.None;
            tbQuantidadeRemover.Font = new Font("Segoe UI", 9F);
            tbQuantidadeRemover.ForeColor = Color.White;
            tbQuantidadeRemover.Location = new Point(8, 9);
            tbQuantidadeRemover.Margin = new Padding(3, 0, 10, 0);
            tbQuantidadeRemover.MaxLength = 5;
            tbQuantidadeRemover.Name = "tbQuantidadeRemover";
            tbQuantidadeRemover.Placeholder = "0";
            tbQuantidadeRemover.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbQuantidadeRemover.Size = new Size(124, 16);
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
            MaximumSize = new Size(461, 412);
            MinimumSize = new Size(461, 412);
            Name = "FormRmvEstoque";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormRmvEstoque";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlWrapperFuncionarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picArrowFuncionarios).EndInit();
            pnlBgQuantidade.ResumeLayout(false);
            pnlBgQuantidade.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Designer fields
        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlMain;

        // wrapper (rounded) apenas para ComboBox
        private telebip_erp.Controls.RoundedPanel pnlWrapperFuncionarios;
        private PictureBox picArrowFuncionarios;
        public telebip_erp.Controls.NeoFlatComboBox cbFuncionarios;

        // background (rounded) para TextBox
        private telebip_erp.Controls.RoundedPanel pnlBgQuantidade;
        public telebip_erp.Controls.PlaceholderTextBox tbQuantidadeRemover;

        // CheckBox WinForms (leve)
        public CheckBox cbExcluirProduto;

        // Labels
        public Label lbQuantidadeAtual;
        private Label lblQuantidade;
        public Label lbNomeProduto;
        private Label lblFuncionario;

        // Cuore buttons
        public CuoreUI.Controls.cuiButton btnCancelar;
        public CuoreUI.Controls.cuiButton btnConfirmar;
    }
}
