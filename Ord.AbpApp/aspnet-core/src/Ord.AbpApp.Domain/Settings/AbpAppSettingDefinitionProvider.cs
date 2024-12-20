using Volo.Abp.Settings;

namespace Ord.AbpApp.Settings;

public class AbpAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpAppSettings.MySetting1));
    }
}
