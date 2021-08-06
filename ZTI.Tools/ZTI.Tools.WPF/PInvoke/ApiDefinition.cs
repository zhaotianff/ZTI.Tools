using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTI.Tools.WPF.PInvoke
{
    public class ApiDefinition
    {
        public delegate long GetMsgProc(int code, IntPtr wParam, IntPtr lParam);
    }
}
