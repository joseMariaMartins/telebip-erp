namespace telebip_erp.Forms.SubForms
{
    partial class FormAddVendas
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
            btnPesquisar = new ReaLTaiizor.Controls.AloneButton();
            dungeonTextBox2 = new ReaLTaiizor.Controls.DungeonTextBox();
            dungeonTextBox1 = new ReaLTaiizor.Controls.DungeonTextBox();
            tbPesquisa = new ReaLTaiizor.Controls.DungeonTextBox();
            comboBoxEdit2 = new ReaLTaiizor.Controls.ComboBoxEdit();
            comboBoxEdit1 = new ReaLTaiizor.Controls.ComboBoxEdit();
            cbCondicao = new ReaLTaiizor.Controls.ComboBoxEdit();
            cbPesquisaCampo = new ReaLTaiizor.Controls.ComboBoxEdit();
            SuspendLayout();
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.Transparent;
            btnPesquisar.EnabledCalc = true;
            btnPesquisar.Font = new Font("Segoe UI", 9.75F);
            btnPesquisar.ForeColor = Color.Black;
            btnPesquisar.Location = new Point(18, 389);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(172, 28);
            btnPesquisar.TabIndex = 26;
            btnPesquisar.Text = "Pesquisar";
            // 
            // dungeonTextBox2
            // 
            dungeonTextBox2.BackColor = Color.Transparent;
            dungeonTextBox2.BorderColor = Color.FromArgb(180, 180, 180);
            dungeonTextBox2.EdgeColor = Color.White;
            dungeonTextBox2.Font = new Font("Tahoma", 11F);
            dungeonTextBox2.ForeColor = Color.DimGray;
            dungeonTextBox2.Location = new Point(18, 307);
            dungeonTextBox2.Margin = new Padding(3, 3, 10, 3);
            dungeonTextBox2.MaxLength = 32767;
            dungeonTextBox2.Multiline = false;
            dungeonTextBox2.Name = "dungeonTextBox2";
            dungeonTextBox2.ReadOnly = false;
            dungeonTextBox2.Size = new Size(235, 28);
            dungeonTextBox2.TabIndex = 25;
            dungeonTextBox2.TextAlignment = HorizontalAlignment.Left;
            dungeonTextBox2.UseSystemPasswordChar = false;
            // 
            // dungeonTextBox1
            // 
            dungeonTextBox1.BackColor = Color.Transparent;
            dungeonTextBox1.BorderColor = Color.FromArgb(180, 180, 180);
            dungeonTextBox1.EdgeColor = Color.White;
            dungeonTextBox1.Font = new Font("Tahoma", 11F);
            dungeonTextBox1.ForeColor = Color.DimGray;
            dungeonTextBox1.Location = new Point(18, 257);
            dungeonTextBox1.Margin = new Padding(3, 3, 10, 3);
            dungeonTextBox1.MaxLength = 32767;
            dungeonTextBox1.Multiline = false;
            dungeonTextBox1.Name = "dungeonTextBox1";
            dungeonTextBox1.ReadOnly = false;
            dungeonTextBox1.Size = new Size(235, 28);
            dungeonTextBox1.TabIndex = 24;
            dungeonTextBox1.TextAlignment = HorizontalAlignment.Left;
            dungeonTextBox1.UseSystemPasswordChar = false;
            // 
            // tbPesquisa
            // 
            tbPesquisa.BackColor = Color.Transparent;
            tbPesquisa.BorderColor = Color.FromArgb(180, 180, 180);
            tbPesquisa.EdgeColor = Color.White;
            tbPesquisa.Font = new Font("Tahoma", 11F);
            tbPesquisa.ForeColor = Color.DimGray;
            tbPesquisa.Location = new Point(18, 211);
            tbPesquisa.Margin = new Padding(3, 3, 10, 3);
            tbPesquisa.MaxLength = 32767;
            tbPesquisa.Multiline = false;
            tbPesquisa.Name = "tbPesquisa";
            tbPesquisa.ReadOnly = false;
            tbPesquisa.Size = new Size(235, 28);
            tbPesquisa.TabIndex = 23;
            tbPesquisa.TextAlignment = HorizontalAlignment.Left;
            tbPesquisa.UseSystemPasswordChar = false;
            // 
            // comboBoxEdit2
            // 
            comboBoxEdit2.BackColor = Color.FromArgb(34, 35, 49);
            comboBoxEdit2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxEdit2.DropDownHeight = 100;
            comboBoxEdit2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEdit2.Font = new Font("Segoe UI", 10F);
            comboBoxEdit2.ForeColor = Color.FromArgb(142, 142, 142);
            comboBoxEdit2.FormattingEnabled = true;
            comboBoxEdit2.HoverSelectionColor = Color.Silver;
            comboBoxEdit2.IntegralHeight = false;
            comboBoxEdit2.ItemHeight = 20;
            comboBoxEdit2.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            comboBoxEdit2.Location = new Point(18, 158);
            comboBoxEdit2.Margin = new Padding(3, 3, 10, 3);
            comboBoxEdit2.Name = "comboBoxEdit2";
            comboBoxEdit2.Size = new Size(198, 26);
            comboBoxEdit2.StartIndex = 0;
            comboBoxEdit2.TabIndex = 22;
            // 
            // comboBoxEdit1
            // 
            comboBoxEdit1.BackColor = Color.FromArgb(34, 35, 49);
            comboBoxEdit1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxEdit1.DropDownHeight = 100;
            comboBoxEdit1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEdit1.Font = new Font("Segoe UI", 10F);
            comboBoxEdit1.ForeColor = Color.FromArgb(142, 142, 142);
            comboBoxEdit1.FormattingEnabled = true;
            comboBoxEdit1.HoverSelectionColor = Color.Silver;
            comboBoxEdit1.IntegralHeight = false;
            comboBoxEdit1.ItemHeight = 20;
            comboBoxEdit1.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            comboBoxEdit1.Location = new Point(18, 126);
            comboBoxEdit1.Margin = new Padding(3, 3, 10, 3);
            comboBoxEdit1.Name = "comboBoxEdit1";
            comboBoxEdit1.Size = new Size(198, 26);
            comboBoxEdit1.StartIndex = 0;
            comboBoxEdit1.TabIndex = 21;
            // 
            // cbCondicao
            // 
            cbCondicao.BackColor = Color.FromArgb(34, 35, 49);
            cbCondicao.DrawMode = DrawMode.OwnerDrawFixed;
            cbCondicao.DropDownHeight = 100;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.Font = new Font("Segoe UI", 10F);
            cbCondicao.ForeColor = Color.FromArgb(142, 142, 142);
            cbCondicao.FormattingEnabled = true;
            cbCondicao.HoverSelectionColor = Color.Silver;
            cbCondicao.IntegralHeight = false;
            cbCondicao.ItemHeight = 20;
            cbCondicao.Items.AddRange(new object[] { "Inicia com", "Contendo", "Diferente de" });
            cbCondicao.Location = new Point(18, 85);
            cbCondicao.Margin = new Padding(3, 3, 10, 3);
            cbCondicao.Name = "cbCondicao";
            cbCondicao.Size = new Size(198, 26);
            cbCondicao.StartIndex = 0;
            cbCondicao.TabIndex = 20;
            // 
            // cbPesquisaCampo
            // 
            cbPesquisaCampo.BackColor = Color.FromArgb(34, 35, 49);
            cbPesquisaCampo.DrawMode = DrawMode.OwnerDrawFixed;
            cbPesquisaCampo.DropDownHeight = 100;
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.Font = new Font("Segoe UI", 10F);
            cbPesquisaCampo.ForeColor = Color.FromArgb(142, 142, 142);
            cbPesquisaCampo.FormattingEnabled = true;
            cbPesquisaCampo.HoverSelectionColor = Color.Silver;
            cbPesquisaCampo.IntegralHeight = false;
            cbPesquisaCampo.ItemHeight = 20;
            cbPesquisaCampo.Items.AddRange(new object[] { "ID_Venda", "Nome_Funcionario", "Data_Hora", "Desconto", "Valor_Total" });
            cbPesquisaCampo.Location = new Point(18, 43);
            cbPesquisaCampo.Margin = new Padding(3, 3, 10, 3);
            cbPesquisaCampo.Name = "cbPesquisaCampo";
            cbPesquisaCampo.Size = new Size(198, 26);
            cbPesquisaCampo.StartIndex = 0;
            cbPesquisaCampo.TabIndex = 19;
            // 
            // FormAddVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 23, 29);
            ClientSize = new Size(600, 700);
            Controls.Add(btnPesquisar);
            Controls.Add(dungeonTextBox2);
            Controls.Add(dungeonTextBox1);
            Controls.Add(tbPesquisa);
            Controls.Add(comboBoxEdit2);
            Controls.Add(comboBoxEdit1);
            Controls.Add(cbCondicao);
            Controls.Add(cbPesquisaCampo);
            ForeColor = Color.FromArgb(24, 23, 29);
            FormStyle = FormStyles.ActionBar_None;
            Margin = new Padding(2);
            Name = "FormAddVendas";
            Padding = new Padding(2, 14, 2, 2);
            Text = "FormAddVendas";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.AloneButton btnPesquisar;
        private ReaLTaiizor.Controls.DungeonTextBox dungeonTextBox2;
        private ReaLTaiizor.Controls.DungeonTextBox dungeonTextBox1;
        private ReaLTaiizor.Controls.DungeonTextBox tbPesquisa;
        private ReaLTaiizor.Controls.ComboBoxEdit comboBoxEdit2;
        private ReaLTaiizor.Controls.ComboBoxEdit comboBoxEdit1;
        private ReaLTaiizor.Controls.ComboBoxEdit cbCondicao;
        private ReaLTaiizor.Controls.ComboBoxEdit cbPesquisaCampo;
    }
}