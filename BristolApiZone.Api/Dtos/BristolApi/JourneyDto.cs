using System;
using System.Collections.Generic;

namespace BristolApiZone.Api.Dtos.BristolApi
{
    public class JourneyDto
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string SummaryHtml { get; set; }
        public int Duration { get; set; }
        public List<LegDto> Legs { get; set; }
        public string OriginPlacePointId { get; set; }
        public string DestinationPlacePointId { get; set; }
    }
}
