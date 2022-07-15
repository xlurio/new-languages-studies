using CalculatorNS;
using System;


public struct CalculatorArrangements
{
    public Calculator _calculator;
    public string _calculatorArgument;

    public CalculatorArrangements(Calculator calculator, 
                                  string argument)
    {
        this._calculator = calculator;
        this._calculatorArgument = argument;
    }
}

[TestFixture]
class CalculatorTests
{
    [Test]
    public void TestCalculate() {
        arrangement = GivenTheSumString();
        result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheSum(result);
    }

    private CalculatorArrangements GivenTheSumString() {
        Calculator calculator = new Calculator();
        string argument = "1 + 2";

        return new CalculatorArrangements(
            calculator,
            argument
        );
    }

    private decimal WhenItsCalculate(CalculatorArrangements arrangements)
    {
        Calculator calculator = arrangements._calculator;
        string argument = arrangements._calculatorArgument;

        return calculator.calculate(argument);
    }

    private void ThenShouldReturnTheSum(decimal sum) {
        decimal expected_result = 3;
        double tolerance = 0.000000001;
        bool isExpectedResult = Math.Abs(sum - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }

    public void TestInvalidCalculation() {
        arrangement = GivenTheInvalidCalculation();
        result = WhenItsCalculate(arrangement); // Turn to delegate
        ThenShouldRaiseInvalidCalculation(result);
    }
}