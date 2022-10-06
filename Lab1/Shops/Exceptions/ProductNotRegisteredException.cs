namespace Shops.Exceptions;
public class ProductNotRegisteredException : Exception
{
    private const string ErrorMessage = "Product is not registered";

    public ProductNotRegisteredException()
        : base(ErrorMessage) { }

    public ProductNotRegisteredException(string message)
            : base(message)
    {
    }

    public ProductNotRegisteredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
