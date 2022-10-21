
namespace Isu.Extra.Exceptions;

public class NoEmptyFlowsException : Exception
{
  private const string ErrorMessage = "no empty flows";
  public NoEmptyFlowsException()
      : base(ErrorMessage) { }

  public NoEmptyFlowsException(string message)
          : base(message)
  {
  }

  public NoEmptyFlowsException(string message, Exception inner)
      : base(message, inner)
  {
  }
}
