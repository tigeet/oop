namespace Backups.Exceptions;
public class MemoryException : Exception
{
    public MemoryException()
        : base() { }

    public MemoryException(string message)
            : base(message)
    {
    }

    public MemoryException(string message, Exception inner)
        : base(message, inner)
    {
    }
}