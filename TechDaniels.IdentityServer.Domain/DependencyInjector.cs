using Microsoft.Extensions.DependencyInjection;
using TechDaniels.IdentityServer.Domain.Mappers;

namespace TechDaniels.IdentityServer.Domain
{
    public static class DependencyInjector
    {
        public static void InjectDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppUserDbToAppUserDTOMapper));
        }
    }
}
