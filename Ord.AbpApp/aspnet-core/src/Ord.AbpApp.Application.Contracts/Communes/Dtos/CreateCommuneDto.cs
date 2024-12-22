using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Communes.Dtos
{
    public class CreateCommuneDto
    {
        public string CommuneName { get; set; }
        public int CommuneCode { get; set; }
        public CommuneType CommuneType { get; set; }
        public int ProvinceCode { get; set; }
        public int DistrictCode { get; set; }
    }
}
