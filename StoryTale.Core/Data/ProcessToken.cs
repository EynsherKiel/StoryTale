using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class ProcessToken
    {
        public JToken Global { get; set; }
        public Dictionary<int, JToken> Outs { get; set; } = new Dictionary<int, JToken>();
    }
}