namespace telebip_erp.Forms.Auth
{
    partial class FormRecuperacaoSenha
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
            label1 = new Label();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            btnConfirmar = new CuoreUI.Controls.cuiButton();
            tbId = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 0;
            label1.Text = "Digite o seu ID de acesso";
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
            btnCancelar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.HoverBackground = Color.White;
            btnCancelar.HoverForeColor = Color.Black;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(206, 201);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NormalBackground = Color.White;
            btnCancelar.NormalForeColor = Color.Black;
            btnCancelar.NormalImageTint = Color.White;
            btnCancelar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.OutlineThickness = 1F;
            btnCancelar.PressedBackground = Color.WhiteSmoke;
            btnCancelar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnCancelar.PressedImageTint = Color.White;
            btnCancelar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.Rounding = new Padding(8);
            btnCancelar.Size = new Size(83, 35);
            btnCancelar.TabIndex = 3;
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
            btnConfirmar.Location = new Point(12, 201);
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
            btnConfirmar.Size = new Size(83, 35);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // tbId
            // 
            tbId.Location = new Point(12, 86);
            tbId.MaxLength = 6;
            tbId.Name = "tbId";
            tbId.Size = new Size(181, 23);
            tbId.TabIndex = 1;
            // 
            // FormRecuperacaoSenha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 248);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(tbId);
            Controls.Add(label1);
            Name = "FormRecuperacaoSenha";
            Text = "FormRecuperacaoSenha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CuoreUI.Controls.cuiButton btnCancelar;
        private CuoreUI.Controls.cuiButton btnConfirmar;
        private TextBox tbId;
    }
}