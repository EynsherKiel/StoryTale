using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoryTale.Core.Handlers;
using System.Collections.Generic;
using StoryTale.Core.Data;

namespace StoryTale.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PipelineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PipelineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> GetPipeline([FromBody]GetPipelineRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async IAsyncEnumerable<Step> ExecutePipeline([FromBody]ExecutePipelineRequest request)
        {
            await foreach (var item in await _mediator.Send(request))
            {
                yield return item;
            }
        }

        [HttpPost]
        public async IAsyncEnumerable<Step> TryExecutePipeline([FromBody]TryExecutePipelineRequest request)
        {
            await foreach (var item in await _mediator.Send(request))
            {
                yield return item;
            }
        }

        // todo: SavePipeline string name, string yaml
    }
}