namespace BristolApiZone.Api.Messages
{
    public abstract class BaseApiRequest
    {
        public virtual string ApiKey { get; set; }

        public virtual string BaseUrl { get; set; }
    }
}
