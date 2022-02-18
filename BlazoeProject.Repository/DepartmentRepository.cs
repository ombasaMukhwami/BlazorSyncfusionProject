using BlazoeProject.Contract;
using BlazoeProject.Shared;

namespace BlazoeProject.Repository
{
    public class DepartmentRepository : Repository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
