using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClassUnit;
using System;

namespace MyClassUnitTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(@"C:\teste\teste.txt");
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(@"C:\teste.txt");
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
