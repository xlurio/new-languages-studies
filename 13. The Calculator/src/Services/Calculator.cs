namespace CalculatorNS;
using CalculatorExceptions;
using MathOperationNS;

public class Calculation
{
    private List<char> MATH_OPERATORS = 
        new List<char> {'+', '-', '*', '/'};
    private MathOperation _operation;
    private decimal _firstOperatee;
    private decimal _secondOperatee;
    public Calculation(string calculation) {
        const byte OPERATEE = 0;
        const byte MID_INDEX = 1;

        byte operatorIndex = GetOperatorIndex(calculation);

        List<string> firstOperateeInformation = 
            GetFirstOperateeSubstring(calculation, 0, operatorIndex);
        _firstOperatee = ValidateOperatee(firstOperateeInformation[OPERATEE]);

        byte secondOperateeIndex = 
            Convert.ToByte(firstOperateeInformation[MID_INDEX]);
        string secondOperatee = 
            calculation.Substring(secondOperateeIndex);
        _secondOperatee = ValidateOperatee(secondOperatee);

        operatorIndex = Convert.ToByte(secondOperateeIndex - 1);
        char mathOperator = calculation[operatorIndex];

        _operation = GetOperation(mathOperator);
    }

    public decimal Result
    {
        get { return _operation.Calculate(_firstOperatee, _secondOperatee); }
    }

    private byte GetOperatorIndex(string calculation) {
        const byte FOUND_INDEX = 0;
        const byte HAS_FOUND = 1;

        calculation = EliminateModifiers(calculation);
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

    private string EliminateModifiers(string stringToClean) {
        return stringToClean.Replace("(-)", "");
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
        const byte FOUND_INDEX = 0;
        const byte HAS_FOUND = 1;

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

    private List<string> GetFirstOperateeSubstring(
        string toExtractOperatee, byte firstIndex, byte lastIndex
    ) {
        if (toExtractOperatee.Contains("(-)")) {
            lastIndex += 3;
        }

        string operatee = toExtractOperatee.Substring(0, lastIndex);
        List<string> foundOperatee = 
            new List<string>{ operatee, $"{lastIndex + 1}" };

        return foundOperatee;
    }


    private decimal ValidateOperatee(string enteredOperatee) {
        enteredOperatee = ProcessModifiers(enteredOperatee);
        string cleanedOperatee = "";

        foreach(char enteredCharacter in enteredOperatee)
        {
            cleanedOperatee += ValidateCharacter(enteredCharacter);
        }

        cleanedOperatee = cleanedOperatee.Replace(" ", "");
        return Decimal.Parse(cleanedOperatee);
    }

    private string ProcessModifiers(string stringToClean) {
        return stringToClean.Replace("(-)", "-");
    }

    private char ValidateCharacter(char character)
    {
        char[] validCharacters = "0123456789.- ".ToCharArray();
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
        Console.WriteLine(operationIndex);

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