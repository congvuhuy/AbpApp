using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ord.AbpApp.Entities
{
    [Table("Hospital")]
    public class Hospital:FullAuditedEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string HospitalName {  get; set; }
        [Required]
        public int ProvinceCode { get; set; }
        [Required]
        public int DistrictCode {  get; set; }
        [Required]
        public int CommuneCode { get; set; }
        [StringLength(100)]
        public string Address {  get; set; }
    }
}
