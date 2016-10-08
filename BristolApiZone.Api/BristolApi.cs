using System.Threading.Tasks;
using BristolApiZone.Api.Messages.BristolApi;

namespace BristolApiZone.Api
{
    public class BristolApi
    {
        public async Task<GetDirectionResponse> GetDirectionsAsync(GetDirectionsRequest request)
        {
            return await Api.PostAsync<GetDirectionResponse>("plan/directions", request, request);
        }
    }
}
