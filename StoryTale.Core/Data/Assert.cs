
namespace StoryTale.Core.Data
{
    public class Assert
    {
        public string Name { get; set; }
        public Condition Condition { get; set; } = new Condition();
        public bool IsGenerateException { get; set; }
    }
}