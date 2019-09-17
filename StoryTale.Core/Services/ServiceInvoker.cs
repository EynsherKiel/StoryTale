using StoryTale.Core.Data;
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

        public Task<string> Execute(Server server, object @in)
        {
            return _client.Invoke(server.Uri, server.HttpMethod, @in);
            //return Task.FromResult("[{\"tableName\":\"Age\",\"uniqueId\":null,\"value\":1.000000}]");
        }
    }
}