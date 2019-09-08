using StoryTale.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Extensions
{
    public static class NodeExtensions
    {
        public static Node<Server> GetTree(this Map map)
            => map
                .Servers
                .GetTrees(el => el.Id, el => el.ParentId)
                .Single(el => el.Current.Id == map.RootId);

        public static IList<Node<T>> GetTrees<T>(this IEnumerable<T> leafs, Func<T, int> getId, Func<T, int?> getParentId)
        {
            var list = new List<Node<T>>();

            var nodesDictionary = leafs.ToDictionary(getId, leaf => new Node<T>(leaf));

            foreach (var currentNode in nodesDictionary.Values)
            {
                var parentId = getParentId(currentNode.Current);

                if (!parentId.HasValue || !nodesDictionary.TryGetValue(parentId.Value, out var parentNode))
                {
                    list.Add(currentNode);
                    continue;
                }

                parentNode.Childrens.Add(currentNode);
            }

            return list;
        }

        public static IEnumerable<T> Visit<T>(this Node<T> node, Predicate<T> chooseChild)
        {
            while (node != null)
            {
                yield return node.Current;

                node = node.Childrens.SingleOrDefault(child => chooseChild(child.Current));
            }
        }
    }
}