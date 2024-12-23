using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Provinces.Dtos
{
    public class CreateProvinceDto
    {
       
        public string ProvinceName { get; set; }
        public int ProvinceCode { get; set; }
        public ProvinceType ProvinceType { get; set; }
    }
}
