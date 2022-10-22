using Isu.Extra.Models;

namespace Isu.Extra.Entities;
public class Lesson : TimeInterval
{
    public Lesson(Time start, Time end, GroupExtra group, string teacher, int classroom)
        : base(start, end)
    {
        Group = group;
        Teacher = teacher;
        Classroom = classroom;
    }

    public GroupExtra Group { get; }
    public string Teacher { get; }
    public int Classroom { get; }
}