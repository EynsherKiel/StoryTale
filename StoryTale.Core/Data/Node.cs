using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class Node<T>
    {
        public Node(T current)
        {
            Current = current;
        }

        public T Current { get; }
        public List<Node<T>> Childrens { get; } = new List<Node<T>>();
    }
}