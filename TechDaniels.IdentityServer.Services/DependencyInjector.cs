using Microsoft.Extensions.DependencyInjection;
using TechDaniels.IdentityServer.Core.Cryptors;
using TechDaniels.IdentityServer.Core.Services;
using TechDaniels.IdentityServer.Services.Cryptors;

namespace TechDaniels.IdentityServer.Services
{
    public static class DependencyInjector
    {
        public static void InjectAdminServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordCryptor, BCryptPasswordCryptor>();
        }

        public static void InjectAuthServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordCryptor, BCryptPasswordCryptor>();
        }
    }
}
