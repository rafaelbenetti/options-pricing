using OptionsPricing.Infrastructure.Resources;
using System;

namespace OptionsPricing.Application.Options.Base
{
    public class InvalidCallOptionException : Exception
    {
        public InvalidCallOptionException()
            : base(ExceptionsResource.MsgInvalidCallOptionException) { }
    }
}
