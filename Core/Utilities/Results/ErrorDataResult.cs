using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,  string message) : base(data,success:false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, success:false)
        {

        }

#pragma warning disable CS8604 // Possible null reference argument.
        public ErrorDataResult(string message) : base(default, success: false, message)
#pragma warning restore CS8604 // Possible null reference argument.
        {
        }

#pragma warning disable CS8604 // Possible null reference argument.
        public ErrorDataResult() : base(default, success: false)
#pragma warning restore CS8604 // Possible null reference argument.
        {
        }


    }
}
