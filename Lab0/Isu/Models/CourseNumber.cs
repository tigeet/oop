namespace Isu.Models;

public class CourseNumber
{
    private int courseNumber;

    public CourseNumber(string groupName)
    {
        courseNumber = int.Parse(groupName[2].ToString());
    }

    public CourseNumber(int courseNumber)
    {
        this.courseNumber = courseNumber;
    }

    public int GetCourseNumber()
    {
        return courseNumber;
    }
}
