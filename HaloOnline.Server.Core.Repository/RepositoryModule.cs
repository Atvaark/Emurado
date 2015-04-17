using Autofac;

namespace HaloOnline.Server.Core.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .InstancePerRequest()
                .AsImplementedInterfaces();
        }
    }
}
