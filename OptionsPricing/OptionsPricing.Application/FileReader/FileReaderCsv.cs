using CsvHelper;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OptionsPricing.Application.FileReader
{
    public class FileReaderCsv : IFileReader
    {
        public List<TReturn> Read<TReturn>(string path)
        {
            using (TextReader fileReader = File.OpenText(path))
            {
                var reader = new CsvReader(fileReader);
                reader.Configuration.RegisterClassMap<BlackScholesInputMap>();
                return reader.GetRecords<TReturn>().ToList();
            }
        }
    }
}
