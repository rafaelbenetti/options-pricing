using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.UnitTest.Const;
using OptionsPricing.UnitTest.Mock;
using System;
using System.Collections.Generic;
using System.IO;

namespace OptionsPricing.UnitTest.FileReader
{

    [TestClass]
    [TestCategory("File Readers")]
    public class FileReaderXmlTest
    {
        private IFileReader _reader;

        public FileReaderXmlTest()
        {
            _reader = FileReaderFactory.GetReader(FileReaderTypeEnum.Csv);
        }

        [TestMethod]
        public void Must_Return_Valid_Results()
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathConst.PathFileCsv);

            List<BlackScholesInput> investments = _reader.Read<BlackScholesInput>(path);
            List<BlackScholesInput> expectedInvestments = GetInputsMock();

            Assert.AreEqual(investments.Count, expectedInvestments.Count);

            // TODO: Overrides Equals to compare objects... 
            // CollectionAssert.AreEqual(investments, expectedInvestments);

            for (int i = 0; i < investments.Count; i++)
            {
                var investment = investments[i];
                var expectedInvestment = expectedInvestments[i];

                Assert.AreEqual(investment.Id, expectedInvestment.Id);
                Assert.AreEqual(investment.Name, expectedInvestment.Name);
                Assert.AreEqual(investment.Type, expectedInvestment.Type);
                Assert.AreEqual(investment.Style, expectedInvestment.Style);
                Assert.AreEqual(investment.Cp, expectedInvestment.Cp);
                Assert.AreEqual(investment.Expiry, expectedInvestment.Expiry);
                Assert.AreEqual(investment.Strike, expectedInvestment.Strike);
                Assert.AreEqual(investment.Ccy, expectedInvestment.Ccy);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Must_Throws_An_Exception_When_File_Not_Found()
        {
            List<BlackScholesInput> investments = _reader.Read<BlackScholesInput>(PathConst.PathInvalid);
        }

        private List<BlackScholesInput> GetInputsMock()
        {
            var reader = new FileReaderMock();
            return reader.GetInvestmentsForCsv();
        }
    }
}
