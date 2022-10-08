namespace Shops.Exceptions;
public class NotEnoughProductsException : Exception
{
    private const string _errorMessage = "Not enough products";

    public NotEnoughProductsException()
        : base(_errorMessage) { }

    public NotEnoughProductsException(string message)
            : base(message)
    {
    }

    public NotEnoughProductsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
