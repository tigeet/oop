using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Xunit;

namespace Isu.Test;

public class IsuService
{
    private Services.IsuService isuService;

    public IsuService()
    {
        isuService = new Services.IsuService();
    }

    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var groupName1 = new GroupName("M32011");
        Group group1 = isuService.AddGroup(groupName1);
        Student student = isuService.AddStudent(group1, "name-1");

        Assert.Contains(student, isuService.FindStudents(groupName1));
        Assert.Equal(group1, isuService.FindGroup(student.GetGroup().GetGroupName()));
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var groupName = new GroupName("M32001");
        var group = new Group(groupName);
        int totalEntries = group.GetMaxCapacity() + 1;

        Assert.Throws<GroupOverflowException>(() =>
        {
            for (int i = 0; i < totalEntries; i++)
            {
                isuService.AddStudent(group, "student#" + (i + 1));
            }
        });
    }

    [Theory]
    [InlineData("M3101000")]
    [InlineData("E3101")]
    [InlineData("M3601")]
    public void CreateGroupWithInvalidName_ThrowException(string groupName)
    {
        Assert.Throws<GroupNameException>(() => new GroupName(groupName));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var groupName1 = new GroupName("M32011");
        var groupName2 = new GroupName("A42001");

        Group group1 = isuService.AddGroup(groupName1);
        Group group2 = isuService.AddGroup(groupName2);
        Student student = isuService.AddStudent(group1, "name-1");

        Assert.Contains(student, isuService.FindStudents(groupName1));

        isuService.ChangeStudentGroup(student, group2);

        Assert.DoesNotContain(student, isuService.FindStudents(groupName1));
        Assert.Contains(student, isuService.FindStudents(groupName2));
    }
}
