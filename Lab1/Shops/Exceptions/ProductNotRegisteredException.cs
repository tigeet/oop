namespace Shops.Exceptions;
public class ProductNotRegisteredException : Exception
{
    private const string _errorMessage = "Product is not registered";

    public ProductNotRegisteredException()
        : base(_errorMessage) { }

    public ProductNotRegisteredException(string message)
            : base(message)
    {
    }

    public ProductNotRegisteredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
