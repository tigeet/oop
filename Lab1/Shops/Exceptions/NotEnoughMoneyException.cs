namespace Shops.Exceptions;
public class NotEnoughMoneyException : Exception
{
    private const string ErrorMessage = "Not enough money";

    public NotEnoughMoneyException()
        : base(ErrorMessage) { }

    public NotEnoughMoneyException(string message)
            : base(message)
    {
    }

    public NotEnoughMoneyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
