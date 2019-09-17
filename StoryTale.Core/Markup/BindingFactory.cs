using StoryTale.Core.Data;
using StoryTale.Core.Markup.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class BindingFactory
    {
        private readonly IList<IBinding> _bindings;

        public BindingFactory(IList<IBinding> bindings)
        {
            _bindings = bindings;
        }

        public Func<Map, object> Create(object obj)
        {
            if(obj == null)
                return map => obj;

            if(obj is IDictionary<object, object> dic)
            {
                var clone = dic.ToDictionary(
                    el => el.Key,
                    el => Create(el.Value));

                return map => clone.ToDictionary(el => el.Key, el => el.Value(map));
            }

            if(obj is IEnumerable<object> enumerable)
            {
                var clone = enumerable.Select(Create).ToArray();

                return map => clone.Select(func => func(map)).ToArray();
            }

            var binding = _bindings.Select(el => el.TryCreate(obj)).SingleOrDefault(el => el != null);
            if (binding != null)
                return binding;

            return map => obj;
        }
    }
}