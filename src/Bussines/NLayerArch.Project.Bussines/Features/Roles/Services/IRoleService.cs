using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Roles.Services
{
    public interface IRoleService
    {
        Task<GetListResponse<RoleDto>> GetAllAsync(PageRequest? request = null);
        Task CreateAsync(CreateRoleDto dto);
        Task UpdateAsync(UpdateRoleDto dto);
        Task SetPermissionsAsync(SetRoleOperationClaimsDto dto);
    }
}
