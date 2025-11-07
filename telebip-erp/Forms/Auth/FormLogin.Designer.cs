namespace telebip_erp.Forms.Auth
{
    partial class FormLogin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            lbSenha = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            lbUsuarioInvalido = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbSenhaInvalida = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbEsqueci = new Label();
            SuspendLayout();
            // 
            // lbUsuario
            // 
            lbUsuario.CustomizableEdges = customizableEdges7;
            lbUsuario.DefaultText = "";
            lbUsuario.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lbUsuario.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lbUsuario.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lbUsuario.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lbUsuario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lbUsuario.Font = new Font("Segoe UI", 9F);
            lbUsuario.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lbUsuario.Location = new Point(143, 67);
            lbUsuario.MaxLength = 6;
            lbUsuario.Name = "lbUsuario";
            lbUsuario.PlaceholderText = "";
            lbUsuario.SelectedText = "";
            lbUsuario.ShadowDecoration.CustomizableEdges = customizableEdges8;
            lbUsuario.Size = new Size(276, 36);
            lbUsuario.TabIndex = 0;
            // 
            // lbSenha
            // 
            lbSenha.CustomizableEdges = customizableEdges9;
            lbSenha.DefaultText = "";
            lbSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            lbSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            lbSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            lbSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            lbSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            lbSenha.Font = new Font("Segoe UI", 9F);
            lbSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            lbSenha.Location = new Point(143, 124);
            lbSenha.MaxLength = 50;
            lbSenha.Name = "lbSenha";
            lbSenha.PasswordChar = '*';
            lbSenha.PlaceholderText = "";
            lbSenha.SelectedText = "";
            lbSenha.ShadowDecoration.CustomizableEdges = customizableEdges10;
            lbSenha.Size = new Size(276, 36);
            lbSenha.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(77, 67);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(60, 23);
            guna2HtmlLabel1.TabIndex = 4;
            guna2HtmlLabel1.Text = "Usuário:";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(88, 124);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(49, 23);
            guna2HtmlLabel2.TabIndex = 5;
            guna2HtmlLabel2.Text = "Senha:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderRadius = 10;
            btnLogin.CustomizableEdges = customizableEdges11;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(40, 120, 80);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(290, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLogin.Size = new Size(129, 45);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Confirmar";
            // 
            // lbUsuarioInvalido
            // 
            lbUsuarioInvalido.BackColor = Color.Transparent;
            lbUsuarioInvalido.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsuarioInvalido.ForeColor = Color.Red;
            lbUsuarioInvalido.Location = new Point(425, 67);
            lbUsuarioInvalido.Name = "lbUsuarioInvalido";
            lbUsuarioInvalido.Size = new Size(97, 19);
            lbUsuarioInvalido.TabIndex = 8;
            lbUsuarioInvalido.Text = "Usuário inválido";
            lbUsuarioInvalido.Visible = false;
            // 
            // lbSenhaInvalida
            // 
            lbSenhaInvalida.BackColor = Color.Transparent;
            lbSenhaInvalida.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSenhaInvalida.ForeColor = Color.Red;
            lbSenhaInvalida.Location = new Point(425, 124);
            lbSenhaInvalida.Name = "lbSenhaInvalida";
            lbSenhaInvalida.Size = new Size(86, 19);
            lbSenhaInvalida.TabIndex = 9;
            lbSenhaInvalida.Text = "Senha inválida";
            lbSenhaInvalida.Visible = false;
            // 
            // lbEsqueci
            // 
            lbEsqueci.AutoSize = true;
            lbEsqueci.BackColor = Color.Transparent;
            lbEsqueci.Cursor = Cursors.Hand;
            lbEsqueci.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEsqueci.ForeColor = Color.RoyalBlue;
            lbEsqueci.Location = new Point(318, 163);
            lbEsqueci.Name = "lbEsqueci";
            lbEsqueci.Size = new Size(101, 17);
            lbEsqueci.TabIndex = 10;
            lbEsqueci.Text = "Esqueci a senha";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 24, 29);
            ClientSize = new Size(543, 263);
            Controls.Add(lbEsqueci);
            Controls.Add(lbSenhaInvalida);
            Controls.Add(lbUsuarioInvalido);
            Controls.Add(btnLogin);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(lbSenha);
            Controls.Add(lbUsuario);
            FormStyle = FormStyles.ActionBar_None;
            Name = "FormLogin";
            Padding = new Padding(3, 24, 3, 3);
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox lbUsuario;
        private Guna.UI2.WinForms.Guna2TextBox lbSenha;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUsuarioInvalido;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSenhaInvalida;
        private Label lbEsqueci;
    }
}