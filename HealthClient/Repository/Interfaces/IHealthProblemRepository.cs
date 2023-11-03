using Clientes.Entities;

namespace Clientes.Repository.Interfaces
{
    public interface IHealthProblemRepository : IGenericRepository<HealthProblem>
    {
        Task<HealthProblem> GetById(long id);
        Task<IEnumerable<HealthProblem>> GetByClientId(long clientId);
    }
}