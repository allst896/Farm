using Farm.Common.Extensions;
using Farm.Common.Tests.Helpers;
using Farm.Models.Db;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Globalization;

namespace Farm.Common.Tests
{
    public class BaseTests
    {
        protected DITest DI { get; set; }

        public virtual void AddToServiceCollection(IServiceCollection serviceCollection, IConfiguration configuration)
        {
        }

        [OneTimeSetUp]
        public virtual void Initialize()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddFarmServices();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection();
            var configuration = configurationBuilder.Build();
            serviceCollection
                .AddScoped<IConfiguration>(_ => configuration);

            AddToServiceCollection(serviceCollection, configuration);

            DI = new DITest(serviceCollection);
        }

        [SetUp]
        public void SetupDatabase()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<FarmContext>()
                  .UseSqlite(connection)
                  .Options;

            var dbContext = new FarmContext(options);
            using (var context = new FarmContext(options))
            {
                context.Database.EnsureCreated();
            }

            var location = new Locations
            {
                Name = "Home"
            };
            dbContext.Locations.Add(location);
            dbContext.SaveChanges();

            DI.ServiceCollection
                .AddScoped(_ => dbContext);
        }

        [NUnit.Framework.TearDown]
        public void BaseTearDown()
        {
            DI.Reset();
        }

        protected string ToFormattedDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}