using StoryTale.Core.Data;
using StoryTale.Core.Handlers;
using StoryTale.Core.Markup;
using MediatR;
using System.Threading.Tasks;

namespace StoryTale.Core.Caches
{
    public class PipeCache
    {
        private readonly MapMarkupFactory _factory;
        private readonly IMediator _mediator;

        public PipeCache(IMediator mediator, MapMarkupFactory factory)
        {
            _factory = factory;
            _mediator = mediator;
        }

        public async Task<MapMarkup> Get(string name)
        {
            var pipeYaml = await _mediator.Send(new GetPipelineRequest { Name = name });

            return _factory.Create(pipeYaml);
        }
    }
}