using System.Threading.Tasks;

namespace Ord.AbpApp.Data;

public interface IAbpAppDbSchemaMigrator
{
    Task MigrateAsync();
}
