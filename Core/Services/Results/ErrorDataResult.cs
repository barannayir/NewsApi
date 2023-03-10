using Core.Services.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(bool isSuccess, string message, T data) : base(isSuccess, message, data)
        {
        }
    }
}
