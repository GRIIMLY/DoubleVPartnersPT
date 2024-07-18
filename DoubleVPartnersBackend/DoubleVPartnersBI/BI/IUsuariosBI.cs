using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;


namespace DoubleVPartnersBI.BI
{
    public interface IUsuariosBI : IGenericBI<Usuario>
    {

        public Task<Usuario> GetUsuarioByUsuario1AndPass(string usuario, string pass);
        public Task<Usuario> GetUsuarioByUsuario1(string usuario);

    }
}
