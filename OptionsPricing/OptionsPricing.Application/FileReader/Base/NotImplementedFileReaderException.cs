using OptionsPricing.Infrastructure.Resources;
using System;

namespace OptionsPricing.Application.FileReader.Base
{
    public class NotImplementedFileReaderException : Exception
    {
        public NotImplementedFileReaderException()
            : base(ExceptionsResource.MsgInvalidFileReaderType) { }
    }
}
