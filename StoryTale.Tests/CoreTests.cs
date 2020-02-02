using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Handlers;
using StoryTale.Core.Services;
using StoryTale.Tests.Extensions;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StoryTale.Tests
{
    [TestClass]
    public class CoreTests
    {
        private ServiceProvider _provider;
        private IMediator _mediator;

        [TestInitialize]
        public void Init()
        {
            var services = new ServiceCollection();

            services.AddStoryTale();

            services.MockSingleton<IServiceInvoker>(mock =>
            {
                mock.Setup(x => x.Execute(It.IsAny<Server>(), It.IsAny<JToken>()))
                    .ReturnsAsync("[{\"tableName\":\"Age\",\"uniqueId\":null,\"value\":1.000000}]");
            });

            _provider = services.BuildServiceProvider();

            _mediator = _provider.GetService<IMediator>();
        }

        [TestCleanup]
        public void Clean()
        {
            _provider.Dispose();
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
