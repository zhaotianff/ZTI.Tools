using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZTI.Tools.WPF.Definitions;
using ZTI.Tools.WPF.PInvoke;
using static ZTI.Tools.WPF.PInvoke.ApiDefinition;

namespace ZTI.Tools.WPF
{
    public static class Mouse
    {
        private static IntPtr mouseHanlder = IntPtr.Zero;

        //C:\Windows\Cursors
        private static Dictionary<string, string> systemCursorPathDic = new Dictionary<string, string>()
        {
            ["OCR_APPSTARTING"] = @"C:\Windows\Cursors\aero_working.ani",
            ["OCR_NORMAL"] = @"C:\Windows\Cursors\aero_arrow.cur",
            ["OCR_CROSS"] = @"C:\Windows\Cursors\cross_r.cur",
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


        public static void ResetSystemCursor(OCR_TYPE oCR_TYPE)
        {
            var cursorFile = systemCursorPathDic[oCR_TYPE.ToString()];
            SetSystemCursor(oCR_TYPE, cursorFile);
        }

        public static bool HookMouse()
        {
            if(mouseHanlder == IntPtr.Zero)
            {
                IntPtr hookPtr = Winapi.LoadLibrary(Winapi.USER32);
                mouseHanlder = (IntPtr)Winapi.SetWindowsHookEx(ApiDefinition.WM_MOUSE_LL,MouseHookProcedure, hookPtr, 0);

                if(mouseHanlder == IntPtr.Zero)
                {
                    var error = Winapi.GetLastError();
                    UnhookMouse();
                    return false;
                }

                if(hookPtr != IntPtr.Zero)
                {
                    Winapi.FreeLibrary(hookPtr);
                    hookPtr = IntPtr.Zero;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam">windows message</param>
        /// <param name="lParam">message param</param>
        /// <returns></returns>
        private static int MouseHookProcedure(int nCode, int wParam,IntPtr lParam)
        {
            if(nCode >= 0)
            {
                MouseHookStruct mouseParam = (MouseHookStruct)Marshal.PtrToStructure<MouseHookStruct>(lParam);

                switch(wParam)
                {
                    case WM_MOUSE_LL:
                    case WM_MOUSEMOVE:
                    case WM_LBUTTONDOWN:
                    case WM_RBUTTONDOWN:
                    case WM_MBUTTONDOWN:
                    case WM_LBUTTONUP:
                    case WM_RBUTTONUP:
                    case WM_MBUTTONUP:
                    case WM_LBUTTONDBLCLK:
                    case WM_RBUTTONDBLCLK:
                    case WM_MBUTTONDBLCLK:
                    case WM_MOUSEWHEEL:
                        return 1;
                }
            }
            return 0;
        }

        public static bool UnhookMouse()
        {
            bool result = false;
            if (mouseHanlder != IntPtr.Zero)
            {
                result =  Winapi.UnhookWindowsHookEx(mouseHanlder);
            }
            mouseHanlder = IntPtr.Zero;
            return result;
        }
    }
}
