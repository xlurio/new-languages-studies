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
        byte FOUND_INDEX = 0;
        byte HAS_FOUND = 1;

        char[] calculationChars = calculation.ToCharArray();
        byte operatorIndex = 0;

        List<string> hasFoundOperator = new List<string>(2);
        hasFoundOperator.Add("0");
        hasFoundOperator.Add("false");

        foreach (char mathOperator in MATH_OPERATORS)
        {
            operatorIndex = GetOperatorIndexIfContains(
                calculationChars, mathOperator
            );
            hasFoundOperator = AssertOperatorSearch(
                operatorIndex, hasFoundOperator
            );
        }

        if (hasFoundOperator[HAS_FOUND] == "false") {
            throw new InvalidCalculationException(
                "A mathematical operator must be passed"
            );
        }

        byte foundIndex = Convert.ToByte(hasFoundOperator[FOUND_INDEX]);
        return foundIndex;
    }

    private byte GetOperatorIndexIfContains(
        char[] calculation, char mathOperator
    )
    {

        if (calculation.Contains(mathOperator)) {
            int operatorIndex = Array.IndexOf(calculation, mathOperator);
            return Convert.ToByte(operatorIndex);
        }

        return Convert.ToByte(0);
    }

    private List<string> AssertOperatorSearch(
        byte foundIndex, List<string> hasFoundOperator
    ) {
        byte FOUND_INDEX = 0;
        byte HAS_FOUND = 1;

        bool wasFound = 
            (foundIndex != 0) && (hasFoundOperator[HAS_FOUND] == "false");

        bool thereAreTwoOperators = (foundIndex != 0) && 
            (hasFoundOperator[HAS_FOUND] == "true");
        
        if (wasFound) {
            hasFoundOperator[FOUND_INDEX] = $"{foundIndex}";
            hasFoundOperator[HAS_FOUND] = "true";

            return hasFoundOperator;
        }

        if (thereAreTwoOperators) {
            throw new InvalidCalculationException(
                "Only one mathematical operator is allowed per calculation"
            );
        }
        
        return hasFoundOperator;
    }

    private decimal ValidateOperatee(string enteredOperatee) {
        string cleanedOperatee = "";
        foreach(char enteredCharacter in enteredOperatee)
        {
            cleanedOperatee += ValidateCharacter(enteredCharacter);
        }

        cleanedOperatee = cleanedOperatee.Replace(" ", "");
        return Decimal.Parse(cleanedOperatee);
    }

    private char ValidateCharacter(char character)
    {
        char[] validCharacters = "0123456789. ".ToCharArray();
        List<char> parsedValidCharacters = validCharacters.ToList();

        bool isCharacterAWhitespace = (character == ' ');
        bool isCharacterValid = parsedValidCharacters.Contains(character);

        if (isCharacterValid) {
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