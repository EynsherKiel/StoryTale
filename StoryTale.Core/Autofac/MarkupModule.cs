using Autofac;
using StoryTale.Core.Markup;
using StoryTale.Core.Markup.Moduls;
using AutofacModule = Autofac.Module;

namespace StoryTale.Core.Autofac
{
    public class MarkupModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BindingFactory>().SingleInstance();
            builder.RegisterType<PipelineFactory>().SingleInstance();
            builder.RegisterType<ServerModule>().SingleInstance();
        }
    }
}