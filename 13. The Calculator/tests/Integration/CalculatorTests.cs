using CalculatorNS;
using CalculatorExceptions;
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
        CalculatorArrangements arrangement = GivenTheSumString();
        decimal result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheSum(result);
    }

    private CalculatorArrangements GivenTheSumString() {
        string argument = "1 + 2";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private decimal WhenItsCalculate(CalculatorArrangements arrangements)
    {
        Calculator calculator = arrangements._calculator;
        string argument = arrangements._calculatorArgument;

        return calculator.Calculate(argument);
    }

    private void ThenShouldReturnTheSum(decimal sum) {
        decimal expected_result = 3;
        double tolerance = 0.000000001;
        bool isExpectedResult = 
            (double)Math.Abs(sum - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }

    [Test]
    public void TestInvalidCalculation() {
        CalculatorArrangements arrangements = GivenTheInvalidCalculation();
        TestDelegate result = () => WhenItsCalculate(arrangements);
        ThenShouldRaiseInvalidCalculation(result);
    }

    private CalculatorArrangements GivenTheInvalidCalculation(){
        string argument = "a + 3";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private void ThenShouldRaiseInvalidCalculation(
        TestDelegate result
    ) {
        Assert.Throws<InvalidCalculationException>(result);
    }
}