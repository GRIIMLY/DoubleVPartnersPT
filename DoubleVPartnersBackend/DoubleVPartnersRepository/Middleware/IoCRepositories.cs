using DoubleVPartnersRepository.Repositories;
using DoubleVPartnersRepository.Repositories.Implements;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace DoubleVPartnersRepository.Middleware
{
    public static class IoCRepositories
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
            #region Repositories Conatainer
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUsuariosRepository), typeof(UsuariosRepository));
            services.AddScoped(typeof(IPersonaRepository), typeof(PersonaRepository));

            #endregion
            return services;
        }
    }
}
