using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telebip_erp.Forms.Main
{
    public partial class FormInicial : FormBase
    {
        public FormInicial()
        {
            InitializeComponent();
            HerdarEstilo();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormInicial
            // 
            ClientSize = new Size(1078, 244);
            Name = "FormInicial";
            ResumeLayout(false);

        }
    }
}
