namespace telebip_erp.Forms.Main
{
    partial class FormInicial
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
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Size = new Size(232, 655);
            pnlMenu.Controls.SetChildIndex(btnVendas, 0);
            pnlMenu.Controls.SetChildIndex(btnEstoque, 0);
            pnlMenu.Controls.SetChildIndex(btnRelatorios, 0);
            pnlMenu.Controls.SetChildIndex(btnFuncionarios, 0);
            pnlMenu.Controls.SetChildIndex(lblTelebip, 0);
            pnlMenu.Controls.SetChildIndex(lblOrganizer, 0);
            // 
            // pnlContent
            // 
            pnlContent.Size = new Size(950, 655);
            // 
            // btnVendas
            // 
            btnVendas.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnVendas.FlatAppearance.BorderSize = 0;
            btnVendas.Location = new Point(11, 180);
            // 
            // btnFuncionarios
            // 
            btnFuncionarios.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnFuncionarios.FlatAppearance.BorderSize = 0;
            btnFuncionarios.Location = new Point(11, 369);
            // 
            // btnRelatorios
            // 
            btnRelatorios.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnRelatorios.Location = new Point(11, 306);
            // 
            // btnEstoque
            // 
            btnEstoque.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnEstoque.FlatAppearance.BorderSize = 0;
            btnEstoque.Location = new Point(11, 243);
            // 
            // FormInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 655);
            MaximumSize = new Size(1600, 1080);
            Name = "FormInicial";
            Text = "Tela Inicial";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
