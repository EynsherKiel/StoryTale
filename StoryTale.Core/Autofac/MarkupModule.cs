using Autofac;
using StoryTale.Core.Markup;
using StoryTale.Core.Markup.Bindings;

namespace StoryTale.Core.Autofac
{
    public class MarkupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapMarkupFactory>().SingleInstance();
            builder.RegisterType<BindingFactory>().SingleInstance();
        }
    }
}