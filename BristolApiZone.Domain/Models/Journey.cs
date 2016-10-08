using System;
using System.Collections.Generic;
using System.Linq;
using BristolApiZone.Api.Dtos.BristolApi;

namespace BristolApiZone.Domain.Models
{
    public class Journey
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Leg> Legs { get; set; }

        public Journey(JourneyDto journey)
        {
            DepartureTime = journey.DepartureTime;
            ArrivalTime = journey.ArrivalTime;
            Duration = TimeSpan.FromTicks(journey.Duration);
            Legs = journey.Legs.Select(l => new Leg(l)).ToList();
        }
    }
}