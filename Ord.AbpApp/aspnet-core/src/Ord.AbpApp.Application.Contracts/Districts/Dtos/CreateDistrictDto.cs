using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Districts.Dtos
{
    public class CreateDistrictDto
    {
        public string DistrictName { get; set; } = string.Empty;
        public int DistrictCode { get; set; }
        public DistrictType DistrictType { get; set; }
        public int ProvinceCode { get; set; }
    }
}
