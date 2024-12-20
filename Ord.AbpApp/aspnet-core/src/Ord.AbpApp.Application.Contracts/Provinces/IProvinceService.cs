using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Provinces
{
    public interface IProvinceService:IScopedDependency
    {
        public Task<ProvinceDto> GetById(int id);
        public Task<List<ProvinceDto>> GetFilterAll(int pageNumber, int pageSize);
        public Task<ProvinceDto>Create(CreateProvinceDto createProvinceDto);
        public Task<ProvinceDto> Update(int id,UpdateProvinceDto updateProvinceDto);
        public Task DeleteById(int id);

    }
}
