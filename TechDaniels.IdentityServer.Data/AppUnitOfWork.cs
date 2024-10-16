using TechDaniels.IdentityServer.Domain.DbEntities;
using TechDaniels.IdentityServer.Data.Base;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Data
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly IdentityServerDbContext _context;

        private readonly Lazy<IBaseRepository<AppUser>> LazyAppUsers;
        public IBaseRepository<AppUser> AppUsers => LazyAppUsers.Value;

        private readonly Lazy<IBaseRepository<LoginPolicy>> LazyLoginPolicies;
        public IBaseRepository<LoginPolicy> LoginPolicies => LazyLoginPolicies.Value;

        private readonly Lazy<IBaseRepository<ExternalLogin>> LazyExternalLogins;
        public IBaseRepository<ExternalLogin> ExternalLogins => LazyExternalLogins.Value;

        public AppUnitOfWork(IdentityServerDbContext context)
        {
            _context = context;
            LazyAppUsers = new Lazy<IBaseRepository<AppUser>>(() => new BaseRepository<AppUser>(context));
            LazyLoginPolicies = new Lazy<IBaseRepository<LoginPolicy>>(() => new BaseRepository<LoginPolicy>(context));
            LazyExternalLogins = new Lazy<IBaseRepository<ExternalLogin>>(() => new BaseRepository<ExternalLogin>(context));
        }
        public async Task Commit(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
