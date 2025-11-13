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
            // main containers
            pnlContainer = new Panel();
            pnlHeader = new Panel();
            pnlBottom = new Panel();
            pnlContent = new Panel();
            // left: dgv area
            pnlMain = new Panel();
            pnlDgv = new Panel();
            dgvFuncionarios = new DataGridView();
            // right: simplified card (dock = Right)
            pnlDetailsWrapper = new Panel();
            pbUserProfile = new PictureBox();
            pnlDetailsFields = new Panel();
            lblNome = new Label();
            lblCargo = new Label();
            lblEmail = new Label();
            lblTelefone = new Label();
            flowButtons = new FlowLayoutPanel();
            btnNovo = new CuoreUI.Controls.cuiButton();
            btnEditar = new CuoreUI.Controls.cuiButton();
            btnExcluir = new CuoreUI.Controls.cuiButton();
            // header/bottom content
            lblTitulo = new Label();
            lblTotal = new Label();
            // Begin init
            SuspendLayout();
            // pnlContainer
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Controls.Add(pnlContent);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Controls.Add(pnlBottom);
            // pnlHeader
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Padding = new Padding(12);
            pnlHeader.Controls.Add(lblTitulo);
            // lblTitulo
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Text = "Gerenciamento de Funcionários";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // pnlBottom
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 40;
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Padding = new Padding(10);
            pnlBottom.Controls.Add(lblTotal);
            // lblTotal
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Text = "Total: 0";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // pnlContent (holds left and right areas)
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(28, 29, 40);
            pnlContent.Padding = new Padding(12);
            // order matters: add left first (Fill), then right (Right) or add right then left — we'll add right then left below
            // pnlDetailsWrapper (RIGHT card)
            pnlDetailsWrapper.Width = 300;
            pnlDetailsWrapper.Dock = DockStyle.Right;
            pnlDetailsWrapper.MinimumSize = new Size(260, 0);
            pnlDetailsWrapper.BackColor = Color.FromArgb(40, 41, 52);
            pnlDetailsWrapper.Padding = new Padding(12);
            // pbUserProfile (top, fixed height)
            pbUserProfile.Dock = DockStyle.Top;
            pbUserProfile.Height = 260;
            pbUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserProfile.BackColor = Color.FromArgb(50, 52, 67);
            pbUserProfile.Margin = new Padding(0);
            pnlDetailsWrapper.Controls.Add(pbUserProfile);
            // pnlDetailsFields (fill remaining space between picture and buttons)
            pnlDetailsFields.Dock = DockStyle.Fill;
            pnlDetailsFields.Padding = new Padding(8);
            // add labels in stack: add last first so DockTop works predictably
            pnlDetailsFields.Controls.Add(lblTelefone);
            pnlDetailsFields.Controls.Add(lblEmail);
            pnlDetailsFields.Controls.Add(lblCargo);
            pnlDetailsFields.Controls.Add(lblNome);
            // labels defaults
            lblNome.Dock = DockStyle.Top;
            lblNome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Height = 32;
            lblNome.Text = "Nome: Não Registrado";
            lblCargo.Dock = DockStyle.Top;
            lblCargo.Font = new Font("Segoe UI", 10F);
            lblCargo.ForeColor = Color.White;
            lblCargo.Height = 24;
            lblCargo.Text = "Cargo: Não Registrado";
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Height = 20;
            lblEmail.Text = "E-mail: exemplo@etc";
            lblTelefone.Dock = DockStyle.Top;
            lblTelefone.Font = new Font("Segoe UI", 9F);
            lblTelefone.ForeColor = Color.White;
            lblTelefone.Height = 20;
            lblTelefone.Text = "Telefone: Não Registrado";
            pnlDetailsWrapper.Controls.Add(pnlDetailsFields);
            // flowButtons (bottom of card)
            flowButtons.Dock = DockStyle.Bottom;
            flowButtons.Height = 56;
            flowButtons.Padding = new Padding(8);
            flowButtons.FlowDirection = FlowDirection.LeftToRight;
            flowButtons.WrapContents = false;
            flowButtons.Controls.Add(btnNovo);
            flowButtons.Controls.Add(btnEditar);
            flowButtons.Controls.Add(btnExcluir);
            // buttons simple sizing (CuoreUI)
            btnNovo.Content = "Novo";
            btnNovo.Size = new Size(88, 36);
            btnEditar.Content = "Editar";
            btnEditar.Size = new Size(88, 36);
            btnExcluir.Content = "Excluir";
            btnExcluir.Size = new Size(88, 36);
            pnlDetailsWrapper.Controls.Add(flowButtons);
            // pnlMain (LEFT - fills remaining space)
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Padding = new Padding(8);
            pnlMain.Controls.Add(pnlDgv);
            // pnlDgv
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Padding = new Padding(8);
            pnlDgv.Controls.Add(dgvFuncionarios);
            // dgvFuncionarios
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.AllowUserToResizeRows = false;
            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvFuncionarios.BorderStyle = BorderStyle.None;
            dgvFuncionarios.ColumnHeadersHeight = 40;
            dgvFuncionarios.Dock = DockStyle.Fill;
            dgvFuncionarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.RowTemplate.Height = 35;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Assemble content: add the right card then left fill so dock works predictably
            pnlContent.Controls.Add(pnlDetailsWrapper);
            pnlContent.Controls.Add(pnlMain);
            // Form (base)
            ClientSize = new Size(1200, 690);
            MinimumSize = new Size(950, 800);
            MaximumSize = new Size(1920, 1080);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(28, 29, 40);
            Name = "FormFuncionarios";
            Text = "FormFuncionarios";
            ResumeLayout(false);
        }

        #endregion

        // Exposed controls
        private Panel pnlContainer;
        private Panel pnlHeader;
        private Panel pnlBottom;
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
        private Label lblTotal;

        private Label lblNome;
        private Label lblCargo;
        private Label lblEmail;
        private Label lblTelefone;
    }
}
