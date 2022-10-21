namespace Isu.Extra.Exceptions;

public class TooManyFlowsException : Exception
{
    private const string ErrorMessage = "Cant assign to too many flows";
    public TooManyFlowsException()
        : base(ErrorMessage) { }

    public TooManyFlowsException(string message)
            : base(message)
    {
    }

    public TooManyFlowsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
