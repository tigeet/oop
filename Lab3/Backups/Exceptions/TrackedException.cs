namespace Backups.Exceptions;
public class TrackedException : Exception
{
    public TrackedException()
        : base()
    {
    }

    public TrackedException(string message)
            : base(message)
    {
    }

    public TrackedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}