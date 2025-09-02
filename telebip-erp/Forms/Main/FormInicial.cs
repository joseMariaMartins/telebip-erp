using System;
using System.Windows.Forms;

namespace telebip_erp.Forms.Main
{
    public partial class FormInicial : FormBase
    {
        public FormInicial()
        {
            InitializeComponent();

            // Exemplo de conteúdo inicial no panelContent
            Label lbl = new Label();
            lbl.Text = "Logo Telebip";
            lbl.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lbl.ForeColor = Color.Gray;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            this.pnlContent.Controls.Add(lbl);
        }
    }
}
