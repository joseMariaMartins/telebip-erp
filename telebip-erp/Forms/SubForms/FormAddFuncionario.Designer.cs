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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNome = new Label();
            roundedNome = new telebip_erp.Controls.RoundedPanel();
            txtNome = new TextBox();
            lblCargo = new Label();
            roundedCargo = new telebip_erp.Controls.RoundedPanel();
            txtCargo = new TextBox();
            lblDataNascimento = new Label();
            roundedData = new telebip_erp.Controls.RoundedPanel();
            mtxtDataNasc = new MaskedTextBox();
            pnlBotoes = new Panel();
            btnSalvar = new CuoreUI.Controls.cuiButton();
            btnCancelar = new CuoreUI.Controls.cuiButton();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            roundedNome.SuspendLayout();
            roundedCargo.SuspendLayout();
            roundedData.SuspendLayout();
            pnlBotoes.SuspendLayout();
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
            pnlContainer.Size = new Size(540, 374);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(tableLayoutPanel1);
            pnlMain.Controls.Add(pnlBotoes);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(30, 20, 30, 20);
            pnlMain.Size = new Size(540, 314);
            pnlMain.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblNome, 0, 0);
            tableLayoutPanel1.Controls.Add(roundedNome, 0, 1);
            tableLayoutPanel1.Controls.Add(lblCargo, 0, 2);
            tableLayoutPanel1.Controls.Add(roundedCargo, 0, 3);
            tableLayoutPanel1.Controls.Add(lblDataNascimento, 0, 4);
            tableLayoutPanel1.Controls.Add(roundedData, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(30, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(480, 194);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Dock = DockStyle.Fill;
            lblNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(3, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(474, 25);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome Completo *";
            lblNome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedNome
            // 
            roundedNome.BackColor = Color.FromArgb(40, 41, 52);
            roundedNome.BorderColor = Color.FromArgb(60, 62, 80);
            roundedNome.BorderThickness = 1;
            roundedNome.Controls.Add(txtNome);
            roundedNome.CornerRadius = 8;
            roundedNome.Dock = DockStyle.Fill;
            roundedNome.FillColor = Color.FromArgb(40, 41, 52);
            roundedNome.Location = new Point(0, 25);
            roundedNome.Margin = new Padding(0);
            roundedNome.Name = "roundedNome";
            roundedNome.Padding = new Padding(12, 8, 12, 8);
            roundedNome.Size = new Size(480, 40);
            roundedNome.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.FromArgb(40, 41, 52);
            txtNome.BorderStyle = BorderStyle.None;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.ForeColor = Color.White;
            txtNome.Location = new Point(12, 9);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite o nome completo";
            txtNome.Size = new Size(456, 18);
            txtNome.TabIndex = 0;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Dock = DockStyle.Fill;
            lblCargo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCargo.ForeColor = Color.White;
            lblCargo.Location = new Point(3, 65);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(474, 25);
            lblCargo.TabIndex = 2;
            lblCargo.Text = "Cargo *";
            lblCargo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedCargo
            // 
            roundedCargo.BackColor = Color.FromArgb(40, 41, 52);
            roundedCargo.BorderColor = Color.FromArgb(60, 62, 80);
            roundedCargo.BorderThickness = 1;
            roundedCargo.Controls.Add(txtCargo);
            roundedCargo.CornerRadius = 8;
            roundedCargo.Dock = DockStyle.Fill;
            roundedCargo.FillColor = Color.FromArgb(40, 41, 52);
            roundedCargo.Location = new Point(0, 90);
            roundedCargo.Margin = new Padding(0);
            roundedCargo.Name = "roundedCargo";
            roundedCargo.Padding = new Padding(12, 8, 12, 8);
            roundedCargo.Size = new Size(480, 40);
            roundedCargo.TabIndex = 3;
            // 
            // txtCargo
            // 
            txtCargo.BackColor = Color.FromArgb(40, 41, 52);
            txtCargo.BorderStyle = BorderStyle.None;
            txtCargo.Font = new Font("Segoe UI", 10F);
            txtCargo.ForeColor = Color.White;
            txtCargo.Location = new Point(12, 10);
            txtCargo.Name = "txtCargo";
            txtCargo.PlaceholderText = "Digite o cargo";
            txtCargo.Size = new Size(456, 18);
            txtCargo.TabIndex = 1;
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Dock = DockStyle.Fill;
            lblDataNascimento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDataNascimento.ForeColor = Color.White;
            lblDataNascimento.Location = new Point(3, 130);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Size = new Size(474, 25);
            lblDataNascimento.TabIndex = 4;
            lblDataNascimento.Text = "Data de Nascimento *";
            lblDataNascimento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roundedData
            // 
            roundedData.BackColor = Color.FromArgb(40, 41, 52);
            roundedData.BorderColor = Color.FromArgb(60, 62, 80);
            roundedData.BorderThickness = 1;
            roundedData.Controls.Add(mtxtDataNasc);
            roundedData.CornerRadius = 8;
            roundedData.Dock = DockStyle.Fill;
            roundedData.FillColor = Color.FromArgb(40, 41, 52);
            roundedData.Location = new Point(0, 155);
            roundedData.Margin = new Padding(0);
            roundedData.Name = "roundedData";
            roundedData.Padding = new Padding(12, 8, 12, 8);
            roundedData.Size = new Size(480, 40);
            roundedData.TabIndex = 5;
            // 
            // mtxtDataNasc
            // 
            mtxtDataNasc.BackColor = Color.FromArgb(40, 41, 52);
            mtxtDataNasc.BorderStyle = BorderStyle.None;
            mtxtDataNasc.Font = new Font("Segoe UI", 10F);
            mtxtDataNasc.ForeColor = Color.White;
            mtxtDataNasc.Location = new Point(12, 11);
            mtxtDataNasc.Mask = "00/00/0000";
            mtxtDataNasc.Name = "mtxtDataNasc";
            mtxtDataNasc.Size = new Size(456, 18);
            mtxtDataNasc.TabIndex = 2;
            mtxtDataNasc.ValidatingType = typeof(DateTime);
            // 
            // pnlBotoes
            // 
            pnlBotoes.BackColor = Color.Transparent;
            pnlBotoes.Controls.Add(btnSalvar);
            pnlBotoes.Controls.Add(btnCancelar);
            pnlBotoes.Dock = DockStyle.Bottom;
            pnlBotoes.Location = new Point(30, 214);
            pnlBotoes.Name = "pnlBotoes";
            pnlBotoes.Size = new Size(480, 80);
            pnlBotoes.TabIndex = 14;
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
            btnSalvar.HoverBackground = Color.FromArgb(50, 150, 100);
            btnSalvar.HoverForeColor = Color.White;
            btnSalvar.HoverImageTint = Color.White;
            btnSalvar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnSalvar.Image = null;
            btnSalvar.ImageAutoCenter = true;
            btnSalvar.ImageExpand = new Point(0, 0);
            btnSalvar.ImageOffset = new Point(0, 0);
            btnSalvar.Location = new Point(370, 22);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnSalvar.NormalForeColor = Color.White;
            btnSalvar.NormalImageTint = Color.White;
            btnSalvar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnSalvar.OutlineThickness = 1F;
            btnSalvar.PressedBackground = Color.FromArgb(30, 100, 70);
            btnSalvar.PressedForeColor = Color.White;
            btnSalvar.PressedImageTint = Color.White;
            btnSalvar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnSalvar.Rounding = new Padding(8);
            btnSalvar.Size = new Size(110, 36);
            btnSalvar.TabIndex = 3;
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
            btnCancelar.HoverBackground = Color.FromArgb(150, 60, 60);
            btnCancelar.HoverForeColor = Color.White;
            btnCancelar.HoverImageTint = Color.White;
            btnCancelar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnCancelar.Image = null;
            btnCancelar.ImageAutoCenter = true;
            btnCancelar.ImageExpand = new Point(0, 0);
            btnCancelar.ImageOffset = new Point(0, 0);
            btnCancelar.Location = new Point(254, 22);
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
            btnCancelar.Size = new Size(110, 36);
            btnCancelar.TabIndex = 4;
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
            pnlHeader.Padding = new Padding(20, 15, 20, 15);
            pnlHeader.Size = new Size(540, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Funcionário";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormAddFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(546, 401);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MaximumSize = new Size(546, 401);
            MinimizeBox = false;
            MinimumSize = new Size(546, 401);
            Name = "FormAddFuncionario";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Funcionário";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            roundedNome.ResumeLayout(false);
            roundedNome.PerformLayout();
            roundedCargo.ResumeLayout(false);
            roundedCargo.PerformLayout();
            roundedData.ResumeLayout(false);
            roundedData.PerformLayout();
            pnlBotoes.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitulo;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNome;
        private Controls.RoundedPanel roundedNome;
        private TextBox txtNome;
        private Label lblCargo;
        private Controls.RoundedPanel roundedCargo;
        private TextBox txtCargo;
        private Label lblDataNascimento;
        private Controls.RoundedPanel roundedData;
        private MaskedTextBox mtxtDataNasc;
        private Panel pnlBotoes;
        private CuoreUI.Controls.cuiButton btnSalvar;
        private CuoreUI.Controls.cuiButton btnCancelar;
    }
}