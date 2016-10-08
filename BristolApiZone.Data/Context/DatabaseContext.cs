using BristolApiZone.Domain.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BristolApiZone.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Schedule> Schedules { get; set; }

        public IDbSet<ScheduleItem> ScheduleItems { get; set; }

        public IDbSet<Location> Locations { get; set; }
    }
}
