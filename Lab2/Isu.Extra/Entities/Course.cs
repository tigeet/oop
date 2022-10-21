using Isu.Extra.Models;
using Isu.Extra.Exceptions;
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
  public List<CourseFlow> Flows { get { return new List<CourseFlow>(_flows); } }
  public int MaxCapacity { get; }
  public int Capacity { get; }

  public List<Student> Students
  {
    get
    {
      var res = new List<Student>();
      foreach (CourseFlow flow in _flows)
      {
        res.AddRange(flow.Students);
      }

      return res;
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

  public void AddStudent(Student student)
  {
    foreach (CourseFlow flow in _flows)
    {
      if (flow.IsFull)
        continue;

      flow.AddStudent(student);
      student.AddFlow(flow);
      return;
    }

    throw new NoEmptyFlowsException();
  }

  public void RemoveStudent(Student student)
  {
    foreach (CourseFlow flow in _flows)
    {
      if (!flow.Students.Contains(student))
        continue;

      flow.RemoveStudent(student);
      student.RemoveFlow(flow);
      return;
    }

    throw new StudentNotAssignedException();
  }

  public bool HasStudent(Student student)
  {
    return Students.Contains(student);
  }
}