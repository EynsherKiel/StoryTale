using StoryTale.Core.Extensions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace StoryTale.Core.Web
{
    public class Client
    {
        public async Task<T> Invoke<T>(string uri, string method, object parameters = default, CancellationToken token = default)
        {
            var response = await SendAsync(uri, method, parameters, token);

            await response.ThrowIfNotSuccessAsync(token);

            return await response.Content.ReadAsAsync<T>();
        }

        private static async Task<HttpResponseMessage> SendAsync(string uri, string method, object parameters, CancellationToken token)
        {
            if (method == "Get")
            {
                return await uri.SetQueryParams(parameters).GetAsync(token);
            }

            return await uri.SendJsonAsync(new HttpMethod(method), parameters, token);
        }
    }
}