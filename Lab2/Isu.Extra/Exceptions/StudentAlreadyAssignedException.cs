namespace Isu.Extra.Exceptions;

public class StudentAlreadyAssignedException : Exception
{
  private const string ErrorMessage = "Student is already assigned";
  public StudentAlreadyAssignedException()
      : base(ErrorMessage) { }

  public StudentAlreadyAssignedException(string message)
          : base(message)
  {
  }

  public StudentAlreadyAssignedException(string message, Exception inner)
      : base(message, inner)
  {
  }
}
