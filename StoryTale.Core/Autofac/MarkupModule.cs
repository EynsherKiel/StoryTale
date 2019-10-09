using Autofac;
using StoryTale.Core.Markup;
using StoryTale.Core.Markup.Bindings;
using StoryTale.Core.Markup.Moduls;
using System.Reflection;
using AutofacModule = Autofac.Module;

namespace StoryTale.Core.Autofac
{
    public class MarkupModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MarkupModule).Assembly)
                   .AsImplementedInterfaces();
            builder.RegisterType<BindingFactory>().SingleInstance();
            builder.RegisterType<PipelineFactory>().SingleInstance();
            builder.RegisterType<ServerModule>().SingleInstance();
        }
    }
}