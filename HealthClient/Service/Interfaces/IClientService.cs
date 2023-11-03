using Clientes.DTOs;

namespace Clientes.Service.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAll();
        Task<ClientDTO> GetById(long id);
        Task<ClientDTO> Create(ClientDTO model);
        Task<ClientDTO> Update(ClientDTO model);
        Task<ClientDTO> Delete(long id);
        Task<List<ClientRiskProblemDTO>> GetHealthScoreRisk();
    }
}