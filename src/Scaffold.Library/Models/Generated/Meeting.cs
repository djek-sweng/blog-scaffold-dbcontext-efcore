using System;
using System.Collections.Generic;

namespace Scaffold.Library.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            Reminders = new HashSet<Reminder>();
        }

        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }
        public DateTime StartAt { get; set; }
        public uint Duration { get; set; }
        public uint CalendarId { get; set; }

        public virtual Calendar Calendar { get; set; } = null!;
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
