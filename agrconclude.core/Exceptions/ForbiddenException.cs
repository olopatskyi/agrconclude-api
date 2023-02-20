namespace agrconclude.core.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException(string message = "You don't have access to this resource") : base(message)
    {
    }
}