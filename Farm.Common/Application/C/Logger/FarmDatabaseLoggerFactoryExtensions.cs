using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Application.C.Logger
{
    public static class FarmDatabaseLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddFarmDatabase(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, FarmDatabaseLoggerProvider>();
            return builder;
        }

        public static ILoggingBuilder AddFarmDatabase(this ILoggingBuilder builder, Action<FarmDatabaseLoggerOptions> configure)
        {
            builder.AddFarmDatabase();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
