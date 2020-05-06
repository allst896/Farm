using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Tests.Helpers
{
    public class DITest
    {
        private int cacheCount = 0;
        private DIServiceCollection diServiceCollection;
        private IServiceProvider cachedServiceProvider;

        public DITest(ServiceCollection serviceCollection)
        {
            this.diServiceCollection = new DIServiceCollection(serviceCollection);
        }

        public IServiceCollection ServiceCollection
        {
            get
            {
                return diServiceCollection;
            }
        }

        public IServiceProvider ServiceProvider
        {
            get
            {
                if (cachedServiceProvider == null || diServiceCollection.UpdateCount != cacheCount)
                {
                    cachedServiceProvider = diServiceCollection.BuildServiceProvider();
                }

                return cachedServiceProvider;
            }
        }

        public void Reset()
        {
            cachedServiceProvider = null;
            diServiceCollection.Reset();
        }
    }
}
