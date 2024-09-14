using AutoMapper;
using NLayerArch.Project.Bussines.Base.PagingStructure;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.Users.Dtos;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.Bussines.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>()
               .ForMember(dest => dest.Roles,
               opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role)));
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, ResetPasswordDto>().ReverseMap();

            CreateMap<IPaginate<User>, GetListResponse<UserDto>>().ReverseMap();
        }
    }
}
