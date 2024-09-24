using Volo.Abp.Modularity;

namespace BlogsApp;

public abstract class BlogsAppApplicationTestBase<TStartupModule> : BlogsAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
