namespace Domain.Exceptions;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException(string? accountId) : base($"Account {accountId} not found.")
    {

    }
}