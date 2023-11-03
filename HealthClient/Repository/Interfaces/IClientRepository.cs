using Clientes.Entities;
using Clientes.Pagination;

namespace Clientes.Repository.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(long id);
    }
}