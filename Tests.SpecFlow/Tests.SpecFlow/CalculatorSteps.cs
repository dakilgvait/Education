using System;
using TechTalk.SpecFlow;
using TestingLibrary;
using Xunit;

namespace Tests.SpecFlow
{
    [Binding]
    public class CalculatorSteps
    {
        public CalculatorSteps()
        {
            this._calculator = new Calculator();
            this._result = 0;
        }

        private Calculator _calculator;
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            this._calculator.FirstNumber = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            this._calculator.SecondNumber = number;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            this._result = this._calculator.Add();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.Equal(expectedResult, this._result);
        }
    }
}