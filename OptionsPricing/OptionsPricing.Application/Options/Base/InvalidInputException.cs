using OptionsPricing.Infrastructure.Resources;
using System;

namespace OptionsPricing.Application.Options.Base
{
    public class InvalidInputDataException : Exception
    {
        public InvalidInputDataException()
            : base(ExceptionsResource.MsgInvalidInputException) { }
    }
}
