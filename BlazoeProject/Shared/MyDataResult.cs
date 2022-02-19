using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeProject.Shared
{
    public class MyDataResult<T> where T : class
    {
        public IEnumerable<T> Result { get; set; }
        public int Count { get; set; }
    }
}
