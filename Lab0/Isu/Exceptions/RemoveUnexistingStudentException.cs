namespace Isu.Exceptions;

public class RemoveUnexistingStudentException
: Exception
{
    private const string ErrorMessage = "Attempted to remove studnet that does not exist";
    public RemoveUnexistingStudentException()
        : base(ErrorMessage) { }

    public RemoveUnexistingStudentException(
string message)
            : base(message)
    {
    }

    public RemoveUnexistingStudentException(
string message, Exception inner)
        : base(message, inner)
    {
    }
}
