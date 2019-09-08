using StoryTale.Core.Data;
using System;

namespace StoryTale.Core.Markup.Bindings
{
    public interface IBinding
    {
        bool TryMatch(object obj, out object value);
        Func<object> Create(object value, Map map);
    }
}