using StoryTale.Core.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace StoryTale.Core.Extensions
{
    public static class ClientExtensions
    {
        public static async Task ThrowIfNotSuccessAsync(this HttpResponseMessage response, CancellationToken token)
        {
            if (!response.IsSuccessStatusCode)
                throw new ClientException(await response.Content.ReadAsAsync<HttpError>(token));
        }
    }
}