using Isu.Entities;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities;

public class StudentExtra
{
    private List<CourseFlow> _courses = new List<CourseFlow>();
    public StudentExtra(Student student, GroupExtra groupExtra)
    {
        Student = student;
        GroupExtra = groupExtra;
    }

    public Student Student { get; }

    public IReadOnlyCollection<CourseFlow> Courses
    {
        get
        {
            return _courses;
        }
    }

    public GroupExtra GroupExtra { get; private set; }

    public void AddFlow(CourseFlow flow)
    {
        if (_courses.Contains(flow))
            throw new StudentAlreadyAssignedException();

        if (_courses.Count == 2)
            throw new TooManyFlowsException();

        if (GroupExtra.Faculty.Letter == flow.Course.Faculty.Letter)
            throw new SameFacultyException();

        _courses.Add(flow);
    }

    public void RemoveFlow(CourseFlow flow)
    {
        if (!_courses.Contains(flow))
            throw new StudentNotAssignedException();

        _courses.Remove(flow);
    }

    public void ChangeGroupExtra(GroupExtra group)
    {
        GroupExtra = group;
    }
}
