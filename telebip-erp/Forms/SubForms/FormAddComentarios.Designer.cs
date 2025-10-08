namespace telebip_erp.Forms.SubForms
{
    partial class FormAddComentarios
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitulo = new Label();
            lblCategoria = new Label();
            cbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            txtComentario = new Guna.UI2.WinForms.Guna2TextBox();
            lblDuracao = new Label();
            cbDuracao = new Guna.UI2.WinForms.Guna2ComboBox();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(196, 33);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(159, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Adicionar Comentario";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.BackColor = Color.Transparent;
            lblCategoria.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.White;
            lblCategoria.Location = new Point(14, 33);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(75, 20);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoria";
            // 
            // cbCategoria
            // 
            cbCategoria.BackColor = Color.Transparent;
            cbCategoria.CustomizableEdges = customizableEdges1;
            cbCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FillColor = Color.FromArgb(25, 26, 38);
            cbCategoria.FocusedColor = Color.FromArgb(94, 148, 255);
            cbCategoria.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbCategoria.Font = new Font("Segoe UI", 10F);
            cbCategoria.ForeColor = Color.White;
            cbCategoria.ItemHeight = 30;
            cbCategoria.Items.AddRange(new object[] { "Diario", "Estoque", "Aviso" });
            cbCategoria.Location = new Point(12, 56);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbCategoria.Size = new Size(166, 36);
            cbCategoria.TabIndex = 2;
            // 
            // txtComentario
            // 
            txtComentario.CustomizableEdges = customizableEdges3;
            txtComentario.DefaultText = "";
            txtComentario.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtComentario.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtComentario.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtComentario.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtComentario.FillColor = Color.FromArgb(25, 26, 38);
            txtComentario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtComentario.Font = new Font("Segoe UI", 9F);
            txtComentario.ForeColor = Color.White;
            txtComentario.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtComentario.Location = new Point(196, 56);
            txtComentario.Multiline = true;
            txtComentario.Name = "txtComentario";
            txtComentario.PlaceholderText = "Digite seu comentário...";
            txtComentario.SelectedText = "";
            txtComentario.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtComentario.Size = new Size(200, 112);
            txtComentario.TabIndex = 4;
            // 
            // lblDuracao
            // 
            lblDuracao.AutoSize = true;
            lblDuracao.BackColor = Color.Transparent;
            lblDuracao.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDuracao.ForeColor = Color.White;
            lblDuracao.Location = new Point(12, 109);
            lblDuracao.Name = "lblDuracao";
            lblDuracao.Size = new Size(67, 20);
            lblDuracao.TabIndex = 5;
            lblDuracao.Text = "Duração";
            // 
            // cbDuracao
            // 
            cbDuracao.BackColor = Color.Transparent;
            cbDuracao.CustomizableEdges = customizableEdges5;
            cbDuracao.DrawMode = DrawMode.OwnerDrawFixed;
            cbDuracao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDuracao.FillColor = Color.FromArgb(25, 26, 38);
            cbDuracao.FocusedColor = Color.FromArgb(94, 148, 255);
            cbDuracao.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbDuracao.Font = new Font("Segoe UI", 10F);
            cbDuracao.ForeColor = Color.White;
            cbDuracao.ItemHeight = 30;
            cbDuracao.Items.AddRange(new object[] { "1 dia", "3 dias", "7 dias" });
            cbDuracao.Location = new Point(12, 132);
            cbDuracao.Name = "cbDuracao";
            cbDuracao.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbDuracao.Size = new Size(166, 36);
            cbDuracao.TabIndex = 6;
            // 
            // btnConfirmar
            // 
            btnConfirmar.CustomizableEdges = customizableEdges7;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.Lime;
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.Black;
            btnConfirmar.Location = new Point(68, 183);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnConfirmar.Size = new Size(113, 45);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Confirmar";
            // 
            // btnCancelar
            // 
            btnCancelar.CustomizableEdges = customizableEdges9;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.Red;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(196, 183);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnCancelar.Size = new Size(113, 45);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            // 
            // FormAddComentarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 39);
            ClientSize = new Size(409, 243);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(cbDuracao);
            Controls.Add(lblDuracao);
            Controls.Add(txtComentario);
            Controls.Add(cbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(lblTitulo);
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAddComentarios";
            Padding = new Padding(3, 24, 3, 3);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Comentário";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtComentario;
        private Label lblDuracao;
        private Guna.UI2.WinForms.Guna2ComboBox cbDuracao;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}