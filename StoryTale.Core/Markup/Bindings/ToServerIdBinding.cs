using System;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;

namespace StoryTale.Core.Markup.Bindings
{
    public class ToServerIdBinding : IBinding
    {
        private const string _referenceName = "global";

        public bool TryMatch(object obj, out object value)
        {
            if (!obj.TryFind(out var arr))
            {
                value = default;
                return false;
            }

            if (arr.Length != 2 || arr[0] != _referenceName)
            {
                value = default;
                return false;
            }

            value = arr[1];
            return true;
        }

        public Func<object> Create(object value, Map map)
        {
            return () => map.Global.Unpack()[(string)value];
        }
    }
}