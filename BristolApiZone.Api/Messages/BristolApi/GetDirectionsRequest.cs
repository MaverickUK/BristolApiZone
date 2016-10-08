using System;
using BristolApiZone.Api.Dtos.BristolApi;
using Newtonsoft.Json;

namespace BristolApiZone.Api.Messages.BristolApi
{
    public class GetDirectionsRequest : BristolApiRequest
    {
        [JsonProperty("origin")]
        public PlacePointDto Origin { get; set; }

        [JsonProperty("destination")]
        public PlacePointDto Destination { get; set; }

        [JsonProperty("departureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("arrivalTime")]
        public DateTime ArrivalTime { get; set; }
    }
}
