using Isu.Extra.Exceptions;

namespace Isu.Extra.Models;

public class Time
{
    public Time(int hours, int minutes)
    {
        if (hours < 0 || hours > 23)
            throw new TimeException("wrong hours signature, [0: 24)");

        if (minutes < 0 || minutes > 59)
            throw new TimeException("wrong minutes signature [0:60)");

        Hours = hours;
        Minutes = minutes;
    }

    public int Hours { get; }
    public int Minutes { get; }
}