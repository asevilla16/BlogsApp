using Microsoft.Extensions.Localization;
using BlogsApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlogsApp;

[Dependency(ReplaceServices = true)]
public class BlogsAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BlogsAppResource> _localizer;

    public BlogsAppBrandingProvider(IStringLocalizer<BlogsAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
