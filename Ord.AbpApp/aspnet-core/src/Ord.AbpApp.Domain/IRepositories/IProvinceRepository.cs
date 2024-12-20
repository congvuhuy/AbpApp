using Ord.AbpApp.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;

namespace Ord.AbpApp.IRepositories
{
    public interface IProvinceRepository
    {
        Task<List<Province>> GetAllAsync(int pageNumber, int pageSize);
    }
}
