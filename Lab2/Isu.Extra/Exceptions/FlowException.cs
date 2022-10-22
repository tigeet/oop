namespace Isu.Extra.Exceptions;

public class FlowException : Exception
{
    public FlowException()
        : base() { }

    public FlowException(string message)
            : base(message)
    {
    }

    public FlowException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
