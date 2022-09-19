using System.Collections.ObjectModel;
using Isu.Entities;
using Isu.Models;
namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(GroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student? FindStudent(int id);
    ReadOnlyCollection<Student> FindStudents(GroupName groupName);
    ReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber);

    Group? FindGroup(GroupName groupName);
    ReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
    void RemoveStudent(Student student);
}

public class IsuService : IIsuService
{
    private Dictionary<GroupName, Group> groups = new Dictionary<GroupName, Group>();
    private Dictionary<int, Student> students = new Dictionary<int, Student>();
    private StudentIdFactory studentIdFactory = new StudentIdFactory();

    public Group AddGroup(GroupName name)
    {
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
        Console.WriteLine(studentId);
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

    public ReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber)
    {
        var foundGroups = (from g in groups.Values.ToArray() where g.GetCourseNumber() == courseNumber select g).ToList();
        return new ReadOnlyCollection<Group>(foundGroups);
    }

    public Student? FindStudent(int id)
    {
        if (students.ContainsKey(id))
            return students[id];

        return null;
    }

    public ReadOnlyCollection<Student> FindStudents(GroupName groupName)
    {
        return new ReadOnlyCollection<Student>(groups[groupName].GetStudents());
    }

    public ReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber)
    {
        var foundStudents = (from s in students.Values.ToArray() where s.GetCourseNumber() == courseNumber select s).ToList();
        return new ReadOnlyCollection<Student>(foundStudents);
    }

    public Student GetStudent(int id)
    {
        throw new NotImplementedException();
    }

    public void RemoveStudent(Student student)
    {
        int id = student.GetStudentId();
        if (students.ContainsKey(id))
        {
            students.Remove(id);
            Group group = student.GetGroup();
            group.RemoveStudent(student);
            studentIdFactory.ReturnId(student);
        }
    }
}
