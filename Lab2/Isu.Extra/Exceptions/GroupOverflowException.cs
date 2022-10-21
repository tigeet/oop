namespace Isu.Extra.Exceptions;
public class FlowOverflowException : Exception
{
    public FlowOverflowException()
        : base("Failed assigning student to the group: Group has no extra space") { }

    public FlowOverflowException(string message)
            : base(message)
    {
    }

    public FlowOverflowException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
