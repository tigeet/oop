using System.Collections.ObjectModel;
using Isu.Exceptions;
using Isu.Models;
namespace Isu.Entities;
public class Group
{
    private int maxCapacity = 20;

    private GroupName groupName;
    private CourseNumber courseNumber;
    private List<Student> students = new List<Student>();

    public Group(GroupName groupName)
    {
        this.groupName = groupName;
        courseNumber = new CourseNumber(groupName.GetGroupName());
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
            throw new GroupOverflowException(student, this);

        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public ReadOnlyCollection<Student> GetStudents()
    {
        return new ReadOnlyCollection<Student>(students);
    }
}
