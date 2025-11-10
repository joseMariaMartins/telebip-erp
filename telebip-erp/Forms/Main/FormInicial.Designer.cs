using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Main
{
    partial class FormInicial
    {
        private IContainer components = null;
        private Panel panelCentral;
        private Label lblWelcome;
        private Label lblAppTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelCentral = new Panel();
            layout = new TableLayoutPanel();
            lblAppTitle = new Label();
            lblWelcome = new Label();
            panelCentral.SuspendLayout();
            layout.SuspendLayout();
            SuspendLayout();
            // 
            // panelCentral
            // 
            panelCentral.AutoSize = true;
            panelCentral.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCentral.BackColor = Color.Transparent;
            panelCentral.Controls.Add(layout);
            panelCentral.Dock = DockStyle.Fill;
            panelCentral.Location = new Point(0, 0);
            panelCentral.Margin = new Padding(0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(969, 600);
            panelCentral.TabIndex = 0;
            // 
            // layout
            // 
            layout.Anchor = AnchorStyles.None;
            layout.AutoSize = true;
            layout.BackColor = Color.Transparent;
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(lblAppTitle, 0, 0);
            layout.Controls.Add(lblWelcome, 0, 1);
            layout.Location = new Point(313, 247);
            layout.Name = "layout";
            layout.RowCount = 2;
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.Size = new Size(345, 100);
            layout.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(3, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Padding = new Padding(0, 0, 0, 10);
            lblAppTitle.Size = new Size(339, 61);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Telebip Organizer";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Segoe UI", 14F);
            lblWelcome.ForeColor = Color.FromArgb(220, 220, 220);
            lblWelcome.Location = new Point(3, 61);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(339, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Seja bem-vindo";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(969, 600);
            Controls.Add(panelCentral);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela Inicial";
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private TableLayoutPanel layout;
    }
}
