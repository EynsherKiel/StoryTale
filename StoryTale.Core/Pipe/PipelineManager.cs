using StoryTale.Core.Data;
using StoryTale.Core.Services;
using System.Collections.Generic;
using StoryTale.Core.Markup;
using System.Threading.Tasks;

namespace StoryTale.Core.Pipe
{
    public class PipelineManager
    {
        private readonly ServiceInvoker _invoker;

        public PipelineManager(ServiceInvoker invoker)
        {
            _invoker = invoker;
        }

        public async Task<IList<Server>> Execute(Process process)
        {
            var list = new List<Server>();

            foreach (var server in process.Visit())
            {
                var @in = process.GetIn(server);
                var @out = await _invoker.Execute(server, @in);

                process.SetOut(server, @out);

                list.Add(server);
            }

            return list;
        }
    }
}