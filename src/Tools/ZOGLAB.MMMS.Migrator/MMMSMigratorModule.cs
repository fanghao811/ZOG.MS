using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using ZOGLAB.MMMS.EntityFramework;

namespace ZOGLAB.MMMS.Migrator
{
    [DependsOn(typeof(MMMSDataModule))]
    public class MMMSMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MMMSDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}