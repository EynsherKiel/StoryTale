using Autofac;
using StoryTale.Core.Autofac;
using StoryTale.Core.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YamlDotNet.Serialization;
using StoryTale.Core.Extensions;

namespace StoryTale.Tests
{
    [TestClass]
    public class YamlTests
    {
        private const string _document = @"---
            global: 
                name: null
                date: null

            rootId: 1
            
            servers:
            -   
                id: 1
                parentId: null
                uri: https://vk.com/feed
                httpMethod: Get
                in: 
                    date: {global date}
                out:
                    carid: null
                    name: null
            -   
                id: 2
                parentId: 1
                uri: https://vk.com/feed
                httpMethod: Post
                in:
                    carId: {{1 carid}}
                    name: {{1 name}}
                    date: {{global date}}
                out:
                    isexecute: null
...";

        private IContainer _container;
        private IDeserializer _deserializer;

        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CoreModule>();

            _container = builder.Build();

            _deserializer = _container.Resolve<IDeserializer>();
        }

        [TestCleanup]
        public void Clean()
        {
            _container.Dispose();
        }

        [TestMethod]
        public void MapDeserializeSuccess()
        {
            var map = _deserializer.Deserialize<Map>(_document);

            Assert.IsNotNull(map);
            Assert.IsTrue(map.Servers.Count == 2);
        }

        [TestMethod]
        public void MapCreateNodesSuccess()
        {
            var tree = _deserializer.Deserialize<Map>(_document)
                .GetTree();

            Assert.IsNotNull(tree);
            Assert.IsTrue(tree.Childrens.Count == 1);
        }
    }
}