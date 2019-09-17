using StoryTale.Core.Data;
using YamlDotNet.Serialization;

namespace StoryTale.Core.Markup
{
    public class ProcessesFactory
    {
        private readonly IDeserializer _deserializer;
        private readonly BindingFactory _binding;

        public ProcessesFactory(IDeserializer deserializer, BindingFactory binding)
        {
            _deserializer = deserializer;
            _binding = binding;
        }

        public ProcessFactory Create(string yaml) => new ProcessFactory(_deserializer.Deserialize<Map>(yaml), _binding);
    }
}