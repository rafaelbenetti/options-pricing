using CsvHelper.Configuration;

namespace OptionsPricing.Application.Models.BlackScholes
{
    public class BlackScholesInputMap : CsvClassMap<BlackScholesInput>
    {
        public BlackScholesInputMap()
        {
            Map(m => m.Id);
            Map(m => m.Name);
            Map(m => m.Type);
            Map(m => m.Style);
            Map(m => m.Cp).Name("C/P");
            Map(m => m.Expiry);
            Map(m => m.Strike).Name("Strike price");
            Map(m => m.Ccy).Name("CCY");
        }
    }
}
