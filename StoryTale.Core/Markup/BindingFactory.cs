using Newtonsoft.Json.Linq;
using StoryTale.Core.Data;
using StoryTale.Core.Markup.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class BindingFactory
    {
        private readonly IEnumerable<IBinding> _bindings;

        public BindingFactory(IEnumerable<IBinding> bindings)
        {
            _bindings = bindings;
        }

        public Func<ProcessData, JToken> Create(object obj)
        {
            if (obj == null)
            {
                var empty = new JObject();
                return tree => empty;
            }

            if(obj is IDictionary<object, object> dic)
            {
                var clone = dic.ToDictionary(
                    el => (string)el.Key,
                    el => Create(el.Value));

                return tree =>
                {
                    var jobj = new JObject();

                    foreach (var item in clone.Select(el => new JProperty(el.Key, el.Value(tree))))
                    {
                        jobj.Add(item);
                    }

                    return jobj;
                };
            }

            if(obj is IEnumerable<object> enumerable)
            {
                var clone = enumerable.Select(Create).ToArray();

                return tree => JArray.FromObject(clone.Select(func => func(tree)));
            }

            var binding = _bindings.Select(el => el.TryCreate(obj)).SingleOrDefault(el => el != null);
            if (binding != null)
                return binding;

            var jobj = JToken.FromObject(obj);
            return tree => jobj; // just empty
        }
    }
}