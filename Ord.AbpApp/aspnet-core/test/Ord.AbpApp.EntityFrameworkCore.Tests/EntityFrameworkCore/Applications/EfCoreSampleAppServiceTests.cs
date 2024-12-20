using Ord.AbpApp.Samples;
using Xunit;

namespace Ord.AbpApp.EntityFrameworkCore.Applications;

[Collection(AbpAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpAppEntityFrameworkCoreTestModule>
{

}
