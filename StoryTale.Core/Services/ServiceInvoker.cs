using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Web;
using System.Threading.Tasks;

namespace StoryTale.Core.Services
{
    public class ServiceInvoker
    {
        private readonly Client _client;

        public ServiceInvoker(Client client)
        {
            _client = client;
        }

        public async Task Execute(Server server, object @in)
        {
            var json = await _client.Invoke(server.Uri, server.HttpMethod, @in);
            var @out = json.ToLowerJToken();

            server.Out = @out;
        }
    }
}