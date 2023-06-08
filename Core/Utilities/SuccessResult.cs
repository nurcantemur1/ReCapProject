using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true) { }
        public SuccessResult(bool success) : base(true) { }
        public SuccessResult(string messages, bool success) : base(messages, true){ }
    }
}
