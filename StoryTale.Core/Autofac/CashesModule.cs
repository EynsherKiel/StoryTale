using Autofac;
using LazyCache;
using StoryTale.Core.Caches;

namespace StoryTale.Core.Autofac
{
    public class CashesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CachingService>().As<IAppCache>().SingleInstance();
            builder.RegisterType<PipelineCache>().SingleInstance();
        }
    }
}