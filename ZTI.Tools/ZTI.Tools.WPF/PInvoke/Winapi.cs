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


        [DllImport(USER32)]
        public static extern void SetSystemCursor(IntPtr hcur, int id);
    }
}
