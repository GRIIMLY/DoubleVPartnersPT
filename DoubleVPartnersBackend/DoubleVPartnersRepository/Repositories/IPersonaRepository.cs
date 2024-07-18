using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.Repositories;

namespace Repositories.Repositories
{
    public interface IPersonaRepository
        : IGenericRepository<Persona>
    {
        public Task<Persona> GetPersonaPorIdUsuario(int IdUsuario);
        public  Task<List<PersonaDTO>> GetPersonasSP();
    }
}
