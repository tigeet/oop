namespace Shops.Exceptions;
public class InvalidAmountException : Exception
{
    private const string _errorMessage = "Invalid Amount";

    public InvalidAmountException()
        : base(_errorMessage) { }

    public InvalidAmountException(string message)
            : base(message)
    {
    }

    public InvalidAmountException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
