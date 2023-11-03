namespace Clientes.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}