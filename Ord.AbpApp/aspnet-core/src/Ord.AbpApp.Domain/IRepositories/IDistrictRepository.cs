using Ord.AbpApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.IRepositories
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllAsync(int pageNumber, int pageSize);
        Task<District> GetByCodeAsync(int code);
    }
}
