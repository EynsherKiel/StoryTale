using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Web;
using System.Threading.Tasks;

namespace StoryTale.Core.Services
{
    public class ServiceInvoker : IServiceInvoker
    {
        private readonly Client _client;

        public ServiceInvoker(Client client)
        {
            _client = client;
        }

        public Task<string> Execute(Server server, JToken @in)
        {
            return _client.Invoke(server.Uri, server.HttpMethod, @in);
        }
    }
}