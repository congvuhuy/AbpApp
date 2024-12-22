using Ord.AbpApp.Districts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Districts
{
    public interface IDistrictService:IScopedDependency
    {
        public Task<List<DistrictDto>> GetFilterAsync(int pageNumber, int pageSize);
        public Task<List<DistrictDto>> GetByCode(int code);
    }
}
