using System.Net.Http;
using System.Threading.Tasks;
using BristolApiZone.Api.Messages;

namespace BristolApiZone.Api
{
    public static class Api
    {
        private static HttpResponseMessage Get(string endpoint, BaseApiRequest request)
        {
            using (var client = Http.GetClient(request))
            {
                return client.GetAsync(endpoint).Result;
            }
        }

        public static T Get<T>(string endpoint, BaseApiRequest request) where T : BaseApiResponse, new()
        {
            var message = Get(endpoint, request);

            if (Http.IsValidStatusCode(message.StatusCode))
            {
                return Convert.DeserializeMessageAsync<T>(message).Result;
            }

            throw new ApiException(message);
        }

        private static async Task<HttpResponseMessage> GetAsync(string endpoint, BaseApiRequest request)
        {
            using (var client = Http.GetClient(request))
            {
                return await client.GetAsync(endpoint);
            }
        }

        public static async Task<T> GetAsync<T>(string endpoint, BaseApiRequest request = null) where T : BaseApiResponse, new()
        {
            var message = await GetAsync(endpoint, request);

            if (Http.IsValidStatusCode(message.StatusCode))
            {
                return await Convert.DeserializeMessageAsync<T>(message);
            }

            throw new ApiException(message);
        }

        private static async Task<HttpResponseMessage> PostAsync(string endpoint, BaseApiRequest request, string content)
        {
            using (var client = Http.GetClient(request))
            {
                return await client.PostAsync(endpoint, new StringContent(content));
            }
        }

        public static async Task<T> PostAsync<T>(string endpoint, BaseApiRequest request, object content) where T : BaseApiResponse, new()
        {
            var message = await PostAsync(endpoint, request, Convert.SerializeObject(content));

            if (Http.IsValidStatusCode(message.StatusCode))
            {
                return await Convert.DeserializeMessageAsync<T>(message);
            }

            throw new ApiException(message);
        }

        private static async Task<HttpResponseMessage> PutAsync(string endpoint, BaseApiRequest request, string content)
        {
            using (var client = Http.GetClient(request))
            {
                return await client.PutAsync(endpoint, new StringContent(content));
            }
        }

        public static async Task<T> PutAsync<T>(string endpoint, BaseApiRequest request, object content) where T : BaseApiResponse, new()
        {
            var message = await PutAsync(endpoint, request, Convert.SerializeObject(content));

            if (Http.IsValidStatusCode(message.StatusCode))
            {
                return await Convert.DeserializeMessageAsync<T>(message);
            }

            throw new ApiException(message);
        }

        private static async Task<HttpResponseMessage> DeleteAsync(string endpoint, BaseApiRequest request)
        {
            using (var client = Http.GetClient(request))
            {
                return await client.DeleteAsync(endpoint);
            }
        }

        public static async Task<T> DeleteAsync<T>(string endpoint, BaseApiRequest request) where T : BaseApiResponse, new()
        {
            var message = await DeleteAsync(endpoint, request);

            if (Http.IsValidStatusCode(message.StatusCode))
            {
                return await Convert.DeserializeMessageAsync<T>(message);
            }

            throw new ApiException(message);
        }
    }
}
