using Xunit;

namespace Ord.AbpApp.EntityFrameworkCore;

[CollectionDefinition(AbpAppTestConsts.CollectionDefinitionName)]
public class AbpAppEntityFrameworkCoreCollection : ICollectionFixture<AbpAppEntityFrameworkCoreFixture>
{

}
