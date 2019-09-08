using System;
using System.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Extensions;

namespace StoryTale.Core.Markup.Bindings
{
    public class ToGlobalBinding : IBinding
    {
        public bool TryMatch(object obj, out object value)
        {
            if (!obj.TryFind(out var arr))
            {
                value = default;
                return false;
            }

            if (arr.Length != 2 || !int.TryParse(arr.First(), out var _))
            {
                value = default;
                return false;
            }

            value = arr;
            return true;
        }

        public Func<object> Create(object value, Map map)
        {
            var arr = (string[])value;
            var id = int.Parse(arr.First());
            var server = map.Servers.Single(el => el.Id == id);
            var targetKey = arr.Last().ToLowerInvariant();

            return () =>
            {
                var dic = server.Out.Unpack();
                var key = dic.Keys.Single(el => el.ToLowerInvariant() == targetKey);

                return dic[key];
            };
        }
    }
}
