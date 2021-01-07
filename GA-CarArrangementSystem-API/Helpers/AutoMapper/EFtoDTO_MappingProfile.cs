using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API.Models;

/// <summary>
/// 建立EF物件映射DTO物件的mapper
/// </summary>

namespace GA_CarArrangementSystem_API.Helpers.AutoMapper
{
    public class EFtoDTO_MappingProfile : Profile
    {
        /// <summary>
        /// 建立各個從model 轉換到 DTO 之間的mapper 
        /// </summary>
        
        public EFtoDTO_MappingProfile()
        {
            CreateMap<ArrangementInfo, ArrangementInfoDTO>();
            CreateMap<CarInfo, CarInfoDTO>();
            CreateMap<RouteInfo, RouteInfoDTO>();
            CreateMap<DriverInfo, DriverInfoDTO>();
            CreateMap<UserAcc, UserAccDTO>();
            CreateMap<GARole, GARoleDTO>();
            CreateMap<RouteSchedule, RouteScheduleDTO>();


        }

    }
}
