using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Models;
using Isu.Models;
using Isu.Services;

namespace Isu.Extra.Services;
public class IsuServiceExtra
{
    private Dictionary<Group, GroupExtra> _groups = new Dictionary<Group, GroupExtra>();
    private Dictionary<Student, StudentExtra> _students = new Dictionary<Student, StudentExtra>();
    private Dictionary<Guid, Course> _courses = new Dictionary<Guid, Course>();
    private StudentIdFactory studentIdFactory = new StudentIdFactory();
    public IsuServiceExtra(IsuService isuService)
    {
        IsuService = isuService;
    }

    public IReadOnlyCollection<Course> Courses { get { return _courses.Values; } }
    public IReadOnlyCollection<GroupExtra> Groups { get { return _groups.Values; } }
    public IReadOnlyCollection<StudentExtra> Students { get { return _students.Values; } }
    public IsuService IsuService { get; }
    public GroupExtra AddGroup(GroupName groupName)
    {
        Group group = IsuService.AddGroup(groupName);
        var groupExtra = new GroupExtra(group);
        _groups[group] = groupExtra;
        return groupExtra;
    }

    public StudentExtra AddStudent(GroupExtra groupExtra, string name)
    {
        Student student = IsuService.AddStudent(groupExtra.Group, name);
        var studentExtra = new StudentExtra(student, groupExtra);
        groupExtra.AddStudent(studentExtra);
        _students[student] = studentExtra;
        return studentExtra;
    }

    public Course AddCourse(Faculty faculty)
    {
        var course = new Course(faculty);
        _courses[course.Id] = course;
        return course;
    }
}
