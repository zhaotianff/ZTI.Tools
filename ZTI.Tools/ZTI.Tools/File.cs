using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ZTI.Tools
{
    public class File
    {
        public static bool Rename(string filePath,string name)
        {
            try
            {
                if (System.IO.File.Exists(filePath) == false)
                    return false;

                var oldFileName = System.IO.Path.GetFileName(filePath);
                var newFileName = "";
                if (name.Contains(".") == false)
                {
                    newFileName = name + System.IO.Path.GetExtension(filePath);
                }
                else
                {
                    newFileName = name;
                }
               
                var newFilePath = filePath.Replace(oldFileName, newFileName);
                System.IO.File.Move(filePath, newFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
