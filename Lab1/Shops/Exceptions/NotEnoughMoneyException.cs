namespace Shops.Exceptions;
public class NotEnoughMoneyException : Exception
{
    private const string _errorMessage = "Not enough money";

    public NotEnoughMoneyException()
        : base(_errorMessage) { }

    public NotEnoughMoneyException(string message)
            : base(message)
    {
    }

    public NotEnoughMoneyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
