using StoryTale.Core.Data;
using StoryTale.Core.Handlers;
using StoryTale.Core.Markup;
using MediatR;
using System.Threading.Tasks;

namespace StoryTale.Core.Caches
{
    public class PipeCache
    {
        private readonly ProcessesFactory _factory;
        private readonly IMediator _mediator;
        private readonly ProcessFactory _processFactory;

        public PipeCache(IMediator mediator, ProcessesFactory factory)
        {
            _factory = factory;
            _mediator = mediator;


            var pipeYaml = _mediator.Send(new GetPipelineRequest {  }).Result;

            _processFactory = _factory.Create(pipeYaml);
        }

        public Task<Process> Get(string name, object global) => Task.FromResult(_processFactory.CreateProcess(global));

        //public async Task<MapMarkup> Get(string name)
        //{
        //    var pipeYaml = await _mediator.Send(new GetPipelineRequest { Name = name });

        //    return _factory.Create(pipeYaml);
        //}
    }
}