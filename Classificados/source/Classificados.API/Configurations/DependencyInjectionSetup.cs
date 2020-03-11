using System;
using Microsoft.Extensions.DependencyInjection;
using Classificados.Infrastructure.CrossCutting.IoC;

namespace Classificados.API.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
