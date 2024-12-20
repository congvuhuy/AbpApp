using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ord.AbpApp.Entities;
using Ord.AbpApp.Districts.Dtos;

namespace Ord.AbpApp.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            //province
            CreateMap<ProvinceDto, Province>();
            CreateMap<Province, ProvinceDto>();
            
            CreateMap<CreateProvinceDto, ProvinceDto>();
            CreateMap<CreateProvinceDto, Province>();

            CreateMap<UpdateProvinceDto, Province>();

            //District
            CreateMap<DistrictDto, District>();
            CreateMap<District, DistrictDto>();

            CreateMap<CreateDistrictDto, DistrictDto>();
            CreateMap<CreateDistrictDto, District>();

            CreateMap<UpdateDistrictDto, District>();
        }
    }
}
