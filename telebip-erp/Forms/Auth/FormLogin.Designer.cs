using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Auth
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        // Controles usados pela lógica em FormLogin.cs
        private Panel pnlWrapperUsuario;
        private TextBox txtUsuario;
        private Label lblUsuario;

        private Panel pnlWrapperSenha;
        private TextBox txtSenha;
        private PictureBox picToggleSenha;
        private Label lblSenha;
        private Label lblEsqueci;

        private Label lblUsuarioInvalido;
        private Label lblSenhaInvalida;

        private Label lblAppName;
        private Label lblTitulo;

        private Panel panel1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            lblAppName = new Label();
            lblTitulo = new Label();
            lblUsuario = new Label();
            pnlWrapperUsuario = new Panel();
            txtUsuario = new TextBox();
            lblUsuarioInvalido = new Label();
            lblSenha = new Label();
            pnlWrapperSenha = new Panel();
            txtSenha = new TextBox();
            picToggleSenha = new PictureBox();
            lblSenhaInvalida = new Label();
            lblEsqueci = new Label();
            panel1 = new Panel();
            btnLogin = new CuoreUI.Controls.cuiButton();
            pnlWrapperUsuario.SuspendLayout();
            pnlWrapperSenha.SuspendLayout();
            ((ISupportInitialize)picToggleSenha).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAppName.ForeColor = Color.FromArgb(140, 180, 255);
            lblAppName.Location = new Point(158, 5);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(120, 19);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Telebip Organizer";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F);
            lblTitulo.ForeColor = Color.FromArgb(230, 230, 235);
            lblTitulo.Location = new Point(175, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(86, 21);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bem-vindo";
            // 
            // lblUsuario
            // 
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(230, 230, 235);
            lblUsuario.Location = new Point(36, 58);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(120, 20);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuário";
            // 
            // pnlWrapperUsuario
            // 
            pnlWrapperUsuario.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperUsuario.Controls.Add(txtUsuario);
            pnlWrapperUsuario.Location = new Point(36, 78);
            pnlWrapperUsuario.Name = "pnlWrapperUsuario";
            pnlWrapperUsuario.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperUsuario.Size = new Size(364, 40);
            pnlWrapperUsuario.TabIndex = 3;
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
            // lblUsuarioInvalido
            // 
            lblUsuarioInvalido.Font = new Font("Segoe UI", 8F);
            lblUsuarioInvalido.ForeColor = Color.FromArgb(255, 100, 100);
            lblUsuarioInvalido.Location = new Point(36, 122);
            lblUsuarioInvalido.Name = "lblUsuarioInvalido";
            lblUsuarioInvalido.Size = new Size(364, 16);
            lblUsuarioInvalido.TabIndex = 4;
            lblUsuarioInvalido.Text = "Usuário inválido";
            lblUsuarioInvalido.Visible = false;
            // 
            // lblSenha
            // 
            lblSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSenha.ForeColor = Color.FromArgb(230, 230, 235);
            lblSenha.Location = new Point(36, 142);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(120, 20);
            lblSenha.TabIndex = 5;
            lblSenha.Text = "Senha";
            // 
            // pnlWrapperSenha
            // 
            pnlWrapperSenha.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperSenha.Controls.Add(txtSenha);
            pnlWrapperSenha.Controls.Add(picToggleSenha);
            pnlWrapperSenha.Location = new Point(36, 162);
            pnlWrapperSenha.Name = "pnlWrapperSenha";
            pnlWrapperSenha.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperSenha.Size = new Size(364, 40);
            pnlWrapperSenha.TabIndex = 6;
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.FromArgb(40, 41, 52);
            txtSenha.BorderStyle = BorderStyle.None;
            txtSenha.Font = new Font("Segoe UI", 9F);
            txtSenha.ForeColor = Color.White;
            txtSenha.Location = new Point(8, 10);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(288, 16);
            txtSenha.TabIndex = 0;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // picToggleSenha
            // 
            picToggleSenha.Cursor = Cursors.Hand;
            picToggleSenha.Location = new Point(325, 8);
            picToggleSenha.Name = "picToggleSenha";
            picToggleSenha.Size = new Size(28, 24);
            picToggleSenha.SizeMode = PictureBoxSizeMode.CenterImage;
            picToggleSenha.TabIndex = 1;
            picToggleSenha.TabStop = false;
            // 
            // lblSenhaInvalida
            // 
            lblSenhaInvalida.Font = new Font("Segoe UI", 8F);
            lblSenhaInvalida.ForeColor = Color.FromArgb(255, 100, 100);
            lblSenhaInvalida.Location = new Point(36, 206);
            lblSenhaInvalida.Name = "lblSenhaInvalida";
            lblSenhaInvalida.Size = new Size(364, 16);
            lblSenhaInvalida.TabIndex = 7;
            lblSenhaInvalida.Text = "Senha inválida";
            lblSenhaInvalida.Visible = false;
            // 
            // lblEsqueci
            // 
            lblEsqueci.AutoSize = true;
            lblEsqueci.Cursor = Cursors.Hand;
            lblEsqueci.Font = new Font("Segoe UI", 9F);
            lblEsqueci.ForeColor = Color.FromArgb(100, 150, 255);
            lblEsqueci.Location = new Point(297, 207);
            lblEsqueci.Name = "lblEsqueci";
            lblEsqueci.Size = new Size(103, 15);
            lblEsqueci.TabIndex = 8;
            lblEsqueci.Text = "Esqueci a senha →";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(28, 29, 40);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblAppName);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(lblEsqueci);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(lblSenhaInvalida);
            panel1.Controls.Add(pnlWrapperUsuario);
            panel1.Controls.Add(pnlWrapperSenha);
            panel1.Controls.Add(lblUsuarioInvalido);
            panel1.Controls.Add(lblSenha);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 298);
            panel1.TabIndex = 10;
            // 
            // btnLogin
            // 
            btnLogin.CheckButton = false;
            btnLogin.Checked = false;
            btnLogin.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnLogin.CheckedForeColor = Color.White;
            btnLogin.CheckedImageTint = Color.White;
            btnLogin.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnLogin.Content = "Entrar";
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
            btnLogin.Location = new Point(280, 235);
            btnLogin.Margin = new Padding(3, 0, 10, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.NormalBackground = Color.FromArgb(40, 120, 80);
            btnLogin.NormalForeColor = Color.White;
            btnLogin.NormalImageTint = Color.White;
            btnLogin.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLogin.OutlineThickness = 1F;
            btnLogin.PressedBackground = Color.WhiteSmoke;
            btnLogin.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnLogin.PressedImageTint = Color.White;
            btnLogin.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLogin.Rounding = new Padding(8);
            btnLogin.Size = new Size(120, 36);
            btnLogin.TabIndex = 11;
            btnLogin.TextAlignment = StringAlignment.Center;
            btnLogin.TextOffset = new Point(0, 0);
            // 
            // FormLogin
            // 
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(440, 328);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(440, 328);
            MinimumSize = new Size(440, 328);
            Name = "FormLogin";
            Padding = new Padding(3, 24, 6, 6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Telebip Organizer";
            pnlWrapperUsuario.ResumeLayout(false);
            pnlWrapperUsuario.PerformLayout();
            pnlWrapperSenha.ResumeLayout(false);
            pnlWrapperSenha.PerformLayout();
            ((ISupportInitialize)picToggleSenha).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiButton btnLogin;
    }
}
