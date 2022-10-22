namespace Isu.Extra.Exceptions;

public class TimeSignatureException : Exception
{
    private const string ErrorMessage = "wrong hour:minute signature";
    public TimeSignatureException()
        : base(ErrorMessage) { }

    public TimeSignatureException(string message)
            : base(message)
    {
    }

    public TimeSignatureException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
