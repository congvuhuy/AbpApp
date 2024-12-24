using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Entities;
using Ord.AbpApp.Hospitals;
using Ord.AbpApp.Hospitals.Dtos;
using Ord.AbpApp.IRepositories;
using Ord.AbpApp.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ord.AbpApp.Serivce
{
    public class HospitalService :
        CrudAppService<
            Hospital,
            HospitalDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateAndUpdateHospitalDto>,
        IHospitalService
    {

        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICommuneRepository _communeRepository;
        public HospitalService(IRepository<Hospital, int> repository, IProvinceRepository provinceRepository , IDistrictRepository districtRepository,ICommuneRepository communeRepository) : base(repository)
        {
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
            _communeRepository = communeRepository;
        }
        public override async Task<HospitalDto> CreateAsync(CreateAndUpdateHospitalDto input)
        {
            try
            {
                
                var communeCode = await _communeRepository.GetByCodeAsync(input.CommuneCode);
               
                if (communeCode==null)
                {
                    throw new AbpValidationException("Mã xã không tồn tại",
                        new List<ValidationResult> { new ValidationResult("Mã xã không tồn tại") });
                }
                if (input.DistrictCode != communeCode.DistrictCode)
                {
                    throw new AbpValidationException("Huyện không có xã này",
                        new List<ValidationResult> { new ValidationResult("Huyện không có xã này") });
                }
                if (input.ProvinceCode != communeCode.ProvinceCode)
                {
                    throw new AbpValidationException("Tỉnh bạn chọn không tồn tại xã này",
                        new List<ValidationResult> { new ValidationResult("Tỉnh bạn chọn không tồn tại này") });
                }

                return await base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                throw new AbpValidationException(ex.Message,
                        new List<ValidationResult> { new ValidationResult(ex.Message) });
            }
        
        }
    }
}
