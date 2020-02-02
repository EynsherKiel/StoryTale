using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using YamlDotNet.Serialization;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StoryTale.Tests
{
    [TestClass]
    public class YamlTests
    {
        private const string _document = @"---
            rootId: 1
            
            containers:
            -   
                id: 1
                name: Сервер коэффициентов
                when:
                    isGenerateException: yes
                    name: Test
                    condition:
                        in:
                            x: !!int 17
                            y: !globalbind
                                path: attribute.id
                        expr: int(x) > int(y)
                server: 
                    uri: http://192.168.5.10:19081/iRIS.InsuranceApp/iRIS.InsuranceApp.CoefficientService.Host/api/coefficient/get
                    httpMethod: Post
                    in: 
                    -
                        tablename: !globalbind
                            path: tablename
                        parameters:
                        -
                            attributeid: !globalbind
                                path: attribute.id
                            attributevalue: !globalbind
                                path: attribute.value
                asserts:
                -
                    isGenerateException: no
                    name: Test
                    condition:
                        in:
                            x: !!int 17
                            y: !globalbind
                                path: attribute.id
                        expr: int(x) < int(y)
...";

        private ServiceProvider _provider;
        private IDeserializer _deserializer;

        [TestInitialize]
        public void Init()
        {
            var services = new ServiceCollection();

            services.AddStoryTale();

            _provider = services.BuildServiceProvider();

            _deserializer = _provider.GetService<IDeserializer>();
        }

        [TestCleanup]
        public void Clean()
        {
            _provider.Dispose();
        }

        [TestMethod]
        public void MapDeserializeSuccess()
        {
            var map = _deserializer.Deserialize<Map>(_document);

            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void MapCreateNodesSuccess()
        {
            var tree = _deserializer.Deserialize<Map>(_document)
                .GetTree();

            Assert.IsNotNull(tree);
        }
    }
}