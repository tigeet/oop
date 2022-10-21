using Isu.Extra.Exceptions;
namespace Isu.Extra.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        if (!Utils.Utils.IsValidGroupName(groupName))
        {
            throw new GroupNameException();
        }

        GroupNameValue = groupName;
    }

    public string GroupNameValue { get; }
    public char FacultyLetter
    {
        get
        {
            return GroupNameValue[0];
        }
    }

    public char CourseLetter
    {
        get
        {
            return GroupNameValue[2];
        }
    }
}
