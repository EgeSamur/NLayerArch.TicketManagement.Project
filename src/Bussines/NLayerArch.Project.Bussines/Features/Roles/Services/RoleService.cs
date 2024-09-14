using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;
using NLayerArch.Project.Bussines.Features.Roles.Rules;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.UnitOfWorks;
using NLayerArch.Project.Domain.Entites.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Roles.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;
        private readonly RoleRules _roleRules;
        public RoleService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, RoleRules roleRules, IRoleOperationClaimRepository roleOperationClaimRepository) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
            _roleRules = roleRules;
            _roleOperationClaimRepository = roleOperationClaimRepository;
        }

        public async Task CreateAsync(CreateRoleDto dto)
        {
            Role? role = await _roleRepository.GetAsync(x=>x.Name == dto.Name);
            await _roleRules.EnsureRoleIsNotExists(role);
            var data = _mapper.Map<Role>(dto);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            data.CreatedBy = currentUserId;
            await _roleRepository.AddAsync(data);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetListResponse<RoleDto>> GetAllAsync(PageRequest? pageRequest = null)
        {
            var size = pageRequest?.Size ?? 0;
            var index = pageRequest?.Index ?? 0;
            var isAll = (pageRequest?.IsAll ?? true) || index == 0 && size == 0;

            var roles = await _roleRepository.GetAllByPagingAsync(pageSize: size,currentPage:index,include:i => i.Include(x=>x.RoleOperationClaims));
            var result = _mapper.Map<GetListResponse<RoleDto>>(roles);
            return result;
        }

        // SETROLEOPERATİON CLAİMS
        public async Task SetPermissionsAsync(SetRoleOperationClaimsDto dto)
        {
            var role = await _roleRepository.GetAsync(x => x.Id == dto.RoleId,
                include: i => i.Include(x => x.RoleOperationClaims),
                enableTracking: true);
            await _roleRules.EnsureIsRoleExists(role);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            role.RoleOperationClaims.Clear();
            foreach(var operationClaimId in dto.OperationClaimIds)
            {
                var roleOperationClaim = new RoleOperationClaim
                {
                    CreatedBy = currentUserId,
                    RoleId = role.Id,
                    OperationClaimId = operationClaimId
                };
                await _roleOperationClaimRepository.AddAsync(roleOperationClaim);
                role.RoleOperationClaims.Add(roleOperationClaim);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateRoleDto dto)
        {
            Role? role = await _roleRepository.GetAsync(x => x.Id == dto.Id,enableTracking:true);
            await _roleRules.EnsureIsRoleExists(role);
            _mapper.Map(dto, role);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            role.UpdatedDate = DateTime.UtcNow;
            role.UpdatedBy = currentUserId;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
