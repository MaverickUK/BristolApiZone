namespace ApiWrapper.Messages
{
    public abstract class BaseApiRequest
    {
        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }
    }
}
