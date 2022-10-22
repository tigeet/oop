namespace Isu.Extra.Exceptions;

public class FacultyException : Exception
{
    public FacultyException()
        : base() { }

    public FacultyException(string message)
            : base(message)
    {
    }

    public FacultyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
