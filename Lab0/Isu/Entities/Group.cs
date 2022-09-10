namespace Isu.Entities;
using Isu.Models;
public class Group {
  private static int nextId = 0;

  private GroupName groupName;
  private int groupId;
  private CourseNumber courseNumber;
  private int MAX_CAPACITY = 20;

  public Group(GroupName groupName) {
    // generate id
    this.groupName = groupName;
    this.groupId = Group.nextId;
    this.courseNumber = new CourseNumber(groupName.GetGroupName());
    Group.nextId++;

  }

  public int GetGroupId() {
    return this.groupId;
  }

  public GroupName GetGroupName() {
    return this.groupName;
  }

  public CourseNumber GetCourseNumber() {
    return this.courseNumber;
  }

  public int getMaxCapacity() {
    return this.MAX_CAPACITY;
  }
}
