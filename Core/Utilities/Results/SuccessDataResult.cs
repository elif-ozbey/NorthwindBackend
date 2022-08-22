using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
       
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

#pragma warning disable CS8604 // Possible null reference argument.
        public SuccessDataResult(string message) : base(default, success:true, message)
#pragma warning restore CS8604 // Possible null reference argument.
        {
        }

#pragma warning disable CS8604 // Possible null reference argument.
        public SuccessDataResult() : base(default, success: true)
#pragma warning restore CS8604 // Possible null reference argument.
        {
        }
    }
}
