// FormFuncionarios.Designer.cs
using System;
using System.Windows.Forms;
using System.Drawing;

namespace telebip_erp.Forms.Modules
{
    partial class FormFuncionarios
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlContainer = new Panel();
            pnlContent = new Panel();
            pnlDetailsWrapper = new Panel();
            pbUserProfile = new PictureBox();
            pnlDetailsFields = new Panel();
            lblTelefone = new Label();
            lblEmail = new Label();
            lblCargo = new Label();
            lblNome = new Label();
            flowButtons = new FlowLayoutPanel();
            btnNovo = new CuoreUI.Controls.cuiButton();
            btnEditar = new CuoreUI.Controls.cuiButton();
            btnExcluir = new CuoreUI.Controls.cuiButton();
            pnlMain = new Panel();
            pnlDgv = new Panel();
            dgvFuncionarios = new DataGridView();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlContainer.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlDetailsWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            pnlDetailsFields.SuspendLayout();
            flowButtons.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlContent);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(1467, 800);
            pnlContainer.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(28, 29, 40);
            pnlContent.Controls.Add(pnlDetailsWrapper);
            pnlContent.Controls.Add(pnlMain);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(10, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(12);
            pnlContent.Size = new Size(1447, 720);
            pnlContent.TabIndex = 0;
            // 
            // pnlDetailsWrapper
            // 
            pnlDetailsWrapper.BackColor = Color.FromArgb(40, 41, 52);
            pnlDetailsWrapper.Controls.Add(pbUserProfile);
            pnlDetailsWrapper.Controls.Add(pnlDetailsFields);
            pnlDetailsWrapper.Controls.Add(flowButtons);
            pnlDetailsWrapper.Dock = DockStyle.Right;
            pnlDetailsWrapper.Location = new Point(1135, 12);
            pnlDetailsWrapper.MinimumSize = new Size(260, 0);
            pnlDetailsWrapper.Name = "pnlDetailsWrapper";
            pnlDetailsWrapper.Padding = new Padding(12);
            pnlDetailsWrapper.Size = new Size(300, 696);
            pnlDetailsWrapper.TabIndex = 0;
            // 
            // pbUserProfile
            // 
            pbUserProfile.BackColor = Color.FromArgb(50, 52, 67);
            pbUserProfile.Dock = DockStyle.Top;
            pbUserProfile.Location = new Point(12, 12);
            pbUserProfile.Margin = new Padding(0);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(276, 260);
            pbUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserProfile.TabIndex = 0;
            pbUserProfile.TabStop = false;
            // 
            // pnlDetailsFields
            // 
            pnlDetailsFields.Controls.Add(lblTelefone);
            pnlDetailsFields.Controls.Add(lblEmail);
            pnlDetailsFields.Controls.Add(lblCargo);
            pnlDetailsFields.Controls.Add(lblNome);
            pnlDetailsFields.Dock = DockStyle.Fill;
            pnlDetailsFields.Location = new Point(12, 12);
            pnlDetailsFields.Name = "pnlDetailsFields";
            pnlDetailsFields.Padding = new Padding(8);
            pnlDetailsFields.Size = new Size(276, 616);
            pnlDetailsFields.TabIndex = 1;
            // 
            // lblTelefone
            // 
            lblTelefone.Dock = DockStyle.Top;
            lblTelefone.Font = new Font("Segoe UI", 9F);
            lblTelefone.ForeColor = Color.White;
            lblTelefone.Location = new Point(8, 84);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(260, 20);
            lblTelefone.TabIndex = 0;
            lblTelefone.Text = "Telefone: Não Registrado";
            // 
            // lblEmail
            // 
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(8, 64);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(260, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail: exemplo@etc";
            // 
            // lblCargo
            // 
            lblCargo.Dock = DockStyle.Top;
            lblCargo.Font = new Font("Segoe UI", 10F);
            lblCargo.ForeColor = Color.White;
            lblCargo.Location = new Point(8, 40);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(260, 24);
            lblCargo.TabIndex = 2;
            lblCargo.Text = "Cargo: Não Registrado";
            // 
            // lblNome
            // 
            lblNome.Dock = DockStyle.Top;
            lblNome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(8, 8);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(260, 32);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome: Não Registrado";
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnNovo);
            flowButtons.Controls.Add(btnEditar);
            flowButtons.Controls.Add(btnExcluir);
            flowButtons.Dock = DockStyle.Bottom;
            flowButtons.Location = new Point(12, 628);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(8);
            flowButtons.Size = new Size(276, 56);
            flowButtons.TabIndex = 2;
            flowButtons.WrapContents = false;
            // 
            // btnNovo
            // 
            btnNovo.CheckButton = false;
            btnNovo.Checked = false;
            btnNovo.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnNovo.CheckedForeColor = Color.White;
            btnNovo.CheckedImageTint = Color.White;
            btnNovo.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnNovo.Content = "Novo";
            btnNovo.DialogResult = DialogResult.None;
            btnNovo.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnNovo.ForeColor = Color.Black;
            btnNovo.HoverBackground = Color.White;
            btnNovo.HoverForeColor = Color.Black;
            btnNovo.HoverImageTint = Color.White;
            btnNovo.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnNovo.Image = null;
            btnNovo.ImageAutoCenter = true;
            btnNovo.ImageExpand = new Point(0, 0);
            btnNovo.ImageOffset = new Point(0, 0);
            btnNovo.Location = new Point(11, 11);
            btnNovo.Name = "btnNovo";
            btnNovo.NormalBackground = Color.White;
            btnNovo.NormalForeColor = Color.Black;
            btnNovo.NormalImageTint = Color.White;
            btnNovo.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnNovo.OutlineThickness = 1F;
            btnNovo.PressedBackground = Color.WhiteSmoke;
            btnNovo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnNovo.PressedImageTint = Color.White;
            btnNovo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnNovo.Rounding = new Padding(8);
            btnNovo.Size = new Size(88, 36);
            btnNovo.TabIndex = 0;
            btnNovo.TextAlignment = StringAlignment.Center;
            btnNovo.TextOffset = new Point(0, 0);
            // 
            // btnEditar
            // 
            btnEditar.CheckButton = false;
            btnEditar.Checked = false;
            btnEditar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnEditar.CheckedForeColor = Color.White;
            btnEditar.CheckedImageTint = Color.White;
            btnEditar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnEditar.Content = "Editar";
            btnEditar.DialogResult = DialogResult.None;
            btnEditar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnEditar.ForeColor = Color.Black;
            btnEditar.HoverBackground = Color.White;
            btnEditar.HoverForeColor = Color.Black;
            btnEditar.HoverImageTint = Color.White;
            btnEditar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnEditar.Image = null;
            btnEditar.ImageAutoCenter = true;
            btnEditar.ImageExpand = new Point(0, 0);
            btnEditar.ImageOffset = new Point(0, 0);
            btnEditar.Location = new Point(105, 11);
            btnEditar.Name = "btnEditar";
            btnEditar.NormalBackground = Color.White;
            btnEditar.NormalForeColor = Color.Black;
            btnEditar.NormalImageTint = Color.White;
            btnEditar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.OutlineThickness = 1F;
            btnEditar.PressedBackground = Color.WhiteSmoke;
            btnEditar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnEditar.PressedImageTint = Color.White;
            btnEditar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.Rounding = new Padding(8);
            btnEditar.Size = new Size(88, 36);
            btnEditar.TabIndex = 1;
            btnEditar.TextAlignment = StringAlignment.Center;
            btnEditar.TextOffset = new Point(0, 0);
            // 
            // btnExcluir
            // 
            btnExcluir.CheckButton = false;
            btnExcluir.Checked = false;
            btnExcluir.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnExcluir.CheckedForeColor = Color.White;
            btnExcluir.CheckedImageTint = Color.White;
            btnExcluir.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnExcluir.Content = "Excluir";
            btnExcluir.DialogResult = DialogResult.None;
            btnExcluir.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnExcluir.ForeColor = Color.Black;
            btnExcluir.HoverBackground = Color.White;
            btnExcluir.HoverForeColor = Color.Black;
            btnExcluir.HoverImageTint = Color.White;
            btnExcluir.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnExcluir.Image = null;
            btnExcluir.ImageAutoCenter = true;
            btnExcluir.ImageExpand = new Point(0, 0);
            btnExcluir.ImageOffset = new Point(0, 0);
            btnExcluir.Location = new Point(199, 11);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.NormalBackground = Color.White;
            btnExcluir.NormalForeColor = Color.Black;
            btnExcluir.NormalImageTint = Color.White;
            btnExcluir.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnExcluir.OutlineThickness = 1F;
            btnExcluir.PressedBackground = Color.WhiteSmoke;
            btnExcluir.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnExcluir.PressedImageTint = Color.White;
            btnExcluir.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnExcluir.Rounding = new Padding(8);
            btnExcluir.Size = new Size(88, 36);
            btnExcluir.TabIndex = 2;
            btnExcluir.TextAlignment = StringAlignment.Center;
            btnExcluir.TextOffset = new Point(0, 0);
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(pnlDgv);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(12, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(8);
            pnlMain.Size = new Size(1423, 696);
            pnlMain.TabIndex = 1;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvFuncionarios);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(8, 8);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(8);
            pnlDgv.Size = new Size(1407, 680);
            pnlDgv.TabIndex = 0;
            // 
            // dgvFuncionarios
            // 
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.AllowUserToResizeRows = false;
            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvFuncionarios.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFuncionarios.ColumnHeadersHeight = 40;
            dgvFuncionarios.Dock = DockStyle.Fill;
            dgvFuncionarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvFuncionarios.Location = new Point(8, 8);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.Name = "dgvFuncionarios";
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.RowTemplate.Height = 35;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.Size = new Size(1391, 664);
            dgvFuncionarios.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12);
            pnlHeader.Size = new Size(1447, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(12, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1423, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerenciamento de Funcionários";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormFuncionarios
            // 
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1467, 800);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(950, 800);
            Name = "FormFuncionarios";
            Text = "FormFuncionarios";
            pnlContainer.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlDetailsWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            pnlDetailsFields.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Exposed controls
        private Panel pnlContainer;
        private Panel pnlHeader;
        private Panel pnlContent;

        private Panel pnlMain;
        private Panel pnlDgv;
        public DataGridView dgvFuncionarios;

        private Panel pnlDetailsWrapper;
        private PictureBox pbUserProfile;
        private Panel pnlDetailsFields;
        private FlowLayoutPanel flowButtons;
        private CuoreUI.Controls.cuiButton btnNovo;
        private CuoreUI.Controls.cuiButton btnEditar;
        private CuoreUI.Controls.cuiButton btnExcluir;

        private Label lblTitulo;

        private Label lblNome;
        private Label lblCargo;
        private Label lblEmail;
        private Label lblTelefone;
    }
}
