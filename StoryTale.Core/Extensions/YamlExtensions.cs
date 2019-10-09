using YamlDotNet.Serialization;

namespace StoryTale.Core.Extensions
{
    public static class YamlExtensions
    {
        public static DeserializerBuilder WithTagMapping<T>(this DeserializerBuilder builder)
        {
            var type = typeof(T);
            return builder.WithTagMapping($"!{type.Name.ToLowerInvariant()}", type);
        }
    }
}
