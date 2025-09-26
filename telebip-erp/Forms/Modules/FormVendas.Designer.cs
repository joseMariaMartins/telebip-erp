namespace telebip_erp.Forms.Modules
{
    partial class FormVendas
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
            dgvVendas = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVendas
            // 
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.Location = new Point(0, 0);
            dgvVendas.Margin = new Padding(4, 5, 4, 5);
            dgvVendas.Name = "dgvVendas";
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.Size = new Size(1119, 663);
            dgvVendas.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvVendas);
            panel1.Location = new Point(12, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(1119, 663);
            panel1.TabIndex = 1;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 24, 29);
            ClientSize = new Size(1143, 750);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVendas";
            Text = "FormVendas";
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvVendas;
        private Panel panel1;
    }
}