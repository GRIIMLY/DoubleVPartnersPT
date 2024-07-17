using AutoMapper;
using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;

namespace PruebaDitechRepository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Persona, PersonaDTO>().ReverseMap();

        }
    }
}
