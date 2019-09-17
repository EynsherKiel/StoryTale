using Autofac;
using StoryTale.Core.Data;
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
                    .WithTagMapping("!globalbind", typeof(GlobalBind))
                    .WithTagMapping("!idbind", typeof(IdBind))
                    .Build()).SingleInstance();
        }
    }
}