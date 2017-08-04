using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options.Base;
using OptionsPricing.Infrastructure.Consts;
using OptionsPricing.Infrastructure.Extensions;
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
            double deltaOne = CalcDeltaOne(blackScholes);
            double deltaTwo = CalcDeltaTwo(blackScholes, deltaOne);

            if (blackScholes.CallOption == CallOption.CALL)
                return CalculateForCallOption(blackScholes, deltaOne, deltaTwo);
            else if (blackScholes.CallOption == CallOption.PUT)
                return CalculateForPutOption(blackScholes, deltaOne, deltaTwo);

            throw new InvalidCallOptionException();
        }

        private double CalculateForCallOption(BlackScholes blackScholes, double deltaOne, double deltaTwo)
        {
            double reducedStrikePrice = deltaOne.CumulativeNormalDistribution() - blackScholes.StrikePrice;
            double riskPerPeriod = Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays);

            return blackScholes.StockPrice * reducedStrikePrice * riskPerPeriod * deltaTwo.CumulativeNormalDistribution();
        }

        private double CalculateForPutOption(BlackScholes blackScholes, double deltaOne, double deltaTwo)
        {
            double reducedStockPrice = (-deltaTwo).CumulativeNormalDistribution() - blackScholes.StockPrice;
            double riskPerPeriod = Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays);            

            return blackScholes.StrikePrice * riskPerPeriod * reducedStockPrice * (-deltaOne).CumulativeNormalDistribution();
        }                

        private double CalcDeltaTwo(BlackScholes blackScholes, double deltaOne)
        {
            return deltaOne - blackScholes.Volatility * Math.Sqrt(blackScholes.PeriodInDays);
        }

        private double CalcDeltaOne(BlackScholes blackScholes)
        {
            double stockDividedByStrike = Math.Log(blackScholes.StockPrice / blackScholes.StrikePrice);
            double riskPerVolatility = blackScholes.RiskFreeRate + blackScholes.Volatility * blackScholes.Volatility / 2.0;
            double stockPerRisksAndDays = stockDividedByStrike + riskPerVolatility * blackScholes.PeriodInDays;

            return stockPerRisksAndDays / (blackScholes.Volatility * Math.Sqrt(blackScholes.PeriodInDays));
        }        
    }
}
