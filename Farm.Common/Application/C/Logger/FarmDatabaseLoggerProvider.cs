using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farm.Common.Application.C.Logger
{
    [ProviderAlias("FarmDatabase")]
    public class FarmDatabaseLoggerProvider : ILoggerProvider, ISupportExternalScope
    {
        private readonly string connectionString;
        private readonly int batchSize;
        private readonly TimeSpan flushPeriod;
        private readonly bool includeScopes;

        private IExternalScopeProvider scopeProvider;
        internal IExternalScopeProvider ScopeProvider => includeScopes ? scopeProvider : null;

        private Task outputTask;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private BlockingCollection<LogMessage> messageQueue;

        public FarmDatabaseLoggerProvider(
            IOptions<FarmDatabaseLoggerOptions> options
        )
        {
            var loggerOptions = options.Value;
            if (string.IsNullOrEmpty(loggerOptions.ConnectionString))
            {
                throw new ArgumentException(nameof(loggerOptions.ConnectionString), $"{nameof(loggerOptions.ConnectionString)} must be a connection string.");
            }

            if (loggerOptions.BatchSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(loggerOptions.BatchSize), $"{nameof(loggerOptions.BatchSize)} must be a positive number.");
            }

            if (loggerOptions.FlushPeriod <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(loggerOptions.FlushPeriod), $"{nameof(loggerOptions.FlushPeriod)} must be longer than zero.");
            }

            connectionString = loggerOptions.ConnectionString;
            batchSize = loggerOptions.BatchSize;
            flushPeriod = loggerOptions.FlushPeriod;
            includeScopes = loggerOptions.IncludeScopes;
            Start();
        }

        // Take messages from concurrent queue and write them out
        private async Task ProcessLogQueue()
        {
            try
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    if (messageQueue.Count > 0)
                    {
                        using (SqlConnection sqlconn = new SqlConnection(connectionString))
                        {
                            sqlconn.Open();
                            while (messageQueue.TryTake(out var message))
                            {
                                if (sqlconn.State == System.Data.ConnectionState.Open)
                                {
                                    SqlCommand cmdx;
                                    cmdx = new SqlCommand("insert into logging (LogLevel, Date_Time, Message, Source) values (@level, @datetime, @message, @source)", sqlconn);
                                    cmdx.Parameters.AddWithValue("@level", message.Level);
                                    cmdx.Parameters.AddWithValue("@datetime", message.LogTime);
                                    cmdx.Parameters.AddWithValue("@message", message.Message);
                                    cmdx.Parameters.AddWithValue("@source", message.Source);
                                    cmdx.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // Wait before writing the next batch
                    await Task.Delay(flushPeriod, cancellationTokenSource.Token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Add a message to the concurrent queue
        internal void AddMessage(LogMessage logMessage)
        {
            if (!messageQueue.IsAddingCompleted)
            {
                messageQueue.Add(logMessage, cancellationTokenSource.Token);
            }
        }

        // Create an instance of an ILogger, which is used to actually write the logs
        public ILogger CreateLogger(string categoryName)
        {
            return new FarmDatabaseLogger(this, categoryName);
        }


        private void Start()
        {
            messageQueue = new BlockingCollection<LogMessage>(new ConcurrentQueue<LogMessage>());

            cancellationTokenSource = new CancellationTokenSource();
            outputTask = Task.Run(ProcessLogQueue);
        }

        private void Stop()
        {
            cancellationTokenSource.Cancel();
            messageQueue.CompleteAdding();

            try
            {
                outputTask.Wait(flushPeriod);
            }
            catch (TaskCanceledException)
            {
            }
            catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is TaskCanceledException)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            Stop();
        }

        public void SetScopeProvider(IExternalScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider;
        }
    }
}
