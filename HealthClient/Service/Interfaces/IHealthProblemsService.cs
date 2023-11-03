using Clientes.DTOs;

namespace Clientes.Service.Interfaces
{
    public interface IHealthProblemsService
    {
        Task<HealthProblemDTO> GetById(long id);
        Task<HealthProblemDTO> Delete(long id);
        Task<HealthProblemDTO[]> SaveHealthProblems(HealthProblemDTO[] models, long clientId);
    }
}