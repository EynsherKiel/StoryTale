using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace StoryTale.Core.Extensions
{
    public static class ExpandoObjectExtensions
    {
        public static IDictionary<string, object> Unpack(this ExpandoObject obj) => obj;

        public static bool Compare(this ExpandoObject left, ExpandoObject right)
        {
            if (left == null && left == null)
                return true;
             
            return left.Open().SequenceEqual(right.Open());
        }

        private static IEnumerable<string> Open(this ExpandoObject obj)
        {
            return obj.Unpack().Keys.Select(el => el.ToLowerInvariant());
        }

        public static ExpandoObject Clone(this ExpandoObject expandoObject, Func<object, object> doSomething)
        {
            var result = new ExpandoObject();
            var dictionary = result.Unpack();

            foreach (var item in expandoObject.Unpack())
            {
                dictionary[item.Key] = doSomething(item.Value);
            }

            return result;
        }
    }
}
