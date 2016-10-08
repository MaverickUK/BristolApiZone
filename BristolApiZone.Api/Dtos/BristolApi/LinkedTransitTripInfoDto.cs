namespace BristolApiZone.Api.Dtos.BristolApi
{
    public class LinkedTransitTripInfoDto
    {
        public string AgencyCode { get; set; }
        public string TripId { get; set; }
        public string OriginName { get; set; }
        public string OriginPrimaryCode { get; set; }
        public string Headsign { get; set; }
        public string DirectionName { get; set; }
        public int DirectionId { get; set; }
        public string VehicleId { get; set; }
        public bool IsWheelchairAccessible { get; set; }
    }
}