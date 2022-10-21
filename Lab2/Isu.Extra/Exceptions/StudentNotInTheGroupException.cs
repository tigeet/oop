namespace Isu.Extra.Exceptions;

public class StudentNotInTheGroupException : Exception
{
    private const string ErrorMessage = "Attempted to remove student that is not assigned to that group";
    public StudentNotInTheGroupException()
        : base(ErrorMessage) { }

    public StudentNotInTheGroupException(string message)
            : base(message)
    {
    }

    public StudentNotInTheGroupException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
