using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.DataResults
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success) : base(data, true)  { }
        public SuccessDataResult(T data) : base(data, true) { }
        public SuccessDataResult(string messages) : base(default, messages, true) { }

        public SuccessDataResult(T data, string messages, bool success) : base(data, messages, true) { }
    }
}
