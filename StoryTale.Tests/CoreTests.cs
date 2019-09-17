using Autofac;
using StoryTale.Core.Autofac;
using StoryTale.Core.Handlers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StoryTale.Tests
{
    [TestClass]
    public class CoreTests
    {
        private IContainer _container;
        private IMediator _mediator;

        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CoreModule>();

            _container = builder.Build();

            _mediator = _container.Resolve<IMediator>();
        }

        [TestCleanup]
        public void Clean()
        {
            _container.Dispose();
        }

        [TestMethod]
        public async Task GetPipelineRequestSuccess()
        {
            var result = await _mediator.Send(new GetPipelineRequest());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ExecutePipelineRequestSuccess()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 100; i++)
            {
                sw.Start();

                await _mediator.Send(new ExecutePipelineRequest
                {
                    Name = "test",
                    Global =  new
                    {
                        TableName =  "Age",
                        Attribute = new
                        {
                            Id = 3,
                            Value = "18-64"
                        }
                    }
                });

                System.Console.WriteLine(sw.Elapsed);
                sw.Reset();
            }
        }
    }
}
