using OfficeOpenXml;
using Ord.AbpApp.AddressLevel;
using Ord.AbpApp.Communes;
using Ord.AbpApp.Communes.Dtos;
using Ord.AbpApp.Districts;
using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Excels;
using Ord.AbpApp.Provinces;
using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Serivce
{
    public class ExcelImportService : IExcelImportService
    {
        private readonly IProvinceService _provinceService; 
        private readonly IDistrictService _districtService; 
        private readonly ICommuneService _communeService;
        public ExcelImportService(IProvinceService provinceService, IDistrictService districtService, ICommuneService communeService ) 
        { 
            _provinceService = provinceService; 
            _districtService = districtService;
            _communeService = communeService;
        }
        public async Task ImportExcelProvince(Stream excelStream)
        {
            var provinceList = new List<CreateProvinceDto>();
            var errors = new List<string>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(excelStream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = 2; row <= worksheet.Dimension.End.Row-1; row++) 
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
            catch(Exception ex)
            {
                throw new Exception("", ex);
            }
            
        }
        //Import District
        public async Task ImportExcelDistrict(Stream excelStream)
        {
            var districtList = new List<CreateDistrictDto>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(excelStream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = 2; row <= worksheet.Dimension.End.Row - 1; row++)
                    {
                        var districtTypeStr = worksheet.Cells[row, 4].Text;
                        var normalizedDistrictTypeStr = NormalizeString(districtTypeStr);
                        Enum.TryParse(normalizedDistrictTypeStr, out DistrictType districtType);
                        var createDistrictDto = new CreateDistrictDto
                        {
                            DistrictCode = int.Parse(worksheet.Cells[row, 1].Text),
                            DistrictName = worksheet.Cells[row, 2].Text,
                            DistrictType = districtType,
                            ProvinceCode = int.Parse(worksheet.Cells [row, 5].Text),
                        };
                        districtList.Add(createDistrictDto);
                    }

                    await _districtService.CreateMultipleAsync(districtList);
                }

            }
            catch (Exception ex)
            {
                
                throw ;
            }

        }
        //Import Commune
        public async Task ImportExcelCommune(Stream excelStream)
        {
            var communeList = new List<CreateCommuneDto>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(excelStream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = 2; row <= worksheet.Dimension.End.Row-1; row++)
                    {
                        var communeTypeStr = worksheet.Cells[row, 4].Text;
                        var normalizedCommuneTypeStr = NormalizeString(communeTypeStr);
                        Enum.TryParse(normalizedCommuneTypeStr, out CommuneType communeType);
                        var createCommuneDto = new CreateCommuneDto
                        {
                            CommuneCode = int.Parse(worksheet.Cells[row, 1].Text),
                            CommuneName = worksheet.Cells[row, 2].Text,
                            CommuneType=communeType,
                            DistrictCode = int.Parse(worksheet.Cells[row,5].Text),
                            ProvinceCode= int.Parse(worksheet.Cells[row,7].Text),

                        };
                        communeList.Add(createCommuneDto);
                    }

                    await _communeService.CreateMultipleAsync(communeList);
                }

            }
            catch (Exception ex)
            {
                throw;
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
