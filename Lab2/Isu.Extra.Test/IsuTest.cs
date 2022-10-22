using Isu.Extra.Entities;
using Isu.Extra.Exceptions;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Extra.Test;

public class IsuTests
{
    private IsuServiceExtra isuServiceExtra;

    public IsuTests()
    {
        var isuService = new IsuService();
        isuServiceExtra = new IsuServiceExtra(isuService);
    }

    [Fact]
    public void AddCourseWorks()
    {
        var faculty = new Faculty('M');
        Course course = isuServiceExtra.AddCourse(faculty);

        Assert.Contains(course, isuServiceExtra.Courses);
    }

    [Fact]
    public void AssignStudentWorks()
    {
        var faculty1 = new Faculty('R');
        var faculty2 = new Faculty('M');
        Course course1 = isuServiceExtra.AddCourse(faculty1);
        Course course2 = isuServiceExtra.AddCourse(faculty1);
        Course course3 = isuServiceExtra.AddCourse(faculty2);

        GroupExtra group = isuServiceExtra.AddGroup(new GroupName("M32011"));
        group.AddInterval(new Lesson(new Time(13, 30), new Time(15, 00), group, "t1", 1));
        CourseFlow flow1 = course1.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        CourseFlow flow2 = course2.AddFlow(new Lesson(new Time(13, 00), new Time(14, 00), group, "t1", 1));
        CourseFlow flow3 = course3.AddFlow(new Lesson(new Time(12, 00), new Time(13, 10), group, "t1", 1));
        StudentExtra studentExtra = isuServiceExtra.AddStudent(group, "s1");

        course1.AddStudent(studentExtra);
        Assert.Contains(studentExtra, course1.Students);

        course1.RemoveStudent(studentExtra);
        Assert.DoesNotContain(studentExtra, course1.Students);
        Assert.Throws<FacultyException>(() => course3.AddStudent(studentExtra)); // Same faculty
        Assert.Throws<FlowException>(() => course2.AddStudent(studentExtra)); // Collision
    }

    [Fact]
    public void GetFlowsWorks()
    {
        var faculty = new Faculty('R');
        Course course = isuServiceExtra.AddCourse(faculty);
        GroupExtra group1 = isuServiceExtra.AddGroup(new GroupName("M32011"));
        GroupExtra group2 = isuServiceExtra.AddGroup(new GroupName("M33011"));
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
        Course course = isuServiceExtra.AddCourse(faculty);
        GroupExtra group = isuServiceExtra.AddGroup(new GroupName("M32011"));
        StudentExtra student1 = isuServiceExtra.AddStudent(group, "s1");
        StudentExtra student2 = isuServiceExtra.AddStudent(group, "s2");

        CourseFlow flow = course.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        course.AddStudent(student1);
        course.AddStudent(student2);
        var list = new List<StudentExtra>
    {
        student1, student2,
    };
        Assert.Equal(list, flow.Students);
    }

    [Fact]
    public void GetNotAssignedWorks()
    {
        var faculty = new Faculty('R');
        Course course = isuServiceExtra.AddCourse(faculty);
        GroupExtra group = isuServiceExtra.AddGroup(new GroupName("M32011"));
        StudentExtra student1 = isuServiceExtra.AddStudent(group, "s1");
        StudentExtra student2 = isuServiceExtra.AddStudent(group, "s2");
        StudentExtra student3 = isuServiceExtra.AddStudent(group, "s2");
        StudentExtra student4 = isuServiceExtra.AddStudent(group, "s2");
        course.AddFlow(new Lesson(new Time(11, 40), new Time(13, 10), group, "t1", 1));
        course.AddStudent(student1);
        course.AddStudent(student3);
        var list = new List<StudentExtra>
        {
            student2, student4,
        };

        Assert.Equal(list, group.NotAssigned);
    }
}
