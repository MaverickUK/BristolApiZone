using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BristolApiZone.Api.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BristolApiZone.Api
{
    public class Convert
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> { new StringEnumConverter { CamelCaseText = true } },
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static string SerializeObject(object value)
        {
            return value == null ? "{}" : JsonConvert.SerializeObject(value, Settings);
        }

        internal static async Task<T> DeserializeMessageAsync<T>(HttpResponseMessage message) where T : BaseApiResponse, new()
        {
            var content = await message.Content.ReadAsStringAsync();

            var baseResponse = JsonConvert.DeserializeObject<BaseApiResponse>(content);

            if (!baseResponse.Status || message.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ApiException(message);
            }

            var response = JsonConvert.DeserializeObject<T>(content, Settings);

            return response;
        }
    }
}
