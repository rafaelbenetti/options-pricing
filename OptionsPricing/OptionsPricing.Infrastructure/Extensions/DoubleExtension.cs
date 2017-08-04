using System;

namespace OptionsPricing.Infrastructure.Extensions
{
    public static class DoubleExtension
    {
        public static double CumulativeNormalDistribution(this double value)
        {
            double a1 = 0.31938153, a2 = -0.356563782, a3 = 1.781477937, a4 = -1.821255978, a5 = 1.330274429;
            double l = Math.Abs(value);
            double k = 1.0 / (1.0 + 0.2316419 * l);
            double w = 1.0 - 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-l * l / 2) * (a1 * k + a2 * k * k + a3 * Math.Pow(k, 3) + a4 * Math.Pow(k, 4) + a5 * Math.Pow(k, 5));

            if (value < 0.0)
                w = 1.0 - w;
            return w;
        }
    }
}
