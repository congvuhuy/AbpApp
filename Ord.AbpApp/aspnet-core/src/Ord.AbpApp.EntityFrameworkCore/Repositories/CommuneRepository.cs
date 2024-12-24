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
    public class CommuneRepository : DapperRepository<AbpAppDbContext>, ICommuneRepository, ITransientDependency
    {
        public CommuneRepository(IDbContextProvider<AbpAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Commune>> GetAllAsync(int pageNumber, int pageSize)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = @"SELECT * FROM Commune ORDER BY CommuneCode LIMIT @PageSize OFFSET @Offset;";
            var parameters = new
            {
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            };

            return (await dbConnection.QueryAsync<Commune>(sql, parameters, transaction: await GetDbTransactionAsync())).ToList();
        }

        public async Task<Commune> GetByCodeAsync(int code)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = @"SELECT * FROM Commune WHERE CommuneCode=@Code";
            var parameters = new { Code = code };
            return (await dbConnection.QueryFirstOrDefaultAsync<Commune>(sql, parameters, transaction: await GetDbTransactionAsync()));
        }

       
    }
}
