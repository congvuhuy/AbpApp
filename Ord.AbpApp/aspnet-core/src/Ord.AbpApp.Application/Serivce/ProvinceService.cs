using AutoMapper;
using Ord.AbpApp.Entities;
using Ord.AbpApp.IRepositories;
using Ord.AbpApp.Provinces;
using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ord.AbpApp.Serivce
{
    public class ProvinceService : ApplicationService, IProvinceService
    {
        private readonly IRepository<Province,int> _repository;
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IRepository<Province, int> repository, IMapper mapper, IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProvinceDto> Create(CreateProvinceDto createProvinceDto)
        {
            var createProvince = _mapper.Map<CreateProvinceDto, Province>(createProvinceDto);
            await _repository.InsertAsync(createProvince);
            return _mapper.Map<Province,ProvinceDto>(createProvince);
        }

        public async Task<List<ProvinceDto>> GetFilterAll(int pageNumber, int pageSize)
        {
            var provinceList = await _provinceRepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<Province>, List<ProvinceDto>>(provinceList);
        }

        public async Task<ProvinceDto> GetById(int id)
        {
            var provnice= await _repository.GetAsync(id);
            return _mapper.Map<Province,ProvinceDto>(provnice);
        }

        public async Task<ProvinceDto> Update(int id,UpdateProvinceDto updateProvinceDto)
        {
            var proviceUpdate = await _repository.GetAsync(id);
            _mapper.Map(updateProvinceDto, proviceUpdate); 
            await _repository.UpdateAsync(proviceUpdate);
            return _mapper.Map<Province, ProvinceDto>(proviceUpdate);
        }
        public async Task DeleteById(int id)
        {
            await _repository.DeleteAsync(id);
            
        }
    }
}
