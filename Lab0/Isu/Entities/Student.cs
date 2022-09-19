using Isu.Models;
namespace Isu.Entities;

public class Student
{
    private int id;
    private string name;
    private Group group;

    private CourseNumber courseNumber;

    public Student(Group group, string name, int id)
    {
        this.name = name;
        this.group = group;
        this.id = id;
        courseNumber = group.GetCourseNumber();
    }

    public int GetStudentId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public Group GetGroup()
    {
        return group;
    }

    public CourseNumber GetCourseNumber()
    {
        return courseNumber;
    }

    public void SetGroup(Group group)
    {
        this.group = group;
    }
}
