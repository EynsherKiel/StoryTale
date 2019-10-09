using Autofac;

namespace StoryTale.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterModule<MediatorModule>()
                .RegisterModule<DatabaseModule>()
                .RegisterModule<YamlModule>()
                .RegisterModule<CashesModule>()
                .RegisterModule<WebModule>()
                .RegisterModule<MarkupModule>();
        }
    }
}