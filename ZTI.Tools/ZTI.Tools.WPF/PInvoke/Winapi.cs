using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ZTI.Tools.WPF.PInvoke
{
    public class Winapi
    {
        public const string USER32 = "user32.dll";
        public const string KERNEL32 = "kernel32.dll";

        #region KERNEL32
        /// <summary>
        /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns></returns>
        [DllImport(KERNEL32)]
        public static extern int GetLastError();

        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpLibFileName"></param>
        /// <returns></returns>
        [DllImport(KERNEL32)]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport(KERNEL32)]
        public static extern bool FreeLibrary(IntPtr hLibModule);
        #endregion

        #region USER32
        /// <summary>
        /// Creates a cursor based on data contained in a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [DllImport(USER32)]
        public static extern IntPtr LoadCursorFromFile(string fileName);


        /// <summary>
        /// Enables an application to customize the system cursors. It replaces the contents of the system cursor specified by the id parameter with the contents of the cursor specified by the hcur parameter and then destroys hcur.
        /// </summary>
        /// <param name="hcur"></param>
        /// <param name="id"></param>
        [DllImport(USER32)]
        public static extern void SetSystemCursor(IntPtr hcur, int id);

        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. 
        /// You would install a hook procedure to monitor the system for certain types of events. 
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int hookType, ApiDefinition.GetMsgProc lpfn, IntPtr hmod, int dwThreadId);

        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        /// <summary>
        /// Defines a system-wide hot key.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// Frees a hot key previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Displays or hides the cursor.
        /// </summary>
        /// <param name="bShow"></param>
        /// <returns></returns>

        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ShowCursor(bool bShow);

        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern uint SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport(USER32, CallingConvention = CallingConvention.StdCall)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
        #endregion
    }
}
