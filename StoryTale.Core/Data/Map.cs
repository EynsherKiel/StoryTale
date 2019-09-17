using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class Map
    {
        public int RootId { get; set; }
        public List<Server> Servers { get; set; }
    } 
}
