using System;

namespace OptionsPricing.Application.Models.BlackScholes
{
    public class BlackScholesInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
        public char Cp { get; set; }
        public DateTime Expiry { get; set; }
        public double Strike { get; set; }
        public string Ccy { get; set; }
    }
}
