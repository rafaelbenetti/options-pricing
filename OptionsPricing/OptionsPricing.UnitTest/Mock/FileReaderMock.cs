using OptionsPricing.Application.Models.BlackScholes;
using System;
using System.Collections.Generic;

namespace OptionsPricing.UnitTest.Mock
{
    public class FileReaderMock
    {
        public List<BlackScholesInput> GetInvestmentsForCsv()
        {
            return new List<BlackScholesInput>()
            {
                CreateNewFor(123,"CDE LTD","StockOption","European","C",new DateTime(2017,04,01),100,"USD"),
                CreateNewFor(124,"ABC INC","StockOption","European","C",new DateTime(2017,04,01),20,"PLN"),
                CreateNewFor(125,"CDE LTD","StockOption","European","P",new DateTime(2017,04,01),120,"USD"),
                CreateNewFor(126,"CDE LTD","StockOption","European","P",new DateTime(2017,04,01),140,"USD"),
                CreateNewFor(127,"CDE LTD","StockOption","European","C",new DateTime(2016,07,01),100,"USD"),
                CreateNewFor(128,"ABC INC","StockOption","European","P",new DateTime(2016,07,01),50,"PLN"),
                CreateNewFor(129,"CDE LTD","StockOption","European","C",new DateTime(2016,10,01),100,"USD"),
                CreateNewFor(130,"ABC INC","StockOption","European","P",new DateTime(2016,10,01),50,"PLN"),
            };
        }

        private BlackScholesInput CreateNewFor(int id, string name, string type, string style, string cp, DateTime expiry, decimal strike, string ccy)
        {
            return new BlackScholesInput()
            {
                Id = id,
                Name = name,
                Type = type,
                Style = style,
                Cp = cp,
                Expiry = expiry,
                Strike = strike,
                Ccy = ccy
            };
        }
    }
}
