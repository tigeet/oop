using Isu.Models;

namespace Isu.Entities;
public class Student
{
    private static int nextId = 100000;

    private int studentId;
    private string name;
    private Group group;

    private CourseNumber courseNumber;

    public Student(Group group, string name)
    {
        studentId = nextId;
        this.name = name;
        this.group = group;
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
