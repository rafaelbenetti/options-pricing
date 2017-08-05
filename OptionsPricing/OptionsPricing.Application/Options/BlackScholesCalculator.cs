using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options.Base;
using OptionsPricing.Infrastructure.Consts;
using OptionsPricing.Infrastructure.Extensions;
using System;
using System.Collections.Generic;

namespace OptionsPricing.Application.Options
{
    public class BlackScholesCalculator : IOptionPricingCalculator<BlackScholesInput>
    {
        public List<BlackScholesResult> CalculateFor(List<BlackScholesInput> blackScholesInputData)
        {
            var blackScholesResultData = new List<BlackScholesResult>();

            foreach (BlackScholesInput input in blackScholesInputData)
            {
                var blackScholesResult = new BlackScholesResult(input);
                blackScholesResult.Result = CalculateFor(blackScholesResult);
                blackScholesResultData.Add(blackScholesResult);
            }

            return blackScholesResultData;
        }

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

        private double CalculateForPutOption(BlackScholes blackScholes, double deltaOne, double deltaTwo)
        {
            double riskPerPeriod = Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays);
            double strikeVersusRisk = blackScholes.StrikePrice * riskPerPeriod * (-deltaTwo).CumulativeNormalDistribution();
            double stockVersusDelta = blackScholes.StockPrice * (-deltaOne).CumulativeNormalDistribution();

            return strikeVersusRisk - stockVersusDelta;
        }

        private double CalculateForCallOption(BlackScholes blackScholes, double deltaOne, double deltaTwo)
        {
            double riskPerPeriod = Math.Exp(-blackScholes.RiskFreeRate * blackScholes.PeriodInDays);
            double stockVersusDelta = blackScholes.StockPrice * deltaOne.CumulativeNormalDistribution();
            double strikeVersusRisk = blackScholes.StrikePrice * riskPerPeriod * deltaTwo.CumulativeNormalDistribution();            

            return stockVersusDelta - strikeVersusRisk;
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
