using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Application.C.Logger
{
    public class FarmDatabaseLogger : ILogger
    {
        private readonly FarmDatabaseLoggerProvider provider;
        private readonly string category;

        public FarmDatabaseLogger(FarmDatabaseLoggerProvider loggerProvider, string categoryName)
        {
            provider = loggerProvider;
            category = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return provider.ScopeProvider?.Push(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        // Write a log message
        public void Log<TState>(DateTimeOffset timestamp, LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var builder = new StringBuilder();
            var scopeProvider = provider.ScopeProvider;
            if (scopeProvider != null)
            {
                scopeProvider.ForEachScope((scope, stringBuilder) =>
                {
                    stringBuilder.Append(" => ").Append(scope);
                }, builder);

                builder.AppendLine(":");
            }

            builder.Append(formatter(state, exception));

            if (exception != null)
            {
                builder.AppendLine();
                builder.AppendLine(exception.ToString());
            }

            provider.AddMessage(new LogMessage
            {
                Level = logLevel.ToString(),
                LogTime = timestamp.UtcDateTime,
                Message = builder.ToString(),
                Source = category
            });
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Log(DateTimeOffset.UtcNow, logLevel, eventId, state, exception, formatter);
        }
    }
}
