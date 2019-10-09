using Autofac;
using StoryTale.Core.Autofac;
using StoryTale.Core.Handlers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using StoryTale.Core.Services;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Moq;

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

            var mock = new Mock<IServiceInvoker>();

            mock.Setup(x => x.Execute(It.IsAny<Server>(), It.IsAny<JToken>()))
                .ReturnsAsync("[{\"tableName\":\"Age\",\"uniqueId\":null,\"value\":1.000000}]");

            builder.RegisterInstance(mock.Object).As<IServiceInvoker>().SingleInstance();

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

                var list = await _mediator.Send(new ExecutePipelineRequest
                {
                    Name = "test",
                    Global = new
                    {
                        TableName = "Age",
                        Attribute = new
                        {
                            Id = 3,
                            Value = "18-64"
                        }
                    }
                });

                await foreach (var item in list)
                {
                    System.Console.WriteLine($"{sw.Elapsed} : {Newtonsoft.Json.JsonConvert.SerializeObject(item)}");
                }

                System.Console.WriteLine(sw.Elapsed);
                sw.Reset();
            }
        }
    }
}
