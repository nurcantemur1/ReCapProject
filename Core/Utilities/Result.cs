using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class Result:IResult
    {
        public Result(string messages, bool success):this(success)
        {
            Messages = messages;
            Success = success;
        }
        public Result(bool success)
        {
            Success = success;

        }

        public string Messages { get;}
        public bool Success { get; }

    }
}
