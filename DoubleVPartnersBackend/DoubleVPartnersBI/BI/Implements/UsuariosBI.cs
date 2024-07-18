
using AutoMapper;
using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;
using Repositories.Repositories;

namespace DoubleVPartnersBI.BI.Implements
{
    internal class UsuariosBI : GenericBI<Usuario>, IUsuariosBI
    {
        /// <summary>
        /// IUsuariosRepository  data access
        /// </summary>
        private readonly IUsuariosRepository UsuariossRepository;



        /// <summary>
        /// mapper 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="UsuariossRepository">objeto de tipo IUsuariossRepository</param>
        public UsuariosBI(IUsuariosRepository UsuariossRepository, IMapper mapper)
            : base(UsuariossRepository)
        {
            this.UsuariossRepository = UsuariossRepository;

            this.mapper = mapper;
        }

        public async Task<Usuario> GetUsuarioByUsuario1AndPass(string usuario, string pass)
        {
            return await this.UsuariossRepository.GetUsuarioByUsuario1AndPass(usuario, pass);
        }

        public async Task<Usuario> GetUsuarioByUsuario1(string usuario)
        {
            return await this.UsuariossRepository.GetUsuarioByUsuario1(usuario);
        }

 
    }
}
