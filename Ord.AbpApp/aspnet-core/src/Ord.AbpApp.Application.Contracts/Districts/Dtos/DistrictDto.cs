using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ord.AbpApp.Districts.Dtos
{
    public class DistrictDto
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int DistrictCode { get; set; }
        public DistrictType DistrictType { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? CreatorId { get; set; }
        public long? LastModifierId { get; set; }
        public long? DeleterId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
