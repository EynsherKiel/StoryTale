using Autofac;
using StoryTale.Core.Markup;
using StoryTale.Core.Markup.Bindings;

namespace StoryTale.Core.Autofac
{
    public class MarkupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MarkupFactory>().SingleInstance();
            builder.RegisterType<BindingFactory>().SingleInstance();
        }
    }
}