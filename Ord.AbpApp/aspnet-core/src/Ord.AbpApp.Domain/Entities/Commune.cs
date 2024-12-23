using Ord.AbpApp.AddressLevel;
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
    [Table("Commune")]
    public class Commune:FullAuditedEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string CommuneName {  get; set; }
        [Required]
        public int CommuneCode { get; set; }
        public CommuneType CommuneType { get; set; }
        [Required]
        public int ProvinceCode { get; set; }
        [Required]
        public int DistictCode { get; set; }
    }
}
