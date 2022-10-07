namespace Shops.Exceptions;
public class InvalidPriceException : Exception
{
    private const string ErrorMessage = "Invalid price";

    public InvalidPriceException()
        : base(ErrorMessage) { }

    public InvalidPriceException(string message)
            : base(message)
    {
    }

    public InvalidPriceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
