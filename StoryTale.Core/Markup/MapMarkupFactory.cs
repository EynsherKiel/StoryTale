using StoryTale.Core.Data;
using StoryTale.Core.Markup.Bindings;
using YamlDotNet.Serialization;

namespace StoryTale.Core.Markup
{
    public class MapMarkupFactory
    {
        private readonly IDeserializer _deserializer;
        private readonly ExpandoObjectBinding _binding;

        public MapMarkupFactory(IDeserializer deserializer, ExpandoObjectBinding binding)
        {
            _deserializer = deserializer;
            _binding = binding;
        }

        public MapMarkup Create(string yaml)
        {
            var map = _deserializer.Deserialize<Map>(yaml);

            return new MapMarkup(map, _binding);
        }
    }
}