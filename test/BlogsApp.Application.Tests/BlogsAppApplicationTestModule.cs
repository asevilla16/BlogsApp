using Volo.Abp.Modularity;

namespace BlogsApp;

[DependsOn(
    typeof(BlogsAppApplicationModule),
    typeof(BlogsAppDomainTestModule)
)]
public class BlogsAppApplicationTestModule : AbpModule
{

}
