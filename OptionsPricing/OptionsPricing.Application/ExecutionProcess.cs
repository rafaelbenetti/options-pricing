using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace OptionsPricing.Application
{
    public class ExecutionProcess
    {
        private const string PathFile = @"OptionsPricing.UnitTest\\Mock\\Files\\BlackScholesModel";

        public void Execute()
        {
            string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\")), PathFile);

            IFileReader readerCsv = FileReaderFactory.GetReader(FileReaderTypeEnum.Csv);
            List<BlackScholesInput> blackScholesInputCsv = readerCsv.Read<BlackScholesInput>($"{path}.csv");

            IFileReader readerXml = FileReaderFactory.GetReader(FileReaderTypeEnum.Xml);
            List<BlackScholesInput> blackScholesInputXml = readerXml.Read<BlackScholesInput>($"{path}.xml");

            var blackScholesCalculator = new BlackScholesCalculator();

            foreach (BlackScholesInput blackScholesInput in blackScholesInputCsv)
            {
                double result = blackScholesCalculator.CalculateFor(blackScholesInput);
                Console.ReadKey();
            }            
        }
    }
}
