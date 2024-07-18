using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;


namespace DoubleVPartnersBI.BI
{
    public interface IPersonaBI : IGenericBI<Persona>
    {


        public Task<Persona> GetPersonaPorIdUsuario(int IdUsuario);
        public Task<List<PersonaDTO>> GetPersonasSP();
    }
}
