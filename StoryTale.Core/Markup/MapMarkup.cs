using Force.DeepCloner;
using StoryTale.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class MapMarkup
    {
        private readonly Map _source;
        private readonly IDictionary<int, Func<Map, object>> _bindings;

        public MapMarkup(Map source, BindingFactory binding)
        {
            _source = source;

            _bindings = _source.Servers.ToDictionary(
                server => server.Id,
                server => binding.Create(server.In));
        }

        public Map GetClone() => _source.DeepClone();
        public object GetIn(Map clone, int serverId) => _bindings[serverId](clone);
    }
}
