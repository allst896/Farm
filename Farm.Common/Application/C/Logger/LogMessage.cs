using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Application.C.Logger
{
    class LogMessage
    {
        public string Level { get; set; }

        public DateTime LogTime { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }
    }
}
