using DoubleVPartnersRepository.Models;
using DoubleVPartnersRepository.Repositories;

namespace Repositories.Repositories
{
    public interface IUsuariosRepository
        : IGenericRepository<Usuario>
    {
        public Task<Usuario> GetUsuarioByUsuario1AndPass(string usuario, string pass);
        public Task<Usuario> GetUsuarioByUsuario1(string usuario);

    }
}
