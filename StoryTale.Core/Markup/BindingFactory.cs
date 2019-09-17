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

        public Func<Tree, object> Create(object obj)
        {
            if(obj == null)
                return tree => obj;

            if(obj is IDictionary<object, object> dic)
            {
                var clone = dic.ToDictionary(
                    el => el.Key,
                    el => Create(el.Value));

                return tree => clone.ToDictionary(el => el.Key, el => el.Value(tree));
            }

            if(obj is IEnumerable<object> enumerable)
            {
                var clone = enumerable.Select(Create).ToArray();

                return tree => clone.Select(func => func(tree)).ToArray();
            }

            var binding = _bindings.Select(el => el.TryCreate(obj)).SingleOrDefault(el => el != null);
            if (binding != null)
                return binding;

            return tree => obj;
        }
    }
}