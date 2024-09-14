using AutoMapper;
using NLayerArch.Project.Bussines.Base.PagingStructure;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.Bussines.Features.Roles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Role, RoleDto>().ForMember(dest => dest.OperationClaims,
                opt => opt.MapFrom(src => src.RoleOperationClaims.Select(rp => rp.OperationClaim)));
            CreateMap<IPaginate<Role>, GetListResponse<RoleDto>>().ReverseMap();
            CreateMap<List<Role>, GetListResponse<RoleDto>>().ReverseMap();
            CreateMap<Role, GetListResponse<RoleDto>>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();
            CreateMap<IPaginate<Role>, IPaginate<RoleDto>>().ReverseMap();
        }
    }
}
