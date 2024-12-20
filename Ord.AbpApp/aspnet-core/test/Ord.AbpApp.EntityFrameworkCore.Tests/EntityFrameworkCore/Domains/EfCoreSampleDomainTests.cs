using Ord.AbpApp.Samples;
using Xunit;

namespace Ord.AbpApp.EntityFrameworkCore.Domains;

[Collection(AbpAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpAppEntityFrameworkCoreTestModule>
{

}
