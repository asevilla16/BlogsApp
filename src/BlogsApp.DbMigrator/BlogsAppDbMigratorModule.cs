using BlogsApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BlogsApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlogsAppEntityFrameworkCoreModule),
    typeof(BlogsAppApplicationContractsModule)
)]
public class BlogsAppDbMigratorModule : AbpModule
{
}
