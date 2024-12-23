using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Provinces
{
    public interface IProvinceService:IScopedDependency
    {
        public Task<List<ProvinceDto>> GetByCode(int code);
        public Task<List<ProvinceDto>> GetFilterAll(int pageNumber, int pageSize);

        public Task CreateMultipleAsync(List<CreateProvinceDto> input);
        public Task ImportExcel(Stream excelStream);
    }
}
