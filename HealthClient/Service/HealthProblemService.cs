using AutoMapper;
using Clientes.DTOs;
using Clientes.Entities;
using Clientes.Repository.Interfaces;
using Clientes.Service.Interfaces;

namespace Clientes.Service
{
    public class HealthProblemService : IHealthProblemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HealthProblemService(IUnitOfWork unifOfWork, IMapper mapper)
        {
            _unitOfWork = unifOfWork;
            _mapper = mapper;
        }
        public async Task<HealthProblemDTO> GetById(long id)
        {
            HealthProblem healthProblem = await _unitOfWork.HealthProblemRepository.GetById(id);
            return _mapper.Map<HealthProblemDTO>(healthProblem);
        }
        private async Task<HealthProblemDTO> Create(HealthProblemDTO model)
        {
            HealthProblem healthProblem = _mapper.Map<HealthProblem>(model);
            _unitOfWork.HealthProblemRepository.Add(healthProblem);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HealthProblemDTO>(healthProblem);
        }
        private async Task<HealthProblemDTO> Update(HealthProblemDTO model)
        {
            HealthProblem healthProblem = await _unitOfWork.HealthProblemRepository.GetById(model.Id);
            if(healthProblem == null) return null;
            HealthProblem healthProblemUpdate = _mapper.Map<HealthProblem>(model);
            _unitOfWork.HealthProblemRepository.Update(healthProblemUpdate);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HealthProblemDTO>(healthProblemUpdate);
        }
        public async Task<HealthProblemDTO> Delete(long id)
        {
            HealthProblem healthProblem = await _unitOfWork.HealthProblemRepository.GetById(id);
            if(healthProblem == null) return null;
            healthProblem.SetActive(false);
            _unitOfWork.HealthProblemRepository.Update(healthProblem);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HealthProblemDTO>(healthProblem);
        }
        public async Task<HealthProblemDTO[]> SaveHealthProblems(HealthProblemDTO[] models, long clientId)
        {
            foreach (var model in models)
            {
                if (model.Id == 0)
                {
                    await Create(model);
                }
                else
                {
                    model.ClientId = clientId;
                    await Update(model);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        IEnumerable<HealthProblem> healthProblems = await _unitOfWork.HealthProblemRepository.GetByClientId(clientId);
        return _mapper.Map<HealthProblemDTO[]>(healthProblems);
        }
    }
}