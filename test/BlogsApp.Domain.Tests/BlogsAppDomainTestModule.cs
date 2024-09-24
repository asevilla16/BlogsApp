using Volo.Abp.Modularity;

namespace BlogsApp;

[DependsOn(
    typeof(BlogsAppDomainModule),
    typeof(BlogsAppTestBaseModule)
)]
public class BlogsAppDomainTestModule : AbpModule
{

}
