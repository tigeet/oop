namespace Isu.Extra.Exceptions;

public class IntervalDoesNotExist : Exception
{
    private const string ErrorMessage = "Interval does not exist";
    public IntervalDoesNotExist()
        : base(ErrorMessage) { }

    public IntervalDoesNotExist(string message)
            : base(message)
    {
    }

    public IntervalDoesNotExist(string message, Exception inner)
        : base(message, inner)
    {
    }
}
