using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZTI.Tools.WPF.PInvoke;
using static ZTI.Tools.WPF.PInvoke.ApiDefinition;

namespace ZTI.Tools.WPF
{
    public class Keyboard
    {
        private static IntPtr keyboardHook = IntPtr.Zero;

        public static bool HookKeyboard()
        {
            //TODO 测试
            IntPtr hookPtr = Winapi.LoadLibrary(Winapi.USER32);
            keyboardHook = (IntPtr)Winapi.SetWindowsHookEx(ApiDefinition.WM_MOUSE_LL, KeyHookProcedure, hookPtr, 0);

            if (keyboardHook == IntPtr.Zero)
            {
                var error = Winapi.GetLastError();
                UnhookKeyboard();
                return false;
            }

            if (hookPtr != IntPtr.Zero)
            {
                Winapi.FreeLibrary(hookPtr);
                hookPtr = IntPtr.Zero;
            }

            return true;
        }

        public static int KeyHookProcedure(int nCode,int wParam,IntPtr lParam)
        {
            //键盘附带参数
            tagKEYBDINPUT keyboardHookStruct = (tagKEYBDINPUT)Marshal.PtrToStructure<tagKEYBDINPUT>(lParam);
            if(nCode == ApiDefinition.HC_ACTION)
            {
                switch (wParam)
                {
                    case ApiDefinition.WM_KEYDOWN:
                    case ApiDefinition.WM_KEYUP:
                    case ApiDefinition.WM_SYSKEYDOWN:
                    case ApiDefinition.WM_SYSKEYUP:
                        //屏蔽Windows键
                        if (keyboardHookStruct.wVk == ApiDefinition.VK_LWIN
                            || keyboardHookStruct.wVk == ApiDefinition.VK_RWIN)
                        {
                            return 1;
                        }
                        break;
                }
            }
          
            //1为屏蔽 2为执行
            return 2;
        }

        public static bool UnhookKeyboard()
        {
            return true;
        }
    }
}
