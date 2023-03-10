using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool isSuccess, string message) : base(isSuccess : false, message)
        {
            
        }
    }
}
