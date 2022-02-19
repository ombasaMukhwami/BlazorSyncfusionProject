using BlazoeProject.Server.services;
using BlazoeProject.Server.services.Implementation;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Threading.Tasks;

namespace BlazoeProject.Client.services.DataAdaptors
{
    public class EmployeeDataAdaptor:DataAdaptor
    {
        private readonly IEmployeeService _service;

        public EmployeeDataAdaptor(IEmployeeService service)
        {
            _service = service;
        }
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
           var result = await  _service.GetEmployees(
               dataManagerRequest.Skip, dataManagerRequest.Take);

            DataResult dataResult = new DataResult
            {
                Result = result.Result,
                Count = result.Count
            };
        
            return dataResult;
        }
    }
}
