
using System;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Domain.DbEntities
{
    public class LoginPolicy : BaseDbEntity
    {
        public Guid AppUserId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime? UnblockedDate { get; set; }
        public int FailedLoginAttempts { get; set; }
    }
}
