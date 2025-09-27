namespace telebip_erp.Forms.Modules
{
    partial class FormEstoque
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
            flpTop = new FlowLayoutPanel();
            pnlDgv = new Panel();
            dataGridView1 = new DataGridView();
            pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // flpTop
            // 
            flpTop.Dock = DockStyle.Top;
            flpTop.Location = new Point(0, 0);
            flpTop.Name = "flpTop";
            flpTop.Size = new Size(1600, 135);
            flpTop.TabIndex = 0;
            // 
            // pnlDgv
            // 
            pnlDgv.Controls.Add(dataGridView1);
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 135);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(15);
            pnlDgv.Size = new Size(1600, 765);
            pnlDgv.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(15, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1570, 735);
            dataGridView1.TabIndex = 0;
            // 
            // FormEstoque
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 49);
            ClientSize = new Size(1600, 900);
            ControlBox = false;
            Controls.Add(pnlDgv);
            Controls.Add(flpTop);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEstoque";
            Text = "FormEstoque";
            pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTop;
        private Panel pnlDgv;
        private DataGridView dataGridView1;
    }
}