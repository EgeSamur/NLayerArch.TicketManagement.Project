using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.OperationClaims.Services
{
    public interface IOperationClaimService
    {
        Task<GetListResponse<OperationClaimsDto>> GetAllAsync();
        Task CreateAsync(CreateOperationClaimDto dto);
        Task UpdateAsync(UpdateOperationClaimDto dto);
    }
}
