using AutoMapper;
using Ord.AbpApp.Districts;
using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Entities;
using Ord.AbpApp.IRepositories;
using Ord.AbpApp.Provinces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace Ord.AbpApp.Serivce
{
    public class DistrictService :
         CrudAppService<
        District, 
        DistrictDto, 
        int, 
        PagedAndSortedResultRequestDto,
        CreateDistrictDto>, IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IProvinceService _provinceService;
        private readonly IRepository<District,int> _repository;
        public DistrictService(IDistrictRepository districtRepository, IMapper mapper, IProvinceService provinceService, IRepository<District,int> repository
            ) : base(repository) 
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
            _provinceService = provinceService;
            _repository=repository;
        }


        public override async Task<DistrictDto> CreateAsync(CreateDistrictDto input)
        {
            var provinceCode = await _provinceService.GetByCode(input.ProvinceCode);
            if (!provinceCode.Any())
            {
                throw new AbpValidationException("Tỉnh bạn chọn không tồn tại", 
                    new List<ValidationResult> { new ValidationResult("Tỉnh bạn chọn không tồn tại") });
            }

            return await base.CreateAsync(input);
        }

        public async Task<List<DistrictDto>> GetFilterAsync(int pageNumber, int pageSize)
        {
            var districts = await _districtRepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<DistrictDto>>(districts);
        }
        public async Task<List<DistrictDto>> GetByCode(int code)
        {
            var districts = await _districtRepository.GetByCodeAsync(code);
            return _mapper.Map<List<DistrictDto>>(districts);
        }

        public async Task CreateMultipleAsync(List<CreateDistrictDto> districtList)
        {
            try
            {
                var districts=_mapper.Map<List<District>>(districtList);
                    await _repository.InsertManyAsync(districts);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
