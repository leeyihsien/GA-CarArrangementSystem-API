using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API.Models;
using AutoMapper;

namespace GA_CarArrangementSystem_API.Helpers.AutoMapper
{
    public class DTOtoEF_MappingProfile : Profile
    {

        public DTOtoEF_MappingProfile()
        {
            CreateMap<ArrangementInfoDTO, ArrangementInfo>();
        }
    }
}
