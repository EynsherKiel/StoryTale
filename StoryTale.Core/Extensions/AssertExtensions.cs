using StoryTale.Core.Data;
using StoryTale.Core.Exceptions;
using StoryTale.Core.Markup;

namespace StoryTale.Core.Extensions
{
    public static class AssertExtensions
    {
        public static Check Check(this Assert assert, ProcessToken token, Container container)
        {
            var @in = token.GetIn(assert.Condition);
            var isPassed = token.CheckCondition(assert.Condition, @in);

            if (!isPassed && assert.IsGenerateException)
                throw new AssertException($"In {container.Name} (id: {container.Id}) was not passed is Assert {assert.Name} with condition {assert.Condition.Expr} by object {@in}");

            return new Check
            {
                IsPassed = isPassed,
                Name = assert.Name,
                Expr = assert.Condition.Expr,
                In = @in
            };
        }
    }
}