using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API._Repositories.Interface.DbUser;
using GA_CarArrangementSystem_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GA_CarArrangementSystem_API._Repositories.Repositories.DbUser
{
    public class DbUserRepository<T> : IDbUserRepository<T> where T : class
    {

        private readonly UserContext _context;
        public DbUserRepository(UserContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.AsQueryable();
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            throw new NotImplementedException();
        }

        public T FindById(object id)
        {
            return _context.Set<T>().Find(id);
            throw new NotImplementedException();
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
            throw new NotImplementedException();
        }
    }
}
