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

        public override IQueryable<Employee> FindAll()
        {
            return _dbContext
                .Employees
                .Include(c => c.Department)
                .AsNoTracking();
        }

        public override IQueryable<Employee> FindAll(Expression<Func<Employee, bool>> expression)
        {
            return _dbContext.Employees
                .Where(expression)
                .Include(c => c.Department);
        }

        public override async Task<MyDataResult<Employee>> FindAllAsync(int skip = 0, int take = 5)
        {
            var employee = _dbContext.Employees.Include(c => c.Department);
            return new MyDataResult<Employee>
            {
                Count = await employee.CountAsync(),
                Result = employee.Skip(skip).Take(take).AsNoTracking()
            };
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
