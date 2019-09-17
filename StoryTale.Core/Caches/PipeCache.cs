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
        private readonly MapMarkup _markup;

        public PipeCache(IMediator mediator, MapMarkupFactory factory)
        {
            _factory = factory;
            _mediator = mediator;


            var pipeYaml = _mediator.Send(new GetPipelineRequest {  }).Result;

            _markup = _factory.Create(pipeYaml);
        }

        public Task<MapMarkup> Get(string name) => Task.FromResult(_markup);

        //public async Task<MapMarkup> Get(string name)
        //{
        //    var pipeYaml = await _mediator.Send(new GetPipelineRequest { Name = name });

        //    return _factory.Create(pipeYaml);
        //}
    }
}