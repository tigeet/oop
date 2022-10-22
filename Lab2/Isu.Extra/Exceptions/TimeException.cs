namespace Isu.Extra.Exceptions;

public class TimeException : Exception
{
    public TimeException()
        : base() { }

    public TimeException(string message)
            : base(message)
    {
    }

    public TimeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
