using System.Collections.Generic;

namespace OptionsPricing.Application.FileReader.Base
{
    public interface IFileReader
    {
        List<TReturn> Read<TReturn>(string path);
    }
}
