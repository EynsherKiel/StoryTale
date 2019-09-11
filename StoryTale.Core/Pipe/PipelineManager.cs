using StoryTale.Core.Data;
using StoryTale.Core.Services;
using StoryTale.Core.Extensions;
using System.Collections.Generic;
using StoryTale.Core.Markup;
using System;

namespace StoryTale.Core.Pipe
{
    public class PipelineManager
    {
        private readonly ServiceInvoker _invoker;

        public PipelineManager(ServiceInvoker invoker)
        {
            _invoker = invoker;
        }

        public async IAsyncEnumerable<Server> Execute(MapMarkup markup, Map map)
        {
            var tree = map.GetTree();

            foreach (var server in tree.Visit(el => true))
            {
                var result = await _invoker.Invoke(markup.GetBy(map, server.Id));

                server.Out = result;

                yield return server;
            }
        }
    }
}