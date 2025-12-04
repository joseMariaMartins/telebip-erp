using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.SubForms
{
    partial class FormAlteracaoSenhaGerente
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private telebip_erp.Controls.RoundedPanel pnlWrapperSenhaAtual;
        private telebip_erp.Controls.PlaceholderTextBox tbSenhaAtual;
        private Label lblSenhaAtual;
        private telebip_erp.Controls.RoundedPanel pnlWrapperNovaSenha;
        private telebip_erp.Controls.PlaceholderTextBox tbNovaSenha;
        private Label lblNovaSenha;
        private telebip_erp.Controls.RoundedPanel pnlWrapperConfirmarSenha;
        private telebip_erp.Controls.PlaceholderTextBox tbConfirmarSenha;
        private Label lblConfirmarSenha;
        private CuoreUI.Controls.cuiButton btnCancelar;
        private CuoreUI.Controls.cuiButton btnConfirmar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlMain = new Panel();
            lblSenha = new Label();
            cboxMostrarSenha = new CheckBox();
            pnlWrapperConfirmarSenha = new telebip_erp.Controls.RoundedPanel();
            tbConfirmarSenha = new telebip_erp.Controls.PlaceholderTextBox();
            lblConfirmarSenha = new Label();
            pnlWrapperNovaSenha = new telebip_erp.Controls.RoundedPanel();
            tbNovaSenha = new telebip_erp.Controls.PlaceholderTextBox();
            lblNovaSenha = new Label();
            pnlWrapperSenhaAtual = new telebip_erp.Controls.RoundedPanel();
            tbSenhaAtual = new telebip_erp.Controls.PlaceholderTextBox();
            lblSenhaAtual = new Label();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            btnConfirmar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlWrapperConfirmarSenha.SuspendLayout();
            pnlWrapperNovaSenha.SuspendLayout();
            pnlWrapperSenhaAtual.SuspendLayout();
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
            pnlContainer.Size = new Size(454, 418);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(lblSenha);
            pnlMain.Controls.Add(cboxMostrarSenha);
            pnlMain.Controls.Add(pnlWrapperConfirmarSenha);
            pnlMain.Controls.Add(lblConfirmarSenha);
            pnlMain.Controls.Add(pnlWrapperNovaSenha);
            pnlMain.Controls.Add(lblNovaSenha);
            pnlMain.Controls.Add(pnlWrapperSenhaAtual);
            pnlMain.Controls.Add(lblSenhaAtual);
            pnlMain.Controls.Add(btnCancelar);
            pnlMain.Controls.Add(btnConfirmar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30);
            pnlMain.Size = new Size(454, 358);
            pnlMain.TabIndex = 1;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.ForeColor = Color.White;
            lblSenha.Location = new Point(320, 261);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(83, 15);
            lblSenha.TabIndex = 20;
            lblSenha.Text = "Mostrar Senha";
            // 
            // cboxMostrarSenha
            // 
            cboxMostrarSenha.AutoSize = true;
            cboxMostrarSenha.Location = new Point(406, 262);
            cboxMostrarSenha.Name = "cboxMostrarSenha";
            cboxMostrarSenha.Size = new Size(15, 14);
            cboxMostrarSenha.TabIndex = 19;
            cboxMostrarSenha.UseVisualStyleBackColor = true;
            // 
            // pnlWrapperConfirmarSenha
            // 
            pnlWrapperConfirmarSenha.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperConfirmarSenha.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperConfirmarSenha.BorderThickness = 1;
            pnlWrapperConfirmarSenha.Controls.Add(tbConfirmarSenha);
            pnlWrapperConfirmarSenha.CornerRadius = 8;
            pnlWrapperConfirmarSenha.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperConfirmarSenha.Location = new Point(33, 215);
            pnlWrapperConfirmarSenha.Name = "pnlWrapperConfirmarSenha";
            pnlWrapperConfirmarSenha.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperConfirmarSenha.Size = new Size(388, 36);
            pnlWrapperConfirmarSenha.TabIndex = 2;
            // 
            // tbConfirmarSenha
            // 
            tbConfirmarSenha.BackColor = Color.FromArgb(40, 41, 52);
            tbConfirmarSenha.BorderStyle = BorderStyle.None;
            tbConfirmarSenha.Font = new Font("Segoe UI", 9F);
            tbConfirmarSenha.ForeColor = Color.White;
            tbConfirmarSenha.Location = new Point(8, 10);
            tbConfirmarSenha.Margin = new Padding(3, 0, 10, 0);
            tbConfirmarSenha.Name = "tbConfirmarSenha";
            tbConfirmarSenha.PasswordChar = '●';
            tbConfirmarSenha.Placeholder = "Digite novamente a nova senha";
            tbConfirmarSenha.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbConfirmarSenha.Size = new Size(342, 16);
            tbConfirmarSenha.TabIndex = 2;
            tbConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirmarSenha.ForeColor = Color.White;
            lblConfirmarSenha.Location = new Point(33, 190);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(200, 20);
            lblConfirmarSenha.TabIndex = 18;
            lblConfirmarSenha.Text = "Confirmar Nova Senha *";
            // 
            // pnlWrapperNovaSenha
            // 
            pnlWrapperNovaSenha.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperNovaSenha.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperNovaSenha.BorderThickness = 1;
            pnlWrapperNovaSenha.Controls.Add(tbNovaSenha);
            pnlWrapperNovaSenha.CornerRadius = 8;
            pnlWrapperNovaSenha.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperNovaSenha.Location = new Point(33, 135);
            pnlWrapperNovaSenha.Name = "pnlWrapperNovaSenha";
            pnlWrapperNovaSenha.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperNovaSenha.Size = new Size(388, 36);
            pnlWrapperNovaSenha.TabIndex = 1;
            // 
            // tbNovaSenha
            // 
            tbNovaSenha.BackColor = Color.FromArgb(40, 41, 52);
            tbNovaSenha.BorderStyle = BorderStyle.None;
            tbNovaSenha.Font = new Font("Segoe UI", 9F);
            tbNovaSenha.ForeColor = Color.White;
            tbNovaSenha.Location = new Point(8, 10);
            tbNovaSenha.Margin = new Padding(3, 0, 10, 0);
            tbNovaSenha.Name = "tbNovaSenha";
            tbNovaSenha.PasswordChar = '●';
            tbNovaSenha.Placeholder = "Digite a nova senha";
            tbNovaSenha.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbNovaSenha.Size = new Size(342, 16);
            tbNovaSenha.TabIndex = 1;
            tbNovaSenha.UseSystemPasswordChar = true;
            // 
            // lblNovaSenha
            // 
            lblNovaSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNovaSenha.ForeColor = Color.White;
            lblNovaSenha.Location = new Point(33, 110);
            lblNovaSenha.Name = "lblNovaSenha";
            lblNovaSenha.Size = new Size(200, 20);
            lblNovaSenha.TabIndex = 16;
            lblNovaSenha.Text = "Nova Senha *";
            // 
            // pnlWrapperSenhaAtual
            // 
            pnlWrapperSenhaAtual.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperSenhaAtual.BorderColor = Color.FromArgb(60, 62, 80);
            pnlWrapperSenhaAtual.BorderThickness = 1;
            pnlWrapperSenhaAtual.Controls.Add(tbSenhaAtual);
            pnlWrapperSenhaAtual.CornerRadius = 8;
            pnlWrapperSenhaAtual.FillColor = Color.FromArgb(40, 41, 52);
            pnlWrapperSenhaAtual.Location = new Point(33, 55);
            pnlWrapperSenhaAtual.Name = "pnlWrapperSenhaAtual";
            pnlWrapperSenhaAtual.Padding = new Padding(8, 6, 30, 6);
            pnlWrapperSenhaAtual.Size = new Size(388, 36);
            pnlWrapperSenhaAtual.TabIndex = 0;
            // 
            // tbSenhaAtual
            // 
            tbSenhaAtual.BackColor = Color.FromArgb(40, 41, 52);
            tbSenhaAtual.BorderStyle = BorderStyle.None;
            tbSenhaAtual.Font = new Font("Segoe UI", 9F);
            tbSenhaAtual.ForeColor = Color.White;
            tbSenhaAtual.Location = new Point(8, 10);
            tbSenhaAtual.Margin = new Padding(3, 0, 10, 0);
            tbSenhaAtual.Name = "tbSenhaAtual";
            tbSenhaAtual.PasswordChar = '●';
            tbSenhaAtual.Placeholder = "Digite a senha atual do gerente";
            tbSenhaAtual.PlaceholderColor = Color.FromArgb(160, 160, 160);
            tbSenhaAtual.Size = new Size(342, 16);
            tbSenhaAtual.TabIndex = 0;
            tbSenhaAtual.UseSystemPasswordChar = true;
            // 
            // lblSenhaAtual
            // 
            lblSenhaAtual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSenhaAtual.ForeColor = Color.White;
            lblSenhaAtual.Location = new Point(33, 30);
            lblSenhaAtual.Name = "lblSenhaAtual";
            lblSenhaAtual.Size = new Size(200, 20);
            lblSenhaAtual.TabIndex = 14;
            lblSenhaAtual.Text = "Senha Atual *";
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
            btnCancelar.HoverBackground = Color.FromArgb(150, 60, 60);
            btnCancelar.HoverForeColor = Color.White;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(211, 288);
            btnCancelar.Margin = new Padding(3, 0, 10, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NormalBackground = Color.FromArgb(120, 40, 40);
            btnCancelar.NormalForeColor = Color.White;
            btnCancelar.NormalImageTint = Color.White;
            btnCancelar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.OutlineThickness = 1F;
            btnCancelar.PressedBackground = Color.FromArgb(90, 30, 30);
            btnCancelar.PressedForeColor = Color.White;
            btnCancelar.PressedImageTint = Color.White;
            btnCancelar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnCancelar.Rounding = new Padding(8);
            btnCancelar.Size = new Size(100, 40);
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
            btnConfirmar.HoverBackground = Color.FromArgb(50, 150, 100);
            btnConfirmar.HoverForeColor = Color.White;
            btnConfirmar.HoverImageTint = Color.White;
            btnConfirmar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnConfirmar.Image = null;
            btnConfirmar.ImageAutoCenter = true;
            btnConfirmar.ImageExpand = new Point(0, 0);
            btnConfirmar.ImageOffset = new Point(0, 0);
            btnConfirmar.Location = new Point(321, 288);
            btnConfirmar.Margin = new Padding(3, 0, 10, 0);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnConfirmar.NormalForeColor = Color.White;
            btnConfirmar.NormalImageTint = Color.White;
            btnConfirmar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.OutlineThickness = 1F;
            btnConfirmar.PressedBackground = Color.FromArgb(30, 100, 70);
            btnConfirmar.PressedForeColor = Color.White;
            btnConfirmar.PressedImageTint = Color.White;
            btnConfirmar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnConfirmar.Rounding = new Padding(8);
            btnConfirmar.Size = new Size(100, 40);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(454, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(424, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alterar Senha - Gerente";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAlteracaoSenhaGerente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(460, 445);
            Controls.Add(pnlContainer);
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(460, 445);
            MinimumSize = new Size(460, 445);
            Name = "FormAlteracaoSenhaGerente";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAlteracaoSenhaGerente";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlWrapperConfirmarSenha.ResumeLayout(false);
            pnlWrapperConfirmarSenha.PerformLayout();
            pnlWrapperNovaSenha.ResumeLayout(false);
            pnlWrapperNovaSenha.PerformLayout();
            pnlWrapperSenhaAtual.ResumeLayout(false);
            pnlWrapperSenhaAtual.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
        private CheckBox cboxMostrarSenha;
        private Label lblSenha;
    }
}