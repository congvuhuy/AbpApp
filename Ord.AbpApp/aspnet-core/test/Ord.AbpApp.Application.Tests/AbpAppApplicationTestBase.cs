using Volo.Abp.Modularity;

namespace Ord.AbpApp;

public abstract class AbpAppApplicationTestBase<TStartupModule> : AbpAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
