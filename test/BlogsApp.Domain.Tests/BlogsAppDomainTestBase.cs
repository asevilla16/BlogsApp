using Volo.Abp.Modularity;

namespace BlogsApp;

/* Inherit from this class for your domain layer tests. */
public abstract class BlogsAppDomainTestBase<TStartupModule> : BlogsAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
