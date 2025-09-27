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
            pnlTop = new Panel();
            pnlDgv = new Panel();
            dgvVendas = new DataGridView();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVendas).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(4, 5, 4, 5);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1946, 135);
            pnlTop.TabIndex = 3;
            // 
            // pnlDgv
            // 
            pnlDgv.BackColor = Color.Transparent;
            pnlDgv.Controls.Add(dgvVendas);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 135);
            pnlDgv.Margin = new Padding(4, 5, 4, 5);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1946, 971);
            pnlDgv.TabIndex = 4;
            // 
            // dgvVendas
            // 
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.Location = new Point(15, 15);
            dgvVendas.Margin = new Padding(4, 5, 4, 5);
            dgvVendas.Name = "dgvVendas";
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.Size = new Size(1916, 941);
            dgvVendas.TabIndex = 0;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1946, 1106);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVendas";
            Text = "FormVendas";
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVendas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlTop;
        private Panel pnlDgv;
        private DataGridView dgvVendas;
    }
}