using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    //
    // Repository Pattern for data abstraction
    //
    public interface IRepository<TContext, T>
        where TContext : DbContext
        where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
