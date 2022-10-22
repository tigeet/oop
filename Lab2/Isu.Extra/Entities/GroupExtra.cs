using Isu.Entities;
using Isu.Extra.Models;

namespace Isu.Extra.Entities;
public class GroupExtra : Flow
{
    public GroupExtra(Group group)
        : base()
    {
        Group = group;
        Faculty = new Faculty(group.GetGroupName().GetGroupName()[0]);
    }

    public Faculty Faculty { get; }
    public Group Group { get; }

    public IReadOnlyCollection<StudentExtra> NotAssigned
    {
        get
        {
            return Students.Where(s => s.Courses.Count == 0).ToList();
        }
    }
}
