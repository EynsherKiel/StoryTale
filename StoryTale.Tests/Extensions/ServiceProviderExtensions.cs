using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Linq;

namespace StoryTale.Tests.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void MockSingleton<T>(this IServiceCollection services, Action<Mock<T>> setup) where T : class
        {
            var mock = new Mock<T>();

            setup(mock);

            services.MockSingleton(mock);
        }

        public static void MockSingleton<T>(this IServiceCollection services, Mock<T> mock) where T : class
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(T));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddSingleton(mock.Object);
        }
    }
}
