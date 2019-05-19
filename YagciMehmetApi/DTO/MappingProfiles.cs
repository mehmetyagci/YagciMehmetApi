using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YagciMehmetApi.Models;
using YagciMehmetApi.DTO;

namespace YagciMehmetApi.DTO
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<YagciMehmetApi.DTO.CategoryCreateDTO, YagciMehmetApi.Models.Category>()
                     .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name));

            CreateMap<YagciMehmetApi.Models.Test, YagciMehmetApi.DTO.TestDto>();
        }
    }
}