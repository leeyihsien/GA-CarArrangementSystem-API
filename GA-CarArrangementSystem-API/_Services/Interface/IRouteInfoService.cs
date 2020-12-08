using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.DTO;

namespace GA_CarArrangementSystem_API._Services.Interface
{
    public interface IRouteInfoService : IGeneralService<RouteInfoDTO>
    {
        Task<List<RouteInfoDTO>> GetIdByType(object type);

    }
}
