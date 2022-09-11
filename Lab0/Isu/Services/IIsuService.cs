using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService
{
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

public class IsuService : IIsuService
{
  private Dictionary<GroupName, Group> groups = new Dictionary<GroupName, Group>();
  private Dictionary<int, Student> students = new Dictionary<int, Student>();

  public Group AddGroup(GroupName name)
  {
    Group group = new Group(name);
    this.groups[name] = group;
    return group;
  }

  public Student AddStudent(Group group, string name)
  {
    Student student = new Student(group, name);
    group.AddStudent();
    this.students[student.GetStudentId()] = student;
    return student;
  }

  public void ChangeStudentGroup(Student student, Group newGroup)
  {
    Group oldGroup = this.groups[student.GetGroupName()];
    newGroup.AddStudent(); // Если группа заполнена, выкинет ошибку
    oldGroup.RemoveStudent();
    student.SetGroup(newGroup);
  }

  public Group? FindGroup(GroupName groupName)
  {
    if (this.groups.ContainsKey(groupName))
      return this.groups[groupName];

    return null;
  }

  public List<Group> FindGroups(CourseNumber courseNumber)
  {
    List<Group> foundGroups = (from g in this.groups.Values.ToArray() where g.GetCourseNumber() == courseNumber select g).ToList();
    return foundGroups;
  }

  public Student? FindStudent(int id)
  {
    if (this.students.ContainsKey(id))
      return this.students[id];

    return null;
  }

  public List<Student> FindStudents(GroupName groupName)
  {
    List<Student> foundStudents = (from s in this.students.Values.ToArray() where s.GetGroupName().Equals(groupName) select s).ToList();
    return foundStudents;
  }

  public List<Student> FindStudents(CourseNumber courseNumber)
  {
    List<Student> foundStudents = (from s in this.students.Values.ToArray() where s.GetCourseNumber() == courseNumber select s).ToList();
    return foundStudents;
  }

  public Student GetStudent(int id)
  {
    throw new NotImplementedException();
  }

  public Dictionary<GroupName, Group> GetGroups()
  {
    return this.groups;
  }
}