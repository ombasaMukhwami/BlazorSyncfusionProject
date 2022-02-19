using BlazoeProject.Server.services;
using BlazoeProject.Server.services.Implementation;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Collections.Generic;
using System.Linq;
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
            string orderByString = null;
            if(dataManagerRequest.Sorted != null)
            {
                List<Sort> sortList = dataManagerRequest.Sorted;
                sortList.Reverse();
                orderByString = string.Join(",", sortList.Select(s=>string.Format("{0} {1}", s.Name, s.Direction)));
            }

           var result = await  _service.GetEmployees(
               dataManagerRequest.Skip, dataManagerRequest.Take, orderByString);

            DataResult dataResult = new DataResult
            {
                Result = result.Result,
                Count = result.Count
            };
        
            return dataResult;
        }
    }
}
