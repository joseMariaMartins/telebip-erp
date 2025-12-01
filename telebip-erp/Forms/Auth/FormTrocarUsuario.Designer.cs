namespace telebip_erp.Forms.Auth
{
    partial class FormTrocarUsuario
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
            btnLogin = new CuoreUI.Controls.cuiButton();
            lblAppName = new Label();
            lblEsqueci = new Label();
            lblUsuario = new Label();
            lblSenhaInvalida = new Label();
            pnlWrapperUsuario = new Panel();
            txtUsuario = new TextBox();
            pnlWrapperSenha = new Panel();
            txtSenha = new TextBox();
            picToggleSenha = new PictureBox();
            lblUsuarioInvalido = new Label();
            lblSenha = new Label();
            panel1 = new Panel();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            pnlWrapperUsuario.SuspendLayout();
            pnlWrapperSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picToggleSenha).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.CheckButton = false;
            btnLogin.Checked = false;
            btnLogin.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnLogin.CheckedForeColor = Color.White;
            btnLogin.CheckedImageTint = Color.White;
            btnLogin.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnLogin.Content = "Trocar";
            btnLogin.DialogResult = DialogResult.None;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverBackground = Color.White;
            btnLogin.HoverForeColor = Color.Black;
            btnLogin.HoverImageTint = Color.White;
            btnLogin.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLogin.Image = null;
            btnLogin.ImageAutoCenter = true;
            btnLogin.ImageExpand = new Point(0, 0);
            btnLogin.ImageOffset = new Point(0, 0);
            btnLogin.Location = new Point(220, 237);
            btnLogin.Margin = new Padding(3, 0, 10, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.NormalBackground = Color.FromArgb(40, 120, 80);
            btnLogin.NormalForeColor = Color.White;
            btnLogin.NormalImageTint = Color.White;
            btnLogin.NormalOutline = Color.Transparent;
            btnLogin.OutlineThickness = 1F;
            btnLogin.PressedBackground = Color.WhiteSmoke;
            btnLogin.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnLogin.PressedImageTint = Color.White;
            btnLogin.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLogin.Rounding = new Padding(8);
            btnLogin.Size = new Size(132, 36);
            btnLogin.TabIndex = 21;
            btnLogin.TextAlignment = StringAlignment.Center;
            btnLogin.TextOffset = new Point(0, 0);
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAppName.ForeColor = Color.FromArgb(140, 180, 255);
            lblAppName.Location = new Point(162, 15);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(100, 19);
            lblAppName.TabIndex = 13;
            lblAppName.Text = "Trocar Usuario";
            // 
            // lblEsqueci
            // 
            lblEsqueci.AutoSize = true;
            lblEsqueci.Cursor = Cursors.Hand;
            lblEsqueci.Font = new Font("Segoe UI", 9F);
            lblEsqueci.ForeColor = Color.FromArgb(100, 150, 255);
            lblEsqueci.Location = new Point(292, 207);
            lblEsqueci.Name = "lblEsqueci";
            lblEsqueci.Size = new Size(103, 15);
            lblEsqueci.TabIndex = 20;
            lblEsqueci.Text = "Esqueci a senha →";
            // 
            // lblUsuario
            // 
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(230, 230, 235);
            lblUsuario.Location = new Point(31, 58);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(120, 20);
            lblUsuario.TabIndex = 14;
            lblUsuario.Text = "Usuário";
            // 
            // lblSenhaInvalida
            // 
            lblSenhaInvalida.Font = new Font("Segoe UI", 8F);
            lblSenhaInvalida.ForeColor = Color.FromArgb(255, 100, 100);
            lblSenhaInvalida.Location = new Point(31, 206);
            lblSenhaInvalida.Name = "lblSenhaInvalida";
            lblSenhaInvalida.Size = new Size(364, 16);
            lblSenhaInvalida.TabIndex = 19;
            lblSenhaInvalida.Text = "Senha inválida";
            lblSenhaInvalida.Visible = false;
            // 
            // pnlWrapperUsuario
            // 
            pnlWrapperUsuario.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperUsuario.Controls.Add(txtUsuario);
            pnlWrapperUsuario.Location = new Point(31, 78);
            pnlWrapperUsuario.Name = "pnlWrapperUsuario";
            pnlWrapperUsuario.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperUsuario.Size = new Size(364, 40);
            pnlWrapperUsuario.TabIndex = 15;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(40, 41, 52);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 9F);
            txtUsuario.ForeColor = Color.White;
            txtUsuario.Location = new Point(8, 10);
            txtUsuario.MaxLength = 6;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(324, 16);
            txtUsuario.TabIndex = 0;
            // 
            // pnlWrapperSenha
            // 
            pnlWrapperSenha.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperSenha.Controls.Add(txtSenha);
            pnlWrapperSenha.Controls.Add(picToggleSenha);
            pnlWrapperSenha.Location = new Point(31, 162);
            pnlWrapperSenha.Name = "pnlWrapperSenha";
            pnlWrapperSenha.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperSenha.Size = new Size(364, 40);
            pnlWrapperSenha.TabIndex = 18;
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.FromArgb(40, 41, 52);
            txtSenha.BorderStyle = BorderStyle.None;
            txtSenha.Font = new Font("Segoe UI", 9F);
            txtSenha.ForeColor = Color.White;
            txtSenha.Location = new Point(8, 12);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(288, 16);
            txtSenha.TabIndex = 0;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // picToggleSenha
            // 
            picToggleSenha.Cursor = Cursors.Hand;
            picToggleSenha.Location = new Point(333, 10);
            picToggleSenha.Name = "picToggleSenha";
            picToggleSenha.Size = new Size(20, 20);
            picToggleSenha.SizeMode = PictureBoxSizeMode.Zoom;
            picToggleSenha.TabIndex = 1;
            picToggleSenha.TabStop = false;
            // 
            // lblUsuarioInvalido
            // 
            lblUsuarioInvalido.Font = new Font("Segoe UI", 8F);
            lblUsuarioInvalido.ForeColor = Color.FromArgb(255, 100, 100);
            lblUsuarioInvalido.Location = new Point(31, 122);
            lblUsuarioInvalido.Name = "lblUsuarioInvalido";
            lblUsuarioInvalido.Size = new Size(364, 16);
            lblUsuarioInvalido.TabIndex = 16;
            lblUsuarioInvalido.Text = "Usuário inválido";
            lblUsuarioInvalido.Visible = false;
            // 
            // lblSenha
            // 
            lblSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSenha.ForeColor = Color.FromArgb(230, 230, 235);
            lblSenha.Location = new Point(31, 142);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(120, 20);
            lblSenha.TabIndex = 17;
            lblSenha.Text = "Senha";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(28, 29, 40);
            panel1.Controls.Add(cuiButton1);
            panel1.Controls.Add(lblAppName);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblSenha);
            panel1.Controls.Add(lblUsuarioInvalido);
            panel1.Controls.Add(lblEsqueci);
            panel1.Controls.Add(pnlWrapperSenha);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(pnlWrapperUsuario);
            panel1.Controls.Add(lblSenhaInvalida);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(434, 301);
            panel1.TabIndex = 22;
            // 
            // cuiButton1
            // 
            cuiButton1.CheckButton = false;
            cuiButton1.Checked = false;
            cuiButton1.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton1.CheckedForeColor = Color.White;
            cuiButton1.CheckedImageTint = Color.White;
            cuiButton1.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton1.Content = "Cancelar";
            cuiButton1.DialogResult = DialogResult.None;
            cuiButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cuiButton1.ForeColor = Color.White;
            cuiButton1.HoverBackground = Color.White;
            cuiButton1.HoverForeColor = Color.Black;
            cuiButton1.HoverImageTint = Color.White;
            cuiButton1.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton1.Image = null;
            cuiButton1.ImageAutoCenter = true;
            cuiButton1.ImageExpand = new Point(0, 0);
            cuiButton1.ImageOffset = new Point(0, 0);
            cuiButton1.Location = new Point(75, 237);
            cuiButton1.Margin = new Padding(3, 0, 10, 0);
            cuiButton1.Name = "cuiButton1";
            cuiButton1.NormalBackground = Color.FromArgb(180, 60, 60);
            cuiButton1.NormalForeColor = Color.White;
            cuiButton1.NormalImageTint = Color.White;
            cuiButton1.NormalOutline = Color.Transparent;
            cuiButton1.OutlineThickness = 1F;
            cuiButton1.PressedBackground = Color.WhiteSmoke;
            cuiButton1.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton1.PressedImageTint = Color.White;
            cuiButton1.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.Rounding = new Padding(8);
            cuiButton1.Size = new Size(132, 36);
            cuiButton1.TabIndex = 22;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            // 
            // FormTrocarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 328);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(440, 328);
            MinimumSize = new Size(440, 328);
            Name = "FormTrocarUsuario";
            Padding = new Padding(3, 24, 3, 3);
            Text = "FormTrocarUsuario";
            pnlWrapperUsuario.ResumeLayout(false);
            pnlWrapperUsuario.PerformLayout();
            pnlWrapperSenha.ResumeLayout(false);
            pnlWrapperSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picToggleSenha).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public CuoreUI.Controls.cuiButton btnLogin;
        private Label lblAppName;
        private Label lblEsqueci;
        private Label lblUsuario;
        private Label lblSenhaInvalida;
        private Panel pnlWrapperUsuario;
        private TextBox txtUsuario;
        private Panel pnlWrapperSenha;
        private TextBox txtSenha;
        private PictureBox picToggleSenha;
        private Label lblUsuarioInvalido;
        private Label lblSenha;
        private Panel panel1;
        public CuoreUI.Controls.cuiButton cuiButton1;
    }
}