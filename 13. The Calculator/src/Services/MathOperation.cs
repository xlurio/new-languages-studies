namespace MathOperationNS;

public abstract class MathOperation
{
    public abstract decimal Calculate(
        decimal firstOperatee, decimal secondOperatee
    );
}

public class Addition : MathOperation
{
    public override decimal Calculate(
        decimal firstOperatee, decimal secondOperatee
    )
    {
        return firstOperatee + secondOperatee;
    }
}

public class Substraction : MathOperation
{
    public override decimal Calculate(
        decimal firstOperatee, decimal secondOperatee
    )
    {
        return firstOperatee - secondOperatee;
    }
}

public class Multiplication : MathOperation
{
    public override decimal Calculate(decimal firstOperatee, decimal secondOperatee)
    {
        return firstOperatee * secondOperatee;
    }
}

public class Division : MathOperation
{
    public override decimal Calculate(decimal firstOperatee, decimal secondOperatee)
    {
        return firstOperatee / secondOperatee;
    }
}