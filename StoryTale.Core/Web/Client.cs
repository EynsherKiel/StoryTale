using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StoryTale.Core.Web
{
    public class Client
    {
        public async Task<string> Invoke(string uri, string method, JToken parameters, CancellationToken token = default)
        {
            var response = await SendAsync(uri, method, parameters, token);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private static Task<HttpResponseMessage> SendAsync(string uri, string method, JToken parameters, CancellationToken token)
        {
            if (method == "Get")
            {
                return uri.SetQueryParams(parameters.ToObject<ExpandoObject>()).GetAsync(token);
            }

            return uri.SendJsonAsync(new HttpMethod(method), parameters, token);
        }
    }
}