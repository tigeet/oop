namespace Shops.Exceptions;
public class InvalidAmountException : Exception
{
    private const string ErrorMessage = "Invalid Amount";

    public InvalidAmountException()
        : base(ErrorMessage) { }

    public InvalidAmountException(string message)
            : base(message)
    {
    }

    public InvalidAmountException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
