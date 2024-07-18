
using Repositories.Repositories;
using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace DoubleVPartnersRepository.Repositories.Implements
{
    internal class UsuariosRepository : GenericRepository<Usuario>, IUsuariosRepository
    {
        private readonly DoubleVPartnersDB _db;

        public UsuariosRepository(DoubleVPartnersDB _db) : base(_db)
        {
            this._db = _db;
        }

        public async  Task<Usuario> GetUsuarioByUsuario1AndPass(string usuario1, string pass)
        {
            var usuarios = await this._db.Usuarios
                .Where(usuario => usuario.Usuario1.Equals(usuario1) && usuario.Pass.Equals(pass))
                .FirstOrDefaultAsync();
            return usuarios;
        }

        public Task<Usuario> GetUsuarioByUsuario1(string usuario1)
        {
            return this._db.Usuarios
                    .Where(usuario => usuario.Usuario1.ToLower().Equals(usuario1.ToLower()))
                    .FirstOrDefaultAsync();
        }

    }

}
