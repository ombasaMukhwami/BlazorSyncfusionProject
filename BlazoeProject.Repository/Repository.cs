﻿using BlazoeProject.Contract;
using BlazoeProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazoeProject.Repository
{
    public class Repository<T, ID> : IRepository<T, ID> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _table;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public virtual IQueryable<T> FindAllAsync()
        {
            return _table.AsNoTracking();
        }

        public virtual IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).AsNoTracking();
        }

        public virtual async Task<T> FindByIdAsync(ID id)
        {
            return await _table.FindAsync(id);
        }

        public  void Remove(T entity)
        {
             _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

    }
}
