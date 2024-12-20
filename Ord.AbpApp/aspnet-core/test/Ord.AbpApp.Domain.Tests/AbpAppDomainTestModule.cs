using Volo.Abp.Modularity;

namespace Ord.AbpApp;

[DependsOn(
    typeof(AbpAppDomainModule),
    typeof(AbpAppTestBaseModule)
)]
public class AbpAppDomainTestModule : AbpModule
{

}
