using System;
using TechDaniels.IdentityServer.Domain.Requests;
using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Domain.DTOs;

namespace TechDaniels.IdentityServer.Core.Services
{
    public interface IAuthService
    {
        public Task<AppResponse<AppUserDTO>> Login(LoginRequest loginRequest);
    }
}
