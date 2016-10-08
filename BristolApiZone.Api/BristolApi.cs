using BristolApiZone.Api.Messages.BristolApi;

namespace BristolApiZone.Api
{
    public class BristolApi
    {
        public GetDirectionResponse GetDirectionsAsync(GetDirectionsRequest request)
        {
            return Api.Post<GetDirectionResponse>("plan/directions", request, request);
        }
    }
}
