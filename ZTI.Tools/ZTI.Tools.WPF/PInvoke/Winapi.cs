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
        private const string USER32 = "user32.dll";

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
        public static extern int SetWindowHookEx(int hookType, ApiDefinition.GetMsgProc lpfn, IntPtr hmod, int dwThreadId);
    }
}
