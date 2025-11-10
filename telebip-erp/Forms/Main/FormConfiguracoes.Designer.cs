using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CuoreUI.Controls;

namespace telebip_erp.Forms.Modules
{
    partial class FormConfiguracoes
    {
        private IContainer components = null;

        #region Controles
        private Panel pnlDgv;
        private TableLayoutPanel mainLayout;

        // Left card
        private Panel pnlLeftCard;
        private TableLayoutPanel leftLayout;
        private Label labelUserTitle;
        private Label lbContato;
        private Panel pnlEmailWrapper;
        private TextBox tbEmail;
        private cuiButton btnConfirmar;

        private Label lblGerenteTitle;
        private cuiButton btnGerente;
        private Label lblFuncionarioTitle;
        private cuiButton btnFuncionario;

        // Right card
        private Panel pnlRightCard;
        private TableLayoutPanel rightLayout;
        private Label labelBackupTitle;
        private Label labelBackupQuestion;
        private FlowLayoutPanel panelBackupButtons;
        private cuiButton btnBackup;
        private cuiButton btnRestaurarBackup;

        private Label labelSupportTitle;
        private Label labelSupportLine1;
        private Label labelSupportLine2;
        private Label lbSuporte;

        // Separators
        private Panel sepLeft;
        private Panel sepRight;
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer
        private void InitializeComponent()
        {
            components = new Container();

            // Root
            pnlDgv = new Panel();
            mainLayout = new TableLayoutPanel();

            // Left
            pnlLeftCard = new Panel();
            leftLayout = new TableLayoutPanel();
            labelUserTitle = new Label();
            lbContato = new Label();
            pnlEmailWrapper = new Panel();
            tbEmail = new TextBox();
            btnConfirmar = new cuiButton();
            sepLeft = new Panel();
            lblGerenteTitle = new Label();
            btnGerente = new cuiButton();
            lblFuncionarioTitle = new Label();
            btnFuncionario = new cuiButton();

            // Right
            pnlRightCard = new Panel();
            rightLayout = new TableLayoutPanel();
            labelBackupTitle = new Label();
            labelBackupQuestion = new Label();
            panelBackupButtons = new FlowLayoutPanel();
            btnBackup = new cuiButton();
            btnRestaurarBackup = new cuiButton();
            sepRight = new Panel();
            labelSupportTitle = new Label();
            labelSupportLine1 = new Label();
            labelSupportLine2 = new Label();
            lbSuporte = new Label();

            SuspendLayout();

            // ======================
            // pnlDgv (root)
            // ======================
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Padding = new Padding(20);
            pnlDgv.BackColor = Color.FromArgb(34, 35, 49);
            pnlDgv.Name = "pnlDgv";

            // ======================
            // mainLayout: duas colunas responsivas (48/52)
            // ======================
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.BackColor = Color.Transparent;
            mainLayout.Padding = new Padding(0);
            mainLayout.Margin = new Padding(0);

            // ======================
            // Left card (fill only, no stroke)
            // ======================
            pnlLeftCard.Dock = DockStyle.Fill;
            pnlLeftCard.Margin = new Padding(8);
            pnlLeftCard.BackColor = Color.FromArgb(32, 33, 39);
            pnlLeftCard.Padding = new Padding(18);
            pnlLeftCard.Name = "pnlLeftCard";
            pnlLeftCard.Paint += (s, e) => DrawRoundedPanelFill(s as Panel, e, pnlLeftCard.BackColor);

            // leftLayout: vertical flow with predictable rows
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.ColumnCount = 1;
            leftLayout.RowCount = 12;
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // title
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F)); // gap
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // contato label
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // email row
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F)); // gap
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // sep
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F)); // gap
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // gerente title
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // gerente btn
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F)); // gap
            leftLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // funcionario btn

            // labelUserTitle
            labelUserTitle.AutoSize = false;
            labelUserTitle.Dock = DockStyle.Fill;
            labelUserTitle.Text = "Configurações de Usuário";
            labelUserTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            labelUserTitle.ForeColor = Color.FromArgb(230, 230, 230);
            labelUserTitle.Height = 32;

            // lbContato
            lbContato.AutoSize = true;
            lbContato.Text = "E-mail para contato";
            lbContato.Font = new Font("Segoe UI", 11F);
            lbContato.ForeColor = Color.FromArgb(200, 200, 200);

            // pnlEmailWrapper (arredondado) - ADJUSTED to avoid squeezing
            pnlEmailWrapper.Dock = DockStyle.Fill;
            pnlEmailWrapper.Padding = new Padding(12, 8, 12, 8);
            pnlEmailWrapper.BackColor = Color.FromArgb(40, 41, 52);
            pnlEmailWrapper.Margin = new Padding(0);
            // set a reasonable minimum width so it doesn't squeeze too much on narrow windows
            pnlEmailWrapper.MinimumSize = new Size(200, 40);
            pnlEmailWrapper.Paint += (s, e) =>
            {
                var panel = s as Panel;
                if (panel == null) return;
                var r = panel.ClientRectangle;
                int radius = 8;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    int d = radius * 2;
                    path.StartFigure();
                    path.AddArc(r.Left, r.Top, d, d, 180, 90);
                    path.AddArc(r.Right - d, r.Top, d, d, 270, 90);
                    path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                    path.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            };

            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Dock = DockStyle.Fill;
            tbEmail.Font = new Font("Segoe UI", 9F);
            tbEmail.ForeColor = Color.White;
            tbEmail.BackColor = pnlEmailWrapper.BackColor;
            tbEmail.Margin = new Padding(0);
            // also give a minimum size to the textbox so the inner text doesn't get cut
            tbEmail.MinimumSize = new Size(140, 22);

            // btnConfirmar (cuiButton) fixed size
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Content = "OK";
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.NormalBackground = Color.FromArgb(40, 120, 80);
            btnConfirmar.NormalForeColor = Color.White;
            btnConfirmar.Rounding = new Padding(6);
            btnConfirmar.Size = new Size(84, 36);
            btnConfirmar.Anchor = AnchorStyles.Right;
            btnConfirmar.Cursor = Cursors.Hand;

            // separator left
            sepLeft.Height = 1;
            sepLeft.Dock = DockStyle.Top;
            sepLeft.BackColor = Color.FromArgb(60, 62, 80);
            sepLeft.Margin = new Padding(0, 12, 0, 12);

            // gerente and funcionario controls (kept same)
            lblGerenteTitle.AutoSize = true;
            lblGerenteTitle.Text = "Alterar senha do perfil gerente";
            lblGerenteTitle.Font = new Font("Segoe UI", 11F);
            lblGerenteTitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblGerenteTitle.Margin = new Padding(0, 6, 0, 6);

            btnGerente.Name = "btnGerente";
            btnGerente.Content = "Alterar senha gerente";
            btnGerente.Font = new Font("Segoe UI", 9.75F);
            btnGerente.NormalBackground = Color.FromArgb(60, 63, 75);
            btnGerente.NormalForeColor = Color.White;
            btnGerente.Rounding = new Padding(8);
            btnGerente.Size = new Size(220, 44);
            btnGerente.Cursor = Cursors.Hand;
            btnGerente.Anchor = AnchorStyles.Left;

            lblFuncionarioTitle.AutoSize = true;
            lblFuncionarioTitle.Text = "Alterar senha do perfil do Funcionário";
            lblFuncionarioTitle.Font = new Font("Segoe UI", 11F);
            lblFuncionarioTitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblFuncionarioTitle.Margin = new Padding(0, 6, 0, 6);

            btnFuncionario.Name = "btnFuncionario";
            btnFuncionario.Content = "Alterar senha funcionário";
            btnFuncionario.Font = new Font("Segoe UI", 9.75F);
            btnFuncionario.NormalBackground = Color.FromArgb(60, 63, 75);
            btnFuncionario.NormalForeColor = Color.White;
            btnFuncionario.Rounding = new Padding(8);
            btnFuncionario.Size = new Size(220, 44);
            btnFuncionario.Cursor = Cursors.Hand;
            btnFuncionario.Anchor = AnchorStyles.Left;

            // Assemble leftLayout
            var emailRow = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            emailRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // email expands
            emailRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));     // button fixed
            emailRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            emailRow.Margin = new Padding(0);
            emailRow.Padding = new Padding(0);
            emailRow.Controls.Add(pnlEmailWrapper, 0, 0);
            emailRow.Controls.Add(btnConfirmar, 1, 0);
            pnlEmailWrapper.Controls.Add(tbEmail);

            leftLayout.Controls.Add(labelUserTitle, 0, 0);
            leftLayout.Controls.Add(lbContato, 0, 2);
            leftLayout.Controls.Add(emailRow, 0, 4);
            leftLayout.Controls.Add(sepLeft, 0, 6);
            leftLayout.Controls.Add(lblGerenteTitle, 0, 8);
            leftLayout.Controls.Add(btnGerente, 0, 9);
            leftLayout.Controls.Add(lblFuncionarioTitle, 0, 10);
            leftLayout.Controls.Add(btnFuncionario, 0, 11);

            leftLayout.Dock = DockStyle.Fill;
            leftLayout.Padding = new Padding(0);
            leftLayout.Margin = new Padding(0);

            pnlLeftCard.Controls.Add(leftLayout);

            // ======================
            // Right card (kept same)
            // ======================
            pnlRightCard.Dock = DockStyle.Fill;
            pnlRightCard.Margin = new Padding(8);
            pnlRightCard.BackColor = Color.FromArgb(32, 33, 39);
            pnlRightCard.Padding = new Padding(18);
            pnlRightCard.Name = "pnlRightCard";
            pnlRightCard.Paint += (s, e) => DrawRoundedPanelFill(s as Panel, e, pnlRightCard.BackColor);

            rightLayout.Dock = DockStyle.Fill;
            rightLayout.ColumnCount = 1;
            rightLayout.RowCount = 10;
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 10; i++) rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightLayout.Padding = new Padding(0);

            labelBackupTitle.AutoSize = false;
            labelBackupTitle.Dock = DockStyle.Fill;
            labelBackupTitle.Text = "Configurações Backup";
            labelBackupTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            labelBackupTitle.ForeColor = Color.FromArgb(230, 230, 230);
            labelBackupTitle.Height = 32;

            labelBackupQuestion.AutoSize = true;
            labelBackupQuestion.Text = "Qual local será guardado o backup do banco de dados?";
            labelBackupQuestion.Font = new Font("Segoe UI", 11F);
            labelBackupQuestion.ForeColor = Color.FromArgb(200, 200, 200);
            labelBackupQuestion.Margin = new Padding(0, 8, 0, 6);

            panelBackupButtons.FlowDirection = FlowDirection.LeftToRight;
            panelBackupButtons.AutoSize = true;
            panelBackupButtons.Dock = DockStyle.Fill;
            panelBackupButtons.WrapContents = false;

            btnBackup.Name = "btnBackup";
            btnBackup.Content = "Criar backup";
            btnBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBackup.NormalBackground = Color.FromArgb(40, 120, 80);
            btnBackup.NormalForeColor = Color.White;
            btnBackup.Rounding = new Padding(6);
            btnBackup.Size = new Size(140, 36);
            btnBackup.Margin = new Padding(0, 0, 12, 0);
            btnBackup.Cursor = Cursors.Hand;

            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.Content = "Restaurar backup";
            btnRestaurarBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRestaurarBackup.NormalBackground = Color.FromArgb(120, 40, 40);
            btnRestaurarBackup.NormalForeColor = Color.White;
            btnRestaurarBackup.Rounding = new Padding(6);
            btnRestaurarBackup.Size = new Size(160, 36);
            btnRestaurarBackup.Cursor = Cursors.Hand;

            panelBackupButtons.Controls.Add(btnBackup);
            panelBackupButtons.Controls.Add(btnRestaurarBackup);

            sepRight.Height = 1;
            sepRight.Dock = DockStyle.Top;
            sepRight.BackColor = Color.FromArgb(60, 62, 80);
            sepRight.Margin = new Padding(0, 12, 0, 12);

            labelSupportTitle.AutoSize = true;
            labelSupportTitle.Text = "Atualizar o banco de dados por um backup?";
            labelSupportTitle.Font = new Font("Segoe UI", 11F);
            labelSupportTitle.ForeColor = Color.FromArgb(200, 200, 200);
            labelSupportTitle.Margin = new Padding(0, 6, 0, 6);

            labelSupportLine1.AutoSize = true;
            labelSupportLine1.Text = "Em caso de dúvidas ou necessidade de assistência técnica,";
            labelSupportLine1.Font = new Font("Segoe UI", 11F);
            labelSupportLine1.ForeColor = Color.FromArgb(200, 200, 200);

            labelSupportLine2.AutoSize = true;
            labelSupportLine2.Text = "entre em contato com nossa equipe de suporte através do e-mail:";
            labelSupportLine2.Font = new Font("Segoe UI", 11F);
            labelSupportLine2.ForeColor = Color.FromArgb(200, 200, 200);

            lbSuporte.AutoSize = true;
            lbSuporte.Cursor = Cursors.Hand;
            lbSuporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lbSuporte.ForeColor = Color.FromArgb(100, 150, 255);
            lbSuporte.Margin = new Padding(0, 8, 0, 0);
            lbSuporte.Text = "telebip.suporte@gmail.com";

            rightLayout.Controls.Add(labelBackupTitle, 0, 0);
            rightLayout.Controls.Add(labelBackupQuestion, 0, 1);
            rightLayout.Controls.Add(panelBackupButtons, 0, 2);
            rightLayout.Controls.Add(sepRight, 0, 3);
            rightLayout.Controls.Add(labelSupportTitle, 0, 4);
            rightLayout.Controls.Add(labelSupportLine1, 0, 5);
            rightLayout.Controls.Add(labelSupportLine2, 0, 6);
            rightLayout.Controls.Add(lbSuporte, 0, 7);

            rightLayout.Dock = DockStyle.Fill;

            pnlRightCard.Controls.Add(rightLayout);

            // add cards to mainLayout
            mainLayout.Controls.Add(pnlLeftCard, 0, 0);
            mainLayout.Controls.Add(pnlRightCard, 1, 0);

            pnlDgv.Controls.Add(mainLayout);

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1120, 540);
            Controls.Add(pnlDgv);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormConfiguracoes";
            Text = "Configurações";
            ResumeLayout(false);
        }
        #endregion

        #region Helpers
        private void DrawRoundedPanelFill(Panel panel, PaintEventArgs e, Color fill)
        {
            if (panel == null) return;
            var r = panel.ClientRectangle;
            int radius = 12;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            using (var brush = new SolidBrush(fill))
            {
                int d = radius * 2;
                path.StartFigure();
                path.AddArc(r.Left, r.Top, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Top, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
        }
        #endregion
    }
}
