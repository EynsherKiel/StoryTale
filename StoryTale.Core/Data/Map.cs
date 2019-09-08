using System.Collections.Generic;
using System.Dynamic;

namespace StoryTale.Core.Data
{
    public class Map
    {
        public int RootId { get; set; }
        public ExpandoObject Global { get; set; } = new ExpandoObject();
        public List<Server> Servers { get; set; } = new List<Server>();
    } 
}