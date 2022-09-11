namespace Isu.Entities;
using Isu.Models;
public class Group
{
  private static int nextId = 0;
  private int maxCapacity = 20;

  private GroupName groupName;
  private int studentsAmount;
  private CourseNumber courseNumber;

  public Group(GroupName groupName)
  {
    this.groupName = groupName;
    this.studentsAmount = 0;
    this.courseNumber = new CourseNumber(groupName.GetGroupName());
    Group.nextId++;
  }

  public GroupName GetGroupName()
  {
    return this.groupName;
  }

  public CourseNumber GetCourseNumber()
  {
    return this.courseNumber;
  }

  public void AddStudent()
  {
    this.studentsAmount++;

    if (this.studentsAmount == this.maxCapacity)
      throw new Exception(); // extract to class;
  }

  public void RemoveStudent()
  {
    this.studentsAmount--;
  }
}
