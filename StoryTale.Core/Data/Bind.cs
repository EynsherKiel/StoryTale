
namespace StoryTale.Core.Data
{
    public class IdBind : Bind 
    {
        public int Id { get; set; }
    }

    public class GlobalBind : Bind
    {
    }

    public class Bind
    {
        public string Path { get; set; }
    }
}
