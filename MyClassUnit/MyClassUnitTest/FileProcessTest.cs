using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassUnit;
using System;
using System.Configuration;
using System.IO;

namespace MyClassUnitTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string FILE_NAME_ERROR = @"C:\teste.txt";
        private string _FileNameSuccess;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            SetFileNameSuccess();
            TestContext.WriteLine($"Creating File: {_FileNameSuccess}");
            File.AppendAllText(_FileNameSuccess, "Some Text");
            TestContext.WriteLine($"Testing File: {_FileNameSuccess}");
            fromCall = fp.FileExists(_FileNameSuccess);
            TestContext.WriteLine($"Deleting File: {_FileNameSuccess}");
            File.Delete(_FileNameSuccess);
            Assert.IsTrue(fromCall);
        }

        public void SetFileNameSuccess()
        {
            _FileNameSuccess = ConfigurationManager.AppSettings["FileNameSuccess"];

            if (_FileNameSuccess.Contains("[AppPath]"))
            {
                _FileNameSuccess = _FileNameSuccess.Replace("[AppPath]", 
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(FILE_NAME_ERROR);
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
    }
}
