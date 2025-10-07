namespace telebip_erp.Forms.SubForms
{
    partial class FormRmvEstoque
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbNomeProduto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            tbQuantidadeRemover = new Guna.UI2.WinForms.Guna2TextBox();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            cbExcluirProduto = new Guna.UI2.WinForms.Guna2CheckBox();
            lbQuantidadeAtual = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // lbNomeProduto
            // 
            lbNomeProduto.BackColor = Color.Transparent;
            lbNomeProduto.Location = new Point(26, 69);
            lbNomeProduto.Name = "lbNomeProduto";
            lbNomeProduto.Size = new Size(97, 17);
            lbNomeProduto.TabIndex = 0;
            lbNomeProduto.Text = "guna2HtmlLabel1";
            // 
            // tbQuantidadeRemover
            // 
            tbQuantidadeRemover.CustomizableEdges = customizableEdges1;
            tbQuantidadeRemover.DefaultText = "";
            tbQuantidadeRemover.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbQuantidadeRemover.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbQuantidadeRemover.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbQuantidadeRemover.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbQuantidadeRemover.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbQuantidadeRemover.Font = new Font("Segoe UI", 9F);
            tbQuantidadeRemover.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbQuantidadeRemover.Location = new Point(26, 99);
            tbQuantidadeRemover.Name = "tbQuantidadeRemover";
            tbQuantidadeRemover.PlaceholderText = "";
            tbQuantidadeRemover.SelectedText = "";
            tbQuantidadeRemover.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbQuantidadeRemover.Size = new Size(97, 36);
            tbQuantidadeRemover.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.CustomizableEdges = customizableEdges3;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.Font = new Font("Segoe UI", 9F);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(26, 194);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnConfirmar.Size = new Size(129, 45);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "guna2Button1";
            // 
            // cbExcluirProduto
            // 
            cbExcluirProduto.AutoSize = true;
            cbExcluirProduto.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbExcluirProduto.CheckedState.BorderRadius = 0;
            cbExcluirProduto.CheckedState.BorderThickness = 0;
            cbExcluirProduto.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            cbExcluirProduto.Location = new Point(143, 44);
            cbExcluirProduto.Name = "cbExcluirProduto";
            cbExcluirProduto.Size = new Size(181, 19);
            cbExcluirProduto.TabIndex = 3;
            cbExcluirProduto.Text = "Excluir o produto do sistema?";
            cbExcluirProduto.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            cbExcluirProduto.UncheckedState.BorderRadius = 0;
            cbExcluirProduto.UncheckedState.BorderThickness = 0;
            cbExcluirProduto.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // lbQuantidadeAtual
            // 
            lbQuantidadeAtual.BackColor = Color.Transparent;
            lbQuantidadeAtual.Location = new Point(143, 99);
            lbQuantidadeAtual.Name = "lbQuantidadeAtual";
            lbQuantidadeAtual.Size = new Size(97, 17);
            lbQuantidadeAtual.TabIndex = 4;
            lbQuantidadeAtual.Text = "guna2HtmlLabel1";
            // 
            // FormRmvEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 263);
            Controls.Add(lbQuantidadeAtual);
            Controls.Add(cbExcluirProduto);
            Controls.Add(btnConfirmar);
            Controls.Add(tbQuantidadeRemover);
            Controls.Add(lbNomeProduto);
            Margin = new Padding(2);
            Name = "FormRmvEstoque";
            Padding = new Padding(2, 14, 2, 2);
            Text = "FormRmvEstoque";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbNomeProduto;
        private Guna.UI2.WinForms.Guna2TextBox tbQuantidadeRemover;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2CheckBox cbExcluirProduto;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbQuantidadeAtual;
    }
}