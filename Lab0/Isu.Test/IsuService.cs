using Xunit;

namespace Isu.Test;
using Isu.Entities;
using Isu.Models;
using Isu.Services;

public class IsuService
{
  [Fact]
  public void AddStudent_GetStudentWorks()
  {
    Isu.Services.IsuService isuService = new Isu.Services.IsuService();
    GroupName groupName1 = new GroupName("M3101");
    GroupName groupName2 = new GroupName("A42001");

    Group group1 = isuService.AddGroup(groupName1);
    Group group2 = isuService.AddGroup(groupName2);

    Student student1 = isuService.AddStudent(group1, "name-1");
    Student student2 = isuService.AddStudent(group1, "name-2");
    Student student3 = isuService.AddStudent(group2, "name-3");

    Assert.Equal(student1, isuService.FindStudent(student1.GetStudentId()));
    Assert.Equal(student2, isuService.FindStudent(student2.GetStudentId()));
    Assert.Equal(student3, isuService.FindStudent(student3.GetStudentId()));
  }

/*
  Add student to group1
  Check if group1 contains student
  Change student's group from group1 to group2
  Check if group2 contains student and group1 does not
*/
  [Fact]
  public void ChangeGroupWorks()
  {
    Isu.Services.IsuService isuService = new Isu.Services.IsuService();
    GroupName groupName1 = new GroupName("M32011");
    GroupName groupName2 = new GroupName("A42001");

    Group group1 = isuService.AddGroup(groupName1);
    Group group2 = isuService.AddGroup(groupName2);
    Student? student = isuService.AddStudent(group1, "name-1");

    Assert.Contains(student, isuService.FindStudents(groupName1));

    isuService.ChangeStudentGroup(student, group2);

    Assert.DoesNotContain(student, isuService.FindStudents(groupName1));
    Assert.Contains(student, isuService.FindStudents(groupName2));
  }

  [Fact]
  public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
  {
    Isu.Services.IsuService isuService = new Isu.Services.IsuService();

    GroupName groupName1 = new GroupName("M32011");
    Group group1 = isuService.AddGroup(groupName1);
    Student? student = isuService.AddStudent(group1, "name-1");

    // Assert group contains student
    Assert.Contains(student, isuService.FindStudents(groupName1));

    // Assert student has group
    Assert.Equal(group1, isuService.FindGroup(student.GetGroupName()));
  }

  [Fact]
  public void ReachMaxStudentPerGroup_ThrowException()
  {
    const int maxStudentCount = 20;

    Isu.Services.IsuService isuService = new Isu.Services.IsuService();
    GroupName groupName = new GroupName("M32001");
    Group group = new Group(groupName);

    // Add exact amount so next AddStudent should throw an error
    for (int i = 1; i < maxStudentCount; i++)
    {
      isuService.AddStudent(group, "student#" + i);
    }

    Assert.Throws<Exception>(() => isuService.AddStudent(group, "student#20")); // Add custom exception class
  }

  [Fact]
  public void CreateGroupWithInvalidName_ThrowException()
  {
    // Incorrect length
    Assert.Throws<Exception>(() => new GroupName("M31010000"));

    // Incorrect Letter
    Assert.Throws<Exception>(() => new GroupName("E3101"));

    // Incorrect course
    Assert.Throws<Exception>(() => new GroupName("M3601"));
  }

/*
  Add student to group1
  Check if group1 contains student
  Change student's group from group1 to group2
  Check if group2 contains student and group1 does not
*/
  [Fact]
  public void TransferStudentToAnotherGroup_GroupChanged()
  {
    Isu.Services.IsuService isuService = new Isu.Services.IsuService();
    GroupName groupName1 = new GroupName("M32011");
    GroupName groupName2 = new GroupName("A42001");

    Group group1 = isuService.AddGroup(groupName1);
    Group group2 = isuService.AddGroup(groupName2);
    Student? student = isuService.AddStudent(group1, "name-1");

    Assert.Contains(student, isuService.FindStudents(groupName1));

    isuService.ChangeStudentGroup(student, group2);

    Assert.DoesNotContain(student, isuService.FindStudents(groupName1));
    Assert.Contains(student, isuService.FindStudents(groupName2));
  }
}