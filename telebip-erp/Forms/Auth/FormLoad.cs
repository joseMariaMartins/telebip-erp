using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace telebip_erp.Forms.Auth
{
    public partial class FormLoad : MaterialForm
    {
        public FormLoad()
        {
            this.Load += FormLoad_Load;
            this.Shown += FormLoad_Shown;
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            // Cursor de carregando enquanto o formulário inicializa
            this.Cursor = Cursors.WaitCursor;
        }

        private void FormLoad_Shown(object sender, EventArgs e)
        {
            // Quando o formulário já apareceu totalmente, volta ao cursor normal
            this.Cursor = Cursors.Default;
        }
    }
}
