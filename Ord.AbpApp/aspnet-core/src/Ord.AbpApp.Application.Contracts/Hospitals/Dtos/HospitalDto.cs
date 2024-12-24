using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Hospitals.Dtos
{
    public class HospitalDto
    {
        public string HospitalName { get; set; }
        public int ProvinceCode { get; set; }
        public int DistrictCode { get; set; }
        public int CommuneCode { get; set; }
        public string Address {  get; set; }
    }
}
