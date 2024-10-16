using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDaniels.IdentityServer.Domain.DbEntities;

namespace TechDaniels.IdentityServer.Services.Data
{
    public interface IAppUnitOfWork
    {
        IBaseRepository<AppUser> AppUsers { get; }
        IBaseRepository<LoginPolicy> LoginPolicies { get; }
        IBaseRepository<ExternalLogin> ExternalLogins { get; }

        Task Commit(CancellationToken ct = default);
    }
}
