using BlogsApp.Localization;
using Volo.Abp.Application.Services;

namespace BlogsApp;

/* Inherit your application services from this class.
 */
public abstract class BlogsAppAppService : ApplicationService
{
    protected BlogsAppAppService()
    {
        LocalizationResource = typeof(BlogsAppResource);
    }
}
