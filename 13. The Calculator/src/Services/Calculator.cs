namespace CalculatorNS;
using CalculatorExceptions;
using MathOperationNS;

public class Calculation
{
    private List<char> MATH_OPERATORS = new List<char> {'+', '-', '*', '/'};
    private MathOperation _operation;
    private decimal _firstOperatee;
    private decimal _secondOperatee;
    public Calculation(string calculation) {
        byte operatorIndex = GetOperatorIndex(calculation);

        string firstOperatee = calculation.Substring(0, operatorIndex);
        _firstOperatee = ValidateOperatee(firstOperatee);

        string secondOperatee = calculation.Substring(operatorIndex + 1);
        _secondOperatee = ValidateOperatee(secondOperatee);

        char mathOperator = calculation[operatorIndex];
        _operation = GetOperation(mathOperator);
    }

    public decimal Result
    {
        get { return _operation.Calculate(_firstOperatee, _secondOperatee); }
    }

    private byte GetOperatorIndex(string calculation) {
        bool hasFoundOperator = false;
        byte index;

        foreach (char mathOperator in MATH_OPERATORS)
        {
            index = GetOperatorIndexIfContains(
                calculation, mathOperator
            );
            hasFoundOperator = AssertOperatorSearch(
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
        string calculation, char mathOperator
    )
    {
        if (calculation.Contains(mathOperator)) {
            int operatorIndex = calculation.IndexOf(mathOperator);
            return Convert.ToByte(operatorIndex);
        }

        return Convert.ToByte(0);
    }

    private bool AssertOperatorSearch(byte foundIndex, bool hasFoundOperator) {
        bool wasFound = (foundIndex != 0) && (hasFoundOperator == false);
        bool thereIsTwoOperators = (foundIndex != 0) && 
            (hasFoundOperator == true);
        
        if (wasFound) {
            return true;
        }

        if (thereIsTwoOperators) {
            throw new InvalidCalculationException(
                "Only one mathematical operator is allowed per calculation"
            );
        }

        return false;
    }

    private decimal ValidateOperatee(string enteredOperatee) {
        string cleanedOperatee = "";
        foreach(char enteredCharacter in enteredOperatee)
        {
            cleanedOperatee += ValidateCharacter(enteredCharacter);
        }

        return Decimal.Parse(cleanedOperatee);
    }

    private char ValidateCharacter(char character)
    {
        char[] validCharacters = "0123456789.".ToCharArray();
        List<char> parsedValidCharacters = validCharacters.ToList();

        bool isCharacterAWhitespace = (character == ' ');
        bool isCharacterValid = parsedValidCharacters.Contains(character);

        if (isCharacterAWhitespace) {
            return '\0';
        } else if (isCharacterValid) {
            return character;
        }

        throw new InvalidCalculationException(
            $"'{character}' is not a valid character"
        );
    }

    private MathOperation GetOperation(char mathOperator) {
        List<MathOperation> operations = new List<MathOperation> {
            new Addition(),
            new Substraction(),
            new Multiplication(),
            new Division()
        };
        int operationIndex = MATH_OPERATORS.IndexOf(mathOperator);

        return operations[operationIndex];
    }
}

public class Calculator
{
    public decimal Calculate(string calculation) {
        Calculation _calculation = new Calculation(calculation);
        return _calculation.Result;
    }
}