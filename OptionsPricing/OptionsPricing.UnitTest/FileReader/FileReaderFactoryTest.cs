using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using System;

namespace OptionsPricing.UnitTest.FileReader
{
    [TestClass]
    [TestCategory("File Readers")]
    public class FileReaderFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedFileReaderException))]
        public void Must_Throws_Exception_When_File_Reader_Is_Not_Implemented()
        {
            IFileReader reader = FileReaderFactory.GetReader((FileReaderTypeEnum)99);
        }

        [TestMethod]
        [DataRow(FileReaderTypeEnum.Csv, typeof(FileReaderCsv), DisplayName = "File_Reader_Must_Be_Csv")]
        [DataRow(FileReaderTypeEnum.Xml, typeof(FileReaderXml), DisplayName = "File_Reader_Must_Be_Xml")]
        public void Must_Return_Specified_File_Reader(FileReaderTypeEnum fileReaderTypeEnum, Type type)
        {
            IFileReader reader = FileReaderFactory.GetReader(fileReaderTypeEnum);
            Assert.IsInstanceOfType(reader, type);
        }
    }
}
