using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(bool isSuccess, string message, T data) : base(isSuccess, message, data)
        {
        }
    }
}
