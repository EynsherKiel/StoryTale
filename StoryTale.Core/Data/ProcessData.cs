using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class ProcessData
    {
        public JToken Global { get; set; }
        public Dictionary<int, JToken> Outs { get; } = new Dictionary<int, JToken>();
        public HashSet<int> Path { get; set; } = new HashSet<int>();
    }
}