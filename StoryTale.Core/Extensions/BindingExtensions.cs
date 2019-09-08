using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;

namespace StoryTale.Core.Extensions
{
    public static class BindingExtensions
    {
        public static bool TryGetYamlReference(this object obj, out string value)
        {
            if (!(obj is Dictionary<object, object> yamlRef) || yamlRef.Keys.Count != 1)
            {
                value = default;
                return false;
            }

            value = (string)yamlRef.Keys.First();
            return true;
        }

        public static bool TryFind(this object obj, out string[] arr, string separator = " ")
        {
            if (!obj.TryGetYamlReference(out var item))
            {
                arr = default;
                return false;
            }

            arr = item.Split(separator);
            return true;
        }

        public static ExpandoObject GetParameters(this ExpandoObject expandoObject)
            => expandoObject.Clone(obj => obj is Func<object> func ? func() : obj);
    }
}