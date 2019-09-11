using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace StoryTale.Core.Markup.Bindings
{
    public class ExpandoObjectBinding
    {
        private readonly IList<IBinding> _bindings;

        public ExpandoObjectBinding(IList<IBinding> bindings)
        {
            _bindings = bindings;
        }

        public Func<Map, ExpandoObject> Create(object obj)
        {
            var bindings = ((ExpandoObject)obj).ToDictionary(
                    pair => pair.Key.ToLowerInvariant(),
                    pair => 
                        _bindings.Select(el => el.TryCreate(pair.Value)).SingleOrDefault(el => el != null) ?? 
                        Create(obj));

            return map => bindings.ToExpando(func => func(map));
        }
    }
}