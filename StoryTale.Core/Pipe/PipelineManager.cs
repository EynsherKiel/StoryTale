using StoryTale.Core.Data;
using StoryTale.Core.Services;
using StoryTale.Core.Extensions;
using System.Collections.Generic;

namespace StoryTale.Core.Pipe
{
    public class PipelineManager
    {
        private readonly ServiceInvoker _invoker;

        public PipelineManager(ServiceInvoker invoker)
        {
            _invoker = invoker;
        }

        public async IAsyncEnumerable<Server> Execute(Node<Server> tree)
        {
            foreach (var server in tree.Visit(el => true))
            {
                var result = await _invoker.Invoke(server);

                server.Out = result;

                yield return server;
            }
        }
    }
}