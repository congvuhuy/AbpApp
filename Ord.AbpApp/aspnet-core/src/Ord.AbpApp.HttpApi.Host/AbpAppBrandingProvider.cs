using Microsoft.Extensions.Localization;
using Ord.AbpApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Ord.AbpApp;

[Dependency(ReplaceServices = true)]
public class AbpAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpAppResource> _localizer;

    public AbpAppBrandingProvider(IStringLocalizer<AbpAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
