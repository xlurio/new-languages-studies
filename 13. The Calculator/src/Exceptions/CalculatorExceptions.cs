namespace CalculatorExceptions;

public class InvalidCalculationException : Exception
{
    public InvalidCalculationException()
    {
    }

    public InvalidCalculationException(string message) : base(message)
    {
    }

    public InvalidCalculationException(string message, Exception inner) 
    : base(message, inner)
    {
    }
}