using Autofac;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace StoryTale.Core.Autofac
{
    public class YamlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
                new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build()).SingleInstance();
        }
    }
}