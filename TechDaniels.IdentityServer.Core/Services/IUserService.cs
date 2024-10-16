using System;
using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Domain.Models.Requests;

namespace TechDaniels.IdentityServer.Core.Services
{
    public interface IUserService
    {
        public Task<AppResponse<string>> Save(SaveUserRequest user);
    }
}
