using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Common.Tests.Helpers
{
    public static class MockExtension
    {
        public static Moq.Language.Flow.IReturnsResult<TMock> ReturnsTask<TMock, TResult>(this Moq.Language.IReturns<TMock, Task<TResult>> moqReturn, TResult value)
            where TMock : class
        {
            return moqReturn.Returns(Task.FromResult(value));
        }

        public static Moq.Language.Flow.IReturnsResult<TMock> ReturnsTask<TMock>(this Moq.Language.IReturns<TMock, Task> moqReturn)
            where TMock : class
        {
            return moqReturn.Returns(Task.FromResult<object>(null));
        }
    }
}
