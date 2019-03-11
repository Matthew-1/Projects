using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace anagrams
{
    public class FileOperations
    {
        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
