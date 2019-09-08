using Autofac;
using StoryTale.Core.Autofac;
using StoryTale.Core.Handlers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
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
            dynamic global = new ExpandoObject();

            global.name = "car";
            global.date = System.DateTime.Now;

            var result = await _mediator.Send(new ExecutePipelineRequest { Name = "test", Global = global });

            await foreach (var item in result)
            {
                Assert.IsNotNull(item);
            }
        }
    }
}
