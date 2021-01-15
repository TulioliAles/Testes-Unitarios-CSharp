using System;
using System.IO;

namespace MyClassUnit
{
    class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            return File.Exists(fileName);
        }
    }
}
