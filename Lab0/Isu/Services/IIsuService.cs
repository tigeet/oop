using Isu.Entities;
using Isu.Models;
namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(GroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student? FindStudent(int id);
    List<Student> FindStudents(GroupName groupName);
    List<Student> FindStudents(CourseNumber courseNumber);

    Group? FindGroup(GroupName groupName);
    List<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}

public class IsuService : IIsuService
{
    private Dictionary<GroupName, Group> groups = new Dictionary<GroupName, Group>();
    private Dictionary<int, Student> students = new Dictionary<int, Student>();

    public Group AddGroup(GroupName name)
    {
        var group = new Group(name);
        groups[name] = group;
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        var student = new Student(group, name);
        group.AddStudent(student.GetStudentId());
        students[student.GetStudentId()] = student;
        return student;
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        Group oldGroup = groups[student.GetGroupName()];
        newGroup.AddStudent(student.GetStudentId());
        oldGroup.RemoveStudent(student.GetStudentId());
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
        var foundGroups = (from g in groups.Values.ToArray() where g.GetCourseNumber() == courseNumber select g).ToList();
        return foundGroups;
    }

    public Student? FindStudent(int id)
    {
        if (students.ContainsKey(id))
            return students[id];

        return null;
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        return new List<Student>(groups[groupName].GetStudentIds().Select<int, Student>(id => students[id]));
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        var foundStudents = (from s in students.Values.ToArray() where s.GetCourseNumber() == courseNumber select s).ToList();
        return foundStudents;
    }

    public Student GetStudent(int id)
    {
        throw new NotImplementedException();
    }

    public Dictionary<GroupName, Group> GetGroups()
    {
        return groups;
    }
}
