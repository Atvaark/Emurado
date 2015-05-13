using Autofac;

namespace HaloOnline.Server.Core.Repository
{
    public class RepositoryPerRequestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .InstancePerRequest()
                .AsImplementedInterfaces();

            builder.RegisterType<HaloDbContext>()
                .InstancePerRequest()
                .AsImplementedInterfaces();
        }
    }
}
