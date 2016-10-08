using System.Collections.Generic;
using System.Linq;
using BristolApiZone.Api.Dtos.BristolApi;

namespace BristolApiZone.Domain.Models
{
    public class DirectionResults
    {
        public List<Journey> Journeys { get; set; }

        public DirectionResults(DirectionsResultsDto results)
        {
            Journeys = results.Journeys.Select(j => new Journey(j)).ToList();
        }
    }
}
