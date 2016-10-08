using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BristolApiZone.Api.Messages;

namespace BristolApiZone.Api
{
    internal class Http
    {
        internal static HttpClient GetClient(BaseApiRequest request)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

            //client.Timeout = TimeSpan.FromSeconds(Settings.Current.Service.Timeout);
            client.BaseAddress = new Uri(request.BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrWhiteSpace(request?.ApiKey))
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", request.ApiKey);
            }

            return client;
        }

        internal static bool IsValidStatusCode(HttpStatusCode statusCode)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    return true;
                default:
                    return false;
            }
        }
    }
}
