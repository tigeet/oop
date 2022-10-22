using Isu.Extra.Models;

namespace Isu.Extra.Entities;
public class CourseFlow : Flow
{
    public CourseFlow(Course course)
        : base()
    {
        Course = course;
    }

    public Course Course { get; }
}