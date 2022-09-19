using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Xunit;

namespace Isu.Test;
public class IsuService
{
    [Fact]
    public void RemoveStudentWorks()
    {
        var isuService = new Isu.Services.IsuService();
        var groupName1 = new GroupName("M3101");
        Group group1 = isuService.AddGroup(groupName1);
        Student student1 = isuService.AddStudent(group1, "name-1");
        Student student2 = isuService.AddStudent(group1, "name-2");
        Student student3 = isuService.AddStudent(group1, "name-3");
        Assert.Contains(student1, isuService.FindStudents(groupName1));

        isuService.RemoveStudent(student2);
        isuService.RemoveStudent(student3);

        Student student4 = isuService.AddStudent(group1, "name-4");
        Student student5 = isuService.AddStudent(group1, "name-5");
        Assert.Contains(student4, isuService.FindStudents(groupName1));
        Assert.Contains(student5, isuService.FindStudents(groupName1));
        Assert.DoesNotContain(student2, isuService.FindStudents(groupName1));
        Assert.DoesNotContain(student3, isuService.FindStudents(groupName1));
    }

    [Fact]

    public void AddStudent_GetStudentWorks()
    {
        var isuService = new Isu.Services.IsuService();
        var groupName1 = new GroupName("M3101");
        var groupName2 = new GroupName("A42001");

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
        var isuService = new Isu.Services.IsuService();
        var groupName1 = new GroupName("M32011");
        var groupName2 = new GroupName("A42001");

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
        var isuService = new Isu.Services.IsuService();

        var groupName1 = new GroupName("M32011");
        Group group1 = isuService.AddGroup(groupName1);
        Student? student = isuService.AddStudent(group1, "name-1");

        // Assert group contains student
        Assert.Contains(student, isuService.FindStudents(groupName1));

        // Assert student has group
        Assert.Equal(group1, isuService.FindGroup(student.GetGroup().GetGroupName()));
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        const int maxStudentCount = 20;

        var isuService = new Isu.Services.IsuService();
        var groupName = new GroupName("M32001");
        var group = new Group(groupName);

        // Add exact amount so next AddStudent should throw an error
        for (int i = 0; i < maxStudentCount; i++)
        {
            isuService.AddStudent(group, "student#" + (i + 1));
        }

        Assert.Throws<GroupOverflowException>(() => isuService.AddStudent(group, "student#21")); // Add custom exception class
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        // Incorrect length
        Assert.Throws<GroupNameException>(() => new GroupName("M31010000"));

        // Incorrect Letter
        Assert.Throws<GroupNameException>(() => new GroupName("E3101"));

        // Incorrect course
        Assert.Throws<GroupNameException>(() => new GroupName("M3601"));
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
        var isuService = new Isu.Services.IsuService();
        var groupName1 = new GroupName("M32011");
        var groupName2 = new GroupName("A42001");

        Group group1 = isuService.AddGroup(groupName1);
        Group group2 = isuService.AddGroup(groupName2);
        Student? student = isuService.AddStudent(group1, "name-1");

        Assert.Contains(student, isuService.FindStudents(groupName1));

        isuService.ChangeStudentGroup(student, group2);

        Assert.DoesNotContain(student, isuService.FindStudents(groupName1));
        Assert.Contains(student, isuService.FindStudents(groupName2));
    }
}
