namespace Isu.Extra.Exceptions;

public class FlowDoesNotExistException : Exception
{
    private const string ErrorMessage = "flow does not exist";
    public FlowDoesNotExistException()
        : base(ErrorMessage) { }

    public FlowDoesNotExistException(string message)
            : base(message)
    {
    }

    public FlowDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
