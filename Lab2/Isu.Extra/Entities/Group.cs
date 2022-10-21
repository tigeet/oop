using Isu.Extra.Models;
namespace Isu.Extra.Entities;

public class Group : Models.Flow
{
  public Group(GroupName groupName)
      : base()
  {
    GroupName = groupName;
    Faculty = new Faculty(groupName.FacultyLetter);
    CourseNumber = new CourseNumber(groupName.CourseLetter);
  }

  public GroupName GroupName { get; }
  public Faculty Faculty { get; }
  public CourseNumber CourseNumber { get; }

  public List<Student> NotAssigned
  {
    get
    {
      var students = new List<Student>();
      foreach (Student student in Students)
      {
        if (student.Courses.Count != 0)
          continue;
        students.Add(student);
      }

      return students;
    }
  }
}
