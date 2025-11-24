using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAddFuncionario
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlMain = new Panel();
            roundedNome = new telebip_erp.Controls.RoundedPanel();
            txtNome = new TextBox();
            roundedCargo = new telebip_erp.Controls.RoundedPanel();
            txtCargo = new TextBox();
            roundedData = new telebip_erp.Controls.RoundedPanel();
            mtxtDataNasc = new MaskedTextBox();
            roundedTel = new telebip_erp.Controls.RoundedPanel();
            txtTelefone = new TextBox();
            roundedEmail = new telebip_erp.Controls.RoundedPanel();
            txtEmail = new TextBox();
            picAvatar = new PictureBox();
            btnSalvar = new CuoreUI.Controls.cuiButton();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            roundedNome.SuspendLayout();
            roundedCargo.SuspendLayout();
            roundedData.SuspendLayout();
            roundedTel.SuspendLayout();
            roundedEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
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
            pnlContainer.Size = new Size(538, 365);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(roundedNome);
            pnlMain.Controls.Add(roundedCargo);
            pnlMain.Controls.Add(roundedData);
            pnlMain.Controls.Add(roundedTel);
            pnlMain.Controls.Add(roundedEmail);
            pnlMain.Controls.Add(picAvatar);
            pnlMain.Controls.Add(btnSalvar);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(538, 305);
            pnlMain.TabIndex = 1;
            // 
            // roundedNome
            // 
            roundedNome.BackColor = Color.FromArgb(40, 41, 52);
            roundedNome.BorderColor = Color.FromArgb(60, 62, 80);
            roundedNome.BorderThickness = 1;
            roundedNome.Controls.Add(txtNome);
            roundedNome.CornerRadius = 8;
            roundedNome.FillColor = Color.FromArgb(40, 41, 52);
            roundedNome.Location = new Point(20, 20);
            roundedNome.Name = "roundedNome";
            roundedNome.Padding = new Padding(8, 6, 8, 6);
            roundedNome.Size = new Size(380, 36);
            roundedNome.TabIndex = 10;
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.FromArgb(40, 41, 52);
            txtNome.BorderStyle = BorderStyle.None;
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.ForeColor = Color.White;
            txtNome.Location = new Point(8, 8);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome completo";
            txtNome.Size = new Size(364, 16);
            txtNome.TabIndex = 0;
            // 
            // roundedCargo
            // 
            roundedCargo.BackColor = Color.FromArgb(40, 41, 52);
            roundedCargo.BorderColor = Color.FromArgb(60, 62, 80);
            roundedCargo.BorderThickness = 1;
            roundedCargo.Controls.Add(txtCargo);
            roundedCargo.CornerRadius = 8;
            roundedCargo.FillColor = Color.FromArgb(40, 41, 52);
            roundedCargo.Location = new Point(20, 70);
            roundedCargo.Name = "roundedCargo";
            roundedCargo.Padding = new Padding(8, 6, 8, 6);
            roundedCargo.Size = new Size(260, 36);
            roundedCargo.TabIndex = 11;
            // 
            // txtCargo
            // 
            txtCargo.BackColor = Color.FromArgb(40, 41, 52);
            txtCargo.BorderStyle = BorderStyle.None;
            txtCargo.Font = new Font("Segoe UI", 9F);
            txtCargo.ForeColor = Color.White;
            txtCargo.Location = new Point(8, 8);
            txtCargo.Name = "txtCargo";
            txtCargo.PlaceholderText = "Cargo";
            txtCargo.Size = new Size(244, 16);
            txtCargo.TabIndex = 1;
            // 
            // roundedData
            // 
            roundedData.BackColor = Color.FromArgb(40, 41, 52);
            roundedData.BorderColor = Color.FromArgb(60, 62, 80);
            roundedData.BorderThickness = 1;
            roundedData.Controls.Add(mtxtDataNasc);
            roundedData.CornerRadius = 8;
            roundedData.FillColor = Color.FromArgb(40, 41, 52);
            roundedData.Location = new Point(320, 145);
            roundedData.Name = "roundedData";
            roundedData.Padding = new Padding(8, 6, 8, 6);
            roundedData.Size = new Size(200, 36);
            roundedData.TabIndex = 12;
            // 
            // mtxtDataNasc
            // 
            mtxtDataNasc.BackColor = Color.FromArgb(40, 41, 52);
            mtxtDataNasc.BorderStyle = BorderStyle.None;
            mtxtDataNasc.Font = new Font("Segoe UI", 9F);
            mtxtDataNasc.ForeColor = Color.White;
            mtxtDataNasc.Location = new Point(8, 8);
            mtxtDataNasc.Mask = "00-00-0000";
            mtxtDataNasc.Name = "mtxtDataNasc";
            mtxtDataNasc.Size = new Size(184, 16);
            mtxtDataNasc.TabIndex = 2;
            // 
            // roundedTel
            // 
            roundedTel.BackColor = Color.FromArgb(40, 41, 52);
            roundedTel.BorderColor = Color.FromArgb(60, 62, 80);
            roundedTel.BorderThickness = 1;
            roundedTel.Controls.Add(txtTelefone);
            roundedTel.CornerRadius = 8;
            roundedTel.FillColor = Color.FromArgb(40, 41, 52);
            roundedTel.Location = new Point(20, 120);
            roundedTel.Name = "roundedTel";
            roundedTel.Padding = new Padding(8, 6, 8, 6);
            roundedTel.Size = new Size(200, 36);
            roundedTel.TabIndex = 13;
            // 
            // txtTelefone
            // 
            txtTelefone.BackColor = Color.FromArgb(40, 41, 52);
            txtTelefone.BorderStyle = BorderStyle.None;
            txtTelefone.Font = new Font("Segoe UI", 9F);
            txtTelefone.ForeColor = Color.White;
            txtTelefone.Location = new Point(8, 8);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.PlaceholderText = "Telefone";
            txtTelefone.Size = new Size(184, 16);
            txtTelefone.TabIndex = 3;
            // 
            // roundedEmail
            // 
            roundedEmail.BackColor = Color.FromArgb(40, 41, 52);
            roundedEmail.BorderColor = Color.FromArgb(60, 62, 80);
            roundedEmail.BorderThickness = 1;
            roundedEmail.Controls.Add(txtEmail);
            roundedEmail.CornerRadius = 8;
            roundedEmail.FillColor = Color.FromArgb(40, 41, 52);
            roundedEmail.Location = new Point(260, 195);
            roundedEmail.Name = "roundedEmail";
            roundedEmail.Padding = new Padding(8, 6, 8, 6);
            roundedEmail.Size = new Size(260, 36);
            roundedEmail.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(40, 41, 52);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(8, 8);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(244, 16);
            txtEmail.TabIndex = 4;
            // 
            // picAvatar
            // 
            picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picAvatar.BackColor = Color.FromArgb(50, 50, 60);
            picAvatar.Location = new Point(420, 20);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(100, 100);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 20;
            picAvatar.TabStop = false;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.CheckButton = false;
            btnSalvar.Checked = false;
            btnSalvar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnSalvar.CheckedForeColor = Color.White;
            btnSalvar.CheckedImageTint = Color.White;
            btnSalvar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnSalvar.Content = "Salvar";
            btnSalvar.DialogResult = DialogResult.None;
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.HoverBackground = Color.White;
            btnSalvar.HoverForeColor = Color.Black;
            btnSalvar.HoverImageTint = Color.White;
            btnSalvar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnSalvar.Image = null;
            btnSalvar.ImageAutoCenter = true;
            btnSalvar.ImageExpand = new Point(0, 0);
            btnSalvar.ImageOffset = new Point(0, 0);
            btnSalvar.Location = new Point(410, 246);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnSalvar.NormalForeColor = Color.White;
            btnSalvar.NormalImageTint = Color.White;
            btnSalvar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnSalvar.OutlineThickness = 1F;
            btnSalvar.PressedBackground = Color.WhiteSmoke;
            btnSalvar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnSalvar.PressedImageTint = Color.White;
            btnSalvar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnSalvar.Rounding = new Padding(8);
            btnSalvar.Size = new Size(110, 36);
            btnSalvar.TabIndex = 5;
            btnSalvar.TextAlignment = StringAlignment.Center;
            btnSalvar.TextOffset = new Point(0, 0);
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.CheckButton = false;
            btnCancelar.Checked = false;
            btnCancelar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnCancelar.CheckedForeColor = Color.White;
            btnCancelar.CheckedImageTint = Color.White;
            btnCancelar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnCancelar.Content = "Cancelar";
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverBackground = Color.White;
            btnCancelar.HoverForeColor = Color.Black;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(290, 246);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NormalBackground = Color.FromArgb(70, 70, 70);
            btnCancelar.NormalForeColor = Color.White;
            btnCancelar.NormalImageTint = Color.White;
            btnCancelar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.OutlineThickness = 1F;
            btnCancelar.PressedBackground = Color.WhiteSmoke;
            btnCancelar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnCancelar.PressedImageTint = Color.White;
            btnCancelar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.Rounding = new Padding(8);
            btnCancelar.Size = new Size(110, 36);
            btnCancelar.TabIndex = 6;
            btnCancelar.TextAlignment = StringAlignment.Center;
            btnCancelar.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(538, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(508, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Funcionário";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(544, 392);
            Controls.Add(pnlContainer);
            Name = "FormAddFuncionario";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAddFuncionario";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            roundedNome.ResumeLayout(false);
            roundedNome.PerformLayout();
            roundedCargo.ResumeLayout(false);
            roundedCargo.PerformLayout();
            roundedData.ResumeLayout(false);
            roundedData.PerformLayout();
            roundedTel.ResumeLayout(false);
            roundedTel.PerformLayout();
            roundedEmail.ResumeLayout(false);
            roundedEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Exposed controls
        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;

        private telebip_erp.Controls.RoundedPanel roundedNome;
        private TextBox txtNome;

        private telebip_erp.Controls.RoundedPanel roundedCargo;
        private TextBox txtCargo;

        private telebip_erp.Controls.RoundedPanel roundedData;
        private MaskedTextBox mtxtDataNasc;

        private telebip_erp.Controls.RoundedPanel roundedTel;
        private TextBox txtTelefone;

        private telebip_erp.Controls.RoundedPanel roundedEmail;
        private TextBox txtEmail;

        private PictureBox picAvatar;
        private CuoreUI.Controls.cuiButton btnSalvar;
        private CuoreUI.Controls.cuiButton btnCancelar;
    }
}