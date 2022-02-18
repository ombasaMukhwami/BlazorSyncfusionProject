using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazoeProject.Contract
{
    public interface IRepository<T, ID> where T : class
    {
        IQueryable<T> FindAllAsync();
        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression);
        Task<T> FindByIdAsync(ID id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);


    }
}
