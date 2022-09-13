using Isu.Models;

namespace Isu.Entities;
public class Group
{
    private static int nextId = 0; // TODO: change so tests work properly
    private int maxCapacity = 20;

    private GroupName groupName;
    private CourseNumber courseNumber;
    private List<int> students = new List<int>();

    public Group(GroupName groupName)
    {
        this.groupName = groupName;
        courseNumber = new CourseNumber(groupName.GetGroupName());
        Group.nextId++;
    }

    public GroupName GetGroupName()
    {
        return groupName;
    }

    public CourseNumber GetCourseNumber()
    {
        return courseNumber;
    }

    public void AddStudent(int studentId)
    {
        if (students.Count == maxCapacity)
            throw new Exception(); // TODO: extract to class

        students.Add(studentId);
    }

    public void RemoveStudent(int studentId)
    {
        // TODO: Check if group contains student
        students.Remove(studentId);
    }

    public List<int> GetStudentIds()
    {
        // TODO: return Readonly collection
        return students;
    }
}
