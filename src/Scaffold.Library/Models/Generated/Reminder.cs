using System;
using System.Collections.Generic;

namespace Scaffold.Library.Models
{
    public partial class Reminder
    {
        public uint Id { get; set; }
        public uint RemindBefore { get; set; }
        public uint MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; } = null!;
    }
}
