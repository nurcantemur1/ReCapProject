using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.DataResults
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data,bool success) : base(success)
        {
            Data= data;
        }

        public DataResult(T data,string messages, bool success) : base(messages, success)
        {
            Data= data;
        }

        public T Data { get; }


    }
}
