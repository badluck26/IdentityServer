using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Core.Cryptors;
using TechDaniels.IdentityServer.Core.Services;
using TechDaniels.IdentityServer.Domain.DbEntities;
using TechDaniels.IdentityServer.Domain.Requests;
using AutoMapper;
using TechDaniels.IdentityServer.Domain.DTOs;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IPasswordCryptor _cryptor;
        private readonly IMapper _mapper;

        public AuthService(IAppUnitOfWork uow, IPasswordCryptor cryptor, IMapper mapper)
        {
            _uow = uow;
            _cryptor = cryptor;
            _mapper = mapper;
        }

        public async Task<AppResponse<AppUserDTO>> Login(LoginRequest loginRequest)
        {
            var user = await _uow.AppUsers
                .Where(w => w.Email == loginRequest.Email)
                .Include(i => i.LoginPolicy)
                .FindOne();

            if(user == null) return AppResponse<AppUserDTO>.Unauthorized("Invalid credentials.");

            if (user.LoginPolicy.IsBlocked && user.LoginPolicy.UnblockedDate > DateTime.Now) return AppResponse<AppUserDTO>.Unauthorized("Account locked.");

            var hasValidPassword = _cryptor.Challenge(loginRequest.Password, user.PasswordHash);

            if(!hasValidPassword)
            {
                user.LoginPolicy.FailedLoginAttempts += user.LoginPolicy.FailedLoginAttempts;
                if (user.LoginPolicy.FailedLoginAttempts > 5) {
                    user.LoginPolicy.IsBlocked = true;
                    user.LoginPolicy.UnblockedDate = DateTime.Now.AddHours(1);
                    _uow.AppUsers.Save(user);
                    await _uow.Commit();
                    return AppResponse<AppUserDTO>.Unauthorized("Invalid credentials.");
                }
            }

            user.LoginPolicy.IsBlocked = false;
            user.LoginPolicy.UnblockedDate = null;
            user.LoginPolicy.FailedLoginAttempts = 0;
            user.LoginPolicy.LastLoginDate = DateTime.Now;

            _uow.AppUsers.Save(user);
            await _uow.Commit();

            return AppResponse<AppUserDTO>.Success(_mapper.Map<AppUser, AppUserDTO>(user));
        }
    }
}
