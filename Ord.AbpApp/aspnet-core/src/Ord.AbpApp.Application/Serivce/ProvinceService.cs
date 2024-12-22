using AutoMapper;
using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Districts;
using Ord.AbpApp.Entities;
using Ord.AbpApp.IRepositories;
using Ord.AbpApp.Provinces;
using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ord.AbpApp.Serivce
{
    public class ProvinceService : 
        CrudAppService<
        Province,
        ProvinceDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateProvinceDto>, IProvinceService
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository, IMapper mapper, IRepository<Province, int> repository
            ) : base(repository)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }
        public async Task<List<ProvinceDto>> GetFilterAll(int pageNumber, int pageSize)
        {
            var provinceList = await _provinceRepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<Province>, List<ProvinceDto>>(provinceList);
        }
        public async Task<List<ProvinceDto>> GetByCode(int code)
        {
            var province = await _provinceRepository.GetByCodeAsync(code);
            return _mapper.Map<List<ProvinceDto>>(province);
        }
        public async Task CreateMultipleAsync(List<CreateProvinceDto> input) 
        { 
            foreach (var createProvinceDto in input) { 
                await CreateAsync(createProvinceDto); 
            } 
        }
    }
}
