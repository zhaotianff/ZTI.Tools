using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTI.Tools.WPF.Definitions;

namespace ZTI.Tools.WPF
{
    public static class Mouse
    {
        public static void OnMouseClick<T>(Action<T> action) where T : class,new()
        {

        }

        public static void SetCursor(string cursorFile)
        {
            if (System.IO.File.Exists(cursorFile) == false)
                return;

            foreach(System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                window.Cursor = new System.Windows.Input.Cursor(cursorFile);
            }
        }

        public static void SetSystemCursor(OCR_TYPE oCR_TYPE, string cursorFile)
        {

        }
    }
}
