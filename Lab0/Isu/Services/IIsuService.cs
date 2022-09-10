using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService {
  Group AddGroup(GroupName name);
  Student AddStudent(Group group, string name);

  Student GetStudent(int id);
  Student? FindStudent(int id);
  List<Student> FindStudents(GroupName groupName);
  List<Student> FindStudents(CourseNumber courseNumber);

  Group? FindGroup(GroupName groupName);
  List<Group> FindGroups(CourseNumber courseNumber);

  void ChangeStudentGroup(Student student, Group newGroup);
}


public class IsuService : IIsuService {
  private Dictionary<GroupName, Group> groups = new Dictionary<GroupName, Group>();
  private Dictionary<int, Student> students = new Dictionary<int, Student>();
  private Dictionary<GroupName, int> groupCapacity = new Dictionary<GroupName, int>();

  public Group AddGroup(GroupName name) {
    Group group = new Group(name);
    this.groups.Add(name, group);
    return group;
  }

  public Student AddStudent(Group group, string name) {
    Student student = new Student(group, name);
    this.students.Add(student.GetStudentId(), student);
    return student;
  }


  // check once again
  public void ChangeStudentGroup(Student student, Group newGroup) {
    GroupName currentGroupName = student.GetGroupName();
    GroupName nextGroupName = newGroup.GetGroupName();

    if (this.groupCapacity.ContainsKey(nextGroupName)) {
      this.groupCapacity[nextGroupName] = 0;
    }

    if (this.groupCapacity[nextGroupName] == newGroup.getMaxCapacity())
      throw new Exception("Group " + newGroup.GetGroupName() + " already contains maximum amount of students");

    groupCapacity[currentGroupName] = groupCapacity[currentGroupName] - 1;
    groupCapacity[nextGroupName] = groupCapacity[nextGroupName] + 1;
    student.SetGroup(newGroup);
  }

  public Group? FindGroup(GroupName groupName) {
    throw new NotImplementedException();
  }

  public List<Group> FindGroups(CourseNumber courseNumber) {
    throw new NotImplementedException();
  }

  public Student? FindStudent(int id) {
    throw new NotImplementedException();
  }

  public List<Student> FindStudents(GroupName groupName) {
    throw new NotImplementedException();
  }

  public List<Student> FindStudents(CourseNumber courseNumber) {
    throw new NotImplementedException();
  }

  public Student GetStudent(int id) {
    throw new NotImplementedException();
  }
}