using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.Main
{
    public partial class FormInicial : FormLoadForm
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private void fomInicialLoad(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
