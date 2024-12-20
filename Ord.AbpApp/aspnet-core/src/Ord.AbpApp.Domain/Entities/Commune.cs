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
    [Table("Commune")]
    public class Commune:FullAuditedEntity<int>
    {
        public string CommuneName {  get; set; }
        public int CommuneCode { get; set; }
        public CommuneType CommuneType { get; set; }
        public int DistrictID { get; set; }
    }
}
