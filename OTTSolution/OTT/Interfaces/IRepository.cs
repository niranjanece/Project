namespace OTT.Interfaces
{
    public interface IRepository<K,T>
    {
        T Add(T entity);
        T Delete(K id);
        T Update(T entity);
        T GetById(K id);
        IList<T> GetAll();
    }
}
