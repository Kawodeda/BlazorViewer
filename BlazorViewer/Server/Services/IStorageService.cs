namespace BlazorViewer.Server.Services
{
    public interface IStorageService<TSource, TKey>
    {
        public void Create(TSource obj);

        public TSource Retrieve(TKey key);

        public IEnumerable<TKey> Retrieve();

        public void Update(TKey key, TSource obj);

        public void Delete(TKey key);
    }
}
