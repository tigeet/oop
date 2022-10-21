using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Extra.Models;
using Xunit;

namespace Isu.Extra.Test;

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
        Assert.Equal(group1, isuService.FindGroup(student.Group.GroupName));
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var groupName = new GroupName("M32001");
        Group group = isuService.AddGroup(groupName);
        int totalEntries = group.MaxCapacity + 1;

        Assert.Throws<FlowOverflowException>(() =>
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

    [Fact]
    public void AddCourseWorks()
    {
        var faculty = new Faculty('M');
        Course course = isuService.AddCourse(faculty);

        Assert.Contains(course, isuService.Courses);
    }

    [Fact]
    public void AssignStudentWorks()
    {
        var faculty1 = new Faculty('R');
        var faculty2 = new Faculty('M');
        Course course1 = isuService.AddCourse(faculty1);
        Course course2 = isuService.AddCourse(faculty1);
        Course course3 = isuService.AddCourse(faculty2);
        Group group = isuService.AddGroup(new GroupName("M32011"));
        group.AddInterval(new Lesson(new Time(13, 30), new Time(15, 00), group, "t1", 1));
        CourseFlow flow1 = course1.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        CourseFlow flow2 = course1.AddFlow(new Lesson(new Time(12, 00), new Time(13, 30), group, "t1", 1));
        Student student = isuService.AddStudent(group, "s1");

        course1.AddStudent(student);
        Assert.Contains(student, course1.Students);

        course1.RemoveStudent(student);
        Assert.DoesNotContain(student, course1.Students);

        Assert.Throws<Exception>(() => course2.AddStudent(student)); // Collision
        Assert.Throws<Exception>(() => course3.AddStudent(student)); // Same faculty
    }

    [Fact]
    public void GetFlowsWorks()
    {
        var faculty = new Faculty('R');
        Course course = isuService.AddCourse(faculty);
        Group group1 = isuService.AddGroup(new GroupName("M32011"));
        Group group2 = isuService.AddGroup(new GroupName("M33011"));
        CourseFlow flow1 = course.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group1, "t1", 1));
        CourseFlow flow2 = course.AddFlow(new Lesson(new Time(13, 30), new Time(15, 00), group2, "t1", 1));

        var list = new List<Entities.CourseFlow>
    {
        flow1, flow2,
    };

        Assert.Equal(list, course.Flows);
    }

    [Fact]
    public void GetStudentsByFlowWorks()
    {
        var faculty = new Faculty('R');
        Course course = isuService.AddCourse(faculty);
        Group group = isuService.AddGroup(new GroupName("M32011"));
        Student student1 = isuService.AddStudent(group, "s1");
        Student student2 = isuService.AddStudent(group, "s2");
        CourseFlow flow = course.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        course.AddStudent(student1);
        course.AddStudent(student2);
        var list = new List<Student>
    {
        student1, student2,
    };
        Assert.Equal(list, flow.Students);
    }

    [Fact]
    public void GetNotAssignedWorks()
    {
        var faculty = new Faculty('R');
        Course course = isuService.AddCourse(faculty);
        Group group = isuService.AddGroup(new GroupName("M32011"));
        Student student1 = isuService.AddStudent(group, "s1");
        Student student2 = isuService.AddStudent(group, "s2");
        Student student3 = isuService.AddStudent(group, "s2");
        Student student4 = isuService.AddStudent(group, "s2");
        _ = course.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        course.AddStudent(student1);
        course.AddStudent(student3);
        var list = new List<Student>
    {
        student2, student4,
    };

        Assert.Equal(list, group.NotAssigned);
    }
}