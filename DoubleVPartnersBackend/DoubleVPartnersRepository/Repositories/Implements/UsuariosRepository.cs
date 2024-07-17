
using Repositories.Repositories;
using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.ContextDB;

namespace DoubleVPartnersRepository.Repositories.Implements
{
    internal class UsuariosRepository : GenericRepository<Usuario>, IUsuariosRepository
    {
        private readonly DoubleVPartnersDB _db;

        public UsuariosRepository(DoubleVPartnersDB _db) : base(_db)
        {
            this._db = _db;
        }

    }

}
