using Isu.Models;

namespace Isu.Entities;
public class Student
{
    private static int nextId = 0;

    private int studentId;
    private string name;
    private GroupName groupName;
    private CourseNumber courseNumber;

    public Student(Group group, string name)
    {
        studentId = nextId;
        this.name = name;
        groupName = group.GetGroupName();
        courseNumber = group.GetCourseNumber();

        Student.nextId++;
    }

    public int GetStudentId()
    {
        return studentId;
    }

    public string GetName()
    {
        return name;
    }

    public GroupName GetGroupName()
    {
        return groupName;
    }

    public CourseNumber GetCourseNumber()
    {
        return courseNumber;
    }

    public void SetGroup(Group group)
    {
        groupName = group.GetGroupName();
    }
}
