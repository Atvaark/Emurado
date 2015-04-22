using Autofac;
using Autofac.Extras.Quartz;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Core.Scheduler.Jobs;
using Quartz;

namespace HaloOnline.Server.Core.Scheduler
{
    public class JobScheduler
    {
        private readonly IScheduler _scheduler;

        public JobScheduler()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<SchedulerModule>();
            containerBuilder.RegisterModule<RepositoryPerLifetimeScopeModule>();
            var container = containerBuilder.Build();
            var schedulerFactory = new AutofacSchedulerFactory(new AutofacJobFactory(container, "SchedulerScope"));
            _scheduler = schedulerFactory.GetScheduler();
            InitializeJobs();
        }

        private void InitializeJobs()
        {
            IJobDetail matchmakingJob = JobBuilder.Create<MatchmakingJob>()
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(matchmakingJob, trigger);
        }

        public void Start()
        {
            if (_scheduler.IsStarted)
            {
                return;
            }

            _scheduler.Start();
        }

        public void Stop()
        {
            _scheduler.Shutdown(true);
        }
    }
}
