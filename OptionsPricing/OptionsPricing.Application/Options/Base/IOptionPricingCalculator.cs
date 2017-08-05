using System.Collections.Generic;

namespace OptionsPricing.Application.Options.Base
{
    public interface IOptionPricingCalculator<TInput>
    {
        double CalculateFor(TInput input);
    }
}


