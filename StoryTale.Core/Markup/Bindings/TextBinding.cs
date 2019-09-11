using StoryTale.Core.Data;
using System;

namespace StoryTale.Core.Markup.Bindings
{
    // is primitive?
    public class TextBinding : IBinding
    {
        public Func<Map, object> TryCreate(object obj)
            => obj is string ? (map => obj) : default(Func<Map, object>);
    }
}