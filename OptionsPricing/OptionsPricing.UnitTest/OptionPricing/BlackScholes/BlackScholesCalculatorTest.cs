using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options;
using OptionsPricing.Application.Options.Base;
using OptionsPricing.UnitTest.Mock;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void Must_Calculate_With_Success_For_Many()
        {
            List<BlackScholesInput> blackScholesInputData = _fileReaderMock.GetAll();
            List<BlackScholesResult> result = _blackScholesCalculator.CalculateFor(blackScholesInputData);
        }

        [TestMethod]
        public void Must_Return_Correct_Result_For()
        {
            List<double> expectedResults = 
                new List<double>() { 110, 30, 0, 0, 110, 1.2444594168143162E-196, 110, 0 };

            List<BlackScholesInput> blackScholesInputData = _fileReaderMock.GetAll();
            List<double> results = _blackScholesCalculator.CalculateFor(blackScholesInputData).Select(r => r.Result).ToList();

            CollectionAssert.AreEqual(expectedResults, results);
        }
    }
}
