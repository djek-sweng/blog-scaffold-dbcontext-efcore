namespace Scaffold.Library.Models;

public partial class Reminder
{
    public static Reminder Create(
        uint remindBefore,
        uint meetingId)
    {
        return new Reminder
        {
            RemindBefore = remindBefore,
            MeetingId = meetingId
        };
    }
}
