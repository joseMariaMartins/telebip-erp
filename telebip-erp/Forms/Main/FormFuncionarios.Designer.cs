// NOTE: cole este conteúdo em FormFuncionarios.Designer.cs (substituindo o atual).
// Pressupõe: CuoreUI.Controls.cuiButton existe; telebip_erp.Controls.RoundedPanel é opcional.
// Eventos referenciados abaixo (DgvFuncionarios_SelectionChanged, BtnNovo_Click, BtnEditar_Click, BtnExcluir_Click)
// devem ser implementados no FormFuncionarios.cs.

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
            pnlContainer = new Panel();
            splitMain = new SplitContainer();
            pnlDetailsWrapper = new Panel();
            tblDetails = new TableLayoutPanel();
            pnlPhoto = new Panel();
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
            pnlBottom = new Panel();
            lblTotal = new Label();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlDetailsWrapper.SuspendLayout();
            tblDetails.SuspendLayout();
            pnlPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            pnlDetailsFields.SuspendLayout();
            flowButtons.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(28, 29, 40);
            pnlContainer.Controls.Add(splitMain);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Controls.Add(pnlBottom);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(1533, 659);
            pnlContainer.TabIndex = 0;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel1;
            splitMain.Location = new Point(10, 71);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = Color.FromArgb(40, 41, 52);
            splitMain.Panel1.Controls.Add(pnlDetailsWrapper);
            splitMain.Panel1.Padding = new Padding(12);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackColor = Color.FromArgb(28, 29, 40);
            splitMain.Panel2.Controls.Add(pnlMain);
            splitMain.Panel2.Padding = new Padding(12);
            splitMain.Size = new Size(1513, 538);
            splitMain.SplitterDistance = 235;
            splitMain.TabIndex = 1;
            // 
            // pnlDetailsWrapper
            // 
            pnlDetailsWrapper.BackColor = Color.FromArgb(40, 41, 52);
            pnlDetailsWrapper.Controls.Add(tblDetails);
            pnlDetailsWrapper.Dock = DockStyle.Fill;
            pnlDetailsWrapper.Location = new Point(12, 12);
            pnlDetailsWrapper.MinimumSize = new Size(260, 0);
            pnlDetailsWrapper.Name = "pnlDetailsWrapper";
            pnlDetailsWrapper.Size = new Size(260, 514);
            pnlDetailsWrapper.TabIndex = 0;
            // 
            // tblDetails
            // 
            tblDetails.ColumnCount = 1;
            tblDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDetails.Controls.Add(pnlPhoto, 0, 0);
            tblDetails.Controls.Add(pnlDetailsFields, 0, 1);
            tblDetails.Controls.Add(flowButtons, 0, 2);
            tblDetails.Dock = DockStyle.Fill;
            tblDetails.Location = new Point(0, 0);
            tblDetails.Name = "tblDetails";
            tblDetails.RowCount = 3;
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblDetails.Size = new Size(260, 514);
            tblDetails.TabIndex = 0;
            // 
            // pnlPhoto
            // 
            pnlPhoto.Controls.Add(pbUserProfile);
            pnlPhoto.Dock = DockStyle.Fill;
            pnlPhoto.Location = new Point(3, 3);
            pnlPhoto.Name = "pnlPhoto";
            pnlPhoto.Padding = new Padding(10);
            pnlPhoto.Size = new Size(254, 302);
            pnlPhoto.TabIndex = 0;
            // 
            // pbUserProfile
            // 
            pbUserProfile.BackColor = Color.FromArgb(50, 52, 67);
            pbUserProfile.Dock = DockStyle.Fill;
            pbUserProfile.Location = new Point(10, 10);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(234, 282);
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
            pnlDetailsFields.Location = new Point(3, 311);
            pnlDetailsFields.Name = "pnlDetailsFields";
            pnlDetailsFields.Padding = new Padding(12);
            pnlDetailsFields.Size = new Size(254, 148);
            pnlDetailsFields.TabIndex = 1;
            // 
            // lblTelefone
            // 
            lblTelefone.Dock = DockStyle.Top;
            lblTelefone.Font = new Font("Segoe UI", 9F);
            lblTelefone.ForeColor = Color.White;
            lblTelefone.Location = new Point(12, 84);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(230, 20);
            lblTelefone.TabIndex = 0;
            lblTelefone.Text = "Telefone: —";
            // 
            // lblEmail
            // 
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(12, 64);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(230, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email: —";
            // 
            // lblCargo
            // 
            lblCargo.Dock = DockStyle.Top;
            lblCargo.Font = new Font("Segoe UI", 10F);
            lblCargo.ForeColor = Color.White;
            lblCargo.Location = new Point(12, 40);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(230, 24);
            lblCargo.TabIndex = 2;
            lblCargo.Text = "Cargo: —";
            // 
            // lblNome
            // 
            lblNome.Dock = DockStyle.Top;
            lblNome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNome.ForeColor = Color.White;
            lblNome.Location = new Point(12, 12);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(230, 28);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome: —";
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnNovo);
            flowButtons.Controls.Add(btnEditar);
            flowButtons.Controls.Add(btnExcluir);
            flowButtons.Dock = DockStyle.Fill;
            flowButtons.Location = new Point(3, 465);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(10, 6, 10, 6);
            flowButtons.Size = new Size(254, 46);
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
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.DialogResult = DialogResult.None;
            btnNovo.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnNovo.ForeColor = Color.White;
            btnNovo.HoverBackground = Color.White;
            btnNovo.HoverForeColor = Color.Black;
            btnNovo.HoverImageTint = Color.White;
            btnNovo.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnNovo.Image = null;
            btnNovo.ImageAutoCenter = true;
            btnNovo.ImageExpand = new Point(0, 0);
            btnNovo.ImageOffset = new Point(0, 0);
            btnNovo.Location = new Point(13, 9);
            btnNovo.Name = "btnNovo";
            btnNovo.NormalBackground = Color.FromArgb(40, 120, 80);
            btnNovo.NormalForeColor = Color.White;
            btnNovo.NormalImageTint = Color.White;
            btnNovo.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnNovo.OutlineThickness = 1F;
            btnNovo.PressedBackground = Color.WhiteSmoke;
            btnNovo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnNovo.PressedImageTint = Color.White;
            btnNovo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnNovo.Rounding = new Padding(8);
            btnNovo.Size = new Size(110, 36);
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
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.DialogResult = DialogResult.None;
            btnEditar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverBackground = Color.White;
            btnEditar.HoverForeColor = Color.Black;
            btnEditar.HoverImageTint = Color.White;
            btnEditar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnEditar.Image = null;
            btnEditar.ImageAutoCenter = true;
            btnEditar.ImageExpand = new Point(0, 0);
            btnEditar.ImageOffset = new Point(0, 0);
            btnEditar.Location = new Point(129, 9);
            btnEditar.Name = "btnEditar";
            btnEditar.NormalBackground = Color.FromArgb(40, 100, 180);
            btnEditar.NormalForeColor = Color.White;
            btnEditar.NormalImageTint = Color.White;
            btnEditar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.OutlineThickness = 1F;
            btnEditar.PressedBackground = Color.WhiteSmoke;
            btnEditar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnEditar.PressedImageTint = Color.White;
            btnEditar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnEditar.Rounding = new Padding(8);
            btnEditar.Size = new Size(110, 36);
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
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.DialogResult = DialogResult.None;
            btnExcluir.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.HoverBackground = Color.White;
            btnExcluir.HoverForeColor = Color.Black;
            btnExcluir.HoverImageTint = Color.White;
            btnExcluir.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnExcluir.Image = null;
            btnExcluir.ImageAutoCenter = true;
            btnExcluir.ImageExpand = new Point(0, 0);
            btnExcluir.ImageOffset = new Point(0, 0);
            btnExcluir.Location = new Point(245, 9);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.NormalBackground = Color.FromArgb(120, 40, 40);
            btnExcluir.NormalForeColor = Color.White;
            btnExcluir.NormalImageTint = Color.White;
            btnExcluir.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnExcluir.OutlineThickness = 1F;
            btnExcluir.PressedBackground = Color.WhiteSmoke;
            btnExcluir.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnExcluir.PressedImageTint = Color.White;
            btnExcluir.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnExcluir.Rounding = new Padding(8);
            btnExcluir.Size = new Size(110, 36);
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
            pnlMain.Size = new Size(1250, 514);
            pnlMain.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvFuncionarios);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 0);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(8);
            pnlDgv.Size = new Size(1250, 514);
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
            dgvFuncionarios.Size = new Size(1234, 498);
            dgvFuncionarios.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(32, 33, 39);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10);
            pnlHeader.Size = new Size(1513, 61);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1493, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestão de Funcionários";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(32, 33, 39);
            pnlBottom.Controls.Add(lblTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(10, 609);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(10);
            pnlBottom.Size = new Size(1513, 40);
            pnlBottom.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(1403, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0 funcionários";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormFuncionarios
            // 
            ClientSize = new Size(1533, 659);
            Controls.Add(pnlContainer);
            Name = "FormFuncionarios";
            pnlContainer.ResumeLayout(false);
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlDetailsWrapper.ResumeLayout(false);
            tblDetails.ResumeLayout(false);
            pnlPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            pnlDetailsFields.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Controls (expostos para usar no .cs)
        private Panel pnlContainer;
        private SplitContainer splitMain;
        private Panel pnlDetailsWrapper;
        private TableLayoutPanel tblDetails;
        private Panel pnlPhoto;
        private PictureBox pbUserProfile;
        private Panel pnlDetailsFields;
        private FlowLayoutPanel flowButtons;
        private CuoreUI.Controls.cuiButton btnNovo;
        private CuoreUI.Controls.cuiButton btnEditar;
        private CuoreUI.Controls.cuiButton btnExcluir;

        private Panel pnlMain;
        private Panel pnlDgv;
        public DataGridView dgvFuncionarios;

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlBottom;
        private Label lblTotal;

        // labels de detalhe
        private Label lblNome;
        private Label lblCargo;
        private Label lblEmail;
        private Label lblTelefone;
    }
}
