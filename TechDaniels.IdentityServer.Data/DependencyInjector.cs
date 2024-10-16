using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechDaniels.IdentityServer.Core;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Data
{
    public static class DependencyInjector
    {
        public static void InjectDataDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<IdentityServerDbContext>(options =>
                options.UseSqlServer(appSettings.ConnectionStrings.IdentityDbConnection));

            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

        }
    }
}
