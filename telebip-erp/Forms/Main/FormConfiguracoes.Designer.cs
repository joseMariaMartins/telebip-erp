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
            pnlDgv.Dock = DockStyle.Fill;
            pnlDgv.Location = new Point(0, 81);
            pnlDgv.Margin = new Padding(2);
            pnlDgv.Name = "pnlDgv";
            pnlDgv.Padding = new Padding(10, 9, 10, 9);
            pnlDgv.Size = new Size(1120, 459);
            pnlDgv.TabIndex = 1;
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
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTop;
        private Panel pnlDgv;
    }
}