namespace Shops.Exceptions;
public class ProductDoesNotExistException : Exception
{
    private const string _errorMessage = "Product does not exist";

    public ProductDoesNotExistException()
        : base(_errorMessage) { }

    public ProductDoesNotExistException(string message)
            : base(message)
    {
    }

    public ProductDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
