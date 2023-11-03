using AutoMapper;
using Clientes.Entities;

namespace Clientes.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<HealthProblem, HealthProblemDTO>().ReverseMap();
        }
    }
}