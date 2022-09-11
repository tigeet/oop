using System.Text.RegularExpressions;
namespace Isu.Models;

public class GroupName
{
  private string groupName;

  public GroupName(string groupName)
  {
    ValidateName(groupName);
    this.groupName = groupName;
  }

  public string GetGroupName()
  {
    return this.groupName;
  }

  private void ValidateName(string groupName)
  {
    const string pattern = @"^[ABCDFKLMNPRTUVWXYZ][3-5][1-5]\d\d\d?c?$";
    MatchCollection matches = Regex.Matches(groupName, pattern, RegexOptions.IgnorePatternWhitespace);
    if (matches.Count == 0)
      throw new Exception(); // Extract to class
  }
}
