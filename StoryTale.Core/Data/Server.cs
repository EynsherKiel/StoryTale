using Newtonsoft.Json.Linq;

namespace StoryTale.Core.Data
{
    public class Server
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Uri { get; set; }
        public string HttpMethod { get; set; }
        public object In { get; set; }
        [YamlDotNet.Serialization.YamlIgnore]
        public JToken Out { get; set; }
        public object When { get; set; }
    }
}