namespace Isu.Extra.Exceptions;

public class SameFacultyException : Exception
{
  private const string ErrorMessage = "same faculty";
  public SameFacultyException()
      : base(ErrorMessage) { }

  public SameFacultyException(string message)
          : base(message)
  {
  }

  public SameFacultyException(string message, Exception inner)
      : base(message, inner)
  {
  }
}
