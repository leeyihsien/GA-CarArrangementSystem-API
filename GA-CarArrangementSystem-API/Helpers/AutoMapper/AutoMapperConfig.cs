using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GA_CarArrangementSystem_API.Helpers.AutoMapper;

namespace GA_CarArrangementSystem_API.Helpers.AutoMapper
{
    /// <summary>
    /// 使用auto mapper 進行 DTO 與 Model 之間的映射
    /// 此類別是一個主要的auto mapper 
    /// 建立完成後會注入service裡
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EFtoDTO_MappingProfile());
                cfg.AddProfile(new DTOtoEF_MappingProfile());
               // cfg.AddProfile(new ViewModel_MappingProfile());
            });
        }
    }
}
