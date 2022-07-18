namespace CalculatorNS;
using CalculatorExceptions;

public class Calculation
{
    public Calculation(string calculation) {
        string[] arguments = ExtractArguments(calculation);
    }

    private string[] ExtractArguments(string calculation) {
        byte operatorIndex = GetOperatorIndex(calculation);
    }

    private byte GetOperatorIndex(string calculation) {
        char[] operators = new char[4] {'+', '-', '*', '/'};
        bool hasFoundOperator = false;

        foreach (char math_operator in operators)
        {
           byte index = GetOperatorIndexIfContains(
            calculation, math_operator
            );
            bool hasFoundOperator = AssertOperatorSearch(
                index, hasFoundOperator
            );
        }

        if (!hasFoundOperator) {
            throw new InvalidCalculationException(
                "A mathematical operator must be passed"
            );
        }

        return index;
    }

    private byte GetOperatorIndexIfContains(
        string calculation, char math_operator
    )
    {
        if (calculation.Contains(math_operator)) {
            return calculation.IndexOf(math_operator);
        }

        return 0;
    }

    private void AssertOperatorSearch(byte foundIndex, bool hasFoundOperator) {
        bool wasFound = (foundIndex != 0) && (hasFoundOperator == False);
        bool thereIsTwoOperators = (foundIndex != 0) && 
            (hasFoundOperator == True);
        
        if (wasFound) {
            return True;
        }

        if (thereIsTwoOperators) {
            throw new InvalidCalculationException(
                "Only one mathematical operator is allowed per calculation"
            );
        }
    }
}

public class Calculator
{
    public decimal Calculate(string calculation) {
        Calculation _calculation = new Calculation(calculation);
        return _calculation.Result;
    }
}