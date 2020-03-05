using Autofac;

namespace Classificados.API
{
    public class ApiModule : Autofac.Module
    {
        protected override void Load (ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
