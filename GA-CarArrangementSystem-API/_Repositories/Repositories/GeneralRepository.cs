using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API._Repositories.Interface;
using GA_CarArrangementSystem_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GA_CarArrangementSystem_API._Repositories.Repositories
{
    /// <summary>
    /// 此class 實作 IGeneralRepository 中的方法
    /// 之後需要新增各類別不同的repository，只要宣告為GeneralRepository 類別的物件即可重用這些方法
    /// 剩下各自獨立特有的方法在各自的repository 中宣告就好，不用再寫一次
    /// </summary>
    /// <typeparam name="T"></typeparam>


    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        /// <summary>
        /// 宣告DbContext 取得entity 
        /// </summary>
        private readonly DataContext _dataContext;

        public GeneralRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dataContext.Add(entity);
        }



        /// <summary>
        /// Expression API 可以將程式轉換為可查詢的機制 (像是轉換成SQL)
        /// include properties 指的是可以同時查詢與此entity相關的entity 
        /// 這裡宣告兩個FindAll方法可以進行條件式查詢
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dataContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items.AsQueryable();

        }


        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dataContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate).AsQueryable();
       
        }


        /// <summary>
        /// 使用ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(object id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        /// <summary>
        /// 查找單筆資料，使用Expression API進行條件查詢
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
       public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }


        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().AsQueryable();
        }


        /// <summary>
        /// 移除資料
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }


        /// <summary>
        /// 刪除指定id 資料
        /// </summary>
        /// <param name="id"></param>
        public void Remove(object id)
        {
            Remove(FindById(id));

        }



        /// <summary>
        /// 移除多筆資料
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveMultiple(List<T> entities)
        {
            _dataContext.Set<T>().RemoveRange(entities);
            
        }


        /// <summary>
        /// 存儲所有資料
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;

        }


        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
        }

     
    }
}
