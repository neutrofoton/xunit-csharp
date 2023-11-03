using System.Linq.Expressions;

namespace NetUnit.Core.EF
{
    public class EFAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public EFAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }
        public EFAsyncEnumerable(Expression expression)
            : base(expression)
        { }
        IQueryProvider IQueryable.Provider => new EFAsyncQueryProvider<T>(this);
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token)
        {
            return new EFAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

    }
}