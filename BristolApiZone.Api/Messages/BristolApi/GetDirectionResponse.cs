using BristolApiZone.Api.Dtos.BristolApi;

namespace BristolApiZone.Api.Messages.BristolApi
{
    public class GetDirectionResponse : BaseApiResponse
    {
        public DirectionsResultsDto Data { get; set; }
    }
}
