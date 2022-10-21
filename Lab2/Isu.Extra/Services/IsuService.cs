using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Extra.Models;

namespace Isu.Extra.Services;
public class IsuService : IIsuService
{
    private Dictionary<GroupName, Group> _groups = new Dictionary<GroupName, Group>();
    private Dictionary<Guid, Student> _students = new Dictionary<Guid, Student>();
    private Dictionary<Guid, Course> _courses = new Dictionary<Guid, Course>();

    public List<Course> Courses { get { return new List<Course>(_courses.Values); } }
    public List<Group> Groups { get { return new List<Group>(_groups.Values); } }
    public List<Student> Students { get { return new List<Student>(_students.Values); } }

    public Group AddGroup(GroupName name)
    {
        if (_groups.ContainsKey(name))
            throw new FlowOverflowException();

        var group = new Group(name);
        _groups[name] = group;
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        var student = new Student(group, name);
        group.AddStudent(student);
        _students[student.Id] = student;
        return student;
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        Group oldGroup = student.Group;
        newGroup.AddStudent(student);
        oldGroup.RemoveStudent(student);
        student.ChangeGroup(newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        if (_groups.ContainsKey(groupName))
            return _groups[groupName];

        return null;
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return _groups.Values.ToArray()
          .Where(g => g.CourseNumber == courseNumber)
          .ToList();
    }

    public Student? FindStudent(Guid id)
    {
        if (_students.ContainsKey(id))
            return _students[id];

        return null;
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        return _groups[groupName].Students;
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        return _students.Values.ToArray()
          .Where(s => s.Group.CourseNumber.CourseNumberValue == courseNumber.CourseNumberValue)
          .ToList();
    }

    public Student GetStudent(Guid id)
    {
        if (!_students.ContainsKey(id))
        {
            throw new StudentDoesNotExistException();
        }

        return _students[id];
    }

    public void RemoveStudent(Student student)
    {
        Guid id = student.Id;

        if (!_students.ContainsKey(id))
            throw new RemoveUnexistingStudentException();

        _students.Remove(id);
        Group group = student.Group;
        group.RemoveStudent(student);
    }

    public Course AddCourse(Faculty faculty)
    {
        var course = new Course(faculty);
        _courses[course.Id] = course;
        return course;
    }
}
