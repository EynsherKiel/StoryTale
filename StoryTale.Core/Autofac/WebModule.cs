using Autofac;
using StoryTale.Core.Services;
using StoryTale.Core.Web;

namespace StoryTale.Core.Autofac
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Client>().SingleInstance();
            builder.RegisterType<ServiceInvoker>().As<IServiceInvoker>().SingleInstance();
        }
    }
}