using System;

namespace BristolApiZone.Domain.Models
{
    public class ScheduleItem
    {
        public int Id { get; set; }

        public virtual Schedule Schedule { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }
        
        public TimeType TimeType { get; set; }

        public DayOfWeek[] Days { get; set; }
        
        public virtual Location Origin { get; set; }

        public virtual Location Destination { get; set; }
    }
}