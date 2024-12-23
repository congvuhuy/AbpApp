using Ord.AbpApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.IRepositories
{
    public interface ICommuneRepository:IScopedDependency
    {
        Task<List<Commune>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<Commune>> GetbByCodeAsync(int code);
    }
}
