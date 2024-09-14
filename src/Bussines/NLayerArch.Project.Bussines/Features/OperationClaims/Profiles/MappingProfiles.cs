using AutoMapper;
using NLayerArch.Project.Bussines.Base.PagingStructure;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.OperationClaims.Dtos;
using NLayerArch.Project.Domain.Entites.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, OperationClaimsDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, GetListResponse<OperationClaimsDto>>().ReverseMap();
            CreateMap<OperationClaim, GetListResponse<OperationClaimsDto>>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimDto>().ReverseMap();
            CreateMap<List<OperationClaim>, GetListResponse<OperationClaimsDto>>().ReverseMap();

        }
    }
}
