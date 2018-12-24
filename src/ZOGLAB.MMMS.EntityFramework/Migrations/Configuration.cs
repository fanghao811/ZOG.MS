using System.Data.Entity.Migrations;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using EntityFramework.DynamicFilters;
using ZOGLAB.MMMS.Migrations.Seed.BD;
using ZOGLAB.MMMS.Migrations.Seed.Host;
using ZOGLAB.MMMS.Migrations.Seed.Tenants;

namespace ZOGLAB.MMMS.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<EntityFramework.MMMSDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MMMS";
        }

        protected override void Seed(EntityFramework.MMMSDbContext context)
        {
            context.DisableAllFilters();

            context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
            context.EventBus = NullEventBus.Instance;

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantBuilder(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();

                //Default BD业务 seed
                new InitialBDBuilder(context).Create();
            }
            else
            {
                //You can add seed for tenant databases using Tenant property...
            }

            context.SaveChanges();
        }
    }
}
