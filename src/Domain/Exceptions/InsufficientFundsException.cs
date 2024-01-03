namespace Domain.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base($"Insufficient funds for the transfer.")
    {

    }
}
