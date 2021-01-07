using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API._Repositories.Interface.DbUser
{
    public interface IDbUserRepository<T> where T : class
    {
        T FindById(object id);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
