using BlogsApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlogsApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlogsAppController : AbpControllerBase
{
    protected BlogsAppController()
    {
        LocalizationResource = typeof(BlogsAppResource);
    }
}
