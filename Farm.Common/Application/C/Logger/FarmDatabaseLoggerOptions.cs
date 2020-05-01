using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Application.C.Logger
{
    public class FarmDatabaseLoggerOptions
    {
        public string ConnectionString { get; set; }
        public int BatchSize { get; set; }
        public TimeSpan FlushPeriod { get; set; }
        public bool IncludeScopes { get; set; }
    }
}
