using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDaniels.IdentityServer.Domain.DbEntities;
using TechDaniels.IdentityServer.Domain.DTOs;

namespace TechDaniels.IdentityServer.Domain.Mappers
{
    public class AppUserDbToAppUserDTOMapper : Profile
    {
        public AppUserDbToAppUserDTOMapper()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
        }
    }
}
