using System;
using System.Diagnostics;

namespace telebip_erp.Forms.Auth
{
    public static class Debug
    {
        public static void WriteLine(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
        }
    }
}