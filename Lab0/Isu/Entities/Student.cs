namespace Isu.Entities;

using Isu.Models;
public class Student {
  private static int nextId = 0;

  private int studentId;
  private string name;
  private GroupName groupName;
  private CourseNumber courseNumber;

  public Student(Group group, string name) {
    this.studentId = nextId;
    this.name = name;
    this.groupName = group.GetGroupName();
    this.courseNumber = group.GetCourseNumber();

    Student.nextId++;
  }

  public int GetStudentId() {
    return this.studentId;
  }

  public string GetName() {
    return this.name;
  }

  public GroupName GetGroupName() {
    return this.groupName;
  }

  public CourseNumber GetCourseNumber() {
    return this.courseNumber;
  }

  public void SetGroup(Group group) {
    this.groupName = group.GetGroupName();
  }
}