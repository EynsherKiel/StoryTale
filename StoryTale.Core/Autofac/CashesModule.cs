using Autofac;
using StoryTale.Core.Caches;

namespace StoryTale.Core.Autofac
{
    public class CashesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PipeCache>().SingleInstance();
        }
    }
}