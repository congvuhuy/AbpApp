using System;
using System.Collections.Generic;
using System.Text;
using Ord.AbpApp.Localization;
using Volo.Abp.Application.Services;

namespace Ord.AbpApp;

/* Inherit your application services from this class.
 */
public abstract class AbpAppAppService : ApplicationService
{
    protected AbpAppAppService()
    {
        LocalizationResource = typeof(AbpAppResource);
    }
}
