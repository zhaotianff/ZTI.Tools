using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTI.Tools.WPF.PInvoke
{
    public class ApiDefinition
    {
        #region Windows messages
        public const int WM_MOUSE_LL = 14;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_MBUTTONUP = 0x208;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_MBUTTONDBLCLK = 0x209;
        public const int WM_MOUSEWHEEL = 0x020A;
        #endregion

        #region WindowsLong
        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        public const int GWL_EXSTYLE = -20;

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        public const int GWL_HINSTANCE =-6;

        /// <summary>
        /// Retrieves a handle to the parent window, if any.
        /// </summary>
        public const int GWL_HWNDPARENT = -8;

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        public const int GWL_ID = -12;

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        public const int GWL_STYLE = -16;

        /// <summary>
        /// Retrieves the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.
        /// </summary>
        public const int GWL_USERDATA = -21;

        /// <summary>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the CallWindowProc function to call the window procedure.
        /// </summary>
        public const int GWL_WNDPROC = -4;

        #endregion

        #region Extended Style
        public const long WS_EX_DLGMODALFRAME = 0x00000001L;
        public const long WS_EX_NOPARENTNOTIFY = 0x00000004L;
        public const long WS_EX_TOPMOST = 0x00000008L;
        public const long WS_EX_ACCEPTFILES = 0x00000010L;
        public const long WS_EX_TRANSPARENT = 0x00000020L;
        public const long WS_EX_MDICHILD = 0x00000040L;
        public const long WS_EX_TOOLWINDOW = 0x00000080L;
        public const long WS_EX_WINDOWEDGE = 0x00000100L;
        public const long WS_EX_CLIENTEDGE = 0x00000200L;
        public const long WS_EX_CONTEXTHELP = 0x00000400L;
        public const long WS_EX_RIGHT = 0x00001000L;
        public const long WS_EX_LEFT = 0x00000000L;
        public const long WS_EX_RTLREADING = 0x00002000L;
        public const long WS_EX_LTRREADING = 0x00000000L;
        public const long WS_EX_LEFTSCROLLBAR = 0x00004000L;
        public const long WS_EX_RIGHTSCROLLBAR = 0x00000000L;
        public const long WS_EX_CONTROLPARENT = 0x00010000L;
        public const long WS_EX_STATICEDGE = 0x00020000L;
        public const long WS_EX_APPWINDOW = 0x00040000L;
        public const long WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        public const long WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        public const int WS_EX_LAYERED = 0x00080000;
#endregion

        public delegate int GetMsgProc(int code, int wParam, IntPtr lParam);

        public struct POINT
        {
            public int x;
            public int y;
        }

        public struct MouseHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public enum MouseEventType : uint
        {
            MOUSEEVENTF_MOVE = 0x0001, /* mouse move */
            MOUSEEVENTF_LEFTDOWN = 0x0002, /* left button down */
            MOUSEEVENTF_LEFTUP = 0x0004, /* left button up */
            MOUSEEVENTF_RIGHTDOWN = 0x0008, /* right button down */
            MOUSEEVENTF_RIGHTUP = 0x0010, /* right button up */
            MOUSEEVENTF_MIDDLEDOWN = 0x0020, /* middle button down */
            MOUSEEVENTF_MIDDLEUP = 0x0040, /* middle button up */
            MOUSEEVENTF_XDOWN = 0x0080, /* x button down */
            MOUSEEVENTF_XUP = 0x0100, /* x button down */
            MOUSEEVENTF_WHEEL = 0x0800, /* wheel button rolled */
        }

        public struct tagINPUT
        {
            int type;         
            int dx;
            int dy;
            int mouseData;
            MouseEventType dwFlags;
            uint time;
            UIntPtr dwExtraInfo;        
        }
    }
}
