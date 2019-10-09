using StoryTale.Core.Handlers;
using StoryTale.Core.Markup;
using MediatR;
using System.Threading.Tasks;
using LazyCache;

namespace StoryTale.Core.Caches
{
    public class PipelineCache
    {
        private readonly PipelineFactory _factory;
        private readonly IMediator _mediator;
        private readonly IAppCache _cache;

        public PipelineCache(IMediator mediator, PipelineFactory factory, IAppCache cache)
        {
            _factory = factory;
            _mediator = mediator;
            _cache = cache;
        }

        public Task<Process> Get(string name) 
            => _cache.GetOrAddAsync(name,
                async () => new Process(name, _mediator, 
                    _factory.Create(await _mediator.Send(new GetPipelineRequest { Name = name }))));
    }
}