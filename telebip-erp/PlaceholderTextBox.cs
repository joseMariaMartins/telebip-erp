using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class PlaceholderTextBox : TextBox
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

    private const int EM_SETCUEBANNER = 0x1501;

    private string _placeholder;
    public string Placeholder
    {
        get => _placeholder;
        set
        {
            _placeholder = value;
            if (IsHandleCreated)
                UpdatePlaceholder();
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdatePlaceholder();
    }

    private void UpdatePlaceholder()
    {
        SendMessage(this.Handle, EM_SETCUEBANNER, 0, _placeholder);
    }
}
