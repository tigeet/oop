namespace Shops.Exceptions;
public class ProductDoesNotExistException : Exception
{
    private const string ErrorMessage = "Product does not exist";

    public ProductDoesNotExistException()
        : base(ErrorMessage) { }

    public ProductDoesNotExistException(string message)
            : base(message)
    {
    }

    public ProductDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
