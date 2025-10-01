namespace telebip_erp.Forms.Auth
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbPesquisa = new ReaLTaiizor.Controls.DungeonTextBox();
            dungeonTextBox1 = new ReaLTaiizor.Controls.DungeonTextBox();
            btnPesquisar = new ReaLTaiizor.Controls.AloneButton();
            SuspendLayout();
            // 
            // tbPesquisa
            // 
            tbPesquisa.BackColor = Color.Transparent;
            tbPesquisa.BorderColor = Color.FromArgb(180, 180, 180);
            tbPesquisa.EdgeColor = Color.White;
            tbPesquisa.Font = new Font("Tahoma", 11F);
            tbPesquisa.ForeColor = Color.DimGray;
            tbPesquisa.Location = new Point(46, 52);
            tbPesquisa.Margin = new Padding(3, 3, 10, 3);
            tbPesquisa.MaxLength = 32767;
            tbPesquisa.Multiline = false;
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.ReadOnly = false;
            tbPesquisa.Size = new Size(270, 28);
            tbPesquisa.TabIndex = 24;
            tbPesquisa.Text = "Nome";
            tbPesquisa.TextAlignment = HorizontalAlignment.Left;
            tbPesquisa.UseSystemPasswordChar = false;
            // 
            // dungeonTextBox1
            // 
            dungeonTextBox1.BackColor = Color.Transparent;
            dungeonTextBox1.BorderColor = Color.FromArgb(180, 180, 180);
            dungeonTextBox1.EdgeColor = Color.White;
            dungeonTextBox1.Font = new Font("Tahoma", 11F);
            dungeonTextBox1.ForeColor = Color.DimGray;
            dungeonTextBox1.Location = new Point(46, 100);
            dungeonTextBox1.Margin = new Padding(3, 3, 10, 3);
            dungeonTextBox1.MaxLength = 32767;
            dungeonTextBox1.Multiline = false;
            dungeonTextBox1.Name = "dungeonTextBox1";
            dungeonTextBox1.ReadOnly = false;
            dungeonTextBox1.Size = new Size(270, 28);
            dungeonTextBox1.TabIndex = 25;
            dungeonTextBox1.Text = "Senha";
            dungeonTextBox1.TextAlignment = HorizontalAlignment.Left;
            dungeonTextBox1.UseSystemPasswordChar = false;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.Transparent;
            btnPesquisar.EnabledCalc = true;
            btnPesquisar.Font = new Font("Segoe UI", 9.75F);
            btnPesquisar.ForeColor = Color.Black;
            btnPesquisar.Location = new Point(46, 146);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(270, 44);
            btnPesquisar.TabIndex = 26;
            btnPesquisar.Text = "Entrar";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 24, 29);
            ClientSize = new Size(391, 226);
            Controls.Add(btnPesquisar);
            Controls.Add(dungeonTextBox1);
            Controls.Add(tbPesquisa);
            FormStyle = FormStyles.ActionBar_None;
            Name = "FormLogin";
            Padding = new Padding(3, 24, 3, 3);
            Text = "FormLogin";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.DungeonTextBox tbPesquisa;
        private ReaLTaiizor.Controls.DungeonTextBox dungeonTextBox1;
        private ReaLTaiizor.Controls.AloneButton btnPesquisar;
    }
}