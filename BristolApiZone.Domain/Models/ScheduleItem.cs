using System;
using System.Collections.Generic;
using System.Linq;

namespace BristolApiZone.Domain.Models
{
    public class ScheduleItem
    {
        public int Id { get; set; }

        public virtual Schedule Schedule { get; set; }
        
        public string Name { get; set; }

        public TimeSpan Time { get; set; }
        
        public TimeType TimeType { get; set; }
        
        public string DaysRaw { get; set; }

        public IEnumerable<DayOfWeek> Days
        {
            get
            {
                return !string.IsNullOrWhiteSpace(DaysRaw) ? DaysRaw.Split(',').Select(day => ((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day))) : null;
            }
            set
            {
                if (value != null) DaysRaw = string.Join(",", value.Select(day => day.ToString()));
            }
        }

        public virtual Location Origin { get; set; }

        public virtual Location Destination { get; set; }
    }
}