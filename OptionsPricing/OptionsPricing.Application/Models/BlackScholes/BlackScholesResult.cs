namespace OptionsPricing.Application.Models.BlackScholes
{
    public class BlackScholesResult : BlackScholesInput
    {
        public BlackScholesResult(BlackScholesInput input)
        {
            this.Id = input.Id;
            this.Name = input.Name;
            this.Type = input.Type;
            this.Style = input.Style;
            this.Strike = input.Strike;
            this.Expiry = input.Expiry;
            this.Cp = input.Cp;
            this.Ccy = input.Ccy;
        }

        public double Result { get; set; }
    }
}
