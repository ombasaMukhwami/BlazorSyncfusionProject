using BlazoeProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazoeProject.Server.services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<MyDataResult<Employee>> GetEmployees(int skip, int take)
        {
          return await _httpClient.GetFromJsonAsync<MyDataResult<Employee>>($"/api/employee?skip={skip}&take={take}");
        }
    }
}
