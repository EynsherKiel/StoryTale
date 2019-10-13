using MediatR;
using Microsoft.AspNetCore.SignalR;
using StoryTale.Core.Data;
using StoryTale.Core.Handlers;
using System.Collections.Generic;

namespace StoryTale.Hubs
{
    public class PipelineHub : Hub
    {
        private readonly IMediator _mediator;

        public PipelineHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async IAsyncEnumerable<Step> TryExecutePipeline(TryExecutePipelineRequest request)
        {
            await foreach (var item in await _mediator.Send(request))
            {
                yield return item;
            }
        }
    }
}