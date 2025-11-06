namespace telebip_erp.Forms.Modules
{
    partial class FormConfiguracoes
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
            flpTop = new FlowLayoutPanel();
            pnlDgv = new Panel();
            btnConfirmar = new Button();
            label4 = new Label();
            btnRestaurarBackup = new Button();
            label1 = new Label();
            btnBackup = new Button();
            label9 = new Label();
            label8 = new Label();
            btnFuncionario = new CuoreUI.Controls.cuiButton();
            label7 = new Label();
            btnGerente = new CuoreUI.Controls.cuiButton();
            label6 = new Label();
            label5 = new Label();
            tbEmail = new TextBox();
            lbContato = new Label();
            label3 = new Label();
            label2 = new Label();
            lbSuporte = new Label();
            pnlDgv.SuspendLayout();
            SuspendLayout();
            // 
            // flpTop
            // 
            flpTop.Dock = DockStyle.Top;
            flpTop.Location = new Point(0, 0);
            flpTop.Margin = new Padding(2);
            flpTop.Name = "flpTop";
            flpTop.Size = new Size(1120, 81);
            flpTop.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(btnConfirmar);
            pnlDgv.Controls.Add(label4);
            pnlDgv.Controls.Add(btnRestaurarBackup);
            pnlDgv.Controls.Add(label1);
            pnlDgv.Controls.Add(btnBackup);
            pnlDgv.Controls.Add(label9);
            pnlDgv.Controls.Add(label8);
            pnlDgv.Controls.Add(btnFuncionario);
            pnlDgv.Controls.Add(label7);
            pnlDgv.Controls.Add(btnGerente);
            pnlDgv.Controls.Add(label6);
            pnlDgv.Controls.Add(label5);
            pnlDgv.Controls.Add(tbEmail);
            pnlDgv.Controls.Add(lbContato);
            pnlDgv.Controls.Add(label3);
            pnlDgv.Controls.Add(label2);
            pnlDgv.Controls.Add(lbSuporte);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 81);
            pnlDgv.Margin = new Padding(2);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(10, 9, 10, 9);
            pnlDgv.Size = new Size(1120, 459);
            pnlDgv.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.Transparent;
            btnConfirmar.ForeColor = Color.Transparent;
            btnConfirmar.Image = Properties.Resources.verification_symbol_outline_svgrepo_com;
            btnConfirmar.Location = new Point(487, 51);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(60, 40);
            btnConfirmar.TabIndex = 16;
            btnConfirmar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(639, 100);
            label4.Name = "label4";
            label4.Size = new Size(303, 20);
            label4.TabIndex = 15;
            label4.Text = "Atualizar o banco de dados por um backup?";
            // 
            // btnRestaurarBackup
            // 
            btnRestaurarBackup.BackColor = Color.Transparent;
            btnRestaurarBackup.ForeColor = Color.Transparent;
            btnRestaurarBackup.Image = Properties.Resources.pasta;
            btnRestaurarBackup.ImageAlign = ContentAlignment.TopLeft;
            btnRestaurarBackup.Location = new Point(948, 100);
            btnRestaurarBackup.Name = "btnRestaurarBackup";
            btnRestaurarBackup.Size = new Size(31, 23);
            btnRestaurarBackup.TabIndex = 14;
            btnRestaurarBackup.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRestaurarBackup.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(639, 289);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 13;
            label1.Text = "Suporte";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.Transparent;
            btnBackup.ForeColor = Color.Transparent;
            btnBackup.Image = Properties.Resources.pasta;
            btnBackup.ImageAlign = ContentAlignment.TopLeft;
            btnBackup.Location = new Point(1026, 57);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(31, 23);
            btnBackup.TabIndex = 12;
            btnBackup.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBackup.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(639, 56);
            label9.Name = "label9";
            label9.Size = new Size(381, 20);
            label9.TabIndex = 11;
            label9.Text = "Qual local será guardado o backup do banco de dados?";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(639, 9);
            label8.Name = "label8";
            label8.Size = new Size(200, 25);
            label8.TabIndex = 10;
            label8.Text = "Configurações Backup";
            // 
            // btnFuncionario
            // 
            btnFuncionario.CheckButton = false;
            btnFuncionario.Checked = false;
            btnFuncionario.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnFuncionario.CheckedForeColor = Color.White;
            btnFuncionario.CheckedImageTint = Color.White;
            btnFuncionario.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnFuncionario.Content = "Alterar senha funcionário";
            btnFuncionario.DialogResult = DialogResult.None;
            btnFuncionario.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnFuncionario.ForeColor = Color.Black;
            btnFuncionario.HoverBackground = Color.White;
            btnFuncionario.HoverForeColor = Color.Black;
            btnFuncionario.HoverImageTint = Color.White;
            btnFuncionario.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFuncionario.Image = null;
            btnFuncionario.ImageAutoCenter = true;
            btnFuncionario.ImageExpand = new Point(0, 0);
            btnFuncionario.ImageOffset = new Point(0, 0);
            btnFuncionario.Location = new Point(281, 179);
            btnFuncionario.Name = "btnFuncionario";
            btnFuncionario.NormalBackground = Color.White;
            btnFuncionario.NormalForeColor = Color.Black;
            btnFuncionario.NormalImageTint = Color.White;
            btnFuncionario.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnFuncionario.OutlineThickness = 1F;
            btnFuncionario.PressedBackground = Color.WhiteSmoke;
            btnFuncionario.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnFuncionario.PressedImageTint = Color.White;
            btnFuncionario.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFuncionario.Rounding = new Padding(8);
            btnFuncionario.Size = new Size(153, 45);
            btnFuncionario.TabIndex = 9;
            btnFuncionario.TextAlignment = StringAlignment.Center;
            btnFuncionario.TextOffset = new Point(0, 0);
            btnFuncionario.Click += btnFuncionario_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(12, 190);
            label7.Name = "label7";
            label7.Size = new Size(263, 20);
            label7.TabIndex = 8;
            label7.Text = "Alterar senha do perfil do Funcionário:";
            // 
            // btnGerente
            // 
            btnGerente.CheckButton = false;
            btnGerente.Checked = false;
            btnGerente.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGerente.CheckedForeColor = Color.White;
            btnGerente.CheckedImageTint = Color.White;
            btnGerente.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGerente.Content = "Alterar senha gerente";
            btnGerente.DialogResult = DialogResult.None;
            btnGerente.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnGerente.ForeColor = Color.Black;
            btnGerente.HoverBackground = Color.White;
            btnGerente.HoverForeColor = Color.Black;
            btnGerente.HoverImageTint = Color.White;
            btnGerente.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGerente.Image = null;
            btnGerente.ImageAutoCenter = true;
            btnGerente.ImageExpand = new Point(0, 0);
            btnGerente.ImageOffset = new Point(0, 0);
            btnGerente.Location = new Point(246, 100);
            btnGerente.Name = "btnGerente";
            btnGerente.NormalBackground = Color.White;
            btnGerente.NormalForeColor = Color.Black;
            btnGerente.NormalImageTint = Color.White;
            btnGerente.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerente.OutlineThickness = 1F;
            btnGerente.PressedBackground = Color.WhiteSmoke;
            btnGerente.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnGerente.PressedImageTint = Color.White;
            btnGerente.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGerente.Rounding = new Padding(8);
            btnGerente.Size = new Size(153, 45);
            btnGerente.TabIndex = 7;
            btnGerente.TextAlignment = StringAlignment.Center;
            btnGerente.TextOffset = new Point(0, 0);
            btnGerente.Click += btnGerente_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(12, 114);
            label6.Name = "label6";
            label6.Size = new Size(215, 20);
            label6.TabIndex = 6;
            label6.Text = "Alterar senha do perfil gerente:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(13, 9);
            label5.Name = "label5";
            label5.Size = new Size(230, 25);
            label5.TabIndex = 5;
            label5.Text = "Configurações de Usuário";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(246, 57);
            tbEmail.MaxLength = 100;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(214, 23);
            tbEmail.TabIndex = 4;
            // 
            // lbContato
            // 
            lbContato.AutoSize = true;
            lbContato.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbContato.ForeColor = SystemColors.ButtonFace;
            lbContato.Location = new Point(12, 60);
            lbContato.Name = "lbContato";
            lbContato.Size = new Size(228, 20);
            lbContato.TabIndex = 3;
            lbContato.Text = "Cadastro de e-mail para contato:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(639, 338);
            label3.Name = "label3";
            label3.Size = new Size(395, 20);
            label3.TabIndex = 2;
            label3.Text = "Em caso de dúvidas ou necessidade de assistência técnica,";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(639, 358);
            label2.Name = "label2";
            label2.Size = new Size(445, 20);
            label2.TabIndex = 1;
            label2.Text = "entre em contato com nossa equipe de suporte através do e-mail:";
            // 
            // lbSuporte
            // 
            lbSuporte.AutoSize = true;
            lbSuporte.Cursor = Cursors.Hand;
            lbSuporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lbSuporte.ForeColor = Color.RoyalBlue;
            lbSuporte.Location = new Point(639, 387);
            lbSuporte.Name = "lbSuporte";
            lbSuporte.Size = new Size(222, 21);
            lbSuporte.TabIndex = 0;
            lbSuporte.Text = "telebip.suporte@gmail.com";
            lbSuporte.Click += lbSuporte_Click;
            // 
            // FormConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1120, 540);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(flpTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfiguracoes";
            Text = "FormConfiguracoes";
            pnlDgv.ResumeLayout(false);
            pnlDgv.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTop;
        private Panel pnlDgv;
        private Label lbSuporte;
        private Label label3;
        private Label label2;
        private TextBox tbEmail;
        private Label lbContato;
        private Label label5;
        private Label label6;
        private CuoreUI.Controls.cuiButton btnFuncionario;
        private Label label7;
        private CuoreUI.Controls.cuiButton btnGerente;
        private Label label9;
        private Label label8;
        private Button btnBackup;
        private Label label1;
        private Label label4;
        private Button btnRestaurarBackup;
        private Button btnConfirmar;
    }
}