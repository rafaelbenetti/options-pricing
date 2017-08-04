using OptionsPricing.Application.FileReader.Base;

namespace OptionsPricing.Application.FileReader
{
    public static class FileReaderFactory
    {
        public static IFileReader GetReader(FileReaderTypeEnum fileReaderTypeEnum)
        {
            if (fileReaderTypeEnum == FileReaderTypeEnum.Csv)
                return new FileReaderCsv();
            else if (fileReaderTypeEnum == FileReaderTypeEnum.Xml)
                return new FileReaderXml();

            throw new NotImplementedFileReaderException();
        }
    }
}

