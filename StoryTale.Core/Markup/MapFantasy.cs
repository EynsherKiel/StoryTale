using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Markup.Bindings;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace StoryTale.Core.Markup
{
    public class MapFantasy
    {
        private readonly IDeserializer _deserializer;
        private readonly IList<IBinding> _bindings;

        public MapFantasy(IDeserializer deserializer, IList<IBinding> bindings)
        {
            _deserializer = deserializer;
            _bindings = bindings;
        }

        public Map Prepare(string yaml)
        {
            var map = _deserializer.Deserialize<Map>(yaml);

            Prepare(map);

            return map;
        }

        // Это должно быть в отдельном классе
        private void Prepare(Map map)
        {
            object value = default;
            foreach (var server in map.Servers)
            {
                server.In = server.In
                    .Clone(obj => 
                        _bindings.FirstOrDefault(el => el.TryMatch(obj, out value))?.Create(value, map) ?? obj);
            }
        }
    }
}