namespace Isu.Extra.Exceptions;

public class StudentDoesNotExistException : Exception
{
    private const string ErrorMessage = "Student with such id does not exist";
    public StudentDoesNotExistException()
        : base(ErrorMessage) { }

    public StudentDoesNotExistException(string message)
            : base(message)
    {
    }

    public StudentDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
