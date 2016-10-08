using System.Collections.Generic;

namespace BristolApiZone.Api.Dtos.BristolApi
{
    public class LegDto
    {

        public LinkedTransitRouteInfoDto LinkedTransitRouteInfo { get; set; }
        public LinkedTransitTripInfoDto LinkedTransitTripInfo { get; set; }
        public List<ScheduledStopCallDto> ScheduledStopCalls { get; set; }
        public string Type { get; set; }
        public string SummaryHtml { get; set; }
        public string OriginPlacePointId { get; set; }
        public string DestinationPlacePointId { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int VehicleType { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
        public string Polyline { get; set; }
    }
}
