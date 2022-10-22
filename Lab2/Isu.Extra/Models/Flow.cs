using Isu.Exceptions;
using Isu.Extra.Entities;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Models;
public class Flow
{
    private List<StudentExtra> _students = new List<StudentExtra>();
    private List<TimeInterval> _intervals = new List<TimeInterval>();

    public Flow()
    {
        MaxCapacity = 20;
    }

    public IReadOnlyCollection<StudentExtra> Students
    {
        get
        {
            return _students;
        }
    }

    public int MaxCapacity { get; }
    public IReadOnlyCollection<TimeInterval> Intervals { get { return _intervals; } }

    public bool IsFull
    {
        get
        {
            return _students.Count == MaxCapacity;
        }
    }

    public void AddStudent(StudentExtra student)
    {
        if (_students.Count == MaxCapacity)
            throw new GroupOverflowException();

        if (_students.Contains(student))
            throw new StudentAlreadyInGroupException();

        _students.Add(student);
    }

    public void RemoveStudent(StudentExtra student)
    {
        if (!_students.Contains(student))
            throw new StudentNotInTheGroupException();

        _students.Remove(student);
    }

    public void AddInterval(params TimeInterval[] intervals)
    {
        _intervals.AddRange(intervals);
    }

    public void RemoveInterval(TimeInterval interval)
    {
        if (!_intervals.Contains(interval))
            throw new IntervalDoesNotExist();

        _intervals.Remove(interval);
    }

    public bool HasCollisions(TimeInterval interval)
    {
        foreach (TimeInterval interval1 in Intervals)
        {
            if (interval.Intersects(interval1))
                return true;
        }

        return false;
    }

    public bool HasCollisions(Flow flow)
    {
        foreach (TimeInterval interval in Intervals)
        {
            if (flow.HasCollisions(interval))
                return true;
        }

        return false;
    }
}