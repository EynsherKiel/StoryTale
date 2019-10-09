using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace StoryTale.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .AddMediatR(typeof(CoreModule).Assembly)
                .RegisterModule<DatabaseModule>()
                .RegisterModule<YamlModule>()
                .RegisterModule<CashesModule>()
                .RegisterModule<WebModule>()
                .RegisterModule<MarkupModule>();
        }
    }
}