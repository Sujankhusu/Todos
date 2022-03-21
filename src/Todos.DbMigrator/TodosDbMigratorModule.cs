using Todos.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Todos.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TodosEntityFrameworkCoreModule),
    typeof(TodosApplicationContractsModule)
    )]
public class TodosDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
