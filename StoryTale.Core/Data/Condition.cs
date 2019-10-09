namespace StoryTale.Core.Data
{
    public class Condition : IInputExpression
    {
        public object In { get; set; }
        public string Expr { get; set; }
    }
}