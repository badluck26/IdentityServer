using Microsoft.EntityFrameworkCore;
using TechDaniels.IdentityServer.Domain.DbEntities;

namespace TechDaniels.IdentityServer.Data
{
    public class IdentityServerDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<LoginPolicy> LoginPolicies { get; set; }
        public DbSet<ExternalLogin> ExternalLogins { get; set; }

        public IdentityServerDbContext()
        {
        }

        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
        {
        }
    }
}
