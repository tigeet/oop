namespace Shops.Exceptions;
public class InvalidPriceException : Exception
{
    private const string _errorMessage = "Invalid price";

    public InvalidPriceException()
        : base(_errorMessage) { }

    public InvalidPriceException(string message)
            : base(message)
    {
    }

    public InvalidPriceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
