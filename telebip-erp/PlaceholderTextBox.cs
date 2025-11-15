using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class PlaceholderTextBox : TextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private string _placeholder;
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                if (IsHandleCreated)
                    SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, _placeholder);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, _placeholder);
        }
    }
}
