using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.DTO;


/// <summary>
/// 宣告一個IArrangmentInfoService 的介面，為 IGeneralService 類型
/// 除了可以實作 IGeneralService中的方法外，亦可宣告自己獨立的介面方法
/// </summary>

namespace GA_CarArrangementSystem_API._Services.Interface
{
    public interface IArrangementInfoService : IGeneralService<ArrangementInfoDTO>
    {
        //Task<List<ArrangementInfoDTO>> GetID();
        //Task<List<ArrangementInfoDTO>> GetStatus();

        //Task<List<ArrangementInfoDTO>> GetGoTime();

        //Task<List<ArrangementInfoDTO>> GetBackTime();

        //Task<List<ArrangementInfoDTO>> GetRouteId();

        //Task<List<ArrangementInfoDTO>> GetArrangeDate();

        //Task<List<ArrangementInfoDTO>> GetUserId();




    }
}
