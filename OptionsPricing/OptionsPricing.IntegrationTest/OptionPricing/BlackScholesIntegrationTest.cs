using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OptionsPricing.IntegrationTest.OptionPricing
{
    [TestClass]
    [TestCategory("Black Scholes Model - Integration")]
    public class BlackScholesIntegrationTest
    {
        private const string PathFile = @"OptionsPricing.UnitTest\\Mock\\Files\\BlackScholesModel";
        private string FullPath;

        public BlackScholesIntegrationTest()
        {
            this.FullPath = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\")), PathFile);
        }

        [TestMethod]
        [DataRow(FileReaderTypeEnum.Csv, ".csv")]
        [DataRow(FileReaderTypeEnum.Xml, ".xml")]
        public void Must_Import_Data_And_Calculate_For_Csv(FileReaderTypeEnum fileReaderTypeEnum, string extension)
        {
            IFileReader reader = FileReaderFactory.GetReader(fileReaderTypeEnum);
            List<BlackScholesInput> blackScholesInputData = reader.Read<BlackScholesInput>($"{FullPath}{extension}");

            var optionPricingCalculator = new BlackScholesCalculator();
            List<BlackScholesResult> blackScholesResultData = optionPricingCalculator.CalculateFor(blackScholesInputData);

            List<double> expectedResults =
                new List<double>() { 110, 30, 0, 0, 110, 1.2444594168143162E-196, 110, 0 };

            List<double> results = optionPricingCalculator.CalculateFor(blackScholesInputData).Select(r => r.Result).ToList();

            CollectionAssert.AreEqual(expectedResults, results);
        }
    }
}
