using BlazoeProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazoeProject.Contract
{
    public interface IRepository<T, ID> where T : class
    {

        IQueryable<T> FindAll();
        IQueryable<T> FindAll(Expression<Func<T, bool>> expression);
        Task<MyDataResult<T>> FindAllAsync(int skip, int take);
        Task<T> FindByIdAsync(ID id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
