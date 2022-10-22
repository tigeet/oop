using Isu.Extra.Exceptions;
using Isu.Extra.Models;
namespace Isu.Extra.Entities;

public class Course
{
    private List<CourseFlow> _flows = new List<CourseFlow>();

    public Course(Faculty faculty)
    {
        MaxCapacity = 100;
        Faculty = faculty;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public Faculty Faculty { get; }
    public IReadOnlyCollection<CourseFlow> Flows { get { return _flows; } }
    public int MaxCapacity { get; }
    public int Capacity { get; }

    public IReadOnlyCollection<StudentExtra> Students
    {
        get
        {
            return Flows.SelectMany(f => f.Students).ToList();
        }
    }

    public CourseFlow AddFlow(params Lesson[] lessons)
    {
        var flow = new CourseFlow(this);
        flow.AddInterval(lessons);
        _flows.Add(flow);
        return flow;
    }

    public void RemoveFlow(CourseFlow flow)
    {
        if (!_flows.Contains(flow))
            throw new FlowDoesNotExistException();

        _flows.Remove(flow);
    }

    public void AddStudent(StudentExtra student)
    {
        if (Students.Contains(student))
            throw new StudentAlreadyAssignedException();

        if (student.GroupExtra.Faculty.Letter == Faculty.Letter)
            throw new SameFacultyException();

        CourseFlow? flow = _flows.Where(f => !f.HasCollisions(student.GroupExtra)).Where(f => !f.IsFull).FirstOrDefault();

        if (flow is null)
         throw new NoSuitableFlowsException();

        flow.AddStudent(student);
        student.AddFlow(flow);
    }

    public void RemoveStudent(StudentExtra student)
    {
        CourseFlow? flow = _flows.Where(f => f.Students.Contains(student)).FirstOrDefault();

        if (flow is null)
            throw new StudentNotAssignedException();

        flow.RemoveStudent(student);
        student.RemoveFlow(flow);
    }

    public bool HasStudent(StudentExtra student)
    {
        return Students.Contains(student);
    }
}