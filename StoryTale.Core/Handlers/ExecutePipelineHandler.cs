using StoryTale.Core.Caches;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Pipe;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace StoryTale.Core.Handlers
{
    public class ExecutePipelineHandler : IRequestHandler<ExecutePipelineRequest, IAsyncEnumerable<Server>>
    {
        private readonly PipelineManager _pipe;
        private readonly PipeCache _cache;

        public ExecutePipelineHandler(PipelineManager pipe, PipeCache cache)
        {
            _pipe = pipe;
            _cache = cache;
        }

        public async Task<IAsyncEnumerable<Server>> Handle(ExecutePipelineRequest request, CancellationToken cancellationToken)
        {
            var map = await _cache.Get(request.Name);

            if (!map.Global.Compare(request.Global))
                throw new ArgumentException("Ожидались другие параметры");

            map.Global = request.Global;

            var tree = map.GetTree();

            return _pipe.Execute(tree);
        }
    }

    public class ExecutePipelineRequest : IRequest<IAsyncEnumerable<Server>>
    {
        public string Name { get; set; }
        public ExpandoObject Global { get; set; }
    }
}