using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StoryTale.Core.Data;
using StoryTale.Core.Markup;

namespace StoryTale.Core.Handlers
{
    public class TryExecutePipelineHandler : IRequestHandler<TryExecutePipelineRequest, IAsyncEnumerable<Step>>
    {
        private readonly PipelineFactory _factory;

        public TryExecutePipelineHandler(PipelineFactory factory)
        {
            _factory = factory;
        }

        public Task<IAsyncEnumerable<Step>> Handle(TryExecutePipelineRequest request, CancellationToken cancellationToken)
        {
            var pipe = _factory.Create(request.Yaml);

            return Task.FromResult(pipe.ExecuteProcess(request.Global));
        }
    }

    public class TryExecutePipelineRequest : IRequest<IAsyncEnumerable<Step>>
    {
        public object Global { get; set; }
        public string Yaml { get; set; }
    }
}