using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Web;
using System.Linq;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StoryTale.Core.Services
{
    public class ServiceInvoker
    {
        private readonly Client _client;

        public ServiceInvoker(Client client)
        {
            _client = client;
        }

        public async Task<ExpandoObject> Invoke(Server server)
        {
            var result = await _client.Invoke<object>(server.Uri, server.HttpMethod, server.In);

            if (result.GetType().IsSimple())
            {
                var dic = server.Out.Unpack();

                if (dic.Count != 1)
                    throw new NotSupportedException();

                dic[dic.Keys.First()] = result;

                return server.Out;
            }

            var @out = JsonConvert.DeserializeObject<ExpandoObject>(JsonConvert.SerializeObject(result));

            if (!@out.Compare(server.Out))
                throw new ArgumentException("Ожидались другие параметры");

            return @out;
        }
    }
}
