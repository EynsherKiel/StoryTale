using MediatR;
using StoryTale.Core.Data;
using StoryTale.Core.Markup.Moduls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace StoryTale.Core.Markup
{
    public class Process
    {
        private readonly Pipeline _pipeline;
        private readonly IMediator _mediator;
        private readonly string _name;

        public Process(string name, IMediator mediator, Pipeline pipeline)
        {
            _pipeline = pipeline;
            _mediator = mediator;
            _name = name;
        }

        public async IAsyncEnumerable<Step> Execute(object global)
        {
            //var id = _mediator.Send(new AddProcessRequest { Name = _name });

            await using var enumerator =  _pipeline.ExecuteProcess(global).GetAsyncEnumerator();

            while(true)
            {
                try
                {
                    if (!await enumerator.MoveNextAsync())
                        break;
                }
                catch (Exception ex)
                {
                    //_mediator.Send(new AddException { Id = id, Exception = ex });
                    throw;
                }

                var step = enumerator.Current;

                //_mediator.Send(new AddStepRequest { Id = id, Step = step });

                yield return step;
            }
        }
    }
}
