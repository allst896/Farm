using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Farm.Common.Tests.Helpers
{
    public class DIServiceCollection : IServiceCollection
    {
        private IServiceCollection originalServiceCollection;
        private IServiceCollection copyServiceCollection;

        private IServiceCollection currentServiceCollection => (copyServiceCollection ?? originalServiceCollection);

        public DIServiceCollection(IServiceCollection originalServiceCollection)
        {
            this.originalServiceCollection = originalServiceCollection;
            this.copyServiceCollection = null;
        }

        // This counter marks how often we updated the DI.
        // This is used in the DITest, if we have a different cache count, then
        // we need to regenerate the serviceProvider from a new collection.
        public int UpdateCount { get; private set; }

        public void Reset()
        {
            copyServiceCollection = null;
            UpdateCount = 0;
        }

        public ServiceDescriptor this[int index]
        {
            get => currentServiceCollection[index];
            set
            {
                EnsureCopy();
                copyServiceCollection[index] = value;
            }
        }

        public int Count => currentServiceCollection.Count;

        public bool IsReadOnly => currentServiceCollection.IsReadOnly;

        public void Add(ServiceDescriptor item)
        {
            EnsureCopy();
            copyServiceCollection.Add(item);
        }

        public void Clear()
        {
            EnsureCopy();
            copyServiceCollection.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return currentServiceCollection.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            currentServiceCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return currentServiceCollection.GetEnumerator();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return currentServiceCollection.IndexOf(item);
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            EnsureCopy();
            copyServiceCollection.Insert(index, item);
        }

        public bool Remove(ServiceDescriptor item)
        {
            EnsureCopy();
            return copyServiceCollection.Remove(item);
        }

        public void RemoveAt(int index)
        {
            EnsureCopy();
            copyServiceCollection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return currentServiceCollection.GetEnumerator();
        }

        private void EnsureCopy()
        {
            UpdateCount++;
            if (copyServiceCollection == null)
            {
                copyServiceCollection = new ServiceCollection();
                using (IEnumerator<ServiceDescriptor> enumerator = originalServiceCollection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ServiceDescriptor current = enumerator.Current;
                        copyServiceCollection.Add(current);
                    }
                }
            }
        }
    }
}
