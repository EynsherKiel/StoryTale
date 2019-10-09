using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class Map
    {
        public object Global { get; set; }
        public int RootId { get; set; }
        public List<Container> Containers { get; set; }
    } 
}
