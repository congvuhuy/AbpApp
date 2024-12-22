using OfficeOpenXml;
using Ord.AbpApp.AddressLevel;
using Ord.AbpApp.Communes.Dtos;
using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Provinces;
using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ord.AbpApp.Serivce
{
    public class ExcelImportService : IScopedDependency
    {
        private readonly IProvinceService _provinceService; 
        public ExcelImportService(IProvinceService provinceService) 
        { 
            _provinceService = provinceService; 
        }
        public async Task ImportExcel(Stream excelStream)
        {
            var provinceList = new List<CreateProvinceDto>();

            try
            {
                using (var package = new ExcelPackage(excelStream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Lấy worksheet đầu tiên

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Bắt đầu từ hàng thứ 2 để bỏ qua tiêu đề
                    {
                        var provinceTypeStr = worksheet.Cells[row, 4].Text;
                        Enum.TryParse(provinceTypeStr, out ProvinceType provinceType);
                        var createProvinceDto = new CreateProvinceDto
                        {
                            ProvinceCode = int.Parse(worksheet.Cells[row, 1].Text),
                            ProvinceName = worksheet.Cells[row, 2].Text,
                            ProvinceType = provinceType
                        };

                        provinceList.Add(createProvinceDto);

                    }
                    await _provinceService.CreateMultipleAsync(provinceList);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Lỗi khi xử lý tệp Excel: {ex.Message}");
            }
            
        }
       
    }
}
