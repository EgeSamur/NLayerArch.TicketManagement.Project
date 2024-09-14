using NLayerArch.Project.Bussines.Features.OperationClaims.Dtos;
using NLayerArch.Project.Bussines.Features.Roles.Dtos;

namespace NLayerArch.Project.Bussines.Features.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
        public List<OperationClaimsDto> OperationClaims { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
