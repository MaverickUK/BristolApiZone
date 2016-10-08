using System;
using BristolApiZone.Api.Dtos.BristolApi;

namespace BristolApiZone.Domain.Models
{
    public class Leg
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string SummaryHtml { get; set; }
        public int Stops { get; set; }
        public string Polyline { get; set; }
        public VehicleTypeEnum VehicleType { get; set; }

        public Leg(LegDto leg)
        {
            DepartureTime = leg.DepartureTime;
            ArrivalTime = leg.ArrivalTime;
            Duration = TimeSpan.FromTicks(leg.Duration);
            SummaryHtml = leg.SummaryHtml;
            Stops = leg.ScheduledStopCalls?.Count ?? 0;
            Polyline = leg.Polyline;
            VehicleType = leg.VehicleType;
        }
    }
}