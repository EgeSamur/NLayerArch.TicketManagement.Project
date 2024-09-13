using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites.Auth
{
    public class RoleOperationClaim : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
