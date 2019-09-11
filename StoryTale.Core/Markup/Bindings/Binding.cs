using StoryTale.Core.Data;
using System;
using System.Collections.Generic;

namespace StoryTale.Core.Markup.Bindings
{
    public class Binding : IBinding
    {
        public Func<Map, object> TryCreate(object obj)
        {
            if (!(obj is IDictionary<object, object> dic))
            {
                return default;
            }

            throw new NotImplementedException();
        }
    }
}