using System.Net;
using Newtonsoft.Json;

namespace BristolApiZone.Api.Messages
{
    public class BaseApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
