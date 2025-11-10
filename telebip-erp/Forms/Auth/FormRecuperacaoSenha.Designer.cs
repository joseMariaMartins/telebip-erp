using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Auth
{
    partial class FormRecuperacaoSenha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private Label label1;
        private CuoreUI.Controls.cuiButton btnCancelar;
        private CuoreUI.Controls.cuiButton btnConfirmar;
        private TextBox tbId;
        private Panel pnlWrapperId;

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
            label1 = new Label();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            btnConfirmar = new CuoreUI.Controls.cuiButton();
            pnlWrapperId = new Panel();
            tbId = new TextBox();
            panel1 = new Panel();
            pnlWrapperId.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(230, 230, 235);
            label1.Location = new Point(32, 27);
            label1.Name = "label1";
            label1.Size = new Size(260, 19);
            label1.TabIndex = 0;
            label1.Text = "Informe seu ID de acesso para continuar";
            // 
            // btnCancelar
            // 
            btnCancelar.CheckButton = false;
            btnCancelar.Checked = false;
            btnCancelar.CheckedBackground = Color.FromArgb(90, 90, 90);
            btnCancelar.CheckedForeColor = Color.White;
            btnCancelar.CheckedImageTint = Color.White;
            btnCancelar.CheckedOutline = Color.FromArgb(90, 90, 90);
            btnCancelar.Content = "Cancelar";
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.HoverBackground = Color.FromArgb(70, 70, 70);
            btnCancelar.HoverForeColor = Color.White;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(30, 255, 255, 255);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(192, 121);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NormalBackground = Color.FromArgb(60, 60, 66);
            btnCancelar.NormalForeColor = Color.White;
            btnCancelar.NormalImageTint = Color.White;
            btnCancelar.NormalOutline = Color.FromArgb(30, 255, 255, 255);
            btnCancelar.OutlineThickness = 0.75F;
            btnCancelar.PressedBackground = Color.FromArgb(48, 48, 54);
            btnCancelar.PressedForeColor = Color.White;
            btnCancelar.PressedImageTint = Color.White;
            btnCancelar.PressedOutline = Color.FromArgb(20, 255, 255, 255);
            btnCancelar.Rounding = new Padding(8);
            btnCancelar.Size = new Size(144, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.TextAlignment = StringAlignment.Center;
            btnCancelar.TextOffset = new Point(0, 0);
            // 
            // btnConfirmar
            // 
            btnConfirmar.CheckButton = false;
            btnConfirmar.Checked = false;
            btnConfirmar.CheckedBackground = Color.FromArgb(34, 139, 34);
            btnConfirmar.CheckedForeColor = Color.White;
            btnConfirmar.CheckedImageTint = Color.White;
            btnConfirmar.CheckedOutline = Color.FromArgb(34, 139, 34);
            btnConfirmar.Content = "Confirmar";
            btnConfirmar.DialogResult = DialogResult.None;
            btnConfirmar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverBackground = Color.FromArgb(62, 146, 111);
            btnConfirmar.HoverForeColor = Color.White;
            btnConfirmar.HoverImageTint = Color.White;
            btnConfirmar.HoverOutline = Color.FromArgb(30, 255, 255, 255);
            btnConfirmar.Image = null;
            btnConfirmar.ImageAutoCenter = true;
            btnConfirmar.ImageExpand = new Point(0, 0);
            btnConfirmar.ImageOffset = new Point(0, 0);
            btnConfirmar.Location = new Point(32, 121);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnConfirmar.NormalForeColor = Color.White;
            btnConfirmar.NormalImageTint = Color.White;
            btnConfirmar.NormalOutline = Color.FromArgb(30, 255, 255, 255);
            btnConfirmar.OutlineThickness = 0.75F;
            btnConfirmar.PressedBackground = Color.FromArgb(26, 90, 60);
            btnConfirmar.PressedForeColor = Color.White;
            btnConfirmar.PressedImageTint = Color.White;
            btnConfirmar.PressedOutline = Color.FromArgb(20, 255, 255, 255);
            btnConfirmar.Rounding = new Padding(8);
            btnConfirmar.Size = new Size(144, 40);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.TextAlignment = StringAlignment.Center;
            btnConfirmar.TextOffset = new Point(0, 0);
            // 
            // pnlWrapperId
            // 
            pnlWrapperId.BackColor = Color.FromArgb(40, 41, 52);
            pnlWrapperId.Controls.Add(tbId);
            pnlWrapperId.Location = new Point(32, 49);
            pnlWrapperId.Name = "pnlWrapperId";
            pnlWrapperId.Padding = new Padding(8, 6, 8, 6);
            pnlWrapperId.Size = new Size(304, 40);
            pnlWrapperId.TabIndex = 1;
            // 
            // tbId
            // 
            tbId.BackColor = Color.FromArgb(40, 41, 52);
            tbId.BorderStyle = BorderStyle.None;
            tbId.Font = new Font("Segoe UI", 9F);
            tbId.ForeColor = Color.White;
            tbId.Location = new Point(10, 12);
            tbId.MaxLength = 6;
            tbId.Name = "tbId";
            tbId.Size = new Size(286, 16);
            tbId.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(pnlWrapperId);
            panel1.Controls.Add(btnConfirmar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 198);
            panel1.TabIndex = 4;
            // 
            // FormRecuperacaoSenha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(378, 232);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            FormStyle = FormStyles.ActionBar_None;
            MaximumSize = new Size(378, 232);
            MinimumSize = new Size(378, 232);
            Name = "FormRecuperacaoSenha";
            Padding = new Padding(3, 24, 10, 10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recuperação de senha";
            pnlWrapperId.ResumeLayout(false);
            pnlWrapperId.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}
