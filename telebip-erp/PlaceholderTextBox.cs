using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace telebip_erp.Controls
{
    public class PlaceholderTextBox : TextBox
    {
        // P/ single-line (Win32 cue banner)
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        private const int WM_PAINT = 0x000F;

        private string _placeholder;
        private Color _placeholderColor = Color.FromArgb(160, 160, 160);

        [Category("Appearance")]
        [Description("Texto do placeholder exibido quando o campo está vazio.")]
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                ApplyPlaceholder();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Cor do placeholder (apenas usada para desenho manual em multiline).")]
        public Color PlaceholderColor
        {
            get => _placeholderColor;
            set
            {
                _placeholderColor = value;
                Invalidate();
            }
        }

        public PlaceholderTextBox()
        {
            // Redesenhar quando texto/estado mudar
            this.TextChanged += (s, e) => Invalidate();
            this.LostFocus += (s, e) => Invalidate();
            this.GotFocus += (s, e) => Invalidate();
            this.FontChanged += (s, e) => Invalidate();
            this.SizeChanged += (s, e) => Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyPlaceholder();
        }

        private void ApplyPlaceholder()
        {
            // Tenta aplicar a mensagem nativa (funciona bem para single-line)
            if (IsHandleCreated && !this.Multiline)
            {
                try
                {
                    SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, _placeholder ?? string.Empty);
                    return;
                }
                catch
                {
                    // se falhar, caímos para o desenho manual abaixo
                }
            }

            // para multiline (ou se a mensagem nativa falhar) apenas invalida para desenhar no WM_PAINT
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Depois do paint nativo, desenha o placeholder se for multiline e estiver vazio
            if (m.Msg == WM_PAINT)
            {
                if (!string.IsNullOrEmpty(_placeholder) && string.IsNullOrEmpty(this.Text) && !this.Focused)
                {
                    // Só desenhar para multiline ou caso a mensagem nativa não tenha sido usada
                    if (this.Multiline || !TryNativeCueBanner())
                    {
                        using (Graphics g = Graphics.FromHwnd(this.Handle))
                        {
                            Rectangle r = this.ClientRectangle;
                            // ajustar padding para alinhar como um TextBox comum
                            int leftPadding = this.Margin.Left + 1;
                            int topPadding = this.Padding.Top + 1;
                            r.Offset(2, 1);
                            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak;
                            // Para single-line é melhor truncar em uma linha
                            if (!this.Multiline) flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis;
                            TextRenderer.DrawText(g, _placeholder, this.Font, r, _placeholderColor, flags);
                        }
                    }
                }
            }
        }

        private bool TryNativeCueBanner()
        {
            // heurística: se control não é multiline e tem handle, assume que EM_SETCUEBANNER foi aplicado
            return IsHandleCreated && !this.Multiline;
        }

        // Garantir que o placeholder seja repintado em mudanças do texto via código
        public new string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
    }
}
