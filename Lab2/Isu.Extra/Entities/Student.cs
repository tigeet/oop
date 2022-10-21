using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities;

public class Student
{
  private List<CourseFlow> _courses = new List<CourseFlow>();
  public Student(Group group, string name)
  {
    Name = name;
    Group = group;
    Id = Guid.NewGuid();
  }

  public List<CourseFlow> Courses
  {
    get
    {
      return new List<CourseFlow>(_courses);
    }
  }

  public Guid Id { get; }
  public string Name { get; }
  public Group Group { get; private set; }

  public void AddFlow(CourseFlow flow)
  {
    if (_courses.Contains(flow))
      throw new StudentAlreadyAssignedException();

    if (_courses.Count == 2)
      throw new TooManyFlowsException();

    if (Group.Faculty.Letter == flow.Course.Faculty.Letter)
      throw new SameFacultyException();

    _courses.Add(flow);
  }

  public void RemoveFlow(CourseFlow flow)
  {
    if (!_courses.Contains(flow))
      throw new StudentNotAssignedException();

    _courses.Remove(flow);
  }

  public void ChangeGroup(Group group)
  {
    Group = group;
  }
}
