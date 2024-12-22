using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ord.AbpApp.Provinces.Dtos;
using Ord.AbpApp.Serivce;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ord.AbpApp.Controllers
{
    public class ExelImportController : ControllerBase
    {
        private readonly ExcelImportService _excelImporterService;

        public ExelImportController(ExcelImportService excelImporterService)
        {
            _excelImporterService = excelImporterService;
        }

        [HttpPost("import")]
        public async Task<ActionResult> ImportExcel(IFormFile file)
        {

            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    await _excelImporterService.ImportExcel(stream);
                    
                }
                return Ok();
            }

            return BadRequest("No file uploaded");
        }

       
    }
}


