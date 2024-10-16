using System;

namespace TechDaniels.IdentityServer.Domain.Base
{
    public abstract class BaseDTO
    {
        public Guid? Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
