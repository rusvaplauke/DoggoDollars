namespace Domain.Exceptions;

public class MaxAccountsException : Exception
{
    public MaxAccountsException() : base($"User already has 2 accounts.")
    {

    }
}
