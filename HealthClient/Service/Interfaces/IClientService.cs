using Clientes.DTOs;
using Clientes.Pagination;

namespace Clientes.Service.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAll();
        Task<PageList<ClientDTO>> GetAllPaged(PageParams pageParams);
        Task<ClientDTO> GetById(long id);
        Task<ClientDTO> Create(ClientDTO model);
        Task<ClientDTO> Update(ClientDTO model);
        Task<ClientDTO> Delete(long id);
        Task<List<ClientRiskProblemDTO>> GetHealthScoreRisk();
    }
}