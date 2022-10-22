namespace Isu.Extra.Exceptions;

public class StudentException : Exception
{
    public StudentException()
        : base() { }

    public StudentException(string message)
            : base(message)
    {
    }

    public StudentException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
