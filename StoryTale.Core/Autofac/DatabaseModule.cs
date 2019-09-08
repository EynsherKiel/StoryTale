using Autofac;
using StoryTale.Core.Database;

namespace StoryTale.Core.Autofac
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionManager>().SingleInstance();
            builder.RegisterType<Queries>().SingleInstance();
        }
    }
}