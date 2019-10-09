using StoryTale.Core.Data;
using StoryTale.Core.Markup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Extensions
{
    public static class NodeExtensions
    {
        public static Node<Container> GetTree(this Map map)
            => map
                .Containers
                .GetTrees(el => el.Id, el => el.ParentIds)
                .Single(el => el.Current.Id == map.RootId);

        public static IList<Node<T>> GetTrees<T>(this IEnumerable<T> leafs, Func<T, int> getId, Func<T, int[]> getParentIds)
        {
            var list = new List<Node<T>>();

            var nodesDictionary = leafs.ToDictionary(getId, leaf => new Node<T>(leaf));

            foreach (var currentNode in nodesDictionary.Values)
            {
                var parents = getParentIds(currentNode.Current);

                if(parents == null)
                {
                    list.Add(currentNode);
                    continue;
                }

                foreach (var parent in parents)
                {
                    if(!nodesDictionary.TryGetValue(parent, out var parentNode))
                    {
                        list.Add(currentNode);
                        continue;
                    }

                    parentNode.Childrens.Add(currentNode);
                }
            }

            return list;
        }

        public static bool CheckPath(this ProcessToken token, Node<Container> node)
            => token.CheckPath(node.Current.ParentIds);

        public static void AddPath(this ProcessToken token, Node<Container> node)
            => token.AddPath(node.Current.Id);
    }
}