using BlazoeProject.Contract;
using BlazoeProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeProject.Repository
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IQueryable<Employee> FindAllAsync()
        {
            return _dbContext
                .Employees
                .Include(c => c.Department)
                .AsNoTracking();
        }

        public override IQueryable<Employee> FindAllAsync(Expression<Func<Employee, bool>> expression)
        {
            return _dbContext.Employees
                .Where(expression)
                .Include(c => c.Department);
        }

        public async override Task<Employee> FindByIdAsync(int id)
        {
            return await _dbContext
                .Employees
                .Include(c=>c.Department)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
