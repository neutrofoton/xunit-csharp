namespace NetUnit.Core.EF
{
    public class EFAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;
        public EFAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }
        public T Current => this.enumerator.Current;
        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(() => this.enumerator.Dispose()));
        }
        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(this.enumerator.MoveNext());
        }
    }
}