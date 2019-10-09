using StoryTale.Core.Data;
using StoryTale.Core.Services;
using System.Threading.Tasks;

namespace StoryTale.Core.Markup.Moduls
{
    public class ServerModule
    {
        private readonly IServiceInvoker _invoker;

        public ServerModule(IServiceInvoker invoker)
        {
            _invoker = invoker;
        }

        public Task<string> Execute(Server current, ProcessToken token)
        {
            var @in = token.GetIn(current);

            return _invoker.Execute(current, @in); 
        }
    }
}