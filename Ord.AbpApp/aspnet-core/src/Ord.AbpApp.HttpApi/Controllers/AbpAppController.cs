using Ord.AbpApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Ord.AbpApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpAppController : AbpControllerBase
{
    protected AbpAppController()
    {
        LocalizationResource = typeof(AbpAppResource);
    }
}
