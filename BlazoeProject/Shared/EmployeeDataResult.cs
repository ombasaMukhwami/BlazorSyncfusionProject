using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeProject.Shared
{
    public class EmployeeDataResult
    {
        public IQueryable<Employee> Employees { get; set; }
        public int Count { get; set; }
    }
}
