using BlazoeProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoeProject.Server.services
{

    public interface IEmployeeService
    {
        Task<MyDataResult<Employee>> GetEmployees(int skip, int take);
        Task<Employee> AddEmployee(Employee employee);
    }
}
