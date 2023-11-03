using System.Collections.Immutable;
using AutoMapper;
using Clientes.DTOs;
using Clientes.Entities;
using Clientes.Repository.Interfaces;
using Clientes.Service.Interfaces;

namespace Clientes.Service
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClientService(IUnitOfWork unifOfWork, IMapper mapper)
        {
            _unitOfWork = unifOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            IEnumerable<Client> clients = await _unitOfWork.ClientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientDTO>>(clients);
        }
        public async Task<ClientDTO> GetById(long id)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(id);
            return _mapper.Map<ClientDTO>(client);
        }
        public async Task<ClientDTO> Create(ClientDTO model)
        {
            Client client = _mapper.Map<Client>(model);
            _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ClientDTO>(client);
        }
        public async Task<ClientDTO> Update(ClientDTO model)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(model.Id);
            if (client == null) return null;
            _mapper.Map(model, client);
            _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ClientDTO>(client);
        }
        public async Task<ClientDTO> Delete(long id)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(id);
            if(client == null) return null;
            client.SetActive(false);
            _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<List<ClientRiskProblemDTO>> GetHealthScoreRisk()
        {
            List<ClientRiskProblemDTO> clientRiskProblemDTOs = new List<ClientRiskProblemDTO>();
            IEnumerable<Client> clients = await _unitOfWork.ClientRepository.GetAll();
            foreach (Client client in clients)
            {
                var clientRisk = new ClientRiskProblemDTO(
                    client.Id,
                    client.Name,
                    client.BirthDay,
                    client.Sex,
                    client.GetScore()
                );
                clientRiskProblemDTOs.Add(clientRisk);
            }
            return clientRiskProblemDTOs.OrderByDescending(c => c.HealthScoreRisk).Take(10).ToList();
        }
    }
}