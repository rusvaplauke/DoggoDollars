namespace Domain.Exceptions;

public class UserExistsException : Exception
{
    public UserExistsException(string name) : base($"User {name} already registered. Cannot create new user.")
    {

    }
}
