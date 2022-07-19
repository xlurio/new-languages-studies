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
    public void TestSum() {
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

    [Test]
    public void TestSubstraction() {
        CalculatorArrangements arrangement = GivenTheSubstractionString();
        decimal result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheSubstraction(result);
    }

    private CalculatorArrangements GivenTheSubstractionString() {
        string argument = "2 - 1";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private void ThenShouldReturnTheSubstraction(decimal result) {
        decimal expected_result = 1;
        double tolerance = 0.000000001;
        bool isExpectedResult = 
            (double)Math.Abs(result - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }

    [Test]
    public void TestMultiplication() {
        CalculatorArrangements arrangement = GivenTheMultiplicationString();
        decimal result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheMultiplication(result);
    }

    private CalculatorArrangements GivenTheMultiplicationString() {
        string argument = "2 * 2";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private void ThenShouldReturnTheMultiplication(decimal result) {
        decimal expected_result = 4;
        double tolerance = 0.000000001;
        bool isExpectedResult = 
            (double)Math.Abs(result - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }

    [Test]
    public void TestDivision() {
        CalculatorArrangements arrangement = GivenTheDivisionString();
        decimal result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheDivision(result);
    }

    private CalculatorArrangements GivenTheDivisionString() {
        string argument = "6 / 2";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private void ThenShouldReturnTheDivision(decimal result) {
        decimal expected_result = 3;
        double tolerance = 0.000000001;
        bool isExpectedResult = 
            (double)Math.Abs(result - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }

    [Test]
    public void TestInvalidOperatee() {
        CalculatorArrangements arrangements = GivenTheInvalidOperatee();
        TestDelegate result = () => WhenItsCalculate(arrangements);
        ThenShouldRaiseInvalidCalculation(result);
    }

    private CalculatorArrangements GivenTheInvalidOperatee(){
        string argument = "a + 3";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    [Test]
    public void TestMissingOperator() {
        CalculatorArrangements arrangements = GivenTheMissingOperator();
        TestDelegate result = () => WhenItsCalculate(arrangements);
        ThenShouldRaiseInvalidCalculation(result);
    }

    private CalculatorArrangements GivenTheMissingOperator() {
        string argument = "35";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    public void TestMoreThenOneOperation() {
        CalculatorArrangements arrangements = GivenMoreThenOneOperator();
        TestDelegate result = () => WhenItsCalculate(arrangements);
        ThenShouldRaiseInvalidCalculation(result);
    }

    private CalculatorArrangements GivenMoreThenOneOperator() {
        string argument = "3 + 5 + 9";

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

    private void ThenShouldRaiseInvalidCalculation(
        TestDelegate result
    ) {
        Assert.Throws<InvalidCalculationException>(result);
    }

    [Test]
    public void TestCalculatingNegativeNumbers() {
        CalculatorArrangements arrangement = GivenTheNegatives();
        decimal result = WhenItsCalculate(arrangement);
        ThenShouldReturnTheSum(result);
    }

    private CalculatorArrangements GivenTheNegatives() {
        string argument = "(-)3 + 6";

        return new CalculatorArrangements(
            new Calculator(),
            argument
        );
    }

    private void ThenShouldReturnTheSum(decimal result) {
        decimal expected_result = 3;
        double tolerance = 0.000000001;
        bool isExpectedResult = 
            (double)Math.Abs(result - expected_result) <= tolerance;

        Assert.True(isExpectedResult);
    }
}