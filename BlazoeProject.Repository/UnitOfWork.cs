using BlazoeProject.Contract;
using BlazoeProject.Shared;
using System.Threading.Tasks;

namespace BlazoeProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region PRIVATE FIELDS

        private IEmployeeRepository _employee;
        private IDepartmentRepository _department;

        #endregion PRIVATE FIELDS

        #region PUBLIC FIELDS
        public IEmployeeRepository Employees => _employee ?? new EmployeeRepository(_dbContext);
        public IDepartmentRepository Departments => _department ?? new DepartmentRepository(_dbContext);
        #endregion PUBLIC FIELDS
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
