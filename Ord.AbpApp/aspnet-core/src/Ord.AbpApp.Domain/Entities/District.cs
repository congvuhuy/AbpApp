using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ord.AbpApp.Entities
{
    [Table("District")]
    public class District:FullAuditedEntity<int>
    {
        public string DistrictName {  get; set; }
        public int DistrictCode {  get; set; }
        public DistrictType DistrictType { get; set; }
        public int ProvinceCode {  get; set; }
    }
}
