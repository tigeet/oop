namespace Shops.Exceptions;
public class ProductAlreadyRegisteredException : Exception
{
    private const string ErrorMessage = "Product is already registered";

    public ProductAlreadyRegisteredException()
        : base(ErrorMessage) { }

    public ProductAlreadyRegisteredException(string message)
            : base(message)
    {
    }

    public ProductAlreadyRegisteredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
