using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryTale.Core.Extensions;
using System.Linq;

namespace StoryTale.Tests
{
    [TestClass]
    public class NodeTests
    {
        private readonly (int id, int? parentId)[] _leafs = 
        {
            (id: 3,   parentId: 1),
            (id: 4,   parentId: 2),
            (id: 7,   parentId: 1),
            (id: 8,   parentId: 0),
            (id: 0,   parentId: null),
            (id: 25,  parentId: 14),
            (id: 1,   parentId: 0),
            (id: 2,   parentId: 0),
            (id: 5,   parentId: 2),
            (id: 24,  parentId: 14),
            (id: 14,  parentId: null),
            (id: 265, parentId: 312),
        };

        [TestMethod]
        public void TreeSuccess()
        {
            var nodes = _leafs.GetTrees(l => l.id, l => l.parentId);

            Assert.IsTrue(nodes.Any());
            Assert.IsTrue(nodes.Count == 3);
            Assert.IsTrue(nodes.Last().Current.id == 265);
            Assert.IsTrue(nodes[0].Childrens.Any());

            int[] path = { 0, 1, 7 };
            var leafs = nodes.First().Visit(el => path.Contains(el.id)).ToArray();

            Assert.IsTrue(leafs.Any());
            Assert.IsTrue(leafs.Length == 3);
            Assert.IsTrue(leafs.Select(el => el.id).SequenceEqual(path));
        }
    }
}