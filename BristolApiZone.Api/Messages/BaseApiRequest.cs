using Newtonsoft.Json;

namespace BristolApiZone.Api.Messages
{
    public abstract class BaseApiRequest
    {
        [JsonIgnore]
        public virtual string ApiKey { get; set; }

        [JsonIgnore]
        public virtual string BaseUrl { get; set; }
    }
}
