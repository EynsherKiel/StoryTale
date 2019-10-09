using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Web;
using System.Threading.Tasks;

namespace StoryTale.Core.Services
{
    public class ServiceInvoker
    {
        private static readonly System.Random random = new System.Random();
        private readonly Client _client;

        public ServiceInvoker(Client client)
        {
            _client = client;
        }

        public async Task<string> Execute(Server server, JToken @in)
        {
            //return _client.Invoke(server.Uri, server.HttpMethod, @in);

            await Task.Delay(random.Next(100,400));

            return await Task.FromResult("[{\"tableName\":\"Age\",\"uniqueId\":null,\"value\":1.000000}]");
        }
    }
}