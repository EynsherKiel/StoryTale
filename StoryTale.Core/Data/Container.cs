using System.Collections.Generic;

namespace StoryTale.Core.Data
{
    public class Container
    {
        public int Id { get; set; }
        public int[] ParentIds { get; set; }
        public string Name { get; set; }
        public Server Server { get; set; }
        public Assert When { get; set; } = new Assert();
        public List<Assert> Asserts { get; set; } = new List<Assert>();
    }
}
