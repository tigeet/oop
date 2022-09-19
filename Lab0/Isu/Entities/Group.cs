using Isu.Models;

namespace Isu.Entities;
public class Group
{
    private static int nextId = 0; // TODO: change so tests work properly
    private int maxCapacity = 20;

    private GroupName groupName;
    private CourseNumber courseNumber;
    private List<Student> students = new List<Student>();

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

    public void AddStudent(Student student)
    {
        if (students.Count == maxCapacity)
            throw new Exception(); // TODO: extract to class

        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        // TODO: Check if group contains student
        students.Remove(student);
    }

    public List<Student> GetStudents()
    {
        // TODO: return Readonly collection
        return students;
    }
}
