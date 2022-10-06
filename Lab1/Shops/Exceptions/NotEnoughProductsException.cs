namespace Shops.Exceptions;
public class NotEnoughProductsException : Exception
{
    private const string ErrorMessage = "Not enough products";

    public NotEnoughProductsException()
        : base(ErrorMessage) { }

    public NotEnoughProductsException(string message)
            : base(message)
    {
    }

    public NotEnoughProductsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
