using Autofac;

namespace HaloOnline.Server.Core.Repository
{
    public class RepositoryPerLifetimeScopeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            builder.RegisterType<HaloDbContext>()
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();
        }
    }
}