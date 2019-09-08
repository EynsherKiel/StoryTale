using Autofac;
using MediatR;
using System.Reflection;
using AutofacModule = Autofac.Module;

namespace StoryTale.Core.Autofac
{
    // https://github.com/jbogard/MediatR/wiki
    public class MediatorModule : AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            // uncomment to enable polymorphic dispatching of requests, but note that
            // this will conflict with generic pipeline behaviors
            // builder.RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // finally register our custom code (individually, or via assembly scanning)
            // - requests & handlers as transient, i.e. InstancePerDependency()
            // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
            // - behaviors as transient, i.e. InstancePerDependency()
            builder.RegisterAssemblyTypes(typeof(MediatorModule).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan
            // builder.RegisterType<MyHandler>().AsImplementedInterfaces().InstancePerDependency();          
            // or individually
        }
    }
}