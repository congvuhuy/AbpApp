using Ord.AbpApp.Provinces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ord.AbpApp.Entities;
using Ord.AbpApp.Districts.Dtos;
using Ord.AbpApp.Communes.Dtos;

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

            //Commune
            CreateMap<CommuneDto, Commune>();
            CreateMap<Commune, CommuneDto>();

            CreateMap<CreateCommuneDto, CommuneDto>();
            CreateMap<CreateCommuneDto, Commune>();

            CreateMap<UpdateCommuneDto, Commune>();
        }
    }
}
