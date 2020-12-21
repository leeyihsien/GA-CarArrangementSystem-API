using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API.ViewModels;


/// <summary>
/// 宣告一個IArrangmentInfoService 的介面，為 IGeneralService 類型
/// 除了可以實作 IGeneralService中的方法外，亦可宣告自己獨立的介面方法
/// </summary>

namespace GA_CarArrangementSystem_API._Services.Interface
{
    public interface IArrangementInfoService : IGeneralService<ArrangementInfoDTO>
    {
        Task<List<ArrangementInfoDTO>> GetNullStatus();

        Task<List<ArrangementInfoDTO>> GetByDate(String date);

        Task<List<ArrangementInfoDTO>> PassengerSearch(String userId, String date);

        Task<List<ArrangementInfoDTO>> DriverSearch(String carId, String date);

        Task<List<ArrangementInfoDTO>> ManagerSearch(String routeId, String date);


    }
}
