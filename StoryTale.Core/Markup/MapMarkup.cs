using StoryTale.Core.Data;
using StoryTale.Core.Markup.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTale.Core.Markup
{
    public class MapMarkup
    {
        private readonly Map _source;
        private readonly IDictionary<int, Func<Map, Server>> _bindings;

        public MapMarkup(Map source, ExpandoObjectBinding binding)
        {
            _source = source;

            _bindings = _source.Servers.ToDictionary(
                server => server.Id,
                server =>
                {
                    var @in = binding.Create(server.In);

                    return (Func<Map, Server>)(map => 
                    {
                        var current = map.Servers.Single(el => el.Id == server.Id);

                        current.In = @in(map);

                        return current;
                    });
                });
        }

        public Map GetClone()
        {
            return _source; // that must be do deep clone
        }

        public Server GetBy(Map clone, int serverId)
        {
            return _bindings[serverId](clone);
        }
    }
}
