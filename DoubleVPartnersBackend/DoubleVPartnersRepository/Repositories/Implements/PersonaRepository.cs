
using Repositories.Repositories;
using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.ContextDB;

namespace DoubleVPartnersRepository.Repositories.Implements
{
    internal class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly DoubleVPartnersDB _db;

        public PersonaRepository(DoubleVPartnersDB _db) : base(_db)
        {
            this._db = _db;
        }


    }

}
