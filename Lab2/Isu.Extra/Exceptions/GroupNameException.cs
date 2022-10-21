namespace Isu.Extra.Exceptions;

public class GroupNameException : Exception
{
    private const string ErrorMessage = "Wrong group name signature";
    public GroupNameException()
        : base(ErrorMessage) { }

    public GroupNameException(string message)
            : base(message)
    {
    }

    public GroupNameException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
