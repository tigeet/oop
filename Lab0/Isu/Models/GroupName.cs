using Isu.Exceptions;
namespace Isu.Models;

public class GroupName
{
    private string groupName;
    public GroupName(string groupName)
    {
        if (!Utils.Utils.IsValidGroupName(groupName))
        {
            throw new GroupNameException();
        }

        this.groupName = groupName;
    }

    public string GetGroupName()
    {
        return groupName;
    }
}
