using Farm.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NodaTime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Farm.Common.Extensions
{
    public static class FarmExtensions
    {
        public static IHostBuilder UseFarmConfiguration(this IHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((context, builder) =>
            {
                var environment = context.HostingEnvironment;

                //builder.AddJsonFile("appsettings-core.json", optional: true, reloadOnChange: true)
                //    .AddJsonFile($"appsettings-core.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

                // We go get the JSON setting in the bin folder, this is because we use a link.
                if (environment.IsDevelopment())
                {
                    var location = Assembly.GetEntryAssembly().Location;
                    var directory = Path.GetDirectoryName(location);
                    //builder.AddJsonFile(Path.Combine(directory, "appsettings-core.json"), optional: true, reloadOnChange: true);
                }

                //builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

                //if (environment.IsDevelopment())
                //{
                //    var assembly = Assembly.Load(new AssemblyName(environment.ApplicationName));
                //    if (assembly != null)
                //    {
                //        builder.AddUserSecrets(assembly, optional: true);
                //    }
                //}

                //builder.AddEnvironmentVariables();
            });
        }

        public static IServiceCollection AddFarmDatabase(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddDbContext<FarmContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddFarm(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            return services
                .AddFarmDatabase(defaultConnectionString)
                .AddFarmServices();
        }

        public static IServiceCollection AddFarmServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IClock>(SystemClock.Instance);

            return services;
        }

    }
}
