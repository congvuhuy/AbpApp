using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Data;

/* This is used if database provider does't define
 * IAbpAppDbSchemaMigrator implementation.
 */
public class NullAbpAppDbSchemaMigrator : IAbpAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
