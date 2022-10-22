namespace Isu.Extra.Exceptions;

public class StudentNotAssignedException : Exception
{
    private const string ErrorMessage = "student is not assigned";
    public StudentNotAssignedException()
        : base(ErrorMessage) { }

    public StudentNotAssignedException(string message)
            : base(message)
    {
    }

    public StudentNotAssignedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
