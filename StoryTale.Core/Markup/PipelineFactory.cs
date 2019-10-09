using StoryTale.Core.Data;
using StoryTale.Core.Extensions;
using StoryTale.Core.Markup.Moduls;
using YamlDotNet.Serialization;

namespace StoryTale.Core.Markup
{
    public class PipelineFactory
    {
        private readonly IDeserializer _deserializer;
        private readonly BindingFactory _binding;
        private readonly ServerModule _serverModule;

        public PipelineFactory(IDeserializer deserializer, BindingFactory binding, ServerModule serverModule)
        {
            _deserializer = deserializer;
            _binding = binding;
            _serverModule = serverModule;
        }

        public Pipeline Create(string yaml)
        {
            var map = _deserializer.Deserialize<Map>(yaml);
            var tree = map.GetTree();

            var bindingMap = new BindingMap(map, _binding)
                .Registr(container => container.When)
                .Registr(container => container.Server)
                .Registr(container => container.Asserts);

            return new Pipeline(tree, bindingMap, _serverModule);
        }
    }
}
