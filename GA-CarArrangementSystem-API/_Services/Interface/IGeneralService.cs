using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.Helpers;

/// <summary>
/// service 針對的是從 repository 取出資料後的商業邏輯處理
/// 這是一個公用的general service 介面，宣告了共用的方法
/// 其餘的service 可以重用他的方法，再各自宣告自己獨立的方法
/// </summary>
namespace GA_CarArrangementSystem_API._Services.Interface
{
    public interface IGeneralService<T> where T : class
    {
        Task<bool> Add(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(object id);

        Task<List<T>> GetAllAsync();

     //   Task<PagedList<T>> GetWithPaginations(PaginationParams param);

     //   Task<PagedList<T>> Search(PaginationParams param, object text);
        T GetById(object id);
    }
}
