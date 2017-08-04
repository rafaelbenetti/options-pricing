using System;

namespace OptionsPricing.Application.Models.BlackScholes
{
    public class BlackScholes
    {
        public BlackScholes(BlackScholesInput input)
        {
            this.CallOption = input.Cp;
            this.StrikePrice = input.Strike;
            this.PeriodInDays = GetPeriodInDaysFor(input.Expiry);
            this.RiskFreeRate = GetRiskFreeRateFor(input.Ccy);
            this.Volatility = GetVolatilityFor(input.Name);
            this.StockPrice = GetStockPriceFor(input.Name);
        }

        public char CallOption { get; private set; }
        public double StockPrice { get; private set; }
        public double StrikePrice { get; private set; }
        public int PeriodInDays { get; private set; }
        public double RiskFreeRate { get; private set; }
        public double Volatility { get; private set; }

        private int GetPeriodInDaysFor(DateTime expiry)
        {
            return (expiry - new DateTime(2016, 04, 01)).Days;
        }

        private double GetRiskFreeRateFor(string ccy)
        {
            return ccy == "PLN" ? 5 : 3;
        }
        
        private double GetVolatilityFor(string name)
        {
            return name == "ABC INC" ? 40 : 5;
        }

        private double GetStockPriceFor(string name)
        {
            return name == "ABC INC" ? 30 : 110;
        }
    }
}
