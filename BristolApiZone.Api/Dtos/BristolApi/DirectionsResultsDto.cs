using System.Collections.Generic;

namespace BristolApiZone.Api.Dtos.BristolApi
{
    public class DirectionsResultsDto
    {
        public List<JourneyDto> Journeys { get; set; }
        public List<PlacePointDto> PlacePoints { get; set; }
    }
}
