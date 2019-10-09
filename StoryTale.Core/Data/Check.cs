using Newtonsoft.Json.Linq;

namespace StoryTale.Core.Data
{
    public class Check
    {
        public bool IsPassed { get; set; }
        public string Name { get; set; }
        public string Expr { get; set; }
        public JToken In { get; set; }
    }
}