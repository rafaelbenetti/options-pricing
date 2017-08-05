using OptionsPricing.Application.Options.Base;
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
            { CcyConst.Pln, 5 },
            { CcyConst.Usd, 3 }
        };

        private Dictionary<string, double> _volatilityForNames =
            new Dictionary<string, double>()
        {
            { BlackScholesNameConst.AbcInc, 40 },
            { BlackScholesNameConst.CdeLtd, 5 }
        };

        private Dictionary<string, double> _stockPricesForNames =
            new Dictionary<string, double>()
        {
            { BlackScholesNameConst.AbcInc, 30 },
            { BlackScholesNameConst.CdeLtd, 110 }
        };

        private DateTime _startDate = new DateTime(2016, 04, 01);

        public BlackScholes(BlackScholesInput input)
        {
            try
            {
                this.CallOption = input.Cp;
                this.StrikePrice = input.Strike;
                this.PeriodInDays = (input.Expiry - _startDate).Days;
                this.RiskFreeRate = _risksForRegions[input.Ccy];
                this.Volatility = _volatilityForNames[input.Name];
                this.StockPrice = _stockPricesForNames[input.Name];
            }
            catch (Exception)
            {
                throw new InvalidInputDataException();
            }            
        }

        public char CallOption { get; private set; }
        public double StockPrice { get; private set; }
        public double StrikePrice { get; private set; }
        public int PeriodInDays { get; private set; }
        public double RiskFreeRate { get; private set; }
        public double Volatility { get; private set; }
    }
}
