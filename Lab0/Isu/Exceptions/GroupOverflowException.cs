using Isu.Entities;
namespace Isu.Exceptions;
public class GroupOverflowException : Exception
{
    public GroupOverflowException()
        : base("Failed assigning student to the group: Group has no extra space") { }

    public GroupOverflowException(Student student, Group group)
        : base("Failed assiging student #" + student.GetStudentId() + " to group " + group.GetGroupName() + ": Group has no extra space") { }

    public GroupOverflowException(string message)
            : base(message)
    {
    }

    public GroupOverflowException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
