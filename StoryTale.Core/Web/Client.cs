using StoryTale.Core.Extensions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System.Dynamic;

namespace StoryTale.Core.Web
{
    public class Client
    {
        public async Task<string> Invoke(string uri, string method, object parameters = default, CancellationToken token = default)
        {
            var response = await SendAsync(uri, method, parameters ?? new object(), token);

            await response.ThrowIfNotSuccessAsync(token);

            return await response.Content.ReadAsStringAsync();
        }

        private static Task<HttpResponseMessage> SendAsync(string uri, string method, object parameters, CancellationToken token)
        {
            if (method == "Get")
            {
                // Flurl doesn't know about jtoken -_- 
                var getParameters = JsonConvert.DeserializeObject<ExpandoObject>(JsonConvert.SerializeObject(parameters));
                return uri.SetQueryParams(getParameters).GetAsync(token);
            }

            return uri.SendJsonAsync(new HttpMethod(method), parameters, token);
        }
    }
}