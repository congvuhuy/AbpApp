using Volo.Abp.Modularity;

namespace Ord.AbpApp;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpAppDomainTestBase<TStartupModule> : AbpAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
