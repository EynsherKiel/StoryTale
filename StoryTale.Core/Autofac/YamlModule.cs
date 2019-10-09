using Autofac;
using StoryTale.Core.Data;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using StoryTale.Core.Extensions;

namespace StoryTale.Core.Autofac
{
    public class YamlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
                new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .WithTagMapping<GlobalBind>()
                    .WithTagMapping<IdBind>()
                    .WithTagMapping<Server>()
                    .Build()).SingleInstance();
        }
    }
}