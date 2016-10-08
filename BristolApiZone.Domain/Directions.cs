using System;
using BristolApiZone.Api;
using BristolApiZone.Api.Dtos.BristolApi;
using BristolApiZone.Api.Messages.BristolApi;
using BristolApiZone.Domain.Models;

namespace BristolApiZone.Domain
{
    public class Directions
    {
        public static DirectionResults GetArrivalDirections(PlacePoint origin, PlacePoint destination, DateTime arrivalTime)
        {
            var bristolApi = new BristolApi();

            var request = new GetDirectionsRequest
            {
                Origin = new PlacePointDto { Lat = origin.Lat, Lng = origin.Lng },
                Destination = new PlacePointDto { Lat = destination.Lat, Lng = destination.Lng },
                ArrivalTime = arrivalTime
            };

            var response = bristolApi.GetDirectionsAsync(request);

            return new DirectionResults(response.Data);
        }

        public static DirectionResults GetDepartureDirections(PlacePoint origin, PlacePoint destination, DateTime departureTime)
        {
            var bristolApi = new BristolApi();

            var request = new GetDirectionsRequest
            {
                Origin = new PlacePointDto { Lat = origin.Lat, Lng = origin.Lng },
                Destination = new PlacePointDto { Lat = destination.Lat, Lng = destination.Lng },
                DepartureTime = departureTime
            };

            var response = bristolApi.GetDirectionsAsync(request);

            return new DirectionResults(response.Data);
        }
    }
}
