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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContainer = new Panel();
            pnlMain = new Panel();
            dgvFuncionarios = new DataGridView();
            pnlSidebar = new Panel();
            pnlUserProfile = new Panel();
            pbUserProfile = new PictureBox();
            pnlProfileInfo = new Panel();
            lblUserIdade = new Label();
            lblUserCargo = new Label();
            lblUserName = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlUserProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            pnlProfileInfo.SuspendLayout();
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
            pnlMain.BackColor = Color.FromArgb(32, 33, 39);
            pnlMain.Controls.Add(dgvFuncionarios);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 50);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(15);
            pnlMain.Size = new Size(1172, 716);
            pnlMain.TabIndex = 3;
            // 
            // dgvFuncionarios
            // 
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvFuncionarios.BorderStyle = BorderStyle.None;
            dgvFuncionarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFuncionarios.Dock = DockStyle.Fill;
            dgvFuncionarios.GridColor = Color.FromArgb(50, 52, 67);
            dgvFuncionarios.Location = new Point(15, 15);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.Name = "dgvFuncionarios";
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.RowHeadersWidth = 62;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.Size = new Size(1142, 686);
            dgvFuncionarios.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(32, 33, 39);
            pnlSidebar.Controls.Add(pnlUserProfile);
            pnlSidebar.Dock = DockStyle.Right;
            pnlSidebar.Location = new Point(1172, 50);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(15);
            pnlSidebar.Size = new Size(425, 716);
            pnlSidebar.TabIndex = 2;
            // 
            // pnlUserProfile
            // 
            pnlUserProfile.BackColor = Color.FromArgb(40, 41, 52);
            pnlUserProfile.Controls.Add(pbUserProfile);
            pnlUserProfile.Controls.Add(pnlProfileInfo);
            pnlUserProfile.Controls.Add(pnlBotoesAcao);
            pnlUserProfile.Dock = DockStyle.Fill;
            pnlUserProfile.Location = new Point(15, 15);
            pnlUserProfile.Name = "pnlUserProfile";
            pnlUserProfile.Size = new Size(395, 686);
            pnlUserProfile.TabIndex = 1;
            // 
            // pbUserProfile
            // 
            pbUserProfile.BackColor = Color.FromArgb(50, 52, 67);
            pbUserProfile.Dock = DockStyle.Fill;
            pbUserProfile.Location = new Point(0, 0);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(395, 486);
            pbUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserProfile.TabIndex = 0;
            pbUserProfile.TabStop = false;
            // 
            // pnlProfileInfo
            // 
            pnlProfileInfo.BackColor = Color.FromArgb(32, 33, 39);
            pnlProfileInfo.Controls.Add(lblUserIdade);
            pnlProfileInfo.Controls.Add(lblUserCargo);
            pnlProfileInfo.Controls.Add(lblUserName);
            pnlProfileInfo.Dock = DockStyle.Bottom;
            pnlProfileInfo.Location = new Point(0, 486);
            pnlProfileInfo.Name = "pnlProfileInfo";
            pnlProfileInfo.Padding = new Padding(15);
            pnlProfileInfo.Size = new Size(395, 100);
            pnlProfileInfo.TabIndex = 1;
            // 
            // lblUserIdade
            // 
            lblUserIdade.Dock = DockStyle.Fill;
            lblUserIdade.Font = new Font("Segoe UI", 9F);
            lblUserIdade.ForeColor = Color.LightGray;
            lblUserIdade.Location = new Point(15, 65);
            lblUserIdade.Name = "lblUserIdade";
            lblUserIdade.Size = new Size(365, 20);
            lblUserIdade.TabIndex = 2;
            lblUserIdade.Text = "Idade";
            lblUserIdade.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserCargo
            // 
            lblUserCargo.Dock = DockStyle.Top;
            lblUserCargo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUserCargo.ForeColor = Color.LightGray;
            lblUserCargo.Location = new Point(15, 40);
            lblUserCargo.Name = "lblUserCargo";
            lblUserCargo.Size = new Size(365, 25);
            lblUserCargo.TabIndex = 1;
            lblUserCargo.Text = "Cargo";
            lblUserCargo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(15, 15);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(365, 25);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Nome do Funcionário";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBotoesAcao
            // 
            pnlBotoesAcao.BackColor = Color.FromArgb(40, 41, 52);
            pnlBotoesAcao.Controls.Add(btnExcluir);
            pnlBotoesAcao.Controls.Add(btnEditar);
            pnlBotoesAcao.Controls.Add(btnNovo);
            pnlBotoesAcao.Dock = DockStyle.Bottom;
            pnlBotoesAcao.Location = new Point(0, 586);
            pnlBotoesAcao.Name = "pnlBotoesAcao";
            pnlBotoesAcao.Padding = new Padding(15);
            pnlBotoesAcao.Size = new Size(395, 100);
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
            btnExcluir.Location = new Point(272, 30);
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
            btnEditar.Location = new Point(143, 30);
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
            btnNovo.Location = new Point(15, 30);
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
            pnlHeader.Size = new Size(1597, 50);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1567, 20);
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
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlUserProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            pnlProfileInfo.ResumeLayout(false);
            pnlBotoesAcao.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlMain;
        private DataGridView dgvFuncionarios;
        private Panel pnlSidebar;
        private Panel pnlUserProfile;
        private Panel pnlBotoesAcao;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Panel pnlProfileInfo;
        private Label lblUserIdade;
        private Label lblUserCargo;
        private Label lblUserName;
        private PictureBox pbUserProfile;
        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlBottom;
        private Label lblTotal;
    }
}