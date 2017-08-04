using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using System;
using System.Collections.Generic;
using System.IO;

namespace OptionsPricing.Presentation
{
    class Program
    {
        private const string PathFile = @"OptionsPricing.UnitTest\\Mock\\Files\\BlackScholesModel";
        
        static void Main(string[] args)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\"));
            path = Path.Combine(path, PathFile);

            IFileReader readerCsv = FileReaderFactory.GetReader(FileReaderTypeEnum.Csv);
            List<BlackScholesInput> investmentsFromCsv = readerCsv.Read<BlackScholesInput>($"{path}.csv");

            IFileReader readerXml = FileReaderFactory.GetReader(FileReaderTypeEnum.Xml);
            List<BlackScholesInput> investmentsFromXml = readerXml.Read<BlackScholesInput>($"{path}.xml");

            Console.ReadKey();            
        }
    }
}
