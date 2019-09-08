using StoryTale.Core.Data;
using StoryTale.Core.Handlers;
using StoryTale.Core.Markup;
using MediatR;
using System.Threading.Tasks;

namespace StoryTale.Core.Caches
{
    public class PipeCache
    {
        private readonly MapFantasy _fantasy;
        private readonly IMediator _mediator;

        public PipeCache(IMediator mediator, MapFantasy fantasy)
        {
            _fantasy = fantasy;
            _mediator = mediator;
        }

        public async Task<Map> Get(string name)
        {
            var pipeYaml = await _mediator.Send(new GetPipelineRequest { Name = name });

            return _fantasy.Prepare(pipeYaml);
        }
    }
}