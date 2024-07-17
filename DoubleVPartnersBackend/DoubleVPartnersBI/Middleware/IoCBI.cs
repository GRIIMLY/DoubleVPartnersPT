
using DoubleVPartnersBI.BI;
using DoubleVPartnersBI.BI.Implements;
using DoubleVPartnersRepository.Repositories;
using DoubleVPartnersRepository.Repositories.Implements;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace DoubleVPartnersBI.Middleware
{
    public static class IoCBI
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
            #region Services Container
       
            services.AddScoped(typeof(IGenericBI<>), typeof(GenericBI<>));
            services.AddScoped(typeof(IUsuariosBI), typeof(UsuariosBI));
            services.AddScoped(typeof(IPersonaBI), typeof(PersonaBI));

            #endregion

            return services;
        }

    }
}
