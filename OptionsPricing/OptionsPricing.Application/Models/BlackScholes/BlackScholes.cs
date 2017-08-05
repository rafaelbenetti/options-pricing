using OptionsPricing.Infrastructure.Consts;
using System;
using System.Collections.Generic;

namespace OptionsPricing.Application.Models.BlackScholes
{
    internal class BlackScholes
    {
        private Dictionary<string, double> _risksForRegions =
            new Dictionary<string, double>()
        {
            { CcyConst.PLN, 5 },
            { CcyConst.USD, 3 }
        };

        private Dictionary<string, double> _volatilityForNames =
            new Dictionary<string, double>()
        {
            { BlackScholesNameConst.ABC_INC, 40 },
            { BlackScholesNameConst.CDE_LTD, 5 }
        };

        private Dictionary<string, double> _stockPricesForNames =
            new Dictionary<string, double>()
        {
            { BlackScholesNameConst.ABC_INC, 30 },
            { BlackScholesNameConst.CDE_LTD, 110 }
        };

        public BlackScholes(BlackScholesInput input)
        {
            this.CallOption = input.Cp;
            this.StrikePrice = input.Strike;
            this.PeriodInDays = (input.Expiry - new DateTime(2016, 04, 01)).Days;
            this.RiskFreeRate = _risksForRegions[input.Ccy];
            this.Volatility = _volatilityForNames[input.Name];
            this.StockPrice = _stockPricesForNames[input.Name];
        }

        public char CallOption { get; private set; }
        public double StockPrice { get; private set; }
        public double StrikePrice { get; private set; }
        public int PeriodInDays { get; private set; }
        public double RiskFreeRate { get; private set; }
        public double Volatility { get; private set; }
    }
}
