using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options;
using OptionsPricing.Application.Options.Base;
using OptionsPricing.UnitTest.Mock;

namespace OptionsPricing.UnitTest.OptionPricing.BlackScholes
{
    [TestClass]
    [TestCategory("Black Scholes Calculator")]
    public class BlackScholesCalculatorTest
    {
        private BlackScholesCalculator _blackScholesCalculator;
        private FileReaderMock _fileReaderMock;

        public BlackScholesCalculatorTest()
        {
            _blackScholesCalculator = new BlackScholesCalculator();
            _fileReaderMock = new FileReaderMock();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCallOptionException))]
        public void Must_Throws_Invalid_Call_Option_Exception()
        {
            BlackScholesInput blackScholesInput = _fileReaderMock.GetOne();
            blackScholesInput.Cp = 'M';

            _blackScholesCalculator.CalculateFor(blackScholesInput);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputDataException))]
        public void Must_Throws_Invalid_Input_Exception()
        {
            BlackScholesInput blackScholesInput = _fileReaderMock.GetOne();
            blackScholesInput.Name = "AAA BBB";
            _blackScholesCalculator.CalculateFor(blackScholesInput);
        }

        [TestMethod]
        public void Must_Calculate_With_Success_For_One()
        {
            BlackScholesInput blackScholesInput = _fileReaderMock.GetOne();
            double result = _blackScholesCalculator.CalculateFor(blackScholesInput);
        }
    }
}
