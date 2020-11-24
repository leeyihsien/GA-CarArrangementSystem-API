using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API._Repositories.Interface
{
    /// <summary>
    /// 針對Repository 建立一個共用的介面，裡面的方法是共用的
    /// Repository 主要是用來針對資料庫基本操作，因此在這裡宣告最基本的CRUD即可
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGeneralRepository<T> where T:class 
    {
        T FindById(object id);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);


        /// <summary>
        /// 基礎資料庫操作
        /// </summary>
        /// <param name="entity"></param>

        void Add(T entity);
        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);

        void RemoveMultiple(List<T> entity);

        IQueryable<T> GetAll();

        Task<bool> SaveAll();
    }
}
