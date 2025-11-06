namespace telebip_erp.Forms.SubForms
{
    public partial class FormAlteracaoSenhaGerente
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
            tbSenhaAtual = new TextBox();
            label1 = new Label();
            tbNovaSenha = new TextBox();
            label2 = new Label();
            btnConfirmar = new CuoreUI.Controls.cuiButton();
            cuiButton2 = new CuoreUI.Controls.cuiButton();
            btnOlhos = new Button();
            btnOlhos2 = new Button();
            SuspendLayout();
            // 
            // tbSenhaAtual
            // 
            tbSenhaAtual.Location = new Point(12, 52);
            tbSenhaAtual.MaxLength = 50;
            tbSenhaAtual.Name = "tbSenhaAtual";
            tbSenhaAtual.PasswordChar = '*';
            tbSenhaAtual.Size = new Size(218, 23);
            tbSenhaAtual.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Senha atual";
            // 
            // tbNovaSenha
            // 
            tbNovaSenha.Location = new Point(12, 153);
            tbNovaSenha.MaxLength = 50;
            tbNovaSenha.Name = "tbNovaSenha";
            tbNovaSenha.PasswordChar = '*';
            tbNovaSenha.Size = new Size(218, 23);
            tbNovaSenha.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Nova senha";
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
            btnConfirmar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnConfirmar.ForeColor = Color.Black;
            btnConfirmar.HoverBackground = Color.White;
            btnConfirmar.HoverForeColor = Color.Black;
            btnConfirmar.HoverImageTint = Color.White;
            btnConfirmar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnConfirmar.Image = null;
            btnConfirmar.ImageAutoCenter = true;
            btnConfirmar.ImageExpand = new Point(0, 0);
            btnConfirmar.ImageOffset = new Point(0, 0);
            btnConfirmar.Location = new Point(12, 357);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.NormalBackground = Color.White;
            btnConfirmar.NormalForeColor = Color.Black;
            btnConfirmar.NormalImageTint = Color.White;
            btnConfirmar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.OutlineThickness = 1F;
            btnConfirmar.PressedBackground = Color.WhiteSmoke;
            btnConfirmar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnConfirmar.PressedImageTint = Color.White;
            btnConfirmar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.Rounding = new Padding(8);
            btnConfirmar.Size = new Size(114, 45);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // cuiButton2
            // 
            cuiButton2.CheckButton = false;
            cuiButton2.Checked = false;
            cuiButton2.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton2.CheckedForeColor = Color.White;
            cuiButton2.CheckedImageTint = Color.White;
            cuiButton2.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton2.Content = "Cancelar";
            cuiButton2.DialogResult = DialogResult.None;
            cuiButton2.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton2.ForeColor = Color.Black;
            cuiButton2.HoverBackground = Color.White;
            cuiButton2.HoverForeColor = Color.Black;
            cuiButton2.HoverImageTint = Color.White;
            cuiButton2.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton2.Image = null;
            cuiButton2.ImageAutoCenter = true;
            cuiButton2.ImageExpand = new Point(0, 0);
            cuiButton2.ImageOffset = new Point(0, 0);
            cuiButton2.Location = new Point(179, 357);
            cuiButton2.Name = "cuiButton2";
            cuiButton2.NormalBackground = Color.White;
            cuiButton2.NormalForeColor = Color.Black;
            cuiButton2.NormalImageTint = Color.White;
            cuiButton2.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton2.OutlineThickness = 1F;
            cuiButton2.PressedBackground = Color.WhiteSmoke;
            cuiButton2.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton2.PressedImageTint = Color.White;
            cuiButton2.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton2.Rounding = new Padding(8);
            cuiButton2.Size = new Size(114, 45);
            cuiButton2.TabIndex = 6;
            cuiButton2.TextAlignment = StringAlignment.Center;
            cuiButton2.TextOffset = new Point(0, 0);
            cuiButton2.Click += cuiButton2_Click;
            // 
            // btnOlhos
            // 
            btnOlhos.Location = new Point(236, 52);
            btnOlhos.Name = "btnOlhos";
            btnOlhos.Size = new Size(23, 23);
            btnOlhos.TabIndex = 7;
            btnOlhos.UseVisualStyleBackColor = true;
            // 
            // btnOlhos2
            // 
            btnOlhos2.Location = new Point(236, 153);
            btnOlhos2.Name = "btnOlhos2";
            btnOlhos2.Size = new Size(23, 23);
            btnOlhos2.TabIndex = 8;
            btnOlhos2.UseVisualStyleBackColor = true;
            // 
            // FormAlteracaoSenhaGerente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 450);
            Controls.Add(btnOlhos2);
            Controls.Add(btnOlhos);
            Controls.Add(cuiButton2);
            Controls.Add(btnConfirmar);
            Controls.Add(label2);
            Controls.Add(tbNovaSenha);
            Controls.Add(label1);
            Controls.Add(tbSenhaAtual);
            Name = "FormAlteracaoSenhaGerente";
            Text = "FormalteracaoSenhaGerente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbSenhaAtual;
        private Label label1;
        private TextBox tbNovaSenha;
        private Label label2;
        private CuoreUI.Controls.cuiButton btnConfirmar;
        private CuoreUI.Controls.cuiButton cuiButton2;
        private Button btnOlhos;
        private Button btnOlhos2;
    }
}