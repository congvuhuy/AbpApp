using Volo.Abp.Modularity;

namespace Ord.AbpApp;

[DependsOn(
    typeof(AbpAppApplicationModule),
    typeof(AbpAppDomainTestModule)
)]
public class AbpAppApplicationTestModule : AbpModule
{

}
