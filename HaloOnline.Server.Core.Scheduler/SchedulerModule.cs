using Autofac;
using Autofac.Extras.Quartz;

namespace HaloOnline.Server.Core.Scheduler
{
    public class SchedulerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            builder.RegisterModule(new QuartzAutofacJobsModule(ThisAssembly));
        }
    }
}