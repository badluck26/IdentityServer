using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDaniels.IdentityServer.Domain.DTOs;

namespace TechDaniels.IdentityServer.Domain.Models.Requests
{
    public class SaveUserRequest
    {
        public AppUserDTO User { get; set; }
        public string Password { get; set; }
        
    }
}
