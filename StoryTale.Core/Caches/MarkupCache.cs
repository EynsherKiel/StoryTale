using StoryTale.Core.Handlers;
using StoryTale.Core.Markup;
using MediatR;
using System.Threading.Tasks;
using LazyCache;

namespace StoryTale.Core.Caches
{
    public class MarkupCache
    {
        private readonly MarkupFactory _factory;
        private readonly IMediator _mediator;
        private readonly IAppCache _cache;

        public MarkupCache(IMediator mediator, MarkupFactory factory, IAppCache cache)
        {
            _factory = factory;
            _mediator = mediator;
            _cache = cache;
        }

        public Task<MapMarkup> Get(string name) 
            => _cache.GetOrAddAsync(name,
                async () => _factory.Create(await _mediator.Send(new GetPipelineRequest { Name = name })));
    }
}