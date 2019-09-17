using StoryTale.Core.Caches;
using StoryTale.Core.Data;
using StoryTale.Core.Pipe;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoryTale.Core.Handlers
{
    public class ExecutePipelineHandler : IRequestHandler<ExecutePipelineRequest, IList<Server>>
    {
        private readonly PipelineManager _pipe;
        private readonly PipeCache _cache;

        public ExecutePipelineHandler(PipelineManager pipe, PipeCache cache)
        {
            _pipe = pipe;
            _cache = cache;
        }

        public async Task<IList<Server>> Handle(ExecutePipelineRequest request, CancellationToken cancellationToken)
        {
            var process = await _cache.Get(request.Name, request.Global);

            return await _pipe.Execute(process);
        }
    }

    public class ExecutePipelineRequest : IRequest<IList<Server>>
    {
        public string Name { get; set; }
        public object Global { get; set; }
    }
}