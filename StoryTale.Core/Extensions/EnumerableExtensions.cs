using System.Collections.Generic;

namespace StoryTale.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T obj)
        {
            yield return obj;
        }
    }
}