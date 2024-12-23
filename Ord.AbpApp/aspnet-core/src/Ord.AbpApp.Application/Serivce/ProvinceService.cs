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
using Ord.AbpApp.AddressLevel;
using System.IO;
using OfficeOpenXml;
using System.Globalization;

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
        private readonly IRepository<Province, int> _repository;
        

        public ProvinceService(IProvinceRepository provinceRepository, IMapper mapper, IRepository<Province, int> repository
            ) : base(repository)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
            _repository = repository;
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
            try
            {

                var provinces = _mapper.Map<List<Province>>(input);
                    await _repository.InsertManyAsync(provinces);                        
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task ImportExcel(Stream excelStream)
        {
            var provinceList = new List<CreateProvinceDto>();
            var errors = new List<string>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(excelStream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = 2; row <= worksheet.Dimension.End.Row - 1; row++)
                    {
                        var provinceCodeStr = worksheet.Cells[row, 1].Text;
                        var provinceName = worksheet.Cells[row, 2].Text;
                        var provinceTypeStr = worksheet.Cells[row, 4].Text;

                        if (!int.TryParse(provinceCodeStr, out int provinceCode) || provinceCode <= 0)
                        {

                            throw new Exception(message: "Sai province code");
                        }

                        if (string.IsNullOrEmpty(provinceName) || provinceName.Length > 10)
                        {
                            throw new Exception(message: "Sai province name");
                        }

                        var normalizedProvinceTypeStr = NormalizeString(provinceTypeStr);
                        if (!Enum.TryParse(normalizedProvinceTypeStr, true, out ProvinceType provinceType))
                        {
                            errors.Add($"Row {row}: Invalid Province Type.");
                            continue;
                        }
                        var createProvinceDto = new CreateProvinceDto
                        {
                            ProvinceCode = provinceCode,
                            ProvinceName = provinceName,
                            ProvinceType = provinceType
                        };


                        provinceList.Add(createProvinceDto);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public string NormalizeString(string input)
        {
            var normalizedString = input.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString()
                                .Normalize(NormalizationForm.FormC)
                                .Replace(" ", string.Empty)
                                .ToLower();
        }
    }
}
