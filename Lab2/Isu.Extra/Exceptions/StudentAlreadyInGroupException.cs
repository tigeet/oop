namespace Isu.Extra.Exceptions;

public class StudentAlreadyInGroupException : Exception
{
    private const string ErrorMessage = "Student is already assigned to that group";
    public StudentAlreadyInGroupException()
        : base(ErrorMessage) { }

    public StudentAlreadyInGroupException(string message)
            : base(message)
    {
    }

    public StudentAlreadyInGroupException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
