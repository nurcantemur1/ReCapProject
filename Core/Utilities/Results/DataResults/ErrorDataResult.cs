using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.DataResults
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(default, false) { }
        public ErrorDataResult(string messages) : base(default, messages, false) { }
        public ErrorDataResult(T data) : base(data, false) { }
        public ErrorDataResult(T data, bool success) : base(data, false) { }
        public ErrorDataResult(T data, string messages, bool success) : base(data, messages, false) { }
    }
}
