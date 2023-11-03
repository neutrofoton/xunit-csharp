using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using IAsyncQueryProvider = Microsoft.EntityFrameworkCore.Query.IAsyncQueryProvider;

namespace NetUnit.Core.EF
{
   
    internal class EFAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider innerQueryProvider;
        internal EFAsyncQueryProvider(IQueryProvider innerQueryProvider)
        {
            this.innerQueryProvider = innerQueryProvider;
        }
        public IQueryable CreateQuery(Expression expression)
        {
            return new EFAsyncEnumerable<TEntity>(expression);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new EFAsyncEnumerable<TElement>(expression);
        }
        public object Execute(Expression expression)
        {
            return innerQueryProvider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return this.innerQueryProvider.Execute<TResult>(expression);
        }
        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = new CancellationToken())
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = ((IQueryProvider)this).Execute(expression);
            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))
                .MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult });
        }
    }
}