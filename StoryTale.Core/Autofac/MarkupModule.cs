using Autofac;
using StoryTale.Core.Markup;

namespace StoryTale.Core.Autofac
{
    public class MarkupModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapFantasy>().SingleInstance(); 
        }
    }
}