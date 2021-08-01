using System;
using System.Collections.Generic;
using System.Text;

namespace ZTI.Tools
{
    public class File
    {
        public void Rename(string filePath,string name)
        {
            var newFilePath = System.Text.RegularExpressions.Regex.Replace()
            System.IO.File.Move(filePath, System.Text.RegularExpressions.Regex.Replace(System.IO.Path.GetFileName(filePath),""));
        }
    }
}
