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
            throw new StudentException("student is already assigned");

        if (_courses.Count == 2)
            throw new FlowException("cant assign student to too many flows(max = 2)");

        if (GroupExtra.Faculty.Letter == flow.Course.Faculty.Letter)
            throw new FacultyException("students facutly matches course faculty");

        _courses.Add(flow);
    }

    public void RemoveFlow(CourseFlow flow)
    {
        if (!_courses.Contains(flow))
            throw new StudentException("student not assigned to that course");

        _courses.Remove(flow);
    }

    public void ChangeGroupExtra(GroupExtra group)
    {
        GroupExtra = group;
    }
}
