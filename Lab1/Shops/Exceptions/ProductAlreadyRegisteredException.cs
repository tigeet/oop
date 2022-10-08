namespace Shops.Exceptions;
public class ProductAlreadyRegisteredException : Exception
{
    private const string _errorMessage = "Product is already registered";

    public ProductAlreadyRegisteredException()
        : base(_errorMessage) { }

    public ProductAlreadyRegisteredException(string message)
            : base(message)
    {
    }

    public ProductAlreadyRegisteredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
