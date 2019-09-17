using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class Tree
    {
        public JToken Global { get; set; }
        public Dictionary<int, Server> Servers { get; set; }
        public Node<Server> Nodes { get; set; }
    }
}