using System;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Domain.DbEntities
{
    public class ExternalLogin : BaseDbEntity
    {
        public Guid AppUserId { get; set; }
        public string Authenticator { get; set; }
        public string ExternalId { get; set; }
    }
}
