using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Services;
using System.Threading.Tasks;

namespace StoryTale.Core.Markup.Moduls
{
    public class ServerModule
    {
        private readonly ServiceInvoker _invoker;

        public ServerModule(ServiceInvoker invoker)
        {
            _invoker = invoker;
        }

        public Task<string> Execute(Server current, JToken @in)
        {
            return _invoker.Execute(current, @in); 
        }
    }
}