
namespace StoryTale.Core.Data
{
    public class Server : IInputExpression
    {
        public string Uri { get; set; }
        public string HttpMethod { get; set; }
        public object In { get; set; }
    }
}