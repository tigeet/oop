namespace Isu.Extra.Exceptions;

public class NoSuitableFlowsException : Exception
{
    private const string ErrorMessage = "no suitable flows";
    public NoSuitableFlowsException()
        : base(ErrorMessage) { }

    public NoSuitableFlowsException(string message)
            : base(message)
    {
    }

    public NoSuitableFlowsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
