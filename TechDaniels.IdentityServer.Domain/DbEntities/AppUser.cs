using System;
using System.ComponentModel.DataAnnotations.Schema;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Domain.DbEntities
{
    public class AppUser : BaseDbEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [ForeignKey(nameof(LoginPolicy))]
        public Guid LoginPolicyId { get; set; }

        public virtual LoginPolicy LoginPolicy { get; set; }
    }
}
