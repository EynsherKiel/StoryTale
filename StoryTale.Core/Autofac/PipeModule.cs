using Autofac;
using StoryTale.Core.Pipe;

namespace StoryTale.Core.Autofac
{
    public class PipeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PipelineManager>().SingleInstance();
        }
    }
}