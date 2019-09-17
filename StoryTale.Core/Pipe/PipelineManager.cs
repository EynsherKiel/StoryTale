using StoryTale.Core.Data;
using StoryTale.Core.Services;
using StoryTale.Core.Extensions;
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

        public async Task<IList<Server>> Execute(MapMarkup markup, Map map)
        {
            var list = new List<Server>();

            foreach (var server in map.GetTree().Visit(el => true))
            {
                var @in = markup.GetIn(map, server.Id);

                await _invoker.Execute(server, @in);
                
                list.Add(server);
            }

            return list;
        }
    }
}