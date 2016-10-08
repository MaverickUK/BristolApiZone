using System.Collections.Generic;

namespace BristolApiZone.Api.Dtos.BristolApi
{
    public class JourneyDto
    {
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string SummaryHtml { get; set; }
        public int Duration { get; set; }
        public List<LegDto> Legs { get; set; }
        public string OriginPlacePointId { get; set; }
        public string DestinationPlacePointId { get; set; }
    }
}
