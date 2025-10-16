using Guna.UI2.WinForms.Suite;

namespace telebip_erp.Forms.Modules
{
    partial class FormFuncionarios
    {
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlDgv = new Panel();
            dgvFuncionarios = new DataGridView();
            pnlSidebar = new Panel();
            pnlUserProfile = new Panel();
            pnlProfileHeader = new Panel();
            lblProfileTitle = new Label();
            pbUserProfile = new PictureBox();
            pnlBotoesAcao = new Panel();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            pnlBottom = new Panel();
            lblTotal = new Label();
            pnlContainer.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlUserProfile.SuspendLayout();
            pnlProfileHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            pnlBotoesAcao.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(pnlMain);
            pnlContainer.Controls.Add(pnlSidebar);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Controls.Add(pnlBottom);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1597, 801);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(28, 29, 40);
            pnlMain.Controls.Add(pnlDgv);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 71);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1172, 695);
            pnlMain.TabIndex = 3;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.FromArgb(28, 29, 40);
            pnlDgv.Controls.Add(dgvFuncionarios);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 0);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1172, 695);
            pnlDgv.TabIndex = 4;
            // 
            // dgvFuncionarios
            // 
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvFuncionarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvFuncionarios.BorderStyle = BorderStyle.None;
            dgvFuncionarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFuncionarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 41, 52);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFuncionarios.ColumnHeadersHeight = 40;
            dgvFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(32, 33, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 90, 130);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvFuncionarios.DefaultCellStyle = dataGridViewCellStyle3;
            dgvFuncionarios.Dock = DockStyle.Fill;
            dgvFuncionarios.EnableHeadersVisualStyles = false;
            dgvFuncionarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvFuncionarios.Location = new Point(15, 15);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.Name = "dgvFuncionarios";
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.RowHeadersWidth = 62;
            dgvFuncionarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvFuncionarios.RowTemplate.Height = 35;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.Size = new Size(1142, 665);
            dgvFuncionarios.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(32, 33, 39);
            pnlSidebar.Controls.Add(pnlUserProfile);
            pnlSidebar.Dock = DockStyle.Right;
            pnlSidebar.Location = new Point(1172, 71);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(15);
            pnlSidebar.Size = new Size(425, 695);
            pnlSidebar.TabIndex = 2;
            // 
            // pnlUserProfile
            // 
            pnlUserProfile.BackColor = Color.FromArgb(40, 41, 52);
            pnlUserProfile.Controls.Add(pnlProfileHeader);
            pnlUserProfile.Controls.Add(pbUserProfile);
            pnlUserProfile.Controls.Add(pnlBotoesAcao);
            pnlUserProfile.Dock = DockStyle.Fill;
            pnlUserProfile.Location = new Point(15, 15);
            pnlUserProfile.Name = "pnlUserProfile";
            pnlUserProfile.Size = new Size(395, 665);
            pnlUserProfile.TabIndex = 1;
            // 
            // pnlProfileHeader
            // 
            pnlProfileHeader.BackColor = Color.FromArgb(50, 52, 67);
            pnlProfileHeader.Controls.Add(lblProfileTitle);
            pnlProfileHeader.Dock = DockStyle.Top;
            pnlProfileHeader.Location = new Point(0, 469);
            pnlProfileHeader.Name = "pnlProfileHeader";
            pnlProfileHeader.Padding = new Padding(15, 10, 15, 10);
            pnlProfileHeader.Size = new Size(395, 45);
            pnlProfileHeader.TabIndex = 3;
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.Dock = DockStyle.Fill;
            lblProfileTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.White;
            lblProfileTitle.Location = new Point(15, 10);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(365, 25);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "Detalhes do Funcionário";
            lblProfileTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbUserProfile
            // 
            pbUserProfile.BackColor = Color.FromArgb(50, 52, 67);
            pbUserProfile.Dock = DockStyle.Top;
            pbUserProfile.Location = new Point(0, 0);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Padding = new Padding(30);
            pbUserProfile.Size = new Size(395, 469);
            pbUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserProfile.TabIndex = 0;
            pbUserProfile.TabStop = false;
            // 
            // pnlBotoesAcao
            // 
            pnlBotoesAcao.BackColor = Color.Transparent;
            pnlBotoesAcao.Controls.Add(btnExcluir);
            pnlBotoesAcao.Controls.Add(btnEditar);
            pnlBotoesAcao.Controls.Add(btnNovo);
            pnlBotoesAcao.Dock = DockStyle.Bottom;
            pnlBotoesAcao.Location = new Point(0, 600);
            pnlBotoesAcao.Name = "pnlBotoesAcao";
            pnlBotoesAcao.Padding = new Padding(20, 15, 20, 20);
            pnlBotoesAcao.Size = new Size(395, 65);
            pnlBotoesAcao.TabIndex = 2;
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 8;
            btnExcluir.CustomizableEdges = customizableEdges1;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(120, 40, 40);
            btnExcluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.HoverState.BorderColor = Color.FromArgb(200, 80, 80);
            btnExcluir.HoverState.FillColor = Color.FromArgb(160, 60, 60);
            btnExcluir.Location = new Point(270, 15);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnExcluir.Size = new Size(105, 40);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 8;
            btnEditar.CustomizableEdges = customizableEdges3;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(40, 100, 180);
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.FromArgb(80, 140, 200);
            btnEditar.HoverState.FillColor = Color.FromArgb(60, 120, 180);
            btnEditar.Location = new Point(145, 15);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditar.Size = new Size(105, 40);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            // 
            // btnNovo
            // 
            btnNovo.BorderRadius = 8;
            btnNovo.CustomizableEdges = customizableEdges5;
            btnNovo.DisabledState.BorderColor = Color.DarkGray;
            btnNovo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNovo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNovo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNovo.FillColor = Color.FromArgb(40, 120, 80);
            btnNovo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNovo.ForeColor = Color.White;
            btnNovo.HoverState.BorderColor = Color.FromArgb(80, 200, 120);
            btnNovo.HoverState.FillColor = Color.FromArgb(60, 160, 100);
            btnNovo.Location = new Point(20, 15);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNovo.Size = new Size(105, 40);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "Novo Funcionário";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1597, 71);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1567, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestão de Funcionários";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lblTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 766);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1597, 35);
            pnlBottom.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(1382, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 5);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0 funcionários";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormFuncionarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1597, 801);
            ControlBox = false;
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormFuncionarios";
            Text = "FormFuncionarios";
            pnlContainer.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlUserProfile.ResumeLayout(false);
            pnlProfileHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            pnlBotoesAcao.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private Panel pnlDgv;
        private DataGridView dgvFuncionarios;
        private Panel pnlSidebar;
        private Panel pnlUserProfile;
        private Panel pnlProfileHeader;
        private Label lblProfileTitle;
        private PictureBox pbUserProfile;
        private Panel pnlBotoesAcao;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlBottom;
        private Label lblTotal;
    }
}