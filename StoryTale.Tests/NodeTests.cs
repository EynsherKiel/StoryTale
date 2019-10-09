using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryTale.Core.Extensions;
using System.Linq;

namespace StoryTale.Tests
{
    [TestClass]
    public class NodeTests
    {
        private readonly (int id, int[] parentIds)[] _leafs = 
        {
            (id: 3,   parentIds: new int [] {1}),
            (id: 4,   parentIds: new int [] {2}),
            (id: 7,   parentIds: new int [] {1}),
            (id: 8,   parentIds: new int [] {0 }),
            (id: 0,   parentIds: null),
            (id: 25,  parentIds: new int [] {14 }),
            (id: 1,   parentIds: new int [] {0}),
            (id: 2,   parentIds: new int [] {0}),
            (id: 5,   parentIds: new int [] {2 }),
            (id: 24,  parentIds: new int [] {14 }),
            (id: 14,  parentIds: null),
            (id: 265, parentIds: new int [] {312 }),
        };

        [TestMethod]
        public void TreeSuccess()
        {
            var nodes = _leafs.GetTrees(l => l.id, l => l.parentIds);

            Assert.IsTrue(nodes.Any());
            Assert.IsTrue(nodes.Count == 3);
            Assert.IsTrue(nodes.Last().Current.id == 265);
            Assert.IsTrue(nodes[0].Childrens.Any());
        }
    }
}