﻿using Ord.AbpApp.AddressLevel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ord.AbpApp.Entities
{
    [Table("Province")]

    public class Province:FullAuditedEntity<int>
    {
        public string ProvinceName {  get; set; }
        
        public int ProvinceCode {  get; set; }
        public ProvinceType ProvinceType { get; set; }
    }
}