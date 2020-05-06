using Farm.Common.Tests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Farm.Common.Tracker.Tests
{
    public class Tests : BaseTests
    {
        public override void AddToServiceCollection(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddFarmTracker(configuration);
        }
    }
}