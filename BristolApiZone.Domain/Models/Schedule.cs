using System.Collections.Generic;

namespace BristolApiZone.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public virtual ICollection<ScheduleItem> ScheduleItems { get; set; }
    }
}
