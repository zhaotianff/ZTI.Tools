using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTI.Tools.WPF.Definitions;
using ZTI.Tools.WPF.PInvoke;

namespace ZTI.Tools.WPF
{
    public static class Mouse
    {
        //C:\Windows\Cursors
        private static Dictionary<string, string> systemCursorPathDic = new Dictionary<string, string>()
        {
            ["OCR_APPSTARTING"] = @"C:\Windows\Cursors\aero_working.ani",
            ["OCR_NORMAL"] = @"C:\Windows\Cursors\aero_arrow.ani",
            ["OCR_CROSS"] = @"C:\Windows\Cursors\cross_r.ani",
            ["OCR_HAND"] = @"C:\Windows\Cursors\aero_link.cur",
            ["OCR_HELP"] = @"C:\Windows\Cursors\aero_helpsel.cur",
            ["OCR_IBEAM"] = @"C:\Windows\Cursors\beam_r.cur",
            ["OCR_NO"] = @"C:\Windows\Cursors\aero_unavail.cur",
            ["OCR_SIZEALL"] = @"C:\Windows\Cursors\aero_move.cur",
            ["OCR_SIZENESW"] = @"C:\Windows\Cursors\aero_nesw.cur",
            ["OCR_SIZENS"] = @"C:\Windows\Cursors\aero_ns.cur",
            ["OCR_SIZENWSE"] = @"C:\Windows\Cursors\aero_nwse.cur",
            ["OCR_SIZEWE"] = @"C:\Windows\Cursors\aero_ew.cur",
            ["OCR_UP"] = @"C:\Windows\Cursors\aero_up.cur",
            ["OCR_WAIT"] = @"C:\Windows\Cursors\aero_busy.ani"
        };

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
            IntPtr hCursor = Winapi.LoadCursorFromFile(cursorFile);

            if(hCursor != IntPtr.Zero)
            {
                Winapi.SetSystemCursor(hCursor, (int)oCR_TYPE);
            }
        }

        /// <summary>
        /// require administrator
        /// </summary>
        /// <param name="oCR_TYPE"></param>
        public static void ResetSystemCursor(OCR_TYPE oCR_TYPE)
        {
            var cursorFile = systemCursorPathDic[oCR_TYPE.ToString()];
            SetSystemCursor(oCR_TYPE, cursorFile);
        }
    }
}
