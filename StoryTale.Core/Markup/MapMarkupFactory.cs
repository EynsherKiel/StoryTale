using StoryTale.Core.Data;
using YamlDotNet.Serialization;

namespace StoryTale.Core.Markup
{
    public class MapMarkupFactory
    {
        private readonly IDeserializer _deserializer;
        private readonly BindingFactory _binding;

        public MapMarkupFactory(IDeserializer deserializer, BindingFactory binding)
        {
            _deserializer = deserializer;
            _binding = binding;
        }

        public MapMarkup Create(string yaml) => new MapMarkup(_deserializer.Deserialize<Map>(yaml), _binding);
    }
}