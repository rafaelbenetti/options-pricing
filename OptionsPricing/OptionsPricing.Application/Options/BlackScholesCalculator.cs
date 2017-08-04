using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options.Base;
using System;

namespace OptionsPricing.Application.Options
{
    public class BlackScholesCalculator : IOptionPricingCalculator<BlackScholesInput>
    {
        public double CalculateFor(BlackScholesInput blackScholesInput)
        {
            char callOption = blackScholesInput.Cp;
            double s = 0;
            double x = 0;
            double t = 0;
            double r = 0;
            double v = 0;

            return CalculateFor(callOption, s, x, t, r, v);
        }

        private double CalculateFor(char callOption, double s, double x, double t, double r, double v)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            double dBlackScholes = 0.0;

            d1 = (Math.Log(s / x) + (r + v * v / 2.0) * t) / (v * Math.Sqrt(t));
            d2 = d1 - v * Math.Sqrt(t);
            if (callOption == 'C')
            {
                dBlackScholes = s * CumulativeNormalDistribution(d1) - x * Math.Exp(-r * t) * CumulativeNormalDistribution(d2);
            }
            else if (callOption == 'P')
            {
                dBlackScholes = x * Math.Exp(-r * t) * CumulativeNormalDistribution(-d2) - s * CumulativeNormalDistribution(-d1);
            }
            return dBlackScholes;
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
