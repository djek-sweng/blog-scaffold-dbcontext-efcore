using System;

namespace Scaffold.Library.Models;

public partial class Meeting
{
    public static Meeting Create(
        string title,
        string? description,
        uint duration,
        DateTime startAt,
        uint calendarId)
    {
        return new Meeting
        {
            Title = title,
            Description = description,
            Duration = duration,
            StartAt = startAt,
            CalendarId = calendarId
        };
    }

    public bool IsStartInFuture()
    {
        return StartAt > DateTime.UtcNow;
    }
}
