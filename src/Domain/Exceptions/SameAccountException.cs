namespace Domain.Exceptions;

public class SameAccountException : Exception
{
    public SameAccountException() : base($"The account and corresponding accounts cannot be the same.")
    {

    }
}
