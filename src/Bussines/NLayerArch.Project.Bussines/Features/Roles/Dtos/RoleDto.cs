using NLayerArch.Project.Bussines.Features.OperationClaims.Dtos;
using NLayerArch.Project.Domain.Entites.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Roles.Dtos
{
    public class RoleDto
    {

        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public List<OperationClaimsDto> OperationClaims { get; set; }

    }
}
