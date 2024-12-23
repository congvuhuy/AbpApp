using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Districts;
using Ord.AbpApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Ord.AbpApp.Communes;
using Ord.AbpApp.Communes.Dtos;
using AutoMapper;
using Ord.AbpApp.IRepositories;
using Ord.AbpApp.Provinces;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Ord.AbpApp.Serivce
{
    public class CommuneService: 
        CrudAppService<
        Commune,
        CommuneDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateCommuneDto>, ICommuneService
    {
        private readonly ICommuneRepository _communeRepository;
        private readonly IMapper _mapper;
        private readonly IDistrictService _districtService;
        private readonly IProvinceService _provinceService;
        private readonly IRepository<Commune, int> _repository;
        public CommuneService(ICommuneRepository communeRepository, IMapper mapper,IProvinceService provinceService, IDistrictService districtService, IRepository<Commune, int> repository
           ) : base(repository)
        {
            _communeRepository = communeRepository;
            _mapper = mapper;
            _districtService = districtService;
            _provinceService = provinceService;
            _repository = repository;
        }

        public override async Task<CommuneDto> CreateAsync(CreateCommuneDto input)
        {
            var provinceCode = await _provinceService.GetByCode(input.ProvinceCode);
            var districtCode = await _districtService.GetByCode(input.DistrictCode);
            var communeCode = await _communeRepository.GetbByCodeAsync(input.CommuneCode);
            if (communeCode.Any())
            {
                throw new AbpValidationException("Mã xã đã tồn tại",
                      new List<ValidationResult> { new ValidationResult("Mã xã đã tồn tại") });
            }
            if (!provinceCode.Any())
            {
                throw new AbpValidationException("Tỉnh bạn chọn không tồn tại",
                    new List<ValidationResult> { new ValidationResult("Tỉnh bạn chọn không tồn tại") });
            }
            if (!districtCode.Any())
            {
                throw new AbpValidationException("Huyện bạn chọn không tồn tại",
                   new List<ValidationResult> { new ValidationResult("Huyện bạn chọn không tồn tại") });
            }

            return await base.CreateAsync(input);
        }
        public async Task CreateMultipleAsync(List<CreateCommuneDto> communeList)
        {
            try
            {
                var communes= _mapper.Map<List<Commune>>(communeList);
                    await _repository.InsertManyAsync(communes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<CommuneDto>> GetFilterAsync(int pageNumber, int pageSize)
        {
            var communes = await _communeRepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<CommuneDto>>(communes);
        }
    }
}
