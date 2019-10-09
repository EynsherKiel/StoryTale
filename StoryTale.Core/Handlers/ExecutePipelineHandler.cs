using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StoryTale.Core.Data;
using StoryTale.Core.Markup;
using StoryTale.Core.Caches;

namespace StoryTale.Core.Handlers
{
    public class ExecutePipelineHandler : IRequestHandler<ExecutePipelineRequest, IAsyncEnumerable<Step>>
    {
        private readonly PipelineCache _cache;

        public ExecutePipelineHandler(PipelineCache cache)
        {
            _cache = cache;
        }

        public async Task<IAsyncEnumerable<Step>> Handle(ExecutePipelineRequest request, CancellationToken cancellationToken)
        {
            var process = await _cache.Get(request.Name);

            return process.Execute(request.Global);
        }
    }

    public class ExecutePipelineRequest : IRequest<IAsyncEnumerable<Step>>
    {
        public string Name { get; set; }
        public object Global { get; set; }
    }
}