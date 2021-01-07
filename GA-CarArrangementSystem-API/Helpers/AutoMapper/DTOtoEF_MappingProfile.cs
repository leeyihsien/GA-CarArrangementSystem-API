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
        /// <summary>
        /// 建立各個從 DTO 轉換到 model 的mapper 
        /// </summary>

        public DTOtoEF_MappingProfile()
        {
            CreateMap<ArrangementInfoDTO, ArrangementInfo>();
            CreateMap<CarInfoDTO, CarInfo>();
            CreateMap<DriverInfoDTO, DriverInfo>();
            CreateMap<RouteInfoDTO, RouteInfo>();
            CreateMap<UserAccDTO, UserAcc>();
            CreateMap<GARoleDTO, GARole>();
            CreateMap<RouteScheduleDTO, RouteSchedule>();



        }
    }
}
