using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool isSuccess, string message) : base(isSuccess : true, message)
        {
        }
    }
}
