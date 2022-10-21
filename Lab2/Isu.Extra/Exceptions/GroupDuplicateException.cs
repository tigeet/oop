namespace Isu.Extra.Exceptions;

public class GroupDuplicateException : Exception
{
    private const string ErrorMessage = "Attempted to add an existing group";
    public GroupDuplicateException()
        : base(ErrorMessage) { }

    public GroupDuplicateException(string message)
            : base(message)
    {
    }

    public GroupDuplicateException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
