
using AutoMapper;
using DoubleVPartnersRepository.Models;
using Repositories.Repositories;

namespace DoubleVPartnersBI.BI.Implements
{
    internal class PersonaBI : GenericBI<Persona>, IPersonaBI
    {
        /// <summary>
        /// IPersonaRepository  data access
        /// </summary>
        private readonly IPersonaRepository personaRepository;

     

        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="personaRepository">objeto de basado IPersonaRepository</param>
        public PersonaBI(IPersonaRepository personaRepository, IMapper mapper)
            : base(personaRepository)
        {
            this.personaRepository = personaRepository;

            this.mapper = mapper;
        }

    
    }
}
