namespace Isu.Extra.Models;

public class TimeInterval
{
    public TimeInterval(Time start, Time end)
    {
        Start = start;
        End = end;
    }

    public Time Start { get; }
    public Time End { get; }

    public bool Intersects(TimeInterval interval2)
    {
        if (interval2.End.Hours < Start.Hours)
            return false;

        if (interval2.End.Hours == Start.Hours && interval2.End.Minutes < Start.Minutes)
            return false;

        if (interval2.Start.Hours > End.Hours)
            return false;

        if (interval2.Start.Hours == End.Hours && interval2.Start.Minutes > End.Minutes)
            return false;

        return true;
    }
}