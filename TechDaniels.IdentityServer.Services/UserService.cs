using AutoMapper;
using TechDaniels.IdentityServer.Core.Cryptors;
using TechDaniels.IdentityServer.Core.Services;
using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Domain.DbEntities;
using TechDaniels.IdentityServer.Domain.DTOs;
using TechDaniels.IdentityServer.Domain.Models;
using TechDaniels.IdentityServer.Domain.Models.Requests;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Services
{
    public class UserService : IUserService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IPasswordCryptor _cryptor;
        private readonly IMapper _mapper;

        public UserService(IAppUnitOfWork uow, IPasswordCryptor cryptor, IMapper mapper)
        {
            _uow = uow;
            _cryptor = cryptor;
            _mapper = mapper;
        }

        public async Task<SearchResponse<AppUserDTO>> Search(SearchUserRequest request)
        {
            var result = await _uow.AppUsers.Where(w => w.Email.Contains(request.Email))
                .FindPaginated(request.Skip, request.Take);

            var users = _mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserDTO>>(result.list);

            return SearchResponse<AppUserDTO>.Build(result.count, users);
        }

        public async Task<AppResponse<string>> Save(SaveUserRequest request)
        {
            var user = _mapper.Map<AppUserDTO, AppUser>(request.User);

            user.PasswordHash = _cryptor.Encrypt(request.Password);

            _uow.AppUsers.Save(user);
            await _uow.Commit();

            return AppResponse<string>.Success("User saved.");
        }
    }
}
