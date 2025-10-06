namespace telebip_erp.Forms.Main
{
    partial class FormInicial
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
            pnlContainer = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            tlpFooter = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            tlpTitulos = new TableLayoutPanel();
            pnlTop01 = new Panel();
            label2 = new Label();
            pnlTop02 = new Panel();
            label3 = new Label();
            pnlTop03 = new Panel();
            label4 = new Label();
            pnlHeader = new Panel();
            lblDate = new Label();
            label1 = new Label();
            pnlContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tlpFooter.SuspendLayout();
            tlpTitulos.SuspendLayout();
            pnlTop01.SuspendLayout();
            pnlTop02.SuspendLayout();
            pnlTop03.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tableLayoutPanel1);
            pnlContainer.Controls.Add(tlpFooter);
            pnlContainer.Controls.Add(tlpTitulos);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1626, 773);
            pnlContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 2, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 148);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1626, 567);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(544, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(535, 561);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(1085, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(538, 561);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(535, 561);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // tlpFooter
            // 
            tlpFooter.ColumnCount = 4;
            tlpFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.23096F));
            tlpFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7076168F));
            tlpFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6461926F));
            tlpFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.41523F));
            tlpFooter.Controls.Add(button1, 1, 0);
            tlpFooter.Controls.Add(button2, 2, 0);
            tlpFooter.Dock = DockStyle.Bottom;
            tlpFooter.Location = new Point(0, 715);
            tlpFooter.Name = "tlpFooter";
            tlpFooter.RowCount = 1;
            tlpFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFooter.Size = new Size(1626, 58);
            tlpFooter.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(32, 33, 39);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(548, 8);
            button1.Margin = new Padding(8);
            button1.Name = "button1";
            button1.Size = new Size(255, 42);
            button1.TabIndex = 0;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(32, 33, 39);
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.White;
            button2.Location = new Point(819, 8);
            button2.Margin = new Padding(8);
            button2.Name = "button2";
            button2.Size = new Size(254, 42);
            button2.TabIndex = 1;
            button2.Text = "Remover";
            button2.UseVisualStyleBackColor = false;
            // 
            // tlpTitulos
            // 
            tlpTitulos.ColumnCount = 3;
            tlpTitulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpTitulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpTitulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpTitulos.Controls.Add(pnlTop01, 0, 0);
            tlpTitulos.Controls.Add(pnlTop02, 1, 0);
            tlpTitulos.Controls.Add(pnlTop03, 2, 0);
            tlpTitulos.Dock = DockStyle.Top;
            tlpTitulos.Location = new Point(0, 99);
            tlpTitulos.Name = "tlpTitulos";
            tlpTitulos.RowCount = 1;
            tlpTitulos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTitulos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpTitulos.Size = new Size(1626, 49);
            tlpTitulos.TabIndex = 2;
            // 
            // pnlTop01
            // 
            pnlTop01.Controls.Add(label2);
            pnlTop01.Dock = DockStyle.Fill;
            pnlTop01.Location = new Point(3, 3);
            pnlTop01.Name = "pnlTop01";
            pnlTop01.Size = new Size(536, 43);
            pnlTop01.TabIndex = 0;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(536, 43);
            label2.TabIndex = 0;
            label2.Text = "Comentarios Diarios";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTop02
            // 
            pnlTop02.Controls.Add(label3);
            pnlTop02.Dock = DockStyle.Fill;
            pnlTop02.Location = new Point(545, 3);
            pnlTop02.Name = "pnlTop02";
            pnlTop02.Size = new Size(536, 43);
            pnlTop02.TabIndex = 1;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(536, 43);
            label3.TabIndex = 1;
            label3.Text = "Avisos Estoque";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTop03
            // 
            pnlTop03.Controls.Add(label4);
            pnlTop03.Dock = DockStyle.Fill;
            pnlTop03.Location = new Point(1087, 3);
            pnlTop03.Name = "pnlTop03";
            pnlTop03.Size = new Size(536, 43);
            pnlTop03.TabIndex = 2;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(536, 43);
            label4.TabIndex = 2;
            label4.Text = "Avisos Semanais";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1626, 99);
            pnlHeader.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(6, 49);
            lblDate.Margin = new Padding(20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(239, 40);
            lblDate.TabIndex = 1;
            lblDate.Text = "Carregando Data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Margin = new Padding(20);
            label1.Name = "label1";
            label1.Size = new Size(331, 50);
            label1.TabIndex = 0;
            label1.Text = "Telebip Organizer";
            // 
            // FormInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 29, 40);
            ClientSize = new Size(1626, 773);
            ControlBox = false;
            Controls.Add(pnlContainer);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInicial";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "FormInicial";
            Load += fomInicialLoad;
            pnlContainer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tlpFooter.ResumeLayout(false);
            tlpTitulos.ResumeLayout(false);
            pnlTop01.ResumeLayout(false);
            pnlTop02.ResumeLayout(false);
            pnlTop03.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlHeader;
        private TableLayoutPanel tlpTitulos;
        private Panel pnlTop01;
        private Label label2;
        private Label lblDate;
        private Label label1;
        private Panel pnlTop02;
        private Label label3;
        private Panel pnlTop03;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private TableLayoutPanel tlpFooter;
        private Button button1;
        private Button button2;
    }
}