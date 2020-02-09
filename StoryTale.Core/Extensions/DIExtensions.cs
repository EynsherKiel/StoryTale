using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StoryTale.Core.Caches;
using StoryTale.Core.Data;
using StoryTale.Core.Database;
using StoryTale.Core.Markup;
using StoryTale.Core.Markup.Bindings;
using StoryTale.Core.Markup.Moduls;
using StoryTale.Core.Services;
using StoryTale.Core.Web;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace StoryTale.Core.Extensions
{
    public static class DIExtensions
    {
        public static void AddStoryTale(this IServiceCollection services)
        {
            var assembly = typeof(DIExtensions).Assembly;

            services.AddLazyCache();
            services.AddSingleton<PipelineCache>();

            services.AddMediatR(assembly);

            services.AddSingleton(context =>
                new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .WithTagMapping<GlobalBind>()
                    .WithTagMapping<IdBind>()
                    .WithTagMapping<Server>()
                    .Build());

            services.AddSingleton<Client>();
            services.AddSingleton<IServiceInvoker, ServiceInvoker>();

            services.AddSingleton<ConnectionManager>();
            services.AddSingleton<Queries>();

            services.AddSingleton<BindingFactory>();
            services.AddSingleton<PipelineFactory>();
            services.AddSingleton<ServerModule>();

            services.Scan(scan => scan
              .FromAssemblyOf<IBinding>()
                .AddClasses(classes => classes.AssignableTo<IBinding>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
        }
    }
}