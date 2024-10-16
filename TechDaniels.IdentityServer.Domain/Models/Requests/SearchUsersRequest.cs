using TechDaniels.IdentityServer.Domain.DTOs;
using TechDaniels.IdentityServer.Domain.Models.Base;

namespace TechDaniels.IdentityServer.Domain.Models.Requests
{
    public class SearchUserRequest : SearchRequest
    {
        public string Email { get; set; }
        
    }
}
