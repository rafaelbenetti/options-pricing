using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options.Base;
using System;

namespace OptionsPricing.Application.Options
{
    public class BlackScholesCalculator : IOptionPricingCalculator<BlackScholesInput>
    {
        public double CalculateFor(BlackScholesInput blackScholesInput)
        {
            return CalculateFor(new BlackScholes(blackScholesInput));
        }

        private double CalculateFor(BlackScholes blackScholes)
        {
            double result = 0;
            double d1 = (Math.Log(blackScholes.StockPrice / blackScholes.StrikePrice) + (blackScholes.RiskFreeRate + blackScholes.Volatility * blackScholes.Volatility / 2.0) * blackScholes.PeriodInDays) / (blackScholes.Volatility * Math.Sqrt(blackScholes.PeriodInDays));
            double d2 = d1 - blackScholes.Volatility * Math.Sqrt(blackScholes.PeriodInDays);

            if (blackScholes.CallOption == 'C')
            {
                result = blackScholes.StockPrice * CumulativeNormalDistribution(d1) - blackScholes.StrikePrice * Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays) * CumulativeNormalDistribution(d2);
            }
            else if (blackScholes.CallOption == 'P')
            {
                result = blackScholes.StrikePrice * Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays) * CumulativeNormalDistribution(-d2) - blackScholes.StockPrice * CumulativeNormalDistribution(-d1);
            }

            return result;
        }

        private double CumulativeNormalDistribution(double input)
        {
            double L, K, w;
            double a1 = 0.31938153, a2 = -0.356563782, a3 = 1.781477937, a4 = -1.821255978, a5 = 1.330274429;

            L = Math.Abs(input);
            K = 1.0 / (1.0 + 0.2316419 * L);
            w = 1.0 - 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-L * L / 2) * (a1 * K + a2 * K * K + a3
            * Math.Pow(K, 3) + a4 * Math.Pow(K, 4) + a5 * Math.Pow(K, 5));

            if (input < 0.0)
            {
                w = 1.0 - w;
            }
            return w;
        }
    }
}
