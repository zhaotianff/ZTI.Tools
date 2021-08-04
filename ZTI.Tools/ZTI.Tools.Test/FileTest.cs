using ZTI.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZTI.Tools.Test
{
    [TestClass()]
    public class FileTest
    {
        [TestMethod()]
        public void RenameTest()
        {
            var result = File.Rename(@"C:\Users\Dream\Desktop\api-monitor-v2r13-setup-x64.exe", "gg.exe");
            Assert.IsTrue(result);
        }
    }
}
