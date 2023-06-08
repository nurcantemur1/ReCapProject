﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false) { }
        public ErrorResult(bool success) : base(false) { }
        public ErrorResult(string messages, bool success) : base(messages, false){ }
    }
}
