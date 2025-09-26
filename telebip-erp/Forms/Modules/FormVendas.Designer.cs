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
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1512, 81);
            pnlTop.TabIndex = 3;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dgvVendas);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 81);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(0, 12, 12, 12);
            pnlDgv.Size = new Size(1512, 655);
            pnlDgv.TabIndex = 4;
            // 
            // dgvVendas
            // 
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendas.Dock = DockStyle.Fill;
            dgvVendas.Location = new Point(0, 12);
            dgvVendas.Name = "dgvVendas";
            dgvVendas.RowHeadersWidth = 62;
            dgvVendas.Size = new Size(1500, 631);
            dgvVendas.TabIndex = 0;
            // 
            // FormVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 24, 29);
            ClientSize = new Size(1512, 736);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
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