using Volo.Abp.Settings;

namespace BlogsApp.Settings;

public class BlogsAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BlogsAppSettings.MySetting1));
    }
}
