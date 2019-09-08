using System.Dynamic;
using System.Net.Http;

namespace StoryTale.Core.Data
{
    public class Server
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Uri { get; set; }
        public string HttpMethod { get; set; }
        public ExpandoObject In { get; set; } = new ExpandoObject();
        public ExpandoObject Out { get; set; } = new ExpandoObject();
        public ExpandoObject When { get; set; } = new ExpandoObject();
    }
}