using System;
using System.ComponentModel.DataAnnotations;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Domain.DTOs
{
    public class AppUserDTO : BaseDTO
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
    }
}
