using Dapper;
using Ord.AbpApp.Entities;
using Ord.AbpApp.EntityFrameworkCore;
using Ord.AbpApp.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace Ord.AbpApp.Repositories
{
    public class DistrictRepository: DapperRepository<AbpAppDbContext>,IDistrictRepository,ITransientDependency
    {
        public DistrictRepository(IDbContextProvider<AbpAppDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public virtual async Task<List<District>> GetAllAsync(int pageNumber, int pageSize)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = @"SELECT * FROM District ORDER BY ProvinceCode LIMIT @PageSize OFFSET @Offset;";
            var parameters = new
            {
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            };

            return (await dbConnection.QueryAsync<District>(sql, parameters, transaction: await GetDbTransactionAsync())).ToList();
        }

        public async Task<District> GetByCodeAsync(int code)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = @"SELECT * FROM District WHERE DistrictCode=@Code";
            var parameters = new { Code = code };
            return (dbConnection.QueryFirstOrDefault<District>(sql, parameters, transaction: await GetDbTransactionAsync()));
        }
    }
}
