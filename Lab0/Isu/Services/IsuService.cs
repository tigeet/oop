using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;

namespace Isu.Services;
public class IsuService : IIsuService
{
    private Dictionary<GroupName, Group> groups = new Dictionary<GroupName, Group>();
    private Dictionary<int, Student> students = new Dictionary<int, Student>();
    private StudentIdFactory studentIdFactory = new StudentIdFactory();

    public Group AddGroup(GroupName name)
    {
        if (groups.ContainsKey(name))
            throw new GroupOverflowException();

        var group = new Group(name);
        groups[name] = group;
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        int studentId = studentIdFactory.GetNewId();
        var student = new Student(group, name, studentId);
        group.AddStudent(student);
        students[studentId] = student;
        return student;
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        Group oldGroup = groups[student.GetGroup().GetGroupName()];
        newGroup.AddStudent(student);
        oldGroup.RemoveStudent(student);
        student.SetGroup(newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        if (groups.ContainsKey(groupName))
            return groups[groupName];

        return null;
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return groups.Values.ToArray()
          .Where(g => g.GetCourseNumber() == courseNumber)
          .ToList();
    }

    public Student? FindStudent(int id)
    {
        if (students.ContainsKey(id))
            return students[id];

        return null;
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        return groups[groupName].GetStudents();
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        return students.Values.ToArray()
          .Where(s => s.GetCourseNumber() == courseNumber)
          .ToList();
    }

    public Student GetStudent(int id)
    {
        if (!students.ContainsKey(id))
        {
            throw new StudentDoesNotExistException();
        }

        return students[id];
    }

    public void RemoveStudent(Student student)
    {
        int id = student.GetStudentId();

        if (!students.ContainsKey(id))
            throw new RemoveUnexistingStudentException();

        students.Remove(id);
        Group group = student.GetGroup();
        group.RemoveStudent(student);
    }
}
