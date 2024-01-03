namespace Domain.Exceptions;

public class InvalidAmountException : Exception
{
    public InvalidAmountException() : base($"Invalid amount: the top-up amount should be greater than 0.")
    {

    }
}
