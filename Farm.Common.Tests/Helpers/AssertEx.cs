using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Common.Tests.Helpers
{
    public static class AssertEx
    {
        public static async Task ThrowsAsync<TException>(Func<Task> func) where TException : class
        {
            await ThrowsAsync<TException>(func, exception => { });
        }

        public static async Task ThrowsAsync<TException>(Func<Task> func, Action<TException> action) where TException : class
        {
            var exception = default(TException);
            var expected = typeof(TException);
            Type actual = null;
            try
            {
                await func();
            }
            catch (Exception e)
            {
                exception = e as TException;
                actual = e.GetType();
            }

            Assert.AreEqual(expected, actual);
            action(exception);
        }

        public static void IsValidDate(DateTime dateTime)
        {
            Assert.IsTrue(dateTime > (System.DateTime)System.Data.SqlTypes.SqlDateTime.MinValue, "DateTime has not been set properly.");
        }
    }
}
